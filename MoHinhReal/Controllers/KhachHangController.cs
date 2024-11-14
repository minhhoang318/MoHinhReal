using BLL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KhachHangController : ControllerBase
    {
        private readonly IKhachHangService _khachHangService;

        public KhachHangController(IKhachHangService khachHangService)
        {
            _khachHangService = khachHangService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllKhachHang()
        {
            var khachHangList = await _khachHangService.GetAllKhachHangAsync();
            return Ok(khachHangList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetKhachHangById(int id)
        {
            var khachHang = await _khachHangService.GetKhachHangByIdAsync(id);
            if (khachHang == null)
            {
                return NotFound();
            }
            return Ok(khachHang);
        }

        [HttpPost]
        public async Task<IActionResult> AddKhachHang([FromBody] KhachHangDTO khachHangDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _khachHangService.AddKhachHangAsync(khachHangDto);
            return CreatedAtAction(nameof(GetKhachHangById), new { id = khachHangDto.KhachHangID }, khachHangDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKhachHang(int id, [FromBody] KhachHangDTO khachHangDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _khachHangService.UpdateKhachHangAsync(id, khachHangDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKhachHang(int id)
        {
            await _khachHangService.DeleteKhachHangAsync(id);
            return NoContent();
        }
    }
}
