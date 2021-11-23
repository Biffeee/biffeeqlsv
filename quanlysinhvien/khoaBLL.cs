using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlysinhvien
{
    class khoaBLL
    {
        khoaDAL dalkhoa;
        public khoaBLL()
        {
            dalkhoa = new khoaDAL();
        }

        public DataTable getallkhoa()
        {
            return dalkhoa.getallkhoa();
        }

        public bool insertkhoa(QLSV_KHOA k)
        {
            return dalkhoa.insertkhoa(k);
        }

        public bool updatekhoa(QLSV_KHOA k)
        {
            return dalkhoa.updatekhoa(k);
        }

        public bool deletekhoa(QLSV_KHOA k)

        {
            return dalkhoa.deletekhoa(k);
        }

    }
}
