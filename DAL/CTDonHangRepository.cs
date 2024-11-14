using DAL.Interfaces;
using DAL.Models;

namespace DAL
{
    public class CTDonHangRepository : Repository<CtdonHang>, ICTDonHangRepository
    {
        public CTDonHangRepository(CSDLBanMoHinh context) : base(context)
        {
        }
    }
}
