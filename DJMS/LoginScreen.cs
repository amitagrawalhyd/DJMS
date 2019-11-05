using DJMS.Common;
using DJMS.DAL.Security;
using DJMS.Models;
using DJMS.Repository.Security;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace DJMS
{
    public partial class LoginScreen : Form
    {
        private ISecurityService _securityService;

        public LoginScreen()
        {
            InitializeComponent();
            _securityService = new SecurityService();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var users = _securityService.GetUsers();

            var user = users.Where(u => u.UserName == txtUserName.Text && u.Password == txtPassword.Text).FirstOrDefault();

            for (int i = 0; i <= 100; i++)
            {
                loginProgress.Value = i;
                Thread.Sleep(10);
            }

            if (user != default(SecurityUser))
            {
                SessionContext.Instance.UserTypeId = user.TypeId;
                this.Hide();
                var _startScreen = new StartScreen();
                _startScreen.Show();
            }
            else
            {
                MessageBox.Show("Supplied user details is incorrect!");
                txtUserName.Text = string.Empty;
                txtPassword.Text = string.Empty;
                loginProgress.Value = 0;
                txtUserName.Focus();
            }
                
        }

        private void Control_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{tab}");
            }
        }
    }
}
