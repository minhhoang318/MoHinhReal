using Microsoft.EntityFrameworkCore;
using System;

namespace DTO
{
    public class SanPhamDTO
    {
        public int SanPhamID { get; set; }
        public string TenSanPham { get; set; }
        public string MotaSanPham { get; set; }
        public decimal GiaBan { get; set; }
        public int? LoaiID { get; set; }
        public string? ImageURL { get; set; }
    }
}
