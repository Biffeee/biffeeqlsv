using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlysinhvien
{
    class sinhvienDAL
    {
        dataconnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public sinhvienDAL()
        {
            dc = new dataconnection();
        }
        public DataTable getallsinhvien()
        {
            string sql = "SELECT * FROM QLSV_TTSV";
            SqlConnection con = dc.GetConnection();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public bool insertsinhvien(QLSV_TTSV sv)
        {
            string sql = "INSERT INTO QLSV_TTSV(mssv,name,phone,email,lop,address,khoa,ngaysinh,gioitinh,toan,van,anh,diemtb) VALUES(@mssv,@name,@phone,@email,@lop,@address,@khoa,@ngaysinh,@gioitinh,@toan,@van,@anh,@diemtb)";
            SqlConnection con = dc.GetConnection();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@mssv", SqlDbType.NVarChar).Value = sv.mssv;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = sv.name;
                cmd.Parameters.Add("@phone", SqlDbType.NVarChar).Value = sv.phone;
                cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = sv.email;
                cmd.Parameters.Add("@lop", SqlDbType.NVarChar).Value = sv.lop;
                cmd.Parameters.Add("@address", SqlDbType.NVarChar).Value = sv.address;
                cmd.Parameters.Add("@khoa", SqlDbType.NVarChar).Value = sv.khoa;
                cmd.Parameters.Add("@ngaysinh", SqlDbType.DateTime).Value = sv.ngaysinh;
                cmd.Parameters.Add("@gioitinh", SqlDbType.NVarChar).Value = sv.gioitinh;
                cmd.Parameters.Add("@toan", SqlDbType.Float).Value = sv.toan;
                cmd.Parameters.Add("@van", SqlDbType.Float).Value = sv.van;
                cmd.Parameters.Add("@anh", SqlDbType.Float).Value = sv.anh;
                cmd.Parameters.Add("@diemtb", SqlDbType.Float).Value = sv.diemtb;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception e)
            {
                return false;
            }
            return true;
        }
        public bool updatesinhvien(QLSV_TTSV sv)
        {
            string sql = "UPDATE QLSV_TTSV SET mssv=@mssv,name=@name,phone=@phone,email=@email,lop=@lop,address=@address,khoa=@khoa,ngaysinh=@ngaysinh,gioitinh=@gioitinh,toan=@toan,van=@van,anh=@anh,diemtb=@diemtb WHERE id=@id";
            SqlConnection con = dc.GetConnection();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = sv.id;
                cmd.Parameters.Add("@mssv", SqlDbType.NVarChar).Value = sv.mssv;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = sv.name;
                cmd.Parameters.Add("@phone", SqlDbType.NVarChar).Value = sv.phone;
                cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = sv.email;
                cmd.Parameters.Add("@lop", SqlDbType.NVarChar).Value = sv.lop;
                cmd.Parameters.Add("@address", SqlDbType.NVarChar).Value = sv.address;
                cmd.Parameters.Add("@khoa", SqlDbType.NVarChar).Value = sv.khoa;
                cmd.Parameters.Add("@ngaysinh", SqlDbType.DateTime).Value = sv.ngaysinh;
                cmd.Parameters.Add("@gioitinh", SqlDbType.NVarChar).Value = sv.gioitinh;
                cmd.Parameters.Add("@toan", SqlDbType.Float).Value = sv.toan;
                cmd.Parameters.Add("@van", SqlDbType.Float).Value = sv.van;
                cmd.Parameters.Add("@anh", SqlDbType.Float).Value = sv.anh;
                cmd.Parameters.Add("@diemtb", SqlDbType.Float).Value = sv.diemtb;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool deletesinhvien(QLSV_TTSV sv)
        {
            string sql = "DELETE QLSV_TTSV WHERE id=@id";
            SqlConnection con = dc.GetConnection();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = sv.id;                
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public DataTable findsinhvien(string sv)
        {
            string sql = "SELECT *FROM QLSV_TTSV WHERE mssv like '%" + sv + "%' OR name like N'%" + sv + "%' OR gioitinh like N'%" + sv + "%'";                      
            SqlConnection con = dc.GetConnection();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        
    }
}
