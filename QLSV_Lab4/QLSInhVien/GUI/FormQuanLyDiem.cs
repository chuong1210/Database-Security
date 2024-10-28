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
    public partial class FormQuanLyDiem : Form
    {
        private string _publicKey = UserSession.PublicKeySession;
        private SinhVienBLL svBll = new SinhVienBLL();
        private DiemBLL diemBLL = new DiemBLL();
        List<SinhVienDTO> dtStudents;
        private string _manv; 
        public FormQuanLyDiem(string manv)
        {
            InitializeComponent();
            _manv = manv;
        }

        private void LoadStudents()
        {
            dtStudents = diemBLL.GetStudentsByEmployee(_manv);
            cmbStudents.DataSource = dtStudents;
            cmbStudents.DisplayMember = "MASV"; // Assuming HOTEN is a column in the DataTable
            cmbStudents.ValueMember = "MASV"; // Assuming MASV is a column in the DataTable
        }

        private void LoadSubjects()
        {
            DataTable dtSubjects = diemBLL.GetSubjects(); // Method to get all subjects
            cmbSubjects.DataSource = dtSubjects;
            cmbSubjects.DisplayMember = "TENHP"; // Assuming TENHP is a column in the DataTable
            cmbSubjects.ValueMember = "MAHP"; // Assuming MAHP is a column in the DataTable
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormQuanLyLop frm = new FormQuanLyLop(_manv);
            this.Hide();
            this.Close();
            frm.ShowDialog();
        }

        private void btnQlSV_Click(object sender, EventArgs e)
        {
            frmQuanLyNhanVien frm = new frmQuanLyNhanVien(_manv,"");
            this.Hide();
            this.Close();
            frm.ShowDialog();
        }

        private void FormQuanLyDiem_Load(object sender, EventArgs e)
        {
            LoadStudents();
            LoadSubjects();
        }

        private void cmbStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            SinhVienDTO sv =(SinhVienDTO) cmbStudents.SelectedItem;
            txtTenSV.Text = sv.HOTEN;

            txt_tenlh.Text = sv.TENLOP;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            // Get selected values
            string masv = cmbStudents.SelectedValue.ToString();
            string mahp = cmbSubjects.SelectedValue.ToString();
            byte[] diemThi;

            if (decimal.TryParse(txtDiem.Text, out decimal score))
            {
                diemThi = RSAHelper.EncryptScore(score, _publicKey); 

                // Update score
                if (diemBLL.InsertScore(masv, mahp, diemThi, _publicKey))
                {
                    MessageBox.Show("Cập nhật điểm thành công!");
                }
                else
                {
                    MessageBox.Show("Cập nhật điểm thất bại!");
                }
            }
            else
            {
                MessageBox.Show("Điểm không hợp lệ!");
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {

        }
    }
}
