using System;

namespace DTO
{
    public class CTDonHangDTO
    {
        public int CTDonHangID { get; set; }             // Primary Key
        public int DonHangID { get; set; }               // Foreign Key to DonHang
        public int SanPhamID { get; set; }               // Foreign Key to SanPham
        public int SoLuong { get; set; }                 // Quantity
        public decimal GiaBan { get; set; }              // Selling Price
    }
}
