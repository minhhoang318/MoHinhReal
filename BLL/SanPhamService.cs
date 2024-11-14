using BLL;
using BLL.Interface;
using DAL.Interfaces;
using DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class SanPhamService : Service<SanPham>, ISanPhamService
{
    public SanPhamService(ISanPhamRepository sanPhamRepository) : base(sanPhamRepository) { }
}
