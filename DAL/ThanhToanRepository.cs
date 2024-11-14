using DAL.Interfaces;
using DAL.Models;

namespace DAL
{
    public class ThanhToanRepository : Repository<ThanhToan>, IThanhToanRepository
    {
        public ThanhToanRepository(BanMoHinh context) : base(context)
        {
        }
    }
}
