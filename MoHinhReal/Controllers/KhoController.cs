using BLL.Interface;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class KhoController : Controller<Kho>
    {
        public KhoController(IKhoService khoService) : base(khoService) { }
    }
}
