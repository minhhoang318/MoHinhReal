using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models
{
    [Table("DonNhap")]
    public partial class DonNhap
    {
        public DonNhap()
        {
            CTDonNhaps = new HashSet<CTDonNhap>();
        }

        [Key]
        [Column("DonNhapID")]
        public int DonNhapID { get; set; }
        [Column(TypeName = "date")]
        public DateTime NgayNhapHang { get; set; }
        [Column("NCCID")]
        public int? NCCID { get; set; }
        [StringLength(50)]
        public string? TrangThai { get; set; }

        [ForeignKey("NCCID")]
        [InverseProperty("DonNhaps")]
        public virtual NCC? NCC { get; set; }
        [InverseProperty("DonNhap")]
        public virtual ICollection<CTDonNhap> CTDonNhaps { get; set; }
    }
}
