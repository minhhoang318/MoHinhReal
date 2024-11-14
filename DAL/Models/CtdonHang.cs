using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models
{
    [Table("CTDonHang")]
    public partial class CTDonHang
    {
        [Key]
        [Column("CTDonHangID")]
        public int CTDonHangID { get; set; }
        [Column("DonHangID")]
        public int DonHangID { get; set; }
        [Column("SanPhamID")]
        public int SanPhamID { get; set; }
        public int SoLuong { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal GiaBan { get; set; }

        [ForeignKey("DonHangID")]
        [InverseProperty("CTDonHangs")]
        public virtual DonHang? DonHang { get; set; }
        [ForeignKey("SanPhamID")]
        [InverseProperty("CTDonHangs")]
        public virtual SanPham? SanPham { get; set; }
    }
}
