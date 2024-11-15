using DTO;

public interface INguoiDungService
{
    Task<IEnumerable<NguoiDungDTO>> GetAllNguoiDungAsync(); 
    Task<NguoiDungDTO> GetNguoiDungByIdAsync(int id);
    Task AddNguoiDungAsync(NguoiDungDTO nguoiDungDto); 
    Task UpdateNguoiDungAsync(int id, NguoiDungDTO nguoiDungDto);
    Task DeleteNguoiDungAsync(int id);
    Task<NguoiDungDTO> AuthenticateUserAsync(LoginDTO loginDto);  // Xác thực người dùng (đăng nhập)
    string GenerateJwtToken(NguoiDungDTO user);  // Tạo JWT token cho người dùng
}
