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
            CtdonNhaps = new HashSet<CtdonNhap>();
        }

        [Key]
        [Column("DonNhapID")]
        public int DonNhapId { get; set; }
        [Column(TypeName = "date")]
        public DateTime NgayNhapHang { get; set; }
        [Column("NCCID")]
        public int? Nccid { get; set; }
        [StringLength(50)]
        public string? TrangThai { get; set; }

        [ForeignKey("Nccid")]
        [InverseProperty("DonNhaps")]
        public virtual Ncc? Ncc { get; set; }
        [InverseProperty("DonNhap")]
        public virtual ICollection<CtdonNhap> CtdonNhaps { get; set; }
    }
}
