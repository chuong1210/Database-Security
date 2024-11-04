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
using QLSInhVien.DTO;
using QLSInhVien.Helper;
using SuperMarketManager;

namespace QLSInhVien.GUI
{
    public partial class FormQuanLyLop : Form
    {
        private LopBLL _lopBLL = new LopBLL();
        private string _manv = "";
        public FormQuanLyLop(string manv)
        {
            InitializeComponent();
            _manv = manv;
        

        }

        private void loadLop()
        {
            data_nhanvien.DataSource = _lopBLL.GetAllClasses();

            // Gán DataPropertyName cho tất cả các cột
            data_nhanvien.Columns["MaLH"].DataPropertyName = "MALOP";
            data_nhanvien.Columns["TenLop"].DataPropertyName = "TENLOP";
            data_nhanvien.Columns["MaNV"].DataPropertyName = "MANV";
        }
        private void FormQuanLyLop_Load(object sender, EventArgs e)
        {
            cboNV.DataSource = _lopBLL.GetAllNhanVien();
            cboNV.ValueMember = "MANV";
            cboNV.DisplayMember = "MANV";
            loadLop();
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] {
                new ToolStripMenuItem("Quản lý sinh viên",null,ManageStudentsItem_Click),
                  new ToolStripMenuItem("Quản lý điểm của lớp", null, ManageScoresItem_Click),

            });

        }
        private void ManageStudentsItem_Click(object sender, EventArgs e)
        {
            var lop = data_nhanvien.SelectedRows[0];
            string malop = lop.Cells[0].Value.ToString();
            formQuanLySinhVien frm= new formQuanLySinhVien(malop,_manv);
            this.Close();
            this.Hide();
            frm.Show();
        }

        private void ManageScoresItem_Click(object sender, EventArgs e)
        {
            var lop = data_nhanvien.SelectedRows[0];
            string malop = lop.Cells[0].Value.ToString();
            FormQuanLyDiem frm = new FormQuanLyDiem( _manv);
            this.Close();
            this.Hide();
            frm.Show();
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            LopDTO lop = new LopDTO
            {
                MALOP = txt_malop.Text,
                TENLOP = txt_tenlh.Text,
                MANV =cboNV.SelectedValue.ToString(),
            };

            ;
          bool rs=  _lopBLL.AddClass(lop);
            if(rs)
            {
                MessageBox.Show("Thêm thành công","Ok",MessageBoxButtons.OK,MessageBoxIcon.Information);
                loadLop();
            }
            else
            {
                MessageBox.Show("Thêm thất bại", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {

            LopDTO lop = new LopDTO
            {
                MALOP = txt_malop.Text,
                TENLOP = txt_tenlh.Text,
                MANV = cboNV.SelectedValue.ToString(),
            };

            ;
            bool rs = _lopBLL.DeleteClass(lop.MALOP);
            if (rs)
            {
                MessageBox.Show("Xóa thành công", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadLop();
            }
            else
            {
                MessageBox.Show("Xóa thất bại", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            LopDTO lop = new LopDTO
            {
                MALOP = txt_malop.Text,
                TENLOP = txt_tenlh.Text,
                MANV = cboNV.SelectedValue.ToString(),
            };

            ;
            bool rs = _lopBLL.UpdateClass(lop);
            if (rs)
            {
                MessageBox.Show("Cập nhật thành công", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadLop();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void data_nhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var lop = data_nhanvien.SelectedRows[0];
          txt_malop.Text=  lop.Cells[0].Value.ToString();
            txt_tenlh.Text = lop.Cells[1].Value.ToString();
            cboNV.SelectedValue = lop.Cells[2].Value.ToString();

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            loadLop();

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

        private void button1_Click(object sender, EventArgs e)
        {
            frmQuanLyNhanVien formDangNhap = new frmQuanLyNhanVien(_manv,UserSession.PublicKeySession);
            formDangNhap.Show();


            this.Close();
        }
    }
}
