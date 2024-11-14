using DAL.Interfaces;
using DAL.Models;

namespace DAL
{
    public class CTDonNhapRepository : Repository<CTDonNhap>, ICTDonNhapRepository
    {
        public CTDonNhapRepository(BanMoHinh context) : base(context)
        {
        }
    }
}
