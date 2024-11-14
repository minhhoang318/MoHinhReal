using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models
{
    [Table("NCC")]
    public partial class NCC
    {
        public NCC()
        {
            DonNhaps = new HashSet<DonNhap>();
        }

        [Key]
        [Column("NCCID")]
        public int NCCID { get; set; }
        [Column("TenNCC")]
        [StringLength(255)]
        public string TenNCC { get; set; } = null!;
        [StringLength(255)]
        public string? DiaChi { get; set; }
        [Column("SDT")]
        [StringLength(50)]
        public string? SDT { get; set; }

        [InverseProperty("NCC")]
        public virtual ICollection<DonNhap> DonNhaps { get; set; }
    }
}
