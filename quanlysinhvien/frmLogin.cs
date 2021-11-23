using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlysinhvien
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            frmSV _sv = new frmSV();
            if (checkobject())
            {
                if (txtusername.Text.Equals("admin") && txtpassword.Text.Equals("123"))
                {
                    _sv.Show();
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Vui lòng kiểm tra lại UserName và PassWord";
                }
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public bool checkobject()
        {
            if (string.IsNullOrWhiteSpace(txtusername.Text))
            {
                MessageBox.Show("Chưa nhập UserName", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtusername.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtpassword.Text))
            {
                MessageBox.Show("Chưa nhập PassWord", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtpassword.Focus();
                return false;
            }
            return true;
        }
    }
}
