using DJMS.DAL.Bills;
using DJMS.Repository.Bill;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DJMS
{
    public partial class SearchBill : Form
    {
        private IBillService _billService;

        public SearchBill()
        {
            InitializeComponent();
            _billService = new BillService();

            LoadAddresses();
            LoadCustomers();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string customerName = txtCustomerName.Text.Trim().Length > 0 ? txtCustomerName.Text : null;
            string address = txtAddress.Text.Trim().Length > 0 ? txtAddress.Text : null;
            string itemName = txtItems.Text.Trim().Length > 0 ? txtItems.Text : null;

            var users = _billService.GetBills(customerName, address, itemName);       

            if (users != null && users.Count() > 0)
            {
                dgvDetails.DataSource = users.Select(b => new {
                                                                BillId = b.BillId,
                                                                CustomerName = b.CustomerName,
                                                                Address = b.Address,
                                                                ItemName = b.ItemName,
                                                                BillDate = b.BillDate,
                                                                Status = b.IsActive ? "With Customer" : "Sold to Us"}).ToList();
            }
            else
            {
                MessageBox.Show("No records found with supplied details, check if supplied details are correct!");
                txtCustomerName.Text = string.Empty;
                txtAddress.Text = string.Empty;
                txtItems.Text = string.Empty;
                txtCustomerName.Focus();
            }
        }

        private void LoadAddresses()
        {
            var addresses = _billService.GetAddresses(null);

            AutoCompleteStringCollection _addresses = new AutoCompleteStringCollection();

            addresses.ToList().ForEach(a => _addresses.Add(a.Address));

            txtAddress.AutoCompleteCustomSource = _addresses;
        }

        private void LoadCustomers()
        {
            var customers = _billService.GetCustomers(null);

            AutoCompleteStringCollection _customers = new AutoCompleteStringCollection();

            customers.ToList().ForEach(a => _customers.Add(a.CustomerName));

            txtCustomerName.AutoCompleteCustomSource = _customers;
        }

        private void Control_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }
    }
}
