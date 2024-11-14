using BLL.Interface;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class ThanhToanController : Controller<ThanhToan>
    {
        public ThanhToanController(IThanhToanService thanhToanService) : base(thanhToanService) { }
    }
}
