using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models
{
    [Table("Kho")]
    public partial class Kho
    {
        [Key]
        [Column("KhoID")]
        public int KhoID { get; set; }
        [Column("SanPhamID")]
        public int SanPhamID { get; set; }
        [Column("SLTon")]
        public int SLTon { get; set; }
        [Column(TypeName = "date")]
        public DateTime NgayNhapKho { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal GiaNhap { get; set; }

        [ForeignKey("SanPhamID")]
        [InverseProperty("Khos")]
        public virtual SanPham SanPham { get; set; } = null!;
    }
}
