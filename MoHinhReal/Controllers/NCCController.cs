using BLL.Interface;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class NCCController : Controller<Ncc>
    {
        public NCCController(INCCService nCCService) : base(nCCService) { }
    }
}
