using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models
{
    [Table("NCC")]
    public partial class Ncc
    {
        public Ncc()
        {
            DonNhaps = new HashSet<DonNhap>();
        }

        [Key]
        [Column("NCCID")]
        public int Nccid { get; set; }
        [Column("TenNCC")]
        [StringLength(255)]
        public string TenNcc { get; set; } = null!;
        [StringLength(255)]
        public string? DiaChi { get; set; }
        [Column("SDT")]
        [StringLength(50)]
        public string? Sdt { get; set; }

        [InverseProperty("Ncc")]
        public virtual ICollection<DonNhap> DonNhaps { get; set; }
    }
}
