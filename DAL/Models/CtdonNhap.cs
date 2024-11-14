using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models
{
    [Table("CTDonNhap")]
    public partial class CtdonNhap
    {
        [Key]
        [Column("CTDonNhapID")]
        public int CtdonNhapId { get; set; }
        [Column("DonNhapID")]
        public int? DonNhapId { get; set; }
        [Column("SanPhamID")]
        public int? SanPhamId { get; set; }
        public int SoLuong { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal GiaNhap { get; set; }

        [ForeignKey("DonNhapId")]
        [InverseProperty("CtdonNhaps")]
        public virtual DonNhap? DonNhap { get; set; }
        [ForeignKey("SanPhamId")]
        [InverseProperty("CtdonNhaps")]
        public virtual SanPham? SanPham { get; set; }
    }
}
