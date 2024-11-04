
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLSInhVien.DAL;
using QLSInhVien.DTO;

namespace QLSInhVien.BLL
{
    public class DiemBLL
    {
        private DiemDAL diemDAL= new DiemDAL();
    


        public List<SinhVienDTO> GetStudentsByEmployee(string manv)
        {
            return diemDAL.GetStudentsByEmployee(manv);
        }

        public bool InsertScore(string masv, string mahp, byte[] diemThi, string pubKey)
        {
            return diemDAL.InsertScore(masv, mahp, diemThi, pubKey);
        }
        public List<DiemDTO> GetStudentScores(string masv, string privateKey)
        {
            return diemDAL.GetStudentScores(masv, privateKey);
        }

            public DataTable GetSubjects()
        {
            return diemDAL.GetSubjects();
        }
        public bool UpdateScore(string masv, string mahp, byte[] diemThi, string pubKey)
        {
            return diemDAL.UpdateScore(masv,mahp, diemThi, pubKey);

        }


        public bool DeleteScore(string masv, string mahp)
        {
            return diemDAL.DeleteScore(masv, mahp);
        }
        }
}
