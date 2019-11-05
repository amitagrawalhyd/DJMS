using DJMS.Common;
using DJMS.DAL.Bills;
using DJMS.Models;
using DJMS.Repository.Bill;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DJMS
{
    public partial class NewBill : Form
    {
        private IBillService _billService;
        private BillMaster _selectedBillDetail;

        public NewBill()
        {
            InitializeComponent();
            _billService = new BillService();

            LoadAddresses();
            LoadCustomers();
            LoadBills();

            txtBill.Focus();
        }

        private void LoadAddresses()
        {
            var addresses = _billService.GetAddresses(null);

            AutoCompleteStringCollection _addresses = new AutoCompleteStringCollection();

            addresses.ToList().ForEach(a => _addresses.Add(a.Address));

            txtCustomerAddress.AutoCompleteCustomSource = _addresses;
        }

        private void LoadCustomers()
        {
            var customers = _billService.GetCustomers(null);

            AutoCompleteStringCollection _customers = new AutoCompleteStringCollection();

            customers.ToList().ForEach(a => _customers.Add(a.CustomerName));

            txtCustomer.AutoCompleteCustomSource = _customers;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBill.Text = string.Empty;
            txtCustomer.Text = string.Empty;
            txtCustomerAddress.Text = string.Empty;
            txtWeight.Text = string.Empty;
            txtItemNames.Text = string.Empty;
            dtBillDate.Value = DateTime.Now;

            LoadBills();

            txtBill.Focus();
        }

        private void txtBill_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch))
            {
                e.Handled = true;
            }

            if (e.KeyChar == 13)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == 13)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void LoadBills()
        {
            var billDatas = _billService.GetBills(null, null, null);

            if (billDatas != null && billDatas.Count() > 0)
            {
                var source = billDatas.Select(b => new {
                    BillId = b.BillId,
                    CustomerName = b.CustomerName,
                    Address = b.Address,
                    ItemName = b.ItemName,
                    BillDate = b.BillDate,
                    Weight = b.Weight,
                    Status = b.IsActive
                }).OrderByDescending(b => b.BillDate).ThenBy(b => b.BillId).ToList();
                dgvBills.DataSource = source;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _selectedBillDetail = new BillMaster();
            _selectedBillDetail.BillId = Convert.ToInt64(txtBill.Text);
            _selectedBillDetail.CustomerName = txtCustomer.Text;
            _selectedBillDetail.Address = txtCustomerAddress.Text;
            _selectedBillDetail.Weight = Convert.ToDecimal(txtWeight.Text);
            _selectedBillDetail.ItemName = txtItemNames.Text;
            _selectedBillDetail.BillDate = dtBillDate.Value;
            _selectedBillDetail.IsActive = true;

            var result = _billService.SaveBill(_selectedBillDetail);

            if (result.OperationStatus == DatabaseOperations.SavedSuccessfully)
            {
                MessageBox.Show("The bill created successfully!");

                lblBill.Text = string.Empty;
                txtCustomer.Text = string.Empty;
                txtCustomerAddress.Text = string.Empty;
                txtItemNames.Text = string.Empty;
                txtWeight.Text = string.Empty;
                dtBillDate.Value = DateTime.Now;
                txtCustomer.Focus();

                btnClear_Click(sender, e);
            }
            else
                MessageBox.Show("The bill creation failed!");
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
