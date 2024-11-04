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
using System.Security.Cryptography.X509Certificates;
using QLSInhVien.Helper;

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
                var (manv,pubkey) = nvBLL.getMaNV(username);
                //var (publickey,privatekey) = RSAKeyGenerator.GenerateKeys();
                string prikey = "";
				// Convert to XML string for storage
				// Convert to XML string for storage

				var (generatedPublicKey, generatedPrivateKey) = RSAKeyGenerator.GenerateKeys();


                //if (pubkey == string.Empty)
                //            {
                //                pubkey = RSAKeyGenerator.RSAParametersToXmlString(generatedPublicKey, false);
                //                prikey = RSAKeyGenerator.RSAParametersToXmlString(generatedPrivateKey, true);

                //                // Store keys in session or database as needed
                //                UserSession.PublicKeySession = pubkey;
                //                UserSession.PriKeySession = prikey;
                //                UserSession.PublicKeyParamerterSession = generatedPublicKey;
                //                UserSession.PrivateKeyParamerterSession = generatedPrivateKey;


                //            }
                //            else
                //            {
                //                RSAParameters publickey = RSAKeyGenerator.XmlStringToRSAParameters(pubkey, false);
                //                UserSession.PublicKeyParamerterSession = publickey;

                //                RSAParameters privatekey = RSAKeyGenerator.XmlStringToRSAParameters(UserSession.PriKeySession, true);
                //                UserSession.PrivateKeyParamerterSession = generatedPrivateKey;

                //            }


                RSAParameters publickey = RSAKeyGenerator.XmlStringToRSAParameters(UserSession.PublicKeySession, false);
                UserSession.PublicKeyParamerterSession = publickey;

                RSAParameters privatekey = RSAKeyGenerator.XmlStringToRSAParameters(UserSession.PriKeySession, true);
                UserSession.PrivateKeyParamerterSession = privatekey;



                frmQuanLyNhanVien dsNhanVien = new frmQuanLyNhanVien(manv, pubkey);
         


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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHienMatKhau.Checked)
            {
                txtMatKhau.PasswordChar = '\0';
            }
            else
            {
                txtMatKhau.PasswordChar = '*';
            }
        }
    }
}
