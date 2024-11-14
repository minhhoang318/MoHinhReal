using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoaiDTO
    {
        public int LoaiID { get; set; }
        public string TenLoai { get; set; }
        public string? MotaLoai { get; set; }
        public int? ParentID { get; set; }
    }
}
