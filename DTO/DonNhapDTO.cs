using System;

namespace DTO
{
    public class DonNhapDTO
    {
        public int DonNhapID { get; set; }               // Primary Key
        public DateTime NgayNhapHang { get; set; }       // Date of Purchase
        public int? NCCID { get; set; }                  // Foreign Key to NCC
        public string TrangThai { get; set; }            // Status
    }
}
