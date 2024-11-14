using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models
{
    [Table("CTDonHang")]
    public partial class CtdonHang
    {
        [Key]
        [Column("CTDonHangID")]
        public int CtdonHangId { get; set; }
        [Column("DonHangID")]
        public int? DonHangId { get; set; }
        [Column("SanPhamID")]
        public int? SanPhamId { get; set; }
        public int SoLuong { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal GiaBan { get; set; }

        [ForeignKey("DonHangId")]
        [InverseProperty("CtdonHangs")]
        public virtual DonHang? DonHang { get; set; }
        [ForeignKey("SanPhamId")]
        [InverseProperty("CtdonHangs")]
        public virtual SanPham? SanPham { get; set; }
    }
}
