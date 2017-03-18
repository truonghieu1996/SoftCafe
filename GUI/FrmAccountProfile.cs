using GUI.DAO;
using GUI.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmAccountProfile : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; changAccount(loginAccount); }
        }
        public FrmAccountProfile(Account acc)
        {
            InitializeComponent();
            LoginAccount = acc;
        }

        void changAccount(Account acc)
        {
            txtUsername.Text = LoginAccount.UserName;
            txtdisplayName.Text = LoginAccount.DisplayName;
        }

        void UpdateAccount()
        {
            string displayName = txtdisplayName.Text;
            string password = txtPassword.Text;
            string newpassword = txtNewPassword.Text;
            string reenterpassword = txtReEnterPassword.Text;
            string username = txtUsername.Text;
            if (!newpassword.Equals(reenterpassword))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu đúng với mật khẩu mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (AccountDAO.Instance.UpdateAccount(username, displayName, password, newpassword))
                {
                    MessageBox.Show("Cập nhật thành công.", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đúng mật khẩu!", "Thông báo");
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAccount();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
