using BLL.Interfaces;
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

            // Trả về token nếu xác thực thành công
            var token = _nguoiDungService.GenerateJwtToken(user);

            return Ok(new
            {
                Token = token  // Trả về token cho người dùng
            });
        }

        // API tạo người dùng mới (register)
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] NguoiDungDTO nguoiDungDto)
        {
            await _nguoiDungService.AddNguoiDungAsync(nguoiDungDto);
            return Ok("User created successfully");
        }

    }
}
