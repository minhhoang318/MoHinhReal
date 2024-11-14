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
            CtdonHangs = new HashSet<CtdonHang>();
            CtdonNhaps = new HashSet<CtdonNhap>();
            Khos = new HashSet<Kho>();
        }

        [Key]
        [Column("SanPhamID")]
        public int SanPhamId { get; set; }
        [StringLength(255)]
        public string TenSanPham { get; set; } = null!;
        [StringLength(1000)]
        public string? MotaSanPham { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal GiaBan { get; set; }
        [Column("LoaiID")]
        public int? LoaiId { get; set; }
        [Column("ImageURL")]
        [StringLength(500)]
        public string? ImageUrl { get; set; }

        [ForeignKey("LoaiId")]
        [InverseProperty("SanPhams")]
        public virtual Loai? Loai { get; set; }
        [InverseProperty("SanPham")]
        public virtual ICollection<CtdonHang> CtdonHangs { get; set; }
        [InverseProperty("SanPham")]
        public virtual ICollection<CtdonNhap> CtdonNhaps { get; set; }
        [InverseProperty("SanPham")]
        public virtual ICollection<Kho> Khos { get; set; }
    }
}
