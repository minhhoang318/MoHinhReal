using BLL;
using BLL.Interface;
using DAL;
using DAL.Interfaces;
using DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class NCCService : Service<Ncc>, INCCService
{
    public NCCService(INCCRepository nCCRepository) : base(nCCRepository) { }
}
