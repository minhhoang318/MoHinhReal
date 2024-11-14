using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models
{
    [Table("CTDonNhap")]
    public partial class CTDonNhap
    {
        [Key]
        [Column("CTDonNhapID")]
        public int CTDonNhapID { get; set; }
        [Column("DonNhapID")]
        public int DonNhapID { get; set; }
        [Column("SanPhamID")]
        public int SanPhamID { get; set; }
        public int SoLuong { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal GiaNhap { get; set; }

        [ForeignKey("DonNhapID")]
        [InverseProperty("CTDonNhaps")]
        public virtual DonNhap? DonNhap { get; set; }
        [ForeignKey("SanPhamID")]
        [InverseProperty("CTDonNhaps")]
        public virtual SanPham? SanPham { get; set; }
    }
}
