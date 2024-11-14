using DAL.Interfaces;
using DAL.Models;

namespace DAL
{
    public class NCCRepository : Repository<NCC>, INCCRepository
    {
        public NCCRepository(BanMoHinh context) : base(context)
        {
        }
    }
}
    