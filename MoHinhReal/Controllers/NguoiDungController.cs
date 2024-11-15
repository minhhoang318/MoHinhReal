using BLL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NguoiDungController : ControllerBase
    {
        private readonly INguoiDungService _nguoiDungService;

        public NguoiDungController(INguoiDungService nguoiDungService)
        {
            _nguoiDungService = nguoiDungService;
        }


        // API tạo người dùng mới (register)
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] NguoiDungDTO nguoiDungDto)
        {
            await _nguoiDungService.AddNguoiDungAsync(nguoiDungDto);
            return Ok("User created successfully");
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetAllNguoiDung()
        {
            var nguoiDungList = await _nguoiDungService.GetAllNguoiDungAsync();
            return Ok(nguoiDungList);
        }

        [HttpGet("{SearchById}")]
        public async Task<IActionResult> GetNguoiDungById(int id)
        {
            var nguoiDung = await _nguoiDungService.GetNguoiDungByIdAsync(id);
            if (nguoiDung == null)
            {
                return NotFound();
            }
            return Ok(nguoiDung);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddNguoiDung([FromBody] NguoiDungDTO nguoiDungDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _nguoiDungService.AddNguoiDungAsync(nguoiDungDto);
            return CreatedAtAction(nameof(GetNguoiDungById), new { id = nguoiDungDto.NguoiDungID }, nguoiDungDto);
        }

        [HttpPut("{update}")]
        public async Task<IActionResult> UpdateNguoiDung(int id, [FromBody] NguoiDungDTO nguoiDungDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _nguoiDungService.UpdateNguoiDungAsync(id, nguoiDungDto);
            return NoContent();
        }

        [HttpDelete("{Delete}")]
        public async Task<IActionResult> DeleteNguoiDung(int id)
        {
            await _nguoiDungService.DeleteNguoiDungAsync(id);
            return NoContent();
        }
    }
}
