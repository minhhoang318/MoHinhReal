using BLL;
using BLL.Interface;
using DAL;
using DAL.Interfaces;
using DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class DonHangService : Service<DonHang>, IDonHangService
{
    public DonHangService(IDonHangRepository donHangRepository) : base(donHangRepository) { }
}
