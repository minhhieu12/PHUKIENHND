using DevExpress.XtraBars;
using PHUKIENHN.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PHUKIENHN
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string userName = txtTenDN.Text.Trim();
            string passWord = txtMK.Text.Trim();
            
            if (LoginDAO.Instance.checkError(userName, passWord) != string.Empty)
            {
                MessageBox.Show(LoginDAO.Instance.checkError(userName, passWord));
                return;
            }

            string query = string.Format("SELECT * FROM NHANVIEN WHERE TENDN = '{0}'", userName);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            
            if(LoginDAO.Instance.isLogin(userName, passWord))
            {
                this.Hide();
                frmMain f = new frmMain();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!");
            }
            
        }

    }
}
