using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DAL
{
    public class NguoiDungRepository : Repository<NguoiDung>, INguoiDungRepository
    {
        public NguoiDungRepository(BanMoHinh context) : base(context)
        {
        }

        // Phương thức AuthenticateUserAsync để xác thực người dùng
        public async Task<NguoiDung> AuthenticateUserAsync(string taiKhoan, string matKhau)
        {
            // Tìm người dùng trong cơ sở dữ liệu theo tài khoản
            var nguoiDung = await _context.NguoiDungs
                .FirstOrDefaultAsync(u => u.Taikhoan == taiKhoan);

            if (nguoiDung == null || nguoiDung.MatKhau != matKhau)  // So sánh mật khẩu trực tiếp
                return null;

            return nguoiDung;  // Trả về người dùng nếu tài khoản và mật khẩu khớp
        }
    }
}
