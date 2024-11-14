using DAL.Interfaces;
using DAL.Models;

namespace DAL
{
    public class KhachHangRepository : Repository<KhachHang>, IKhachHangRepository
    {
        public KhachHangRepository(BanMoHinh context) : base(context)
        {
        }
    }
}
