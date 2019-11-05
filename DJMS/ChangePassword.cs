using DJMS.Models;
using DJMS.Repository.Security;
using System;
using System.Linq;
using System.Windows.Forms;
using DJMS.Common;
using DJMS.DAL.Security;

namespace DJMS
{
    public partial class ChangePassword : Form
    {
        private ISecurityService _securityService;

        public ChangePassword()
        {
            InitializeComponent();
            _securityService = new SecurityService();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            var users = _securityService.GetUsers();

            var user = users.Where(u => u.UserName == txtUserName.Text && u.Password == txtPassword.Text).FirstOrDefault();

            if (user != default(SecurityUser))
            {
                if (txtNewPassword.Text == txtConfirmPassword.Text)
                {
                    var userData = new SecurityUser() { ID = user.ID, UserName = txtUserName.Text, Password = txtNewPassword.Text, TypeId = 3 };

                    var result = _securityService.SaveUser(userData);

                    if(result.OperationStatus == DatabaseOperations.SavedSuccessfully)
                        MessageBox.Show("The password changed successfully!");
                    else
                        MessageBox.Show("The password change failed!");

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("The password must match!");
                    txtNewPassword.Text = string.Empty;
                    txtConfirmPassword.Text = string.Empty;
                    txtNewPassword.Focus();
                }
            }
            else
            {
                MessageBox.Show("Supplied user details is incorrect!");
                txtUserName.Text = string.Empty;
                txtPassword.Text = string.Empty;
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
