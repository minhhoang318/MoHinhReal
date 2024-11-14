using BLL.Interface;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class CTDonNhapController : Controller<CtdonNhap>
    {
        public CTDonNhapController(ICTDonNhapService ctDonNhapService) : base(ctDonNhapService) { }
    }
}
