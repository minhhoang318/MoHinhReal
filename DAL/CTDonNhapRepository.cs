using DAL.Interfaces;
using DAL.Models;

namespace DAL
{
    public class CTDonNhapRepository : Repository<CtdonNhap>, ICTDonNhapRepository
    {
        public CTDonNhapRepository(CSDLBanMoHinh context) : base(context)
        {
        }
    }
}
