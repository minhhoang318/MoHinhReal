namespace DTO
{
    public class NguoiDungDTO
    {
        public int NguoiDungID { get; set; }
        public string HoTen { get; set; }
        public string Taikhoan { get; set; }
        public string MatKhau { get; set; } // Mã hóa mật khẩu trong cơ sở dữ liệu
        public string Quyen { get; set; }
    }
}
