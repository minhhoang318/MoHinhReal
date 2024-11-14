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
            HoTen = nd.HoTen,
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
            HoTen = nguoiDung.HoTen,
            Taikhoan = nguoiDung.Taikhoan,
            MatKhau = nguoiDung.MatKhau,
            Quyen = nguoiDung.Quyen
        };
    }

    public async Task<NguoiDungDTO> AuthenticateUserAsync(LoginDTO loginDto)
    {
        var nguoiDung = await _nguoiDungRepository.GetAllAsync();
        var user = nguoiDung.FirstOrDefault(u => u.Taikhoan == loginDto.Taikhoan);

        if (user == null || user.MatKhau != loginDto.MatKhau)  // So sánh mật khẩu trực tiếp (không mã hóa)
            return null;

        var token = GenerateJwtToken(new NguoiDungDTO
        {
            NguoiDungID = user.NguoiDungID,
            Taikhoan = user.Taikhoan,
            Quyen = user.Quyen
        });

        return new NguoiDungDTO
        {
            NguoiDungID = user.NguoiDungID,
            Taikhoan = user.Taikhoan,
            Quyen = user.Quyen
        };
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
            HoTen = nguoiDungDto.HoTen,
            Taikhoan = nguoiDungDto.Taikhoan,
            MatKhau = nguoiDungDto.MatKhau,  // Không mã hóa mật khẩu
            Quyen = nguoiDungDto.Quyen
        };
        await _nguoiDungRepository.AddAsync(nguoiDung);
        await _nguoiDungRepository.SaveAsync();
    }

    public async Task UpdateNguoiDungAsync(int id, NguoiDungDTO nguoiDungDto)
    {
        var nguoiDung = await _nguoiDungRepository.GetByIdAsync(id);
        if (nguoiDung == null) return;

        nguoiDung.HoTen = nguoiDungDto.HoTen;
        nguoiDung.Taikhoan = nguoiDungDto.Taikhoan;
        if (!string.IsNullOrEmpty(nguoiDungDto.MatKhau))  // Kiểm tra nếu mật khẩu mới không rỗng
        {
            nguoiDung.MatKhau = nguoiDungDto.MatKhau;  // Không mã hóa mật khẩu mới
        }
        nguoiDung.Quyen = nguoiDungDto.Quyen;

        _nguoiDungRepository.Update(nguoiDung);
        await _nguoiDungRepository.SaveAsync();
    }


    public async Task DeleteNguoiDungAsync(int id)
    {
        var nguoiDung = await _nguoiDungRepository.GetByIdAsync(id);
        if (nguoiDung == null) return;

        _nguoiDungRepository.Delete(nguoiDung);
        await _nguoiDungRepository.SaveAsync();
    }
}
