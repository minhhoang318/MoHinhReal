using DTO;

public interface INguoiDungService
{
    Task<IEnumerable<NguoiDungDTO>> GetAllNguoiDungAsync();  // Lấy tất cả người dùng
    Task<NguoiDungDTO> GetNguoiDungByIdAsync(int id);  // Lấy người dùng theo id
    Task AddNguoiDungAsync(NguoiDungDTO nguoiDungDto);
    Task UpdateNguoiDungAsync(int id, NguoiDungDTO nguoiDungDto);
    Task DeleteNguoiDungAsync(int id);
    Task<NguoiDungDTO> AuthenticateUserAsync(LoginDTO loginDto);
    string GenerateJwtToken(NguoiDungDTO user);
}
