using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlysinhvien
{
    class khoaDAL
    {
        dataconnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public khoaDAL()
        {
            dc = new dataconnection();
        }
        public DataTable getallkhoa()
        {
            string sql = "SELECT * FROM QLSV_KHOA";
            SqlConnection con = dc.GetConnection();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public bool insertkhoa(QLSV_KHOA k)
        {
            string sql = "INSERT INTO QLSV_KHOA(makhoa,khoa) VALUES(@makhoa,@khoa)";
            SqlConnection con = dc.GetConnection();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@makhoa", SqlDbType.NVarChar).Value = k.makhoa;
                cmd.Parameters.Add("@khoa", SqlDbType.NVarChar).Value = k.khoa;               
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool updatekhoa(QLSV_KHOA k)
        {
            string sql = "UPDATE QLSV_KHOA SET khoa=@khoa WHERE makhoa=@makhoa";
            SqlConnection con = dc.GetConnection();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();              
                cmd.Parameters.Add("@makhoa", SqlDbType.NVarChar).Value = k.makhoa;
                cmd.Parameters.Add("@khoa", SqlDbType.NVarChar).Value = k.khoa;               
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool deletekhoa(QLSV_KHOA k)
        {
            string sql = "DELETE QLSV_KHOA WHERE makhoa=@makhoa";
            SqlConnection con = dc.GetConnection();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@makhoa", SqlDbType.NVarChar).Value = k.makhoa;
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
