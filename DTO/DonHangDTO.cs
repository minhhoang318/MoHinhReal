using System;

namespace DTO
{
    public class DonHangDTO
    {
        public int DonHangID { get; set; }               // Primary Key
        public int? KhachHangID { get; set; }            // Foreign Key to KhachHang
        public DateTime NgayDat { get; set; }            // Order Date
        public decimal TongTien { get; set; }            // Total Amount
        public string TrangThai { get; set; }            // Status
    }
}
