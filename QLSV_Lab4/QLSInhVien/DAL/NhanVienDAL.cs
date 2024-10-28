using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using QLSInhVien.DTO;
using System.Configuration;
using QLSInhVien.Helper;
namespace QLSInhVien.DAL
{

    internal class NhanVienDAL
    {



        //private SqlDataAdapter dataAdapter;
        private SqlConnection connection;
        private DataSet dataSet;
        private string connectionString = ConfigurationManager.ConnectionStrings["MyDataConnection"].ConnectionString;


        public NhanVienDAL()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
        //    dataAdapter = new SqlDataAdapter("SELECT * FROM NHANVIEN", connection);
            dataSet = new DataSet();
     
        }

        public bool CheckClassManagement(string malop, string manv)
        {
            // Check in the database if the employee manages this class
            // Example SQL command logic
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM LOP WHERE MALOP = @malop AND MANV = @manv";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@malop", malop);
                    cmd.Parameters.AddWithValue("@manv", manv);
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0; // Return true if the employee manages the class
                }
            }
        }
        public List<NhanVienDTO> GetAllNhanVien(string privateKey)
        {
            List<NhanVienDTO> nvs = new List<NhanVienDTO>();
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_SEL_ALL_NHANVIEN", conn)) // Assuming you have a stored procedure to get all employees
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }




            foreach (DataRow row in dt.Rows)
            {
                NhanVienDTO nv = new NhanVienDTO
                {
                    MANV = row["MANV"].ToString(),
                    HOTEN = row["HOTEN"].ToString(),
                    EMAIL = row["EMAIL"].ToString(),
                    // Encrypt LUONG and convert to Base64 string
                    LUONG = Convert.ToBase64String((byte[])row["LUONG"]),
                 //   LUONG = ConvertSalaryFromBytes((byte[])row["LUONG"], privateKey).ToString(),
                    TENDN = row["TENDN"].ToString(),
                    MATKHAU = Convert.ToBase64String((byte[])row["MATKHAU"])
                };

                nvs.Add(nv);
            }

            return nvs; 

        }


        public DataTable GetAllNhanVienDT(string privateKey)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_SEL_ALL_NHANVIEN", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            // Encrypt the LUONG and MATKHAU columns and replace their values
            foreach (DataRow row in dt.Rows)
            {
                // Assuming LUONG is stored as byte[] in the database
                byte[] luongBytes = (byte[])row["LUONG"];
                string encryptedSalary = Convert.ToBase64String(luongBytes); // Convert to Base64 string
                row["LUONG"] = encryptedSalary; 

                // Assuming MATKHAU is stored as byte[] in the database
                byte[] passwordBytes = (byte[])row["MATKHAU"];
                string encryptedPassword = Convert.ToBase64String(passwordBytes); // Convert to Base64 string
                row["MATKHAU"] = encryptedPassword; // Update the row with the Base64 string
            }

            return dt;
        }

        public bool AddNhanVien(NhanVienDTO nv,string pubKey)
        
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_INS_PUBLIC_ENCRYPT_NHANVIEN", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        byte[] hashedPassword = RSAHelper.HashPasswordSHA1(nv.MATKHAU);
                        string privateKey= Convert.ToBase64String(hashedPassword);

                        byte[] encryptedSalary = RSAHelper.EncryptWithRSA(decimal.Parse(nv.LUONG), pubKey);

                        // Set parameters
                        cmd.Parameters.AddWithValue("@MANV", nv.MANV);
                        cmd.Parameters.AddWithValue("@HOTEN", nv.HOTEN);
                        cmd.Parameters.AddWithValue("@EMAIL", nv.EMAIL);
                        cmd.Parameters.AddWithValue("@LUONG", encryptedSalary);
                        cmd.Parameters.AddWithValue("@TENDN", nv.TENDN);
                        cmd.Parameters.AddWithValue("@MK", hashedPassword);
                        cmd.Parameters.AddWithValue("@PUB", pubKey);

                        conn.Open();
                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
        public (string,string) getMaNV(string username)
        {
            string rs = "";
            string rs2 = "";
                       using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT MANV, PUBKEY FROM NHANVIEN WHERE TENDN = @username";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {

                        rs = reader["MaNV"].ToString();
                        rs2 = reader["PubKey"].ToString();
                    }

                }
            }
            return (rs,rs2);

        }
        public bool VerifyLogin(string username, string password)
        {
            byte[] storedHashedPassword = null;
            bool rs = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT MATKHAU FROM SINHVIEN WHERE TENDN = @username";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        storedHashedPassword = (byte[])reader["MATKHAU"];
                        byte[] hashedInputPasswordSV = RSAHelper.HashPasswordSHA1(password);
                        rs = CompareByteArrays(storedHashedPassword, hashedInputPasswordSV);
                        return rs;
                    }

                }
            }
           
          
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT MATKHAU FROM NHANVIEN WHERE TENDN = @username";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            storedHashedPassword = (byte[])reader["MATKHAU"];
                        }

                    }
                }
            byte[] hashedInputPassword = RSAHelper.HashPasswordSHA1(password);
            if (storedHashedPassword != null)
            {
                rs = CompareByteArrays(storedHashedPassword, hashedInputPassword);
                return rs;
            }
            return false;


        }

        public bool UpdateNhanVien(NhanVienDTO nv, string pubKey)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_UPD_NHANVIEN", conn)) // Assuming you have an update stored procedure
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Hash the password with SHA1
                        byte[] hashedPassword = RSAHelper.HashPasswordSHA1(nv.MATKHAU);

                        // Encrypt salary (LUONG) with RSA using the provided public key
                        byte[] encryptedSalary = RSAHelper.EncryptWithRSA(decimal.Parse(nv.LUONG), pubKey);

                        // Set parameters
                        cmd.Parameters.AddWithValue("@MANV", nv.MANV);
                        cmd.Parameters.AddWithValue("@HOTEN", nv.HOTEN);
                        cmd.Parameters.AddWithValue("@EMAIL", nv.EMAIL);
                        cmd.Parameters.AddWithValue("@LUONG", encryptedSalary);
                        cmd.Parameters.AddWithValue("@MK", hashedPassword);

                        conn.Open();
                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        private decimal ConvertSalaryFromBytes(byte[] salaryBytes, string privateKey)
        {

            return RSAHelper.DecryptSalary(salaryBytes, privateKey);
        }

        public bool RemoveNhanVien(string manv)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_DEL_NHANVIEN", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MANV", manv);

                        conn.Open();
                        int result = cmd.ExecuteNonQuery();
                        return result > 0; // Return true if the deletion was successful
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }



        private bool CompareByteArrays(byte[] array1, byte[] array2)
        {
            if (array1.Length != array2.Length) 
                return false;
            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i]) return false;
            }
            return true;
        }

    }
}
