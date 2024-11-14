using BLL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThanhToanController : ControllerBase
    {
        private readonly IThanhToanService _thanhToanService;

        public ThanhToanController(IThanhToanService thanhToanService)
        {
            _thanhToanService = thanhToanService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllThanhToan()
        {
            var thanhToanList = await _thanhToanService.GetAllThanhToanAsync();
            return Ok(thanhToanList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetThanhToanById(int id)
        {
            var thanhToan = await _thanhToanService.GetThanhToanByIdAsync(id);
            if (thanhToan == null)
            {
                return NotFound();
            }
            return Ok(thanhToan);
        }

        [HttpPost]
        public async Task<IActionResult> AddThanhToan([FromBody] ThanhToanDTO thanhToanDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _thanhToanService.AddThanhToanAsync(thanhToanDto);
            return CreatedAtAction(nameof(GetThanhToanById), new { id = thanhToanDto.ThanhToanID }, thanhToanDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateThanhToan(int id, [FromBody] ThanhToanDTO thanhToanDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _thanhToanService.UpdateThanhToanAsync(id, thanhToanDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThanhToan(int id)
        {
            await _thanhToanService.DeleteThanhToanAsync(id);
            return NoContent();
        }
    }
}
