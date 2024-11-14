using System;

namespace DTO
{
    public class CTDonNhapDTO
    {
        public int CTDonNhapID { get; set; }             // Primary Key
        public int DonNhapID { get; set; }               // Foreign Key to DonNhap
        public int SanPhamID { get; set; }               // Foreign Key to SanPham
        public int SoLuong { get; set; }                 // Quantity
        public decimal GiaNhap { get; set; }             // Purchase Price
    }
}
