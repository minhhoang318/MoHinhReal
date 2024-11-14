using BLL;
using BLL.Interface;
using DAL;
using DAL.Interfaces;
using DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class CTDonHangService : Service<CtdonHang>, ICTDonHangService
{
    public CTDonHangService(ICTDonHangRepository ctDonHangRepository) : base(ctDonHangRepository) { }
}
