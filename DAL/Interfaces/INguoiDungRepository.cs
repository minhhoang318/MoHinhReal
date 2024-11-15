using DAL.Models;


namespace DAL.Interfaces
{
    public interface INguoiDungRepository : IRepository<NguoiDung>
    {
        Task<NguoiDung> AuthenticateUserAsync(string taiKhoan, string matKhau);
    }
}
