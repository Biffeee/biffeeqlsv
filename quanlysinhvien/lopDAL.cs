using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlysinhvien
{
    class lopDAL
    {
        dataconnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public lopDAL()
        {
            dc = new dataconnection();
        }
        public DataTable getalllop()
        {
            string sql = "SELECT * FROM QLSV_LOP";
            SqlConnection con = dc.GetConnection();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public bool insertlop(QLSV_LOP l)
        {
            string sql = "INSERT INTO QLSV_LOP(malop,lop) VALUES(@malop,@lop)";
            SqlConnection con = dc.GetConnection();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@malop", SqlDbType.NVarChar).Value = l.malop;
                cmd.Parameters.Add("@lop", SqlDbType.NVarChar).Value = l.lop;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool updatelop(QLSV_LOP l)
        {
            string sql = "UPDATE QLSV_LOP SET lop=@lop WHERE malop=@malop";
            SqlConnection con = dc.GetConnection();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@malop", SqlDbType.NVarChar).Value = l.malop;
                cmd.Parameters.Add("@lop", SqlDbType.NVarChar).Value = l.lop;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool deletelop(QLSV_LOP l)
        {
            string sql = "DELETE QLSV_LOP WHERE malop=@malop";
            SqlConnection con = dc.GetConnection();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@malop", SqlDbType.NVarChar).Value = l.malop;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}
