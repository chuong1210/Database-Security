using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using QLSInhVien.DTO;
using QLSInhVien.Helper;

namespace QLSInhVien.DAL
{
    public class SinhVienDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MyDataConnection"].ConnectionString;

        public DataTable GetStudentsByClass(string malop)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_SEL_STUDENTS_BY_CLASS", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MALOP", malop);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public List<SinhVienDTO> GetAllStudents()
        {
            List<SinhVienDTO> students = new List<SinhVienDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM SINHVIEN", conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        students.Add(new SinhVienDTO
                        {
                            MASV = reader["MASV"].ToString(),
                            HOTEN = reader["HOTEN"].ToString(),
                            NGAYSINH = Convert.ToDateTime(reader["NGAYSINH"]),
                            DIACHI = reader["DIACHI"].ToString(),
                            MALOP = reader["MALOP"].ToString(),
                            TENDN = reader["TENDN"].ToString(),
                            MATKHAU = reader["MATKHAU"].ToString() // Assuming password is stored as byte[]
                        });
                    }
                }
            }
            return students;
        }
        public bool AddStudent(SinhVienDTO student)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO SINHVIEN (MASV, HOTEN, NGAYSINH, DIACHI, MALOP, TENDN, MATKHAU) VALUES (@MASV, @HOTEN, @NGAYSINH, @DIACHI, @MALOP, @TENDN, @MATKHAU)", conn))
                {
                    cmd.Parameters.AddWithValue("@MASV", student.MASV);
                    cmd.Parameters.AddWithValue("@HOTEN", student.HOTEN);
                    cmd.Parameters.AddWithValue("@NGAYSINH", student.NGAYSINH);
                    cmd.Parameters.AddWithValue("@DIACHI", student.DIACHI);
                    cmd.Parameters.AddWithValue("@MALOP", student.MALOP);
                    cmd.Parameters.AddWithValue("@TENDN", student.TENDN);
                    cmd.Parameters.AddWithValue("@MATKHAU", RSAHelper.HashPasswordSHA1(student.MATKHAU)); // Hash the password

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }


        public bool UpdateStudent(SinhVienDTO updatedStudent)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE SINHVIEN SET HOTEN = @HOTEN, NGAYSINH = @NGAYSINH, DIACHI = @DIACHI, MALOP = @MALOP, TENDN = @TENDN, MATKHAU = @MATKHAU WHERE MASV = @MASV", conn))
                {
                    cmd.Parameters.AddWithValue("@MASV", updatedStudent.MASV);
                    cmd.Parameters.AddWithValue("@HOTEN", updatedStudent.HOTEN);
                    cmd.Parameters.AddWithValue("@NGAYSINH", updatedStudent.NGAYSINH);
                    cmd.Parameters.AddWithValue("@DIACHI", updatedStudent.DIACHI);
                    cmd.Parameters.AddWithValue("@MALOP", updatedStudent.MALOP);
                    cmd.Parameters.AddWithValue("@TENDN", updatedStudent.TENDN);
                    cmd.Parameters.AddWithValue("@MATKHAU", RSAHelper.HashPasswordSHA1(updatedStudent.MATKHAU)); // Assuming MATKHAU is a byte array
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteStudent(string masv)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM SINHVIEN WHERE MASV = @MASV", conn))
                {
                    cmd.Parameters.AddWithValue("@MASV", masv);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

     
        }
}
