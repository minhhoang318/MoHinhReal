using DAL.Interfaces;
using DAL.Models;

namespace DAL
{
    public class CTDonHangRepository : Repository<CTDonHang>, ICTDonHangRepository
    {
        public CTDonHangRepository(BanMoHinh context) : base(context)
        {
        }
    }
}
