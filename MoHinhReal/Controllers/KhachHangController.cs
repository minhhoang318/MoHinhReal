using BLL.Interface;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class KhachHangController : Controller<KhachHang>
    {
        public KhachHangController(IKhachHangService khachHangService) : base(khachHangService) { }
    }
}
