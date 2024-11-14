using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.Models
{
    public partial class BanMoHinh : DbContext
    {
        public BanMoHinh()
        {
        }

        public BanMoHinh(DbContextOptions<BanMoHinh> options)
            : base(options)
        {
        }

        public virtual DbSet<CTDonHang> CTDonHangs { get; set; } = null!;
        public virtual DbSet<CTDonNhap> CTDonNhaps { get; set; } = null!;
        public virtual DbSet<DonHang> DonHangs { get; set; } = null!;
        public virtual DbSet<DonNhap> DonNhaps { get; set; } = null!;
        public virtual DbSet<KhachHang> KhachHangs { get; set; } = null!;
        public virtual DbSet<Kho> Khos { get; set; } = null!;
        public virtual DbSet<Loai> Loais { get; set; } = null!;
        public virtual DbSet<NCC> NCCs { get; set; } = null!;
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; } = null!;
        public virtual DbSet<SanPham> SanPhams { get; set; } = null!;
        public virtual DbSet<ThanhToan> ThanhToans { get; set; } = null!;


    }
}
