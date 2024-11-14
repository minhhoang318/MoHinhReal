using Microsoft.EntityFrameworkCore;
using System;

namespace DTO
{
    public class ThanhToanDTO 
    {
        public int ThanhToanID { get; set; }             // Primary Key
        public int DonHangID { get; set; }               // Foreign Key to DonHang
        public string PhuongThuc { get; set; }           // Payment Method
        public DateTime NgayThanhToan { get; set; }     // Payment Date
    }
}
