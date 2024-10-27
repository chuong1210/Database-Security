using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using QLSInhVien.DTO;

namespace QLSInhVien.DAL
{
    public class LopDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MyDataConnection"].ConnectionString;

        public List<LopDTO> GetAllClasses()
        {
            List<LopDTO> classes = new List<LopDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_SEL_ALL_CLASSES", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        classes.Add(new LopDTO
                        {
                            MALOP = reader["MALOP"].ToString(),
                            TENLOP = reader["TENLOP"].ToString(),
                            MANV = reader["MANV"].ToString()
                        });
                    }
                }
            }
            return classes;
        }

        public bool AddClass(LopDTO newClass)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_INS_CLASS", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MALOP", newClass.MALOP);
                        cmd.Parameters.AddWithValue("@TENLOP", newClass.TENLOP);
                        cmd.Parameters.AddWithValue("@MANV", newClass.MANV);
                        conn.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateClass(LopDTO lop)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_UPD_CLASS", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MALOP", lop.MALOP);
                    cmd.Parameters.AddWithValue("@TENLOP", lop.TENLOP);
                    cmd.Parameters.AddWithValue("@MANV", lop.MANV);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteClass(string malop)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_DEL_CLASS", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MALOP", malop);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }



        public DataTable GetClassesByEmployee(string manv)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_SEL_CLASSES_BY_EMPLOYEE", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MANV", manv);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public List<NhanVienDTO> GetAllNhanVien()
        {
            List<NhanVienDTO> employees = new List<NhanVienDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_SEL_ALL_EMPLOYEES", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        employees.Add(new NhanVienDTO
                        {
                            MANV = reader["MANV"].ToString(),
                            HOTEN = reader["HOTEN"].ToString()
                        });
                    }
                }
            }
            return employees;
        }
    }
}
