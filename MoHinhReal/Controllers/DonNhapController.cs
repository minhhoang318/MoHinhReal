using BLL.Interface;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class DonNhapController : Controller<DonNhap>
    {
        public DonNhapController(IDonNhapService donNhapService) : base(donNhapService) { }
    }
}
