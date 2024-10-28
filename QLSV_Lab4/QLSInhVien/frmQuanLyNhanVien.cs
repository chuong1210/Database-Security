using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using QLSInhVien;
using QLSInhVien.BLL;
using System.Net.NetworkInformation;
using QLSInhVien.DTO;
using System.Configuration;
using QLSInhVien.DAL;
using QLSInhVien.GUI;
using QLSInhVien.Helper;

namespace SuperMarketManager
{
    public partial class frmQuanLyNhanVien : Form
    {
        private NhanVienBLL _nhanVienBLL = new NhanVienBLL();
        private string privateKey = "<RSAKeyValue><Modulus>vnahAtVsWGFZgF4iYbXyp15crqDiG7ZPSmS6DdRO4iSoojlrIi2/yUvN4S0wu8whH71WCy5wAoI5/YLOE3/6IQ==</Modulus><Exponent>AQAB</Exponent><P>yZ46yJYkupsiLqYrAWKL9zps6YnK1hP7TEbxfVGSI9c=</P><Q>8dYqaUMc++z7sE7PtgbMQ3sHVBuxD5Jc7We+TbKHEsc=</Q><DP>HGhQ/AY7spc9H7mGAbHy6qiuw9EIZVV3aO3uBKxDnQ0=</DP><DQ>fircf4QrB+fQO2Ayj2WmhYIXBbNYwaX7Y0QfjYuZWps=</DQ><InverseQ>XgZQ0H4m5ZGTF4T7JIXskIxmIOvP3xOXFILD5Z8URGQ=</InverseQ><D>bTENddZtWu3UpedRxrrM9m7+q47IkiKeqoO8tpj08GgdmZyFiuznEVsIEpmNPFv9yQlG12bYM6ZQruACbR35EQ==</D></RSAKeyValue>";
        private string publicKey = "<RSAKeyValue><Modulus>vnahAtVsWGFZgF4iYbXyp15crqDiG7ZPSmS6DdRO4iSoojlrIi2/yUvN4S0wu8whH71WCy5wAoI5/YLOE3/6IQ==</Modulus><Exponent>AQAB</Exponent><P>yZ46yJYkupsiLqYrAWKL9zps6YnK1hP7TEbxfVGSI9c=</P><Q>8dYqaUMc++z7sE7PtgbMQ3sHVBuxD5Jc7We+TbKHEsc=</Q><DP>HGhQ/AY7spc9H7mGAbHy6qiuw9EIZVV3aO3uBKxDnQ0=</DP><DQ>fircf4QrB+fQO2Ayj2WmhYIXBbNYwaX7Y0QfjYuZWps=</DQ><InverseQ>XgZQ0H4m5ZGTF4T7JIXskIxmIOvP3xOXFILD5Z8URGQ=</InverseQ><D>bTENddZtWu3UpedRxrrM9m7+q47IkiKeqoO8tpj08GgdmZyFiuznEVsIEpmNPFv9yQlG12bYM6ZQruACbR35EQ==</D></RSAKeyValue>";
        private string _manv = "";
        public frmQuanLyNhanVien(string manv,string pubkey)
        {
            InitializeComponent();
            data_nhanvien.CellClick += data_nhanvien_CellContentClick;

        //    publicKey = pubkey;
            LoadNhanVien();
            _manv = manv;
        }

        private void data_nhanvien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo rằng hàng được chọn là hợp lệ
            {
                DataGridViewRow row = data_nhanvien.Rows[e.RowIndex];

                // Gán giá trị từ các cột vào các TextBox tương ứng
                txt_manv.Text = row.Cells["MaNV"].Value.ToString();
                txt_hoten.Text = row.Cells["HoTen"].Value.ToString();
                txt_email.Text = row.Cells["email"].Value.ToString();
                txt_luong.Text = row.Cells["luong"].Value.ToString();
                txt_tendn.Text = row.Cells["tendn"].Value.ToString();
                txt_matkhau.Text = row.Cells["matkhau"].Value.ToString();
            }
        }

        private async void btnthem_Click(object sender, EventArgs e)
        {

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(txt_manv.Text) || string.IsNullOrEmpty(txt_hoten.Text) ||
                string.IsNullOrEmpty(txt_email.Text) || string.IsNullOrEmpty(txt_luong.Text) ||
                string.IsNullOrEmpty(txt_tendn.Text) || string.IsNullOrEmpty(txt_matkhau.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } 


        }

        private async void btnxoa_Click(object sender, EventArgs e)
        {
           
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No) return;

                  
                     
                            MessageBox.Show("Xóa nhân viên thành công!");
                            LoadNhanVien(); // Tải lại dữ liệu
                     
                            MessageBox.Show("Không tìm thấy nhân viên để xóa.");
        }

        private async void btnsua_Click(object sender, EventArgs e)
        {
          
                    // Kiểm tra dữ liệu đầu vào
                    if (string.IsNullOrEmpty(txt_manv.Text) || string.IsNullOrEmpty(txt_hoten.Text) ||
                        string.IsNullOrEmpty(txt_email.Text) || string.IsNullOrEmpty(txt_luong.Text) ||
                        string.IsNullOrEmpty(txt_tendn.Text) || string.IsNullOrEmpty(txt_matkhau.Text))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                  
                
                        // Thực thi lệnh cập nhật không đồng bộ
                      
                            MessageBox.Show("Cập nhật nhân viên thành công!");
                            LoadNhanVien(); // Tải lại danh sách nhân viên
              
             
        }

        private void LoadNhanVien()
        {
        

                
                    data_nhanvien.AutoGenerateColumns = false;
            //data_nhanvien.DataSource = dt;
            //DataTable dt= _nhanVienBLL.GetAllNhanVien(privateKey);
            List<NhanVienDTO> dt= _nhanVienBLL.GetAllNhanVien(privateKey);

            if (dt.Count > 0)
            {
                data_nhanvien.DataSource = dt;

                data_nhanvien.Columns["MaNV"].DataPropertyName = "MANV";
                data_nhanvien.Columns["HoTen"].DataPropertyName = "HOTEN";
                data_nhanvien.Columns["email"].DataPropertyName = "EMAIL";
                data_nhanvien.Columns["Luong"].DataPropertyName = "LUONG";
                data_nhanvien.Columns["tendn"].DataPropertyName = "TENDN";
                data_nhanvien.Columns["matkhau"].DataPropertyName = "MATKHAU";
            }
           
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            LoadNhanVien();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (result == DialogResult.Yes)
            {

                Login formDangNhap = new Login();
                formDangNhap.Show();


                this.Close();
            }
        }

        private async void btnsave_Click(object sender, EventArgs e)
        {
           
                    // Kiểm tra dữ liệu đầu vào
                    if (string.IsNullOrEmpty(txt_manv.Text) || string.IsNullOrEmpty(txt_hoten.Text) ||
                        string.IsNullOrEmpty(txt_email.Text) || string.IsNullOrEmpty(txt_luong.Text) ||
                        string.IsNullOrEmpty(txt_tendn.Text) || string.IsNullOrEmpty(txt_matkhau.Text))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                  
                        // Nếu nhân viên đã tồn tại, thì thực hiện cập nhật
                     
                            // Nếu nhân viên chưa tồn tại, thì thực hiện thêm mới
                            

                    // Tải lại danh sách nhân viên sau khi lưu
                    LoadNhanVien();
            
        }

        private void btnthem_Click_1(object sender, EventArgs e)
        {
            //var (pub, pri) = RSAKeyGenerator.GenerateKeys();
            NhanVienDTO nhanVien = new NhanVienDTO();
            nhanVien.MANV = txt_manv.Text;
            nhanVien.HOTEN = txt_hoten.Text;
            nhanVien.EMAIL = txt_email.Text;
            if (!decimal.TryParse(txt_luong.Text, out decimal luong))
            {
                MessageBox.Show("Please enter a valid salary.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            nhanVien.LUONG = luong.ToString();
           nhanVien.TENDN = txt_tendn.Text;
           nhanVien.MATKHAU = txt_matkhau.Text;
            var pub = RSAKeyGenerator.GeneratePublicKey(nhanVien.MATKHAU);

            bool result = _nhanVienBLL.AddNhanVien(nhanVien, pub);

            if (result)
            {
                MessageBox.Show("Employee added successfully.");
                LoadNhanVien(); // Tải lại danh sách nhân viên

            }
            else
            {
                MessageBox.Show("Failed to add employee.");
            }
        }

        private void btnsua_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_manv.Text) || string.IsNullOrEmpty(txt_hoten.Text) ||
       string.IsNullOrEmpty(txt_email.Text) || string.IsNullOrEmpty(txt_luong.Text) ||
       string.IsNullOrEmpty(txt_tendn.Text) || string.IsNullOrEmpty(txt_matkhau.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Prepare DTO
            NhanVienDTO nv = new NhanVienDTO
            {
                MANV = txt_manv.Text,
                HOTEN = txt_hoten.Text,
                EMAIL = txt_email.Text,
                LUONG = txt_luong.Text, 
                MATKHAU = txt_matkhau.Text 
            };

            bool success = _nhanVienBLL.UpdateNhanVien(nv, publicKey); // Ensure you have publicKey defined

            if (success)
            {
                MessageBox.Show("Cập nhật nhân viên thành công!");
                LoadNhanVien(); // Reload employee data
            }
            else
            {
                MessageBox.Show("Cập nhật nhân viên thất bại.");
            }
        }

        private void btnxoa_Click_1(object sender, EventArgs e)
        {
            if (data_nhanvien.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the selected row
            DataGridViewRow selectedRow = data_nhanvien.SelectedRows[0];

            string manv = selectedRow.Cells["MANV"].Value.ToString();

            // Confirm deletion
            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?",
                                                 "Xác nhận xóa!",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                bool success = _nhanVienBLL.RemoveNhanVien(manv); 

                if (success)
                {
                    MessageBox.Show("Xóa nhân viên thành công!");
                    LoadNhanVien();
                }
                else
                {
                    MessageBox.Show("Xóa nhân viên thất bại.");
                }
            }
        }

        private void btnQlSV_Click(object sender, EventArgs e)
        {
            FormQuanLyLop frm= new FormQuanLyLop(_manv);
            this.Hide();
            this.Close();
            frm.ShowDialog();
        }
    }
}
