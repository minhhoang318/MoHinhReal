using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models
{
    [Table("SanPham")]
    public partial class SanPham
    {
        public SanPham()
        {
            CTDonHangs = new HashSet<CTDonHang>();
            CTDonNhaps = new HashSet<CTDonNhap>();
            Khos = new HashSet<Kho>();
        }

        [Key]
        [Column("SanPhamID")]
        public int SanPhamID { get; set; }
        [StringLength(255)]
        public string TenSanPham { get; set; } = null!;
        [StringLength(1000)]
        public string? MotaSanPham { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal GiaBan { get; set; }
        [Column("LoaiID")]
        public int? LoaiID { get; set; }
        [Column("ImageURL")]
        [StringLength(500)]
        public string? ImageURL { get; set; }

        [ForeignKey("LoaiID")]
        [InverseProperty("SanPhams")]
        public virtual Loai? Loai { get; set; }
        [InverseProperty("SanPham")]
        public virtual ICollection<CTDonHang> CTDonHangs { get; set; }
        [InverseProperty("SanPham")]
        public virtual ICollection<CTDonNhap> CTDonNhaps { get; set; }
        [InverseProperty("SanPham")]
        public virtual ICollection<Kho> Khos { get; set; }
    }
}
