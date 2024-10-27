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
    public class SinhVienBLL
    {
        private SinhVienDAL sinhVienDAL;

        public SinhVienBLL()
        {
            sinhVienDAL = new SinhVienDAL();
        }
        public DataTable GetStudentsByClass(string malop)
        {
            if (string.IsNullOrWhiteSpace(malop))
            {
                throw new ArgumentException("Mã lớp không được để trống.");
            }
            return sinhVienDAL.GetStudentsByClass(malop);
        }

        public bool AddStudent(SinhVienDTO student)
        {
            return sinhVienDAL.AddStudent(student);
        }
        public bool Update(SinhVienDTO student)
        {
            return sinhVienDAL.UpdateStudent(student);
        }
        public bool DeleteStudent(string masv)
        {
            return sinhVienDAL.DeleteStudent(masv);
        }
        }
}
