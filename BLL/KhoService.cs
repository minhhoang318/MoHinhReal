using BLL;
using BLL.Interface;
using DAL;
using DAL.Interfaces;
using DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class KhoService : Service<Kho>, IKhoService
{
    public KhoService(IKhoRepository khoRepository) : base(khoRepository) { }
}
