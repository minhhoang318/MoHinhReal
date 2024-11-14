using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models
{
    [Table("KhachHang")]
    [Index("Email", Name = "UQ__KhachHan__A9D1053420804A5B", IsUnique = true)]
    public partial class KhachHang
    {
        public KhachHang()
        {
            DonHangs = new HashSet<DonHang>();
        }

        [Key]
        [Column("KhachHangID")]
        public int KhachHangID { get; set; }
        [StringLength(255)]
        public string HoTen { get; set; } = null!;
        [StringLength(255)]
        public string Email { get; set; } = null!;
        [Column("SDT")]
        [StringLength(50)]
        public string? SDT { get; set; }
        [StringLength(500)]
        public string? DiaChi { get; set; }

        [InverseProperty("KhachHang")]
        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
