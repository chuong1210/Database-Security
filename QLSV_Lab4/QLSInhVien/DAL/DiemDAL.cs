using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLSInhVien.DTO;
using QLSInhVien.Helper;

namespace QLSInhVien.DAL
{
    public class DiemDAL
    {
        private SqlConnection connection;
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
                                TENLOP = reader["TENLOP"].ToString() ,

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

        public bool UpdateScore(string masv, string mahp, byte[] diemThi, string pubKey)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_UPDATE_SCORE", conn)) // Assuming you have a stored procedure for update
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MASV", masv);
                    cmd.Parameters.AddWithValue("@MAHP", mahp);
                    cmd.Parameters.AddWithValue("@DIEMTHI", diemThi);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0; // Returns true if update was successful
                }
            }
        }

        public List<DiemDTO> GetStudentScores(string masv, string privateKey)
        {
            List<DiemDTO> scores = new List<DiemDTO>();
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_GET_STUDENT_SCORES", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MASV", masv);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                }
            }
                             foreach (DataRow reader in dt.Rows)
            {
                            byte[] data = (byte[])reader["DIEMTHI"];
                            string encryptedScore = Convert.ToBase64String(data);

                            byte[] decryptedtex = RSAKeyGenerator.Decryption(data, UserSession.PrivateKeyParamerterSession, false);
                            UnicodeEncoding ByteConverter = new UnicodeEncoding();
                            encryptedScore = ByteConverter.GetString(decryptedtex);




                            DiemDTO score = new DiemDTO
                            {
                                MAHP = reader["MAHP"].ToString(),
                                TENHP = reader["TENHP"].ToString(),
								//DIEM =Convert.ToBase64String(data),

								DIEM = encryptedScore,
                            };
                            scores.Add(score);
                        }

            return scores;
        }

      

       

        public bool DeleteScore(string masv, string mahp)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_DELETE_SCORE", conn)) // Assuming you have a stored procedure for delete
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MASV", masv);
                    cmd.Parameters.AddWithValue("@MAHP", mahp);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0; // Returns true if delete was successful
                }
            }
        }

    }
}
