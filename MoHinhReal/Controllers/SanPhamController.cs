using Microsoft.AspNetCore.Mvc;
using BLL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Authorization;

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

        // API này dành cho cả Admin và Customer để xem danh sách sản phẩm
        [Authorize(Policy = "CustomerPolicy")]
        [HttpGet("List")]
        public async Task<IActionResult> GetAllSanPham()
        {
            var sanPhams = await _sanPhamService.GetAllSanPhamAsync();
            return Ok(sanPhams);
        }

        // API này chỉ dành cho Admin để tìm sản phẩm theo ID
        [Authorize(Policy = "AdminPolicy")]
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

        // API này chỉ dành cho Admin để thêm sản phẩm
        [Authorize(Policy = "AdminPolicy")]
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

        // API này chỉ dành cho Admin để cập nhật sản phẩm
        [Authorize(Policy = "AdminPolicy")]
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateSanPham(int id, [FromBody] SanPhamDTO sanPhamDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _sanPhamService.UpdateSanPhamAsync(id, sanPhamDto);
            return NoContent();
        }

        // API này chỉ dành cho Admin để xóa sản phẩm
        [Authorize(Policy = "AdminPolicy")]
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteSanPham(int id)
        {
            await _sanPhamService.DeleteSanPhamAsync(id);
            return NoContent();
        }
    }
}
