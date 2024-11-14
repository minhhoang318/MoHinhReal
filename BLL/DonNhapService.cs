using BLL;
using BLL.Interface;
using DAL;
using DAL.Interfaces;
using DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class DonNhapService : Service<DonNhap>, IDonNhapService
{
    public DonNhapService(IDonNhapRepository donNhapRepository) : base(donNhapRepository) { }
}
