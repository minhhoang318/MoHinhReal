using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.Models
{
    public partial class CSDLBanMoHinh : DbContext
    {
        public CSDLBanMoHinh()
        {
        }

        public CSDLBanMoHinh(DbContextOptions<CSDLBanMoHinh> options)
            : base(options)
        {
        }

        public virtual DbSet<CtdonHang> CtdonHangs { get; set; } = null!;
        public virtual DbSet<CtdonNhap> CtdonNhaps { get; set; } = null!;
        public virtual DbSet<DonHang> DonHangs { get; set; } = null!;
        public virtual DbSet<DonNhap> DonNhaps { get; set; } = null!;
        public virtual DbSet<KhachHang> KhachHangs { get; set; } = null!;
        public virtual DbSet<Kho> Khos { get; set; } = null!;
        public virtual DbSet<Loai> Loais { get; set; } = null!;
        public virtual DbSet<Ncc> Nccs { get; set; } = null!;
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; } = null!;
        public virtual DbSet<SanPham> SanPhams { get; set; } = null!;
        public virtual DbSet<ThanhToan> ThanhToans { get; set; } = null!;
    }
}
