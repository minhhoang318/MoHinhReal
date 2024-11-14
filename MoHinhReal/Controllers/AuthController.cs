using BLL.Interfaces;
using BLL;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly INguoiDungService _nguoiDungService;

        public AuthController(INguoiDungService nguoiDungService)
        {
            _nguoiDungService = nguoiDungService;
        }

        // API đăng nhập
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {
            // Xác thực người dùng
            var user = await _nguoiDungService.AuthenticateUserAsync(loginDto);

            if (user == null)
            {
                return Unauthorized("Invalid username or password");  // Trả về lỗi nếu đăng nhập thất bại
            }

            // Trả về token
            var token = _nguoiDungService.GenerateJwtToken(user); // Gọi trực tiếp từ NguoiDungService

            return Ok(new
            {
                User = user,
                Token = token
            });
        }
    }
}
