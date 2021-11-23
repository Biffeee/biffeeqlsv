using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;

namespace quanlysinhvien
{
    public partial class frmSV : Form
    {
        #region[Load]
        sinhvienBLL bllSV;
        khoaBLL bllKHOA;
        lopBLL bllLOP;
        public frmSV()
        {
            InitializeComponent();
            bllSV = new sinhvienBLL();
            bllKHOA = new khoaBLL();
            bllLOP = new lopBLL();
        }
             
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLSVDataSetlop.QLSV_LOP' table. You can move, or remove it, as needed.
            this.qLSV_LOPTableAdapter.Fill(this.qLSVDataSetlop.QLSV_LOP);
            // TODO: This line of code loads data into the 'qLSVDataSetkhoa.QLSV_KHOA' table. You can move, or remove it, as needed.
            this.qLSV_KHOATableAdapter.Fill(this.qLSVDataSetkhoa.QLSV_KHOA);
            // TODO: This line of code loads data into the 'qLSVDataSet.QLSV_TTSV' table. You can move, or remove it, as needed.
            this.qLSV_TTSVTableAdapter.Fill(this.qLSVDataSet.QLSV_TTSV);
            hienthi();
            this.reportViewer1.RefreshReport();
        }

        public void hienthi()
        {
            DataTable dt = bllSV.getallsinhvien();
            DataTable dtkhoa = bllKHOA.getallkhoa();
            DataTable dtlop = bllLOP.getalllop();
            dgvsv.DataSource = dt;
            dgvkhoa.DataSource = dtkhoa;
            dgvlop.DataSource = dtlop;

        }
        #endregion

        #region[checkdata]
        public bool checkdata()
        {
            if (string.IsNullOrEmpty(txtmssv.Text)) 
            {
                MessageBox.Show("Bạn chưa nhập mssv", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmssv.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtname.Text))
            {
                MessageBox.Show("Bạn chưa nhập Họ Tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtname.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtphone.Text))
            {
                MessageBox.Show("Bạn chưa nhập SĐT", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtphone.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtemail.Text))
            {
                MessageBox.Show("Bạn chưa nhập Email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtemail.Focus();
                return false;
            }
            //if (string.IsNullOrEmpty(txtlop.Text))
            //{
            //    MessageBox.Show("Bạn chưa nhập Lớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    txtlop.Focus();
            //    return false;
            //}
            if (string.IsNullOrEmpty(txtaddress.Text))
            {
                MessageBox.Show("Bạn chưa nhập Địa Chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtaddress.Focus();
                return false;
            }
            //if (string.IsNullOrEmpty(txtkhoa.Text))
            //{
            //    MessageBox.Show("Bạn chưa nhập Khoa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    txtkhoa.Focus();
            //    return false;
            //}
            if (string.IsNullOrEmpty(cbgender.Text))
            {
                MessageBox.Show("Bạn chưa nhập Giới Tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbgender.Focus();
                return false;
            }
           
            if (string.IsNullOrEmpty(txttoan.Text))
            {
                MessageBox.Show("Bạn chưa nhập Điểm Toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttoan.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtvan.Text))
            {
                MessageBox.Show("Bạn chưa nhập Điểm Văn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtvan.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtanh.Text))
            {
                MessageBox.Show("Bạn chưa nhập Điểm Anh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtanh.Focus();
                return false;
            }
           
            return true;
        }
        #endregion

        #region[SinhVien]

        int ID;
        private void txtfind_TextChanged(object sender, EventArgs e)
        {
            string value = txtfind.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable dt = bllSV.findsinhvien(value);
                dgvsv.DataSource = dt;
            }
            else
                hienthi();
        }

        private void dgvsv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            DataGridViewRow row = dgvsv.Rows[dgvsv.CurrentCell.RowIndex];
            ID = int.Parse(row.Cells[0].Value.ToString());
            txtmssv.Text = row.Cells[1].Value.ToString();
            txtname.Text = row.Cells[2].Value.ToString();
            txtphone.Text = row.Cells[3].Value.ToString();
            txtemail.Text = row.Cells[4].Value.ToString();
            cblop.Text = row.Cells[5].Value.ToString();
            txtaddress.Text = row.Cells[6].Value.ToString();
            cbkhoa.Text = row.Cells[7].Value.ToString();
            dtpbirth.Text = row.Cells[8].Value.ToString();
            cbgender.SelectedItem = row.Cells[9].Value.ToString();
            txttoan.Text = row.Cells[10].Value.ToString();
            txtvan.Text = row.Cells[11].Value.ToString();
            txtanh.Text = row.Cells[12].Value.ToString();
        

        }

        private void btnexit_Click(object sender, EventArgs e)
        {
           if( MessageBox.Show("Bạn có muốn thoát không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes);
            Application.Exit();
        }
           

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (checkdata())
            {
                double toan = Convert.ToDouble(txttoan.Text);
                double van = Convert.ToDouble(txtvan.Text);
                double anh = Convert.ToDouble(txtanh.Text);
                if (van >= 0 && van <= 10 && toan >= 0 && toan <= 10 && anh >= 0 && anh <= 10)
                {
                    double diemtb = (toan + van + anh) / 3;
                }
                QLSV_TTSV sv = new QLSV_TTSV();
                sv.mssv = txtmssv.Text;
                sv.name = txtname.Text;
                sv.phone = txtphone.Text;
                sv.email = txtemail.Text;
                sv.lop = cblop.Text;
                sv.address = txtaddress.Text;
                sv.khoa = cbkhoa.Text;
                sv.ngaysinh = dtpbirth.Value;
                sv.gioitinh = cbgender.Text;
                sv.toan = double.Parse(txttoan.Text);
                sv.van = double.Parse(txtvan.Text);
                sv.anh = double.Parse(txtanh.Text);
                sv.diemtb = (Convert.ToDouble(txttoan.Text) + Convert.ToDouble(txtvan.Text) + Convert.ToDouble(txtanh.Text)) / 3;
                if (bllSV.insertsinhvien(sv))
                {

                    hienthi();
                    clearfields();
                    MessageBox.Show("Thêm thành công","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Đã có lỗi", "Thông báo");

                }

            }
        }

        private void btnmodify_Click(object sender, EventArgs e)
        {
            if (checkdata())
            {
                QLSV_TTSV sv = new QLSV_TTSV();
                sv.id = ID;
                sv.mssv = txtmssv.Text;
                sv.name = txtname.Text;
                sv.phone = txtphone.Text;
                sv.email = txtemail.Text;
                sv.lop = cblop.Text;
                sv.address = txtaddress.Text;
                sv.khoa = cbkhoa.Text;
                sv.ngaysinh = dtpbirth.Value;
                sv.gioitinh = cbgender.Text;
                sv.toan = double.Parse(txttoan.Text);
                sv.van = double.Parse(txtvan.Text);
                sv.anh = double.Parse(txtanh.Text);
                double diemtb = (Convert.ToDouble(txttoan.Text) + Convert.ToDouble(txtvan.Text) + Convert.ToDouble(txtanh.Text)) / 3;
                sv.diemtb = double.Parse(diemtb.ToString());
                if (bllSV.updatesinhvien(sv))
                {
                    hienthi();
                    clearfields();
                    MessageBox.Show("Sửa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    MessageBox.Show("Đã có lỗi", "Thông báo");
                }

            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                QLSV_TTSV sv = new QLSV_TTSV();
                sv.id = ID;
                if (bllSV.deletesinhvien(sv))
                {
                    hienthi();
                    clearfields();
                    MessageBox.Show("Xóa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Đã có lỗi", "Thông báo");
                }

            }
        }
        #endregion

        #region[Clearfields]
        public void clearfields()
        {
            txtmssv.Text = "";
            txtname.Text = "";
            txtphone.Text = "";
            txtemail.Text = "";
            cblop.SelectedIndex = -1;
            txtaddress.Text = "";
            cbkhoa.SelectedIndex = -1;
            cbgender.SelectedIndex = -1;
            txttoan.Text = "";
            txtvan.Text = "";
            txtanh.Text = "";
            txtmakhoa.Text = "";
            txtkhoaa.Text = "";
            txtmalop.Text = "";
            txtlopp.Text = "";

        }
        #endregion

        #region[Thống Kê] 
        SqlConnection con = new SqlConnection("Data Source = MRDANH\\SQLEXPRESS; Initial Catalog = QLSV; Integrated Security = true");
        private void radgioi_CheckedChanged(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select mssv,name,lop,khoa,ngaysinh,gioitinh,diemtb from QLSV_TTSV where diemtb>=8 and diemtb<10", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvtk.DataSource = dt;
            dgvtk.DataSource = null;
            foreach (DataRow row in dt.Rows)
            {
                int n = dgvtk.Rows.Add();
                dgvtk.Rows[n].Cells[0].Value = row["mssv"].ToString();
                dgvtk.Rows[n].Cells[1].Value = row["name"].ToString();
                dgvtk.Rows[n].Cells[2].Value = row["lop"].ToString();
                dgvtk.Rows[n].Cells[3].Value = row["khoa"].ToString();
                dgvtk.Rows[n].Cells[4].Value = row["ngaysinh"].ToString();
                dgvtk.Rows[n].Cells[5].Value = row["gioitinh"].ToString();
                dgvtk.Rows[n].Cells[6].Value = row["diemtb"].ToString();

            }

        }

        private void radtb_CheckedChanged(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select mssv,name,lop,khoa,ngaysinh,gioitinh,diemtb from QLSV_TTSV where diemtb>=4 and diemtb<6", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvtk.DataSource = dt;
            dgvtk.DataSource = null;
            foreach (DataRow row in dt.Rows)
            {
                int n = dgvtk.Rows.Add();
                dgvtk.Rows[n].Cells[0].Value = row["mssv"].ToString();
                dgvtk.Rows[n].Cells[1].Value = row["name"].ToString();
                dgvtk.Rows[n].Cells[2].Value = row["lop"].ToString();
                dgvtk.Rows[n].Cells[3].Value = row["khoa"].ToString();
                dgvtk.Rows[n].Cells[4].Value = row["ngaysinh"].ToString();
                dgvtk.Rows[n].Cells[5].Value = row["gioitinh"].ToString();
                dgvtk.Rows[n].Cells[6].Value = row["diemtb"].ToString();

            }
        }

        private void radyeu_CheckedChanged(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select mssv,name,lop,khoa,ngaysinh,gioitinh,diemtb from QLSV_TTSV where diemtb>=0 and diemtb<4", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvtk.DataSource = dt;
            dgvtk.DataSource = null;
            foreach (DataRow row in dt.Rows)
            {
                int n = dgvtk.Rows.Add();
                dgvtk.Rows[n].Cells[0].Value = row["mssv"].ToString();
                dgvtk.Rows[n].Cells[1].Value = row["name"].ToString();
                dgvtk.Rows[n].Cells[2].Value = row["lop"].ToString();
                dgvtk.Rows[n].Cells[3].Value = row["khoa"].ToString();
                dgvtk.Rows[n].Cells[4].Value = row["ngaysinh"].ToString();
                dgvtk.Rows[n].Cells[5].Value = row["gioitinh"].ToString();
                dgvtk.Rows[n].Cells[6].Value = row["diemtb"].ToString();

            }
        }

        private void radkha_CheckedChanged(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select mssv,name,lop,khoa,ngaysinh,gioitinh,diemtb from QLSV_TTSV where diemtb>=6 and diemtb<8", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvtk.DataSource = dt;
            dgvtk.DataSource = null;
            foreach (DataRow row in dt.Rows)
            {
                int n = dgvtk.Rows.Add();
                dgvtk.Rows[n].Cells[0].Value = row["mssv"].ToString();
                dgvtk.Rows[n].Cells[1].Value = row["name"].ToString();
                dgvtk.Rows[n].Cells[2].Value = row["lop"].ToString();
                dgvtk.Rows[n].Cells[3].Value = row["khoa"].ToString();
                dgvtk.Rows[n].Cells[4].Value = row["ngaysinh"].ToString();
                dgvtk.Rows[n].Cells[5].Value = row["gioitinh"].ToString();
                dgvtk.Rows[n].Cells[6].Value = row["diemtb"].ToString();

            }
        }
        #endregion

        #region[Chart]
        private void btnload_Click(object sender, EventArgs e)
        {      
            chart1.Series["name"].XValueMember = "name";
            chart1.Series["name"].YValueMembers = "diemtb";
            chart1.DataSource = qLSVDataSet.QLSV_TTSV;
            chart1.DataBind();
        }
        #endregion

        #region[KHOA]
        private void btnaddk_Click(object sender, EventArgs e)
        {
            QLSV_KHOA k = new QLSV_KHOA();
            k.makhoa = txtmakhoa.Text;
            k.khoa = txtkhoaa.Text;
            if (bllKHOA.insertkhoa(k))
            {
                hienthi();
                clearfields();
                MessageBox.Show("Thêm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);               

            }
            else
            {
                MessageBox.Show("Đã có lỗi", "Thông báo");

            }
        }

        private void btnmodifyk_Click(object sender, EventArgs e)
        {
            QLSV_KHOA k = new QLSV_KHOA();
            k.makhoa = txtmakhoa.Text;
            k.khoa = txtkhoaa.Text;                     
            if (bllKHOA.updatekhoa(k))
            {
                hienthi();
                clearfields();
                MessageBox.Show("Sửa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearfields();
            }

            else
            {
                MessageBox.Show("Đã có lỗi", "Thông báo");
            }
        }

        private void dgvkhoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvkhoa.Rows[dgvkhoa.CurrentCell.RowIndex];
            txtmakhoa.Text = row.Cells[0].Value.ToString();
            txtkhoaa.Text = row.Cells[1].Value.ToString();
        }

        private void btndeletek_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                QLSV_KHOA k = new QLSV_KHOA();
                k.makhoa = txtmakhoa.Text;
                if (bllKHOA.deletekhoa(k))
                {
                    hienthi();
                    clearfields();
                    MessageBox.Show("Xóa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Đã có lỗi", "Thông báo");
                }

            }
        }
        #endregion

        #region[LOP]
        private void btnaddl_Click(object sender, EventArgs e)
        {
            QLSV_LOP l = new QLSV_LOP();
            l.malop = txtmalop.Text;
            l.lop = txtlopp.Text;
            if (bllLOP.insertlop(l))
            {
                hienthi();
                clearfields();
                MessageBox.Show("Thêm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Đã có lỗi", "Thông báo");

            }
        }

        private void btnmodifyl_Click(object sender, EventArgs e)
        {
            QLSV_LOP l = new QLSV_LOP();
            l.malop = txtmalop.Text;
            l.lop = txtlopp.Text;
            if (bllLOP.updatelop(l))
            {
                hienthi();
                clearfields();
                MessageBox.Show("Sửa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearfields();
            }

            else
            {
                MessageBox.Show("Đã có lỗi", "Thông báo");
            }
        }

        private void btndeletel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                QLSV_LOP l = new QLSV_LOP();
                l.malop = txtmalop.Text;
                if (bllLOP.deletelop(l))
                {
                    hienthi();
                    clearfields();
                    MessageBox.Show("Xóa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Đã có lỗi", "Thông báo");
                }

            }
        }

        private void dgvlop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvlop.Rows[dgvlop.CurrentCell.RowIndex];
            txtmalop.Text = row.Cells[0].Value.ToString();
            txtlopp.Text = row.Cells[1].Value.ToString();
        }


        #endregion

        #region[Báo Cáo]
        private void btnloadrp_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select *from QLSV_TTSV where gioitinh='"+cbgioitinhrp.Text+"'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ReportDataSource rds = new ReportDataSource("DataSet1",dt);
            reportViewer1.LocalReport.ReportPath = @"D:\quanlysinhvien\quanlysinhvien\Report.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
            con.Close();
        }
        #endregion
    }
}
