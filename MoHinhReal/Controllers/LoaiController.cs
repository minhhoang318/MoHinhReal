using BLL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/Loai")]
    public class LoaiController : ControllerBase
    {
        private readonly ILoaiService _loaiService;

        public LoaiController(ILoaiService loaiService)
        {
            _loaiService = loaiService;
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetAllLoai()
        {
            var loaiList = await _loaiService.GetAllLoaiAsync();
            return Ok(loaiList);
        }

        [HttpGet("{Search}")]
        public async Task<IActionResult> GetLoaiById(int id)
        {
            var loai = await _loaiService.GetLoaiByIdAsync(id);
            if (loai == null)
            {
                return NotFound();
            }
            return Ok(loai);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddLoai([FromBody] LoaiDTO loaiDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _loaiService.AddLoaiAsync(loaiDto);
            return CreatedAtAction(nameof(GetLoaiById), new { id = loaiDto.LoaiID }, loaiDto);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateLoai(int id, [FromBody] LoaiDTO loaiDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _loaiService.UpdateLoaiAsync(id, loaiDto);
            return NoContent();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteLoai(int id)
        {
            await _loaiService.DeleteLoaiAsync(id);
            return NoContent();
        }
    }
}
