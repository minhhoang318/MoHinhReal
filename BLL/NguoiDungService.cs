using DAL.Interfaces;
using DAL.Models;
using DTO;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class NguoiDungService : INguoiDungService
{
    private readonly INguoiDungRepository _nguoiDungRepository;
    private readonly IConfiguration _configuration;

    public NguoiDungService(INguoiDungRepository nguoiDungRepository, IConfiguration configuration)
    {
        _nguoiDungRepository = nguoiDungRepository;
        _configuration = configuration;
    }

    // Triển khai phương thức lấy tất cả người dùng
    public async Task<IEnumerable<NguoiDungDTO>> GetAllNguoiDungAsync()
    {
        var nguoiDungList = await _nguoiDungRepository.GetAllAsync();
        return nguoiDungList.Select(nd => new NguoiDungDTO
        {
            NguoiDungID = nd.NguoiDungID,
            Taikhoan = nd.Taikhoan,
            MatKhau = nd.MatKhau,
            Quyen = nd.Quyen
        }).ToList();
    }

    // Triển khai phương thức lấy người dùng theo ID
    public async Task<NguoiDungDTO> GetNguoiDungByIdAsync(int id)
    {
        var nguoiDung = await _nguoiDungRepository.GetByIdAsync(id);
        if (nguoiDung == null) return null;

        return new NguoiDungDTO
        {
            NguoiDungID = nguoiDung.NguoiDungID,
            Taikhoan = nguoiDung.Taikhoan,
            MatKhau = nguoiDung.MatKhau,
            Quyen = nguoiDung.Quyen
        };
    }

    public async Task<NguoiDungDTO> AuthenticateUserAsync(LoginDTO loginDto)
    {
        // Tìm người dùng trong cơ sở dữ liệu trực tiếp theo TaiKhoan và MatKhau
        var nguoiDung = await _nguoiDungRepository.AuthenticateUserAsync(loginDto.Taikhoan, loginDto.MatKhau);

        if (nguoiDung == null)
            return null;

        // Nếu người dùng tồn tại và mật khẩu đúng (nếu mật khẩu được mã hóa, so sánh mã hóa mật khẩu)
        var userDto = new NguoiDungDTO
        {
            NguoiDungID = nguoiDung.NguoiDungID,
            Taikhoan = nguoiDung.Taikhoan,
            Quyen = nguoiDung.Quyen
        };

        return userDto;
    }

    public string GenerateJwtToken(NguoiDungDTO user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.NguoiDungID.ToString()),
            new Claim(ClaimTypes.Name, user.Taikhoan),
            new Claim(ClaimTypes.Role, user.Quyen)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task AddNguoiDungAsync(NguoiDungDTO nguoiDungDto)
    {
        var nguoiDung = new NguoiDung
        {
            Taikhoan = nguoiDungDto.Taikhoan,
            MatKhau = nguoiDungDto.MatKhau,  // Không mã hóa mật khẩu
            Quyen = nguoiDungDto.Quyen
        };
        await _nguoiDungRepository.AddAsync(nguoiDung);
        await _nguoiDungRepository.SaveAsync();
    }

    public async Task UpdateNguoiDungAsync(int id, NguoiDungDTO nguoiDungDto)
    {
        // Lấy người dùng từ cơ sở dữ liệu theo ID
        var nguoiDung = await _nguoiDungRepository.GetByIdAsync(id);
        if (nguoiDung != null)
        {
            // Cập nhật các trường thông tin từ DTO vào đối tượng NguoiDung
            nguoiDung.Taikhoan = nguoiDungDto.Taikhoan;

            // Kiểm tra và cập nhật mật khẩu nếu không rỗng
            if (!string.IsNullOrEmpty(nguoiDungDto.MatKhau))
            {
                nguoiDung.MatKhau = nguoiDungDto.MatKhau;  // Không mã hóa mật khẩu nếu chưa mã hóa
            }

            nguoiDung.Quyen = nguoiDungDto.Quyen;

            // Cập nhật đối tượng vào cơ sở dữ liệu
            _nguoiDungRepository.Update(nguoiDung);
            await _nguoiDungRepository.SaveAsync();  // Lưu thay đổi vào cơ sở dữ liệu
        }
        else
        {
            // Trả về lỗi nếu không tìm thấy người dùng với ID đó
            throw new KeyNotFoundException($"Người dùng với ID {id} không tìm thấy.");
        }
    }


        public async Task DeleteNguoiDungAsync(int id)
    {
        var nguoiDung = await _nguoiDungRepository.GetByIdAsync(id);
        if (nguoiDung == null) return;

        _nguoiDungRepository.Delete(nguoiDung);
        await _nguoiDungRepository.SaveAsync();
    }
}
