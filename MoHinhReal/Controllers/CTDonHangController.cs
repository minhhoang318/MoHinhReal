using BLL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CTDonHangController : ControllerBase
    {
        private readonly ICTDonHangService _ctDonHangService;

        public CTDonHangController(ICTDonHangService ctDonHangService)
        {
            _ctDonHangService = ctDonHangService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCTDonHang()
        {
            var ctDonHangList = await _ctDonHangService.GetAllCTDonHangAsync();
            return Ok(ctDonHangList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCTDonHangById(int id)
        {
            var ctDonHang = await _ctDonHangService.GetCTDonHangByIdAsync(id);
            if (ctDonHang == null)
            {
                return NotFound();
            }
            return Ok(ctDonHang);
        }

        [HttpPost]
        public async Task<IActionResult> AddCTDonHang([FromBody] CTDonHangDTO ctDonHangDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _ctDonHangService.AddCTDonHangAsync(ctDonHangDto);
            return CreatedAtAction(nameof(GetCTDonHangById), new { id = ctDonHangDto.CTDonHangID }, ctDonHangDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCTDonHang(int id, [FromBody] CTDonHangDTO ctDonHangDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _ctDonHangService.UpdateCTDonHangAsync(id, ctDonHangDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCTDonHang(int id)
        {
            await _ctDonHangService.DeleteCTDonHangAsync(id);
            return NoContent();
        }
    }
}
