using BLL.Interface;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class SanPhamController : Controller<SanPham>
    {
        public SanPhamController(ISanPhamService sanPhamService) : base(sanPhamService) { }
    }
}
