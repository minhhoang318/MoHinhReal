using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhoDTO
    {
        public int KhoID { get; set; }
        public int SanPhamID { get; set; }
        public int SLTon { get; set; }
        public DateTime NgayNhapKho { get; set; }
        public decimal GiaNhap { get; set; }
    }
}
