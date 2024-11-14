using BLL;
using BLL.Interface;
using DAL;
using DAL.Interfaces;
using DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class CTDonNhapService : Service<CtdonNhap>, ICTDonNhapService
{
    public CTDonNhapService(ICTDonNhapRepository ctDonNhapRepository) : base(ctDonNhapRepository) { }
}
