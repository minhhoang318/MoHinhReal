using BLL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CTDonNhapController : ControllerBase
    {
        private readonly ICTDonNhapService _ctDonNhapService;

        public CTDonNhapController(ICTDonNhapService ctDonNhapService)
        {
            _ctDonNhapService = ctDonNhapService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCTDonNhap()
        {
            var ctDonNhapList = await _ctDonNhapService.GetAllCTDonNhapAsync();
            return Ok(ctDonNhapList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCTDonNhapById(int id)
        {
            var ctDonNhap = await _ctDonNhapService.GetCTDonNhapByIdAsync(id);
            if (ctDonNhap == null)
            {
                return NotFound();
            }
            return Ok(ctDonNhap);
        }

        [HttpPost]
        public async Task<IActionResult> AddCTDonNhap([FromBody] CTDonNhapDTO ctDonNhapDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _ctDonNhapService.AddCTDonNhapAsync(ctDonNhapDto);
            return CreatedAtAction(nameof(GetCTDonNhapById), new { id = ctDonNhapDto.CTDonNhapID }, ctDonNhapDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCTDonNhap(int id, [FromBody] CTDonNhapDTO ctDonNhapDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _ctDonNhapService.UpdateCTDonNhapAsync(id, ctDonNhapDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCTDonNhap(int id)
        {
            await _ctDonNhapService.DeleteCTDonNhapAsync(id);
            return NoContent();
        }
    }
}
