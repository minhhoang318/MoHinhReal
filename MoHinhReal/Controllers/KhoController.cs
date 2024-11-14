using BLL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KhoController : ControllerBase
    {
        private readonly IKhoService _khoService;

        public KhoController(IKhoService khoService)
        {
            _khoService = khoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllKho()
        {
            var khoList = await _khoService.GetAllKhoAsync();
            return Ok(khoList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetKhoById(int id)
        {
            var kho = await _khoService.GetKhoByIdAsync(id);
            if (kho == null)
            {
                return NotFound();
            }
            return Ok(kho);
        }

        [HttpPost]
        public async Task<IActionResult> AddKho([FromBody] KhoDTO khoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _khoService.AddKhoAsync(khoDto);
            return CreatedAtAction(nameof(GetKhoById), new { id = khoDto.KhoID }, khoDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKho(int id, [FromBody] KhoDTO khoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _khoService.UpdateKhoAsync(id, khoDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKho(int id)
        {
            await _khoService.DeleteKhoAsync(id);
            return NoContent();
        }
    }
}
