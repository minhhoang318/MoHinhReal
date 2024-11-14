using Microsoft.AspNetCore.Mvc;
using BLL.Interfaces;
using DTO;

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

        // GET: api/SanPham
        [HttpGet]
        public async Task<IActionResult> GetAllSanPham()
        {
            var sanPhams = await _sanPhamService.GetAllSanPhamAsync();
            return Ok(sanPhams);
        }

        // GET: api/SanPham/{id}
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

        // POST: api/SanPham
        [HttpPost]
        public async Task<IActionResult> AddSanPham([FromBody] SanPhamDTO sanPhamDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _sanPhamService.AddSanPhamAsync(sanPhamDto);
            return CreatedAtAction(nameof(GetSanPhamById), new { id = sanPhamDto.SanPhamID }, sanPhamDto);
        }

        // PUT: api/SanPham/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSanPham(int id, [FromBody] SanPhamDTO sanPhamDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _sanPhamService.UpdateSanPhamAsync(id, sanPhamDto);
            return NoContent();
        }

        // DELETE: api/SanPham/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSanPham(int id)
        {
            await _sanPhamService.DeleteSanPhamAsync(id);
            return NoContent();
        }
    }
}
