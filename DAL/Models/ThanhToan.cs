using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models
{
    [Table("ThanhToan")]
    public partial class ThanhToan
    {
        [Key]
        [Column("ThanhToanID")]
        public int ThanhToanID { get; set; }
        [Column("DonHangID")]
        public int DonHangID { get; set; }
        [StringLength(100)]
        public string PhuongThuc { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime NgayThanhToan { get; set; }

        [ForeignKey("DonHangID")]
        [InverseProperty("ThanhToans")]
        public virtual DonHang? DonHang { get; set; }
    }
}
