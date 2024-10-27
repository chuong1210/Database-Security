using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using SuperMarketManager;
using QLSInhVien.BLL;

namespace QLSInhVien
{
    public partial class Login : Form
    {
        private NhanVienBLL nvBLL = new NhanVienBLL();

        public Login()
        {
            InitializeComponent();
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTenDangNhap.Text;
            string password = txtMatKhau.Text;

            bool rs= nvBLL.VerifyLogin(username, password);

            if (rs)
            {
                // Đăng nhập thành công
                MessageBox.Show("Đăng nhập thành công");
                string manv = nvBLL.getMaNV(username);
                frmQuanLyNhanVien dsNhanVien = new frmQuanLyNhanVien(manv);
                dsNhanVien.Show();
                this.Hide();
            }
            else
            {


                    // Đăng nhập thất bại
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không hợp lệ");
                }

            
        }
        private void btnthoat_Click(object sender, EventArgs e)
        {
            Application.Exit();


        }






    }
}
