using DAL.Interfaces;
using DAL.Models;

namespace DAL
{
    public class DonNhapRepository : Repository<DonNhap>, IDonNhapRepository
    {
        public DonNhapRepository(BanMoHinh context) : base(context)
        {
        }
    }
}
