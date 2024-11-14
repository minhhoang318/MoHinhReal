using BLL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NCCController : ControllerBase
    {
        private readonly INCCService _nccService;

        public NCCController(INCCService nccService)
        {
            _nccService = nccService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNCC()
        {
            var nccList = await _nccService.GetAllNCCAsync();
            return Ok(nccList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNCCById(int id)
        {
            var ncc = await _nccService.GetNCCByIdAsync(id);
            if (ncc == null)
            {
                return NotFound();
            }
            return Ok(ncc);
        }

        [HttpPost]
        public async Task<IActionResult> AddNCC([FromBody] NCCDTO nccDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _nccService.AddNCCAsync(nccDto);
            return CreatedAtAction(nameof(GetNCCById), new { id = nccDto.NCCID }, nccDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNCC(int id, [FromBody] NCCDTO nccDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _nccService.UpdateNCCAsync(id, nccDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNCC(int id)
        {
            await _nccService.DeleteNCCAsync(id);
            return NoContent();
        }
    }
}
