using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BLL.Interfaces;
using DTO;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SanPhamController : ControllerBase
    {
        private readonly ISanPhamService _sanPhamService;

        public SanPhamController(ISanPhamService sanPhamService)
        {
            _sanPhamService = sanPhamService;
        }

        // API cho Quản trị viên (Admin) xem và chỉnh sửa sản phẩm
        [Authorize(Policy = "AdminPolicy")]  // Chỉ dành cho Quản trị viên
        [HttpPost("Add")]
        public async Task<IActionResult> AddSanPham([FromBody] SanPhamDTO sanPhamDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _sanPhamService.AddSanPhamAsync(sanPhamDto);
            return CreatedAtAction(nameof(GetSanPhamById), new { id = sanPhamDto.SanPhamID }, sanPhamDto);
        }

        [Authorize(Policy = "AdminPolicy")]  // Chỉ dành cho Quản trị viên
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateSanPham(int id, [FromBody] SanPhamDTO sanPhamDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _sanPhamService.UpdateSanPhamAsync(id, sanPhamDto);
            return NoContent();
        }

        [Authorize(Policy = "AdminPolicy")]  // Chỉ dành cho Quản trị viên
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteSanPham(int id)
        {
            await _sanPhamService.DeleteSanPhamAsync(id);
            return NoContent();
        }

        // API cho Khách hàng (Customer) chỉ được phép xem sản phẩm
        [Authorize(Policy = "CustomerPolicy")] // Chỉ dành cho Khách hàng
        [HttpGet("List")]
        public async Task<IActionResult> GetAllSanPham()
        {
            var sanPhams = await _sanPhamService.GetAllSanPhamAsync();
            return Ok(sanPhams);
        }

        [Authorize(Policy = "CustomerPolicy")]  // Chỉ dành cho Khách hàng
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSanPhamById(int id)
        {
            var sanPham = await _sanPhamService.GetSanPhamByIdAsync(id);
            if (sanPham == null)
            {
                return NotFound();
            }
            return Ok(sanPham);
        }
    }
}
