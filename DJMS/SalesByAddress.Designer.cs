namespace DJMS
{
    partial class SalesByAddress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesByAddress));
            this.pnlDateRange = new System.Windows.Forms.Panel();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.dtBillStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblBillStartDate = new System.Windows.Forms.Label();
            this.dtBillEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblTotalSalesInTheMentionedPeriod = new System.Windows.Forms.Label();
            this.btnReport = new System.Windows.Forms.Button();
            this.pnlDateRange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDateRange
            // 
            this.pnlDateRange.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDateRange.Controls.Add(this.btnReport);
            this.pnlDateRange.Controls.Add(this.lblTotalSalesInTheMentionedPeriod);
            this.pnlDateRange.Controls.Add(this.dtBillEndDate);
            this.pnlDateRange.Controls.Add(this.lblEndDate);
            this.pnlDateRange.Controls.Add(this.dtBillStartDate);
            this.pnlDateRange.Controls.Add(this.lblBillStartDate);
            this.pnlDateRange.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDateRange.Location = new System.Drawing.Point(0, 0);
            this.pnlDateRange.Name = "pnlDateRange";
            this.pnlDateRange.Size = new System.Drawing.Size(1254, 112);
            this.pnlDateRange.TabIndex = 0;
            // 
            // dgvReport
            // 
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReport.Location = new System.Drawing.Point(0, 112);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            this.dgvReport.RowTemplate.Height = 24;
            this.dgvReport.Size = new System.Drawing.Size(1254, 508);
            this.dgvReport.TabIndex = 1;
            // 
            // dtBillStartDate
            // 
            this.dtBillStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtBillStartDate.Location = new System.Drawing.Point(110, 7);
            this.dtBillStartDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtBillStartDate.Name = "dtBillStartDate";
            this.dtBillStartDate.Size = new System.Drawing.Size(265, 30);
            this.dtBillStartDate.TabIndex = 27;
            // 
            // lblBillStartDate
            // 
            this.lblBillStartDate.AutoSize = true;
            this.lblBillStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillStartDate.ForeColor = System.Drawing.Color.Navy;
            this.lblBillStartDate.Location = new System.Drawing.Point(8, 11);
            this.lblBillStartDate.Name = "lblBillStartDate";
            this.lblBillStartDate.Size = new System.Drawing.Size(101, 20);
            this.lblBillStartDate.TabIndex = 26;
            this.lblBillStartDate.Text = "Start Date : ";
            // 
            // dtBillEndDate
            // 
            this.dtBillEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtBillEndDate.Location = new System.Drawing.Point(523, 7);
            this.dtBillEndDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtBillEndDate.Name = "dtBillEndDate";
            this.dtBillEndDate.Size = new System.Drawing.Size(265, 30);
            this.dtBillEndDate.TabIndex = 29;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndDate.ForeColor = System.Drawing.Color.Navy;
            this.lblEndDate.Location = new System.Drawing.Point(421, 11);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(94, 20);
            this.lblEndDate.TabIndex = 28;
            this.lblEndDate.Text = "End Date : ";
            // 
            // lblTotalSalesInTheMentionedPeriod
            // 
            this.lblTotalSalesInTheMentionedPeriod.AutoSize = true;
            this.lblTotalSalesInTheMentionedPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSalesInTheMentionedPeriod.ForeColor = System.Drawing.Color.Navy;
            this.lblTotalSalesInTheMentionedPeriod.Location = new System.Drawing.Point(8, 64);
            this.lblTotalSalesInTheMentionedPeriod.Name = "lblTotalSalesInTheMentionedPeriod";
            this.lblTotalSalesInTheMentionedPeriod.Size = new System.Drawing.Size(0, 20);
            this.lblTotalSalesInTheMentionedPeriod.TabIndex = 30;
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(850, 7);
            this.btnReport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(132, 30);
            this.btnReport.TabIndex = 31;
            this.btnReport.Text = "Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // SalesByAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 620);
            this.Controls.Add(this.dgvReport);
            this.Controls.Add(this.pnlDateRange);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SalesByAddress";
            this.Text = "Sales By Address";
            this.pnlDateRange.ResumeLayout(false);
            this.pnlDateRange.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDateRange;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.Label lblTotalSalesInTheMentionedPeriod;
        private System.Windows.Forms.DateTimePicker dtBillEndDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtBillStartDate;
        private System.Windows.Forms.Label lblBillStartDate;
        private System.Windows.Forms.Button btnReport;
    }
}