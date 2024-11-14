using Microsoft.EntityFrameworkCore;
using System;

namespace DTO
{
    public class NCCDTO
    { 
        public int NCCID { get; set; }                   // Primary Key
        public string? TenNCC { get; set; }               // Supplier Name
        public string? DiaChi { get; set; }               // Address
        public string? SDT { get; set; }                  // Phone Number
    }
}
