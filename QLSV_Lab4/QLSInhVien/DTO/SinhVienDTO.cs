using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSInhVien.DTO
{
    public class SinhVienDTO
    {
        public string MASV { get; set; }      // Mã sinh viên
        public string HOTEN { get; set; }     // Họ tên sinh viên
        public DateTime NGAYSINH { get; set; } // Ngày sinh
        public string DIACHI { get; set; }    // Địa chỉ
        public string MALOP { get; set; }     // Mã lớp
        public string TENLOP { get; set; }     // Mã lớp

        public string TENDN { get; set; }     // Tên đăng nhập
        public string MATKHAU { get; set; }   // Mật khẩu (được mã hóa)

    }

}
