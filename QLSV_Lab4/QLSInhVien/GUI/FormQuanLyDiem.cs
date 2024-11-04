using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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
			if (dtStudents.Count > 0)
			{
				cmbStudents.DataSource = dtStudents;
				cmbStudents.DisplayMember = "MASV";
				cmbStudents.ValueMember = "MASV";

				cmbStudents.SelectedIndex = 0;
			}
			else
			{
				MessageBox.Show("Không tìm thấy sinh viên nào trong danh sách.");
				cmbStudents.DataSource = null;  // or  cmbStudents.DataSource = new DataTable();


			}
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
			loadBD();

			UserSession.PrivateKeyParamerterSession = RSAKeyGenerator.XmlStringToRSAParameters(UserSession.PriKeySession, true);

            DataGridViewImageColumn eyeColumn = new DataGridViewImageColumn();
            //eyeColumn.Name = "eyeColumn";
            //eyeColumn.HeaderText = "Xem điểm";
            //eyeColumn.Image = Properties.Resources.search_icon_png_21;
            //dataGridViewScores.Columns.Add(eyeColumn);

        }

        private void loadBD()
        {

            // Check if an item is selected in the ComboBox
            if (cmbStudents.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn 1 sinh viên.");
                return;
            }

            string selectedStudentId = cmbStudents.SelectedValue.ToString();

            try
            {
                // Assuming `diemBLL.GetStudentScores` takes the student ID and public key
                List<DiemDTO> dt = diemBLL.GetStudentScores(selectedStudentId, UserSession.PublicKeySession);

                if (dt != null && dt.Count > 0)
                {
                    // Bind data to your DataGridView or any other control you need
                    dataGridViewScores.DataSource = dt;
                    dataGridViewScores.Columns["DiemThi"].DataPropertyName = "DIEM";
                    dataGridViewScores.Columns["DIEM"].Visible = false;

                }
                else
                {
                    MessageBox.Show("Sinh viên được chọn hiện chưa có điểm nào");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading student scores: " + ex.Message);
            }
        

    }
        private void cmbStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            SinhVienDTO sv =(SinhVienDTO) cmbStudents.SelectedItem;
            txtTenSV.Text = sv.HOTEN;

            txt_tenlh.Text = sv.TENLOP;
            loadBD();


        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            string masv = cmbStudents.SelectedValue.ToString();
            string mahp = cmbSubjects.SelectedValue.ToString();
            byte[] diemThi;

            if (!decimal.TryParse(txtDiem.Text, out decimal score1) || score1 < 0 || score1 > 10)
            {
                MessageBox.Show("Điểm phải là số từ 0 đến 10.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method if validation fails.
            }
            if (decimal.TryParse(txtDiem.Text, out decimal score))
            {

                UnicodeEncoding ByteConverter = new UnicodeEncoding();
                byte[] encryptedScore = ByteConverter.GetBytes(score.ToString());
                diemThi = RSAKeyGenerator.Encryption(encryptedScore, UserSession.PublicKeyParamerterSession, false);

                // Update score
                if (diemBLL.InsertScore(masv, mahp, diemThi, _publicKey))
                {
                    MessageBox.Show("Thêm điểm thành công cho sinh viên!");
                    loadBD();

                }
                else
                {
                    MessageBox.Show("Thêm điểm thất bại!");
                }
            }
            else
            {
                MessageBox.Show("Điểm không hợp lệ!");
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string masv = cmbStudents.SelectedValue.ToString();
			string mahp = dataGridViewScores.SelectedRows[0].Cells[1].Value.ToString(); 
            if (diemBLL.DeleteScore(masv, mahp)) 
            {
                MessageBox.Show("Xóa điểm thành công!");
                loadBD();

            }
            else
            {
                MessageBox.Show("Xóa điểm thất bại!");
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string masv = cmbStudents.SelectedValue.ToString();
            string mahp = cmbSubjects.SelectedValue.ToString();
            byte[] diemThi;
            if (!decimal.TryParse(txtDiem.Text, out decimal score1) || score1 < 0 || score1 > 10)
            {
                MessageBox.Show("Điểm phải là số từ 0 đến 10.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method if validation fails.
            }
            // Ensure the score textbox is not empty and parse score to byte array
            if (decimal.TryParse(txtDiem.Text, out decimal score))
            {
                UnicodeEncoding ByteConverter = new UnicodeEncoding();
                byte[] encryptedScore = ByteConverter.GetBytes(score.ToString());
                diemThi = RSAKeyGenerator.Encryption(encryptedScore, UserSession.PublicKeyParamerterSession, false);

                // Update score
                if (diemBLL.UpdateScore(masv, mahp, diemThi, _publicKey)) // Assuming UpdateScore method exists
                {
                    MessageBox.Show("Cập nhật điểm thành công!");
                    loadBD();

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
    }
    }

