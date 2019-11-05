using System;
using System.Configuration;
using System.Windows.Forms;
using DJMS.Common;

namespace DJMS
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();

            if (Common.ApplicationContext.Instance == null)
                Common.ApplicationContext.Instance = new ApplicationData();

            if (SessionContext.Instance == null)
                SessionContext.Instance = new SessionData();

            Common.ApplicationContext.Instance.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }

        private void tmrSplash_Tick(object sender, EventArgs e)
        {
            this.Hide();
            var _loginForm = new LoginScreen();
            _loginForm.Show();
            tmrSplash.Enabled = false;
        }
    }
}
