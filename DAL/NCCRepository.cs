using DAL.Interfaces;
using DAL.Models;

namespace DAL
{
    public class NCCRepository : Repository<Ncc>, INCCRepository
    {
        public NCCRepository(CSDLBanMoHinh context) : base(context)
        {
        }
    }
}
    