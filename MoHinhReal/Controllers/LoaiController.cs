using BLL.Interface;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class LoaiController : Controller<Loai>
    {
        public LoaiController(ILoaiService loaiService) : base(loaiService) { }
    }
}
