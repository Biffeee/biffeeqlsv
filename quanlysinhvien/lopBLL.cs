using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlysinhvien
{
    class lopBLL
    {
        lopDAL dallop;
        public lopBLL()
        {
            dallop = new lopDAL();
        }

        public DataTable getalllop()
        {
            return dallop.getalllop();
        }

        public bool insertlop(QLSV_LOP l)
        {
            return dallop.insertlop(l);
        }

        public bool updatelop(QLSV_LOP l)
        {
            return dallop.updatelop(l);
        }

        public bool deletelop(QLSV_LOP l)

        {
            return dallop.deletelop(l);
        }
    }
}
