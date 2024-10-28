using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLSInhVien.DTO;

namespace QLSInhVien.DAL
{
    public class DiemDAL
    {
        private SqlConnection connection;
        private DataSet dataSet;
        private string connectionString = ConfigurationManager.ConnectionStrings["MyDataConnection"].ConnectionString;
   
        public DataTable GetStudentsByEmployeeDT(string manv)
        {
            DataTable dtStudents = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_GET_STUDENTS_BY_EMPLOYEE", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MANV", manv);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dtStudents);
                    }
                }
            }

            return dtStudents;
        }
        public List<SinhVienDTO> GetStudentsByEmployee(string manv)
        {
            List<SinhVienDTO> students = new List<SinhVienDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_GET_STUDENTS_BY_EMPLOYEE", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MANV", manv);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SinhVienDTO student = new SinhVienDTO
                            {
                                MASV = reader["MASV"].ToString(),
                                HOTEN = reader["HOTEN"].ToString(),
                                TENLOP = reader["TENLOP"].ToString() 
                            };
                            students.Add(student);
                        }
                    }
                }
            }

            return students;
        }

        public bool InsertScore(string masv, string mahp, byte[] diemThi, string pubKey)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_INSERT_SCORE", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MASV", masv);
                    cmd.Parameters.AddWithValue("@MAHP", mahp);
                    cmd.Parameters.AddWithValue("@DIEMTHI", diemThi);
                    cmd.Parameters.AddWithValue("@PUBKEY", pubKey);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; 
                }
            }
        }
        public DataTable GetSubjects()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM HOCPHAN";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
}
