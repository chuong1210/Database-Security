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
    internal class NhanVienBLL
    {
        NhanVienDAL nvDAL = new NhanVienDAL();
        public bool VerifyLogin(string username, string password)
        {
            return nvDAL.VerifyLogin(username, password);
        }

        public DataTable GetAllNhanVienDT(string MK)
        {
            return nvDAL.GetAllNhanVienDT(MK);
        }
        public bool CheckClassManagement(string malop, string manv)
        {
            return nvDAL.CheckClassManagement(malop, manv);
        }
        public (string,string) getMaNV(string username)
        {
            return nvDAL.getMaNV(username);
        }
            public List<NhanVienDTO> GetAllNhanVien(string MK)
        {
            return nvDAL.GetAllNhanVien(MK);
        }

        public bool AddNhanVien(NhanVienDTO nv, string pubKey)
        {
          return   nvDAL.AddNhanVien(nv,pubKey);
        }
        public bool UpdateNhanVien(NhanVienDTO nv, string pubKey)
        {
            return nvDAL.UpdateNhanVien(nv, pubKey);
        }

        public bool RemoveNhanVien(string manv)
        {
            return nvDAL.RemoveNhanVien(manv);
        }
        }
}
