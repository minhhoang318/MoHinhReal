using BLL.Interface;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class CTDonHangController : Controller<CtdonHang>
    {
        public CTDonHangController(ICTDonHangService ctDonHangService) : base(ctDonHangService) { }
    }
}
