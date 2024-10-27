using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLSInhVien.BLL;
using QLSInhVien.DAL;
using QLSInhVien.DTO;
using QLSInhVien.Helper;

namespace QLSInhVien.GUI
{
    public partial class formQuanLySinhVien : Form
    {
        private string _malop = "";
        private SinhVienBLL svBll = new SinhVienBLL();
        private NhanVienBLL nvBll = new NhanVienBLL();
        private string _manv = "";
        public formQuanLySinhVien(string malop, string manv)
        {
            InitializeComponent();
            _malop = malop;
            lbDM.Text = string.Format("Danh mục sinh viên lớp {0}", malop);
            _manv = manv;
            if(CanManageClass(_malop,_manv))
            {
                MessageBox.Show("123");
            }
        }
        
private bool CanManageClass(string malop, string manv)
{
    // Check if the employee manages the class
    return nvBll.CheckClassManagement(malop, manv); // Implement this method in BLL
}

        private void formQuanLySinhVien_Load(object sender, EventArgs e)
        {
            LoadStudentData();

        }


        private void LoadStudentData()
        {
            DataTable dt = svBll.GetStudentsByClass(_malop);

            if (dt.Columns.Contains("MATKHAU"))
            {
                dt.Columns.Add("MATKHAU_Display", typeof(string));

                foreach (DataRow row in dt.Rows)
                {
                    byte[] passwordBytes = (byte[])row["MATKHAU"];
                    string base64Password = Convert.ToBase64String(passwordBytes);
                    row["MATKHAU_Display"] = base64Password;
                }
                dt.Columns.Remove("MATKHAU");
            }

            data_sinhvien.DataSource = dt;
            data_sinhvien.Columns["MATKHAU_Display"].HeaderText = "Mật Khẩu (Mã hóa)";
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            if (CanManageClass(_malop, _manv))
            {
                var newStudent = new SinhVienDTO
                {
                    MASV = txtMASV.Text.Trim(),
                    HOTEN = txtHOTEN.Text.Trim(),
                    NGAYSINH = dtpNGAYSINH.Value,
                    DIACHI = txtDIACHI.Text.Trim(),
                    MALOP = _malop,
                    TENDN = txtTENDN.Text.Trim(),
                    //MATKHAU =RSAHelper.HashPasswordSHA1(txtMATKHAU.Text)
                    MATKHAU =txtMATKHAU.Text

                };
                if (svBll.AddStudent(newStudent)) // Implement this method in BLL
                {
                    MessageBox.Show("Thêm sinh viên thành công");
                    formQuanLySinhVien_Load(sender, e); // Refresh the data grid
                }
                else
                {
                    MessageBox.Show("Thêm sinh viên thất bại");
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền quản lý lớp này.");
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (!CanManageClass(_manv, _malop))
            {
                MessageBox.Show("Bạn không có quyền xóa sinh viên trong lớp này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (data_sinhvien.SelectedRows.Count > 0)
            {
                string masv = data_sinhvien.SelectedRows[0].Cells["MASV"].Value.ToString();

                if (svBll.DeleteStudent(masv))
                {
                    MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStudentData(); 
                }
                else
                {
                    MessageBox.Show("Xóa sinh viên không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sinh viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (!CanManageClass(_manv, _malop))
            {
                MessageBox.Show("Bạn không có quyền cập nhật sinh viên trong lớp này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (data_sinhvien.SelectedRows.Count > 0)
            {
                string masv = data_sinhvien.SelectedRows[0].Cells["MASV"].Value.ToString();

                SinhVienDTO updatedStudent = new SinhVienDTO
                {
                    MASV = masv,
                    HOTEN = txtHOTEN.Text.Trim(),
                    NGAYSINH = dtpNGAYSINH.Value,
                    DIACHI = txtDIACHI.Text.Trim(),
                    MALOP = _malop,
                    TENDN = txtTENDN.Text.Trim(),
                    MATKHAU = txtMATKHAU.Text // Assuming password is updated as well
                };

                if (svBll.Update(updatedStudent))
                {
                    MessageBox.Show("Cập nhật sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStudentData(); // Refresh the data grid
                }
                else
                {
                    MessageBox.Show("Cập nhật sinh viên không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sinh viên để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void data_sinhvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row is clicked
            {
                var sinhvien = data_sinhvien.Rows[e.RowIndex];

                txtMASV.Text = sinhvien.Cells["MASV"].Value.ToString();
                txtHOTEN.Text = sinhvien.Cells["HOTEN"].Value.ToString();
                dtpNGAYSINH.Value = Convert.ToDateTime(sinhvien.Cells["NGAYSINH"].Value);
                txtDIACHI.Text = sinhvien.Cells["DIACHI"].Value.ToString();
                txtTENDN.Text = sinhvien.Cells["TENDN"].Value.ToString();

                if (sinhvien.Cells["MATKHAU_Display"].Value != null)
                {
                    byte[] passwordBytes = Convert.FromBase64String(sinhvien.Cells["MATKHAU_Display"].Value.ToString());
                    txtMATKHAU.Text = Encoding.UTF8.GetString(passwordBytes);
                }
                else
                {
                    txtMATKHAU.Text = ""; // Clear if not available
                }
            }
        }

        private void btnQlSV_Click(object sender, EventArgs e)
        {
            FormQuanLyLop frm = new FormQuanLyLop(_manv);
            this.Hide();
            this.Close();
            frm.ShowDialog();
        }
    }
}
