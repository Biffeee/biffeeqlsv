using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlysinhvien
{
    class dataconnection
    {
        string constring;
        public dataconnection()
        {
            constring = "Data Source=MRDANH\\SQLEXPRESS; Initial Catalog=QLSV; Integrated Security=true"  ;

        }
        public SqlConnection GetConnection()
        {
            return new SqlConnection(constring);
        }
    }
}
