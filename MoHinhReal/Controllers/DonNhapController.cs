using BLL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonNhapController : ControllerBase
    {
        private readonly IDonNhapService _donNhapService;

        public DonNhapController(IDonNhapService donNhapService)
        {
            _donNhapService = donNhapService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDonNhap()
        {
            var donNhapList = await _donNhapService.GetAllDonNhapAsync();
            return Ok(donNhapList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDonNhapById(int id)
        {
            var donNhap = await _donNhapService.GetDonNhapByIdAsync(id);
            if (donNhap == null)
            {
                return NotFound();
            }
            return Ok(donNhap);
        }

        [HttpPost]
        public async Task<IActionResult> AddDonNhap([FromBody] DonNhapDTO donNhapDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _donNhapService.AddDonNhapAsync(donNhapDto);
            return CreatedAtAction(nameof(GetDonNhapById), new { id = donNhapDto.DonNhapID }, donNhapDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDonNhap(int id, [FromBody] DonNhapDTO donNhapDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _donNhapService.UpdateDonNhapAsync(id, donNhapDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonNhap(int id)
        {
            await _donNhapService.DeleteDonNhapAsync(id);
            return NoContent();
        }
    }
}
