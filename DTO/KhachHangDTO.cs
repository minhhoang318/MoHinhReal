using System;

namespace  DTO
{
    public class KhachHangDTO
    {
        public int KhachHangID { get; set; }             // Primary Key
        public string HoTen { get; set; }                // Full Name
        public string Email { get; set; }                // Email Address
        public string SDT { get; set; }                  // Phone Number
        public string DiaChi { get; set; }               // Address
    }
}
