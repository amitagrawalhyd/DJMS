using DJMS.Common;
using DJMS.DAL.Bills;
using DJMS.Models;
using DJMS.Repository.Bill;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DJMS
{
    public partial class UpdateBill : Form
    {
        private IBillService _billService;
        private BillMaster _selectedBillDetail;

        public UpdateBill()
        {
            InitializeComponent();
            _billService = new BillService();

            LoadAddresses();
            LoadCustomers();
        }

        private void LoadAddresses()
        {
            var addresses = _billService.GetAddresses(null);

            AutoCompleteStringCollection _addresses = new AutoCompleteStringCollection();

            addresses.ToList().ForEach(a => _addresses.Add(a.Address));

            txtAddress.AutoCompleteCustomSource = _addresses;
            txtCustomerAddress.AutoCompleteCustomSource = _addresses;
        }

        private void LoadCustomers()
        {
            var customers = _billService.GetCustomers(null);

            AutoCompleteStringCollection _customers = new AutoCompleteStringCollection();

            customers.ToList().ForEach(a => _customers.Add(a.CustomerName));

            txtCustomerName.AutoCompleteCustomSource = _customers;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string customerName = txtCustomerName.Text.Trim().Length > 0 ? txtCustomerName.Text : null;
            string address = txtAddress.Text.Trim().Length > 0 ? txtAddress.Text : null;
            string itemName = txtItems.Text.Trim().Length > 0 ? txtItems.Text : null;

            var billDatas = _billService.GetBills(customerName, address, itemName);

            if (billDatas != null && billDatas.Count() > 0)
            {
                dgvBills.DataSource = billDatas.Select(b => new {
                    Id = b.ID,
                    CustomerId = b.CustomerId,
                    BillId = b.BillId,
                    CustomerName = b.CustomerName,
                    Address = b.Address,
                    ItemName = b.ItemName,
                    BillDate = b.BillDate,
                    Weight = b.Weight,
                    Status = b.IsActive ? "With Customer" : "Sold to Us"
                }).ToList();

                dgvBills.Columns["Id"].Visible = false;
                dgvBills.Columns["CustomerId"].Visible = false;
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

        private void dgvBills_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBills.SelectedRows.Count > 0)
            {
                _selectedBillDetail = new BillMaster();

                var definition = new { Id = 0, CustomerId = 0,  BillId = 0, CustomerName="", Address="", ItemName="", BillDate=DateTime.Now, Weight=0.000m, Status ="" };
                var row = dgvBills.SelectedRows[0];

                var result = JsonConvert.DeserializeAnonymousType(JsonConvert.SerializeObject(row.DataBoundItem), definition);

                _selectedBillDetail.ID = result.Id;
                _selectedBillDetail.CustomerId = result.CustomerId;
                _selectedBillDetail.BillId = result.BillId;
                _selectedBillDetail.CustomerName = result.CustomerName;
                _selectedBillDetail.Address = result.Address;
                _selectedBillDetail.ItemName = result.ItemName;
                _selectedBillDetail.BillDate = result.BillDate;
                _selectedBillDetail.Weight = result.Weight;
                _selectedBillDetail.IsActive = true;

                lblBill.Text = _selectedBillDetail.BillId.ToString();
                txtCustomer.Text = _selectedBillDetail.CustomerName;
                txtCustomerAddress.Text = _selectedBillDetail.Address;
                txtItemNames.Text = _selectedBillDetail.ItemName;
                txtWeight.Text = _selectedBillDetail.Weight.ToString();
                dtBillDate.Value = _selectedBillDetail.BillDate;

                txtCustomerAddress.Focus();
            }
        }

        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if(!Char.IsDigit(ch) && ch != 8 && ch != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == 13)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblBill.Text = string.Empty;
            txtCustomer.Text = string.Empty;
            txtCustomerAddress.Text = string.Empty;
            txtItemNames.Text = string.Empty;
            txtWeight.Text = string.Empty;
            dtBillDate.Value = DateTime.Now;
            txtCustomer.Focus();
        }

        private void btnClearCriteria_Click(object sender, EventArgs e)
        {
            txtCustomerName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtItems.Text = string.Empty;
            dgvBills.DataSource = null;
            txtCustomerName.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _selectedBillDetail.Weight = Convert.ToDecimal(txtWeight.Text);
            _selectedBillDetail.ItemName = txtItemNames.Text;
            _selectedBillDetail.Address = txtCustomerAddress.Text;


            var result = _billService.SaveBill(_selectedBillDetail);

            if (result.OperationStatus == DatabaseOperations.SavedSuccessfully)
            {
                MessageBox.Show("The bill updated successfully!");

                lblBill.Text = string.Empty;
                txtCustomer.Text = string.Empty;
                txtCustomerAddress.Text = string.Empty;
                txtItemNames.Text = string.Empty;
                txtWeight.Text = string.Empty;
                dtBillDate.Value = DateTime.Now;
                txtCustomer.Focus();

                LoadCustomers();
                LoadAddresses();
                dgvBills.DataSource = null;

                btnSearch_Click(sender, e);
            }                
            else
                MessageBox.Show("The bill update failed!");
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
