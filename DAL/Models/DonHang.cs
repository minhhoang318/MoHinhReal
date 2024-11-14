using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models
{
    [Table("DonHang")]
    public partial class DonHang
    {
        public DonHang()
        {
            CTDonHangs = new HashSet<CTDonHang>();
            ThanhToans = new HashSet<ThanhToan>();
        }

        [Key]
        [Column("DonHangID")]
        public int DonHangID { get; set; }
        [Column("KhachHangID")]
        public int? KhachHangID { get; set; }
        [Column(TypeName = "date")]
        public DateTime NgayDat { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TongTien { get; set; }
        [StringLength(50)]
        public string? TrangThai { get; set; }

        [ForeignKey("KhachHangID")]
        [InverseProperty("DonHangs")]
        public virtual KhachHang? KhachHang { get; set; }
        [InverseProperty("DonHang")]
        public virtual ICollection<CTDonHang> CTDonHangs { get; set; }
        [InverseProperty("DonHang")]
        public virtual ICollection<ThanhToan> ThanhToans { get; set; }
    }
}
