using DAL.Interfaces;
using DAL.Models;

namespace DAL
{
    public class LoaiRepository : Repository<Loai>, ILoaiRepository
    {
        public LoaiRepository(BanMoHinh context) : base(context)
        {
        }
    }
}
