using BLL;
using BLL.Interface;
using DAL;
using DAL.Interfaces;
using DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ThanhToanService : Service<ThanhToan>, IThanhToanService
{
    public ThanhToanService(IThanhToanRepository thanhToanRepository) : base(thanhToanRepository) { }
}
