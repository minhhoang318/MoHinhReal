using BLL;
using BLL.Interface;
using DAL;
using DAL.Interfaces;
using DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class KhachHangService : Service<KhachHang>, IKhachHangService
{
    public KhachHangService(IKhachHangRepository khachHangRepository) : base(khachHangRepository) { }
}
