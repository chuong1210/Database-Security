using System;
using System.Collections.Generic;
using System.Data;
using QLSInhVien.DAL;
using QLSInhVien.DTO;

namespace QLSInhVien.BLL
{
    public class LopBLL
    {
        private LopDAL lopDAL;

        public LopBLL()
        {
            lopDAL = new LopDAL();
        }

        public List<LopDTO> GetAllClasses()
        {
            return lopDAL.GetAllClasses();
        }

        // Add a new class
        public bool AddClass(LopDTO newClass)
        {
            if (string.IsNullOrWhiteSpace(newClass.MALOP) || string.IsNullOrWhiteSpace(newClass.TENLOP))
            {
                throw new ArgumentException("Mã lớp và tên lớp không được để trống.");
            }
            return lopDAL.AddClass(newClass);
        }

        public bool UpdateClass(LopDTO lop)
        {
            if (string.IsNullOrWhiteSpace(lop.MALOP) || string.IsNullOrWhiteSpace(lop.TENLOP))
            {
                throw new ArgumentException("Mã lớp và tên lớp không được để trống.");
            }
            return lopDAL.UpdateClass(lop);
        }

        public bool DeleteClass(string malop)
        {
            if (string.IsNullOrWhiteSpace(malop))
            {
                throw new ArgumentException("Mã lớp không được để trống.");
            }
            return lopDAL.DeleteClass(malop);
        }

   
        public DataTable GetClassesByEmployee(string manv)
        {
            if (string.IsNullOrWhiteSpace(manv))
            {
                throw new ArgumentException("Mã nhân viên không được để trống.");
            }
            return lopDAL.GetClassesByEmployee(manv);
        }
        public List<NhanVienDTO> GetAllNhanVien()
        {
            return lopDAL.GetAllNhanVien();
        }
        }
}
