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
            CtdonHangs = new HashSet<CtdonHang>();
            ThanhToans = new HashSet<ThanhToan>();
        }

        [Key]
        [Column("DonHangID")]
        public int DonHangId { get; set; }
        [Column("KhachHangID")]
        public int? KhachHangId { get; set; }
        [Column(TypeName = "date")]
        public DateTime NgayDat { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TongTien { get; set; }
        [StringLength(50)]
        public string? TrangThai { get; set; }

        [ForeignKey("KhachHangId")]
        [InverseProperty("DonHangs")]
        public virtual KhachHang? KhachHang { get; set; }
        [InverseProperty("DonHang")]
        public virtual ICollection<CtdonHang> CtdonHangs { get; set; }
        [InverseProperty("DonHang")]
        public virtual ICollection<ThanhToan> ThanhToans { get; set; }
    }
}
