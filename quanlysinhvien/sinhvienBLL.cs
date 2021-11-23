using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlysinhvien
{
     class sinhvienBLL
    {
        sinhvienDAL dalsinhvien;
     
        public sinhvienBLL()
        {
            dalsinhvien = new sinhvienDAL();
        }

        public DataTable getallsinhvien()
        {
            return dalsinhvien.getallsinhvien();
        }

        public bool insertsinhvien(QLSV_TTSV sv)
        {
            return dalsinhvien.insertsinhvien(sv);
        }

        public bool updatesinhvien(QLSV_TTSV sv)
        {
            return dalsinhvien.updatesinhvien(sv);
        }

        public bool deletesinhvien(QLSV_TTSV sv)

        {
            return dalsinhvien.deletesinhvien(sv);
        }

        public DataTable findsinhvien(string sv)
        {
            return dalsinhvien.findsinhvien(sv);
        }


    }
}
