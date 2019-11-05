namespace DJMS
{
    partial class NewBill
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewBill));
            this.pnlNewBill = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtBill = new System.Windows.Forms.TextBox();
            this.lblBill = new System.Windows.Forms.Label();
            this.dtBillDate = new System.Windows.Forms.DateTimePicker();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.lblBillDate = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.lblAddres = new System.Windows.Forms.Label();
            this.lblWeight = new System.Windows.Forms.Label();
            this.txtCustomerAddress = new System.Windows.Forms.TextBox();
            this.txtItemNames = new System.Windows.Forms.TextBox();
            this.lblItems = new System.Windows.Forms.Label();
            this.dgvBills = new System.Windows.Forms.DataGridView();
            this.pnlNewBill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlNewBill
            // 
            this.pnlNewBill.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlNewBill.Controls.Add(this.btnClear);
            this.pnlNewBill.Controls.Add(this.btnAdd);
            this.pnlNewBill.Controls.Add(this.txtBill);
            this.pnlNewBill.Controls.Add(this.lblBill);
            this.pnlNewBill.Controls.Add(this.dtBillDate);
            this.pnlNewBill.Controls.Add(this.txtCustomer);
            this.pnlNewBill.Controls.Add(this.lblBillDate);
            this.pnlNewBill.Controls.Add(this.lblCustomerName);
            this.pnlNewBill.Controls.Add(this.txtWeight);
            this.pnlNewBill.Controls.Add(this.lblAddres);
            this.pnlNewBill.Controls.Add(this.lblWeight);
            this.pnlNewBill.Controls.Add(this.txtCustomerAddress);
            this.pnlNewBill.Controls.Add(this.txtItemNames);
            this.pnlNewBill.Controls.Add(this.lblItems);
            this.pnlNewBill.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNewBill.Location = new System.Drawing.Point(0, 0);
            this.pnlNewBill.Name = "pnlNewBill";
            this.pnlNewBill.Size = new System.Drawing.Size(1068, 222);
            this.pnlNewBill.TabIndex = 0;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(209, 181);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(137, 29);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(8, 181);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(137, 29);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnAdd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // txtBill
            // 
            this.txtBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBill.Location = new System.Drawing.Point(124, 9);
            this.txtBill.Name = "txtBill";
            this.txtBill.Size = new System.Drawing.Size(200, 26);
            this.txtBill.TabIndex = 0;
            this.txtBill.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBill_KeyPress);
            // 
            // lblBill
            // 
            this.lblBill.AutoSize = true;
            this.lblBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBill.ForeColor = System.Drawing.Color.Navy;
            this.lblBill.Location = new System.Drawing.Point(2, 13);
            this.lblBill.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBill.Name = "lblBill";
            this.lblBill.Size = new System.Drawing.Size(49, 17);
            this.lblBill.TabIndex = 36;
            this.lblBill.Text = "Bill Id :";
            // 
            // dtBillDate
            // 
            this.dtBillDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtBillDate.Location = new System.Drawing.Point(124, 102);
            this.dtBillDate.Name = "dtBillDate";
            this.dtBillDate.Size = new System.Drawing.Size(200, 26);
            this.dtBillDate.TabIndex = 5;
            this.dtBillDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // txtCustomer
            // 
            this.txtCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCustomer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomer.Location = new System.Drawing.Point(124, 40);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(363, 26);
            this.txtCustomer.TabIndex = 1;
            this.txtCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // lblBillDate
            // 
            this.lblBillDate.AutoSize = true;
            this.lblBillDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillDate.ForeColor = System.Drawing.Color.Navy;
            this.lblBillDate.Location = new System.Drawing.Point(5, 109);
            this.lblBillDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBillDate.Name = "lblBillDate";
            this.lblBillDate.Size = new System.Drawing.Size(72, 17);
            this.lblBillDate.TabIndex = 34;
            this.lblBillDate.Text = "Bill Date : ";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.ForeColor = System.Drawing.Color.Navy;
            this.lblCustomerName.Location = new System.Drawing.Point(2, 44);
            this.lblCustomerName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(117, 17);
            this.lblCustomerName.TabIndex = 26;
            this.lblCustomerName.Text = "Customer Name :";
            // 
            // txtWeight
            // 
            this.txtWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWeight.Location = new System.Drawing.Point(671, 71);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(363, 26);
            this.txtWeight.TabIndex = 4;
            this.txtWeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWeight_KeyPress);
            // 
            // lblAddres
            // 
            this.lblAddres.AutoSize = true;
            this.lblAddres.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddres.ForeColor = System.Drawing.Color.Navy;
            this.lblAddres.Location = new System.Drawing.Point(534, 44);
            this.lblAddres.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAddres.Name = "lblAddres";
            this.lblAddres.Size = new System.Drawing.Size(132, 17);
            this.lblAddres.TabIndex = 28;
            this.lblAddres.Text = "Customer Address :";
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeight.ForeColor = System.Drawing.Color.Navy;
            this.lblWeight.Location = new System.Drawing.Point(534, 75);
            this.lblWeight.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(56, 17);
            this.lblWeight.TabIndex = 32;
            this.lblWeight.Text = "Weight:";
            // 
            // txtCustomerAddress
            // 
            this.txtCustomerAddress.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtCustomerAddress.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCustomerAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCustomerAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerAddress.Location = new System.Drawing.Point(671, 40);
            this.txtCustomerAddress.Name = "txtCustomerAddress";
            this.txtCustomerAddress.Size = new System.Drawing.Size(363, 26);
            this.txtCustomerAddress.TabIndex = 2;
            this.txtCustomerAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // txtItemNames
            // 
            this.txtItemNames.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtItemNames.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemNames.Location = new System.Drawing.Point(124, 71);
            this.txtItemNames.Name = "txtItemNames";
            this.txtItemNames.Size = new System.Drawing.Size(363, 26);
            this.txtItemNames.TabIndex = 3;
            this.txtItemNames.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // lblItems
            // 
            this.lblItems.AutoSize = true;
            this.lblItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItems.ForeColor = System.Drawing.Color.Navy;
            this.lblItems.Location = new System.Drawing.Point(2, 75);
            this.lblItems.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(49, 17);
            this.lblItems.TabIndex = 30;
            this.lblItems.Text = "Items :";
            // 
            // dgvBills
            // 
            this.dgvBills.AllowUserToAddRows = false;
            this.dgvBills.AllowUserToDeleteRows = false;
            this.dgvBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBills.Location = new System.Drawing.Point(0, 222);
            this.dgvBills.Name = "dgvBills";
            this.dgvBills.ReadOnly = true;
            this.dgvBills.Size = new System.Drawing.Size(1068, 372);
            this.dgvBills.TabIndex = 1;
            // 
            // NewBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 594);
            this.Controls.Add(this.dgvBills);
            this.Controls.Add(this.pnlNewBill);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewBill";
            this.Text = "New Bill";
            this.pnlNewBill.ResumeLayout(false);
            this.pnlNewBill.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlNewBill;
        private System.Windows.Forms.DataGridView dgvBills;
        private System.Windows.Forms.TextBox txtBill;
        private System.Windows.Forms.Label lblBill;
        private System.Windows.Forms.DateTimePicker dtBillDate;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label lblBillDate;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Label lblAddres;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.TextBox txtCustomerAddress;
        private System.Windows.Forms.TextBox txtItemNames;
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAdd;
    }
}