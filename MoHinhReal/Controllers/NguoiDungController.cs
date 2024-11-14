using BLL.Interface;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class NguoiDungController : Controller<NguoiDung>
    {
        public NguoiDungController(INguoiDungService nguoiDungService) : base(nguoiDungService) { }
    }
}
