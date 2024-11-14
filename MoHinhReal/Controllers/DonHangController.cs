using BLL.Interface;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class DonHangController : Controller<DonHang>
    {
        public DonHangController(IDonHangService donHangService) : base(donHangService) { }
    }
}
