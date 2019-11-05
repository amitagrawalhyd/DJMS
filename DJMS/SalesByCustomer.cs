using DJMS.DAL.Reports;
using DJMS.Repository.Report;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DJMS
{
    public partial class SalesByCustomer : Form
    {
        private IDJMSReport _reportService;

        public SalesByCustomer()
        {
            InitializeComponent();
            _reportService = new DJMSReport();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (dtBillEndDate.Value < dtBillStartDate.Value)
            {
                MessageBox.Show("End date must not be smaller than Start date!");
            }
            else
            {
                var reportData = _reportService.GetSalesByCustomer(dtBillStartDate.Value, dtBillEndDate.Value).OrderByDescending(a => a.SaleDetails).ToList();

                var salesWeight = reportData.Sum(rd => rd.SaleDetails);

                dgvReport.DataSource = reportData;
                lblTotalSalesInTheMentionedPeriod.Text = "Total Sales in this period is : " + salesWeight.ToString();
            }
        }
    }
}
