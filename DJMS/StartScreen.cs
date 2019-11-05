using DJMS.Common;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DJMS
{
    public partial class StartScreen : Form
    {
        public StartScreen()
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
        }

        private void StartScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var _aboutScreen = new AboutDJMS();
            _aboutScreen.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(SessionContext.Instance.UserTypeId == 3)
            {
                var _changePassword = new ChangePassword();
                _changePassword.MdiParent = this;
                _changePassword.WindowState = FormWindowState.Normal;
                _changePassword.Show();
                _changePassword.WindowState = FormWindowState.Maximized;
                _changePassword.Show();
            }
            else
            {
                MessageBox.Show("The user is a super user, you can't change password!");
            }
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var _searchBill = new SearchBill();
            _searchBill.MdiParent = this;
            _searchBill.WindowState = FormWindowState.Normal;
            _searchBill.Show();
            _searchBill.WindowState = FormWindowState.Maximized;
            _searchBill.Show();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Under Development", "DADI SOFTWARE");
        }

        private void updateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Under Development", "DADI SOFTWARE");
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Under Development", "DADI SOFTWARE");
        }

        private void searchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Under Development", "DADI SOFTWARE");
        }

        private void newBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var _newBill = new NewBill();
            _newBill.MdiParent = this;
            _newBill.WindowState = FormWindowState.Normal;
            _newBill.Show();
            _newBill.WindowState = FormWindowState.Maximized;
            _newBill.Show();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var _updateBill = new UpdateBill();
            _updateBill.MdiParent = this;
            _updateBill.WindowState = FormWindowState.Normal;
            _updateBill.Show();
            _updateBill.WindowState = FormWindowState.Maximized;
            _updateBill.Show();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var _deleteBill = new DeleteBill();
            _deleteBill.MdiParent = this;
            _deleteBill.WindowState = FormWindowState.Normal;
            _deleteBill.Show();
            _deleteBill.WindowState = FormWindowState.Maximized;
            _deleteBill.Show();
        }

        private void reportByAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var _reportBill = new SalesByAddress();
            _reportBill.MdiParent = this;
            _reportBill.WindowState = FormWindowState.Normal;
            _reportBill.Show();
            _reportBill.WindowState = FormWindowState.Maximized;
            _reportBill.Show();
        }

        private void reportByCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var _reportBill = new SalesByCustomer();
            _reportBill.MdiParent = this;
            _reportBill.WindowState = FormWindowState.Normal;
            _reportBill.Show();
            _reportBill.WindowState = FormWindowState.Maximized;
            _reportBill.Show();
        }
    }
}
