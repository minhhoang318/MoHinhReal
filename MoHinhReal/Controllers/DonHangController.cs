using BLL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonHangController : ControllerBase
    {
        private readonly IDonHangService _donHangService;

        public DonHangController(IDonHangService donHangService)
        {
            _donHangService = donHangService;
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetAllDonHang()
        {
            var donHangList = await _donHangService.GetAllDonHangAsync();
            return Ok(donHangList);
        }

        [HttpGet("{Search}")]
        public async Task<IActionResult> GetDonHangById(int id)
        {
            var donHang = await _donHangService.GetDonHangByIdAsync(id);
            if (donHang == null)
            {
                return NotFound();
            }
            return Ok(donHang);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddDonHang([FromBody] DonHangDTO donHangDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _donHangService.AddDonHangAsync(donHangDto);
            return CreatedAtAction(nameof(GetDonHangById), new { id = donHangDto.DonHangID }, donHangDto);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateDonHang(int id, [FromBody] DonHangDTO donHangDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _donHangService.UpdateDonHangAsync(id, donHangDto);
            return NoContent();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteDonHang(int id)
        {
            await _donHangService.DeleteDonHangAsync(id);
            return NoContent();
        }
    }
}
