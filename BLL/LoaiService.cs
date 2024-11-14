using BLL;
using BLL.Interface;
using DAL;
using DAL.Interfaces;
using DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class LoaiService : Service<Loai>, ILoaiService
{
    public LoaiService(ILoaiRepository loaiRepository) : base(loaiRepository) { }
}
