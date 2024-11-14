using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models
{
    [Table("NguoiDung")]
    [Index("Taikhoan", Name = "UQ__NguoiDun__7FB3F64F345AE968", IsUnique = true)]
    public partial class NguoiDung
    {
        [Key]
        [Column("NguoiDungID")]
        public int NguoiDungID { get; set; }
        [StringLength(255)]
        public string HoTen { get; set; } = null!;
        [StringLength(100)]
        public string Taikhoan { get; set; } = null!;
        [StringLength(255)]
        public string MatKhau { get; set; } = null!;
        [StringLength(100)]
        public string? Quyen { get; set; }
    }
}
