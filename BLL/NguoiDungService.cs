using BLL;
using BLL.Interface;
using DAL;
using DAL.Interfaces;
using DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class NguoiDungService : Service<NguoiDung>, INguoiDungService
{
    public NguoiDungService(INguoiDungRepository nguoiDungRepository) : base(nguoiDungRepository) { }
}
