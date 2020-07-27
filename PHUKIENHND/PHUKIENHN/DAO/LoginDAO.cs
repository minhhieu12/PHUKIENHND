using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHUKIENHN.DAO
{
    class LoginDAO
    {
        private static LoginDAO instance;

        public static LoginDAO Instance
        {
            get { if (instance == null) instance = new LoginDAO(); return instance; }
            private set { instance = value; }
        }

        private LoginDAO() { }

        public bool isLogin(string userName, string passWord)
        {
            string query = string.Format("SELECT * FROM NHANVIEN WHERE TENDN = '{0}' AND MATKHAU = '{1}' ", userName, passWord);

            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            return result.Rows.Count == 1;
        }

        public string checkError(string strUserName, string strPassWord)
        {
            string strErr = string.Empty;

            if (strUserName == string.Empty && strPassWord == string.Empty)
            {
                strErr = "Bạn chưa nhập tài khoản và mật khẩu!";
            }
            else if (strUserName == string.Empty)
            {
                strErr = "Tài khoản vui lòng không được bỏ trống";
            }
            else if (strPassWord == string.Empty)
            {
                strErr = "Mật khẩu vui lòng không được bỏ trống";
            }

            return strErr;
        }
    }
}
