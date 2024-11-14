using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models
{
    [Table("Loai")]
    public partial class Loai
    {
        public Loai()
        {
            InverseParent = new HashSet<Loai>();
            SanPhams = new HashSet<SanPham>();
        }

        [Key]
        [Column("LoaiID")]
        public int LoaiId { get; set; }
        [StringLength(255)]
        public string TenLoai { get; set; } = null!;
        [StringLength(500)]
        public string? MotaLoai { get; set; }
        [Column("ParentID")]
        public int? ParentId { get; set; }

        [ForeignKey("ParentId")]
        [InverseProperty("InverseParent")]
        public virtual Loai? Parent { get; set; }
        [InverseProperty("Parent")]
        public virtual ICollection<Loai> InverseParent { get; set; }
        [InverseProperty("Loai")]
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
