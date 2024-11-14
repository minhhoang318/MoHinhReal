using DAL.Interfaces;
using DAL.Models;

namespace DAL
{
    public class KhoRepository : Repository<Kho>, IKhoRepository
    {
        public KhoRepository(CSDLBanMoHinh context) : base(context)
        {
        }
    }
}
