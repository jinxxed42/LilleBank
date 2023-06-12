namespace LilleBank
{
    partial class UpdateForm
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
            this.LblUpdateCustomer = new System.Windows.Forms.Label();
            this.LblUpdateCustomerName = new System.Windows.Forms.Label();
            this.LblUpdateCustomerCPR = new System.Windows.Forms.Label();
            this.LblUpdateCustomerAddress = new System.Windows.Forms.Label();
            this.LblUpdateCustomerCity = new System.Windows.Forms.Label();
            this.TbUpdateCustomerName = new System.Windows.Forms.TextBox();
            this.TbUpdateCustomerCPR = new System.Windows.Forms.TextBox();
            this.TbUpdateCustomerAddress = new System.Windows.Forms.TextBox();
            this.TbUpdateCustomerCity = new System.Windows.Forms.TextBox();
            this.BtnUpdateCustomer = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblUpdateCustomer
            // 
            this.LblUpdateCustomer.AutoSize = true;
            this.LblUpdateCustomer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblUpdateCustomer.Location = new System.Drawing.Point(73, 9);
            this.LblUpdateCustomer.Name = "LblUpdateCustomer";
            this.LblUpdateCustomer.Size = new System.Drawing.Size(129, 21);
            this.LblUpdateCustomer.TabIndex = 0;
            this.LblUpdateCustomer.Text = "Update customer";
            // 
            // LblUpdateCustomerName
            // 
            this.LblUpdateCustomerName.AutoSize = true;
            this.LblUpdateCustomerName.Location = new System.Drawing.Point(25, 50);
            this.LblUpdateCustomerName.Name = "LblUpdateCustomerName";
            this.LblUpdateCustomerName.Size = new System.Drawing.Size(39, 15);
            this.LblUpdateCustomerName.TabIndex = 1;
            this.LblUpdateCustomerName.Text = "Name";
            // 
            // LblUpdateCustomerCPR
            // 
            this.LblUpdateCustomerCPR.AutoSize = true;
            this.LblUpdateCustomerCPR.Location = new System.Drawing.Point(25, 75);
            this.LblUpdateCustomerCPR.Name = "LblUpdateCustomerCPR";
            this.LblUpdateCustomerCPR.Size = new System.Drawing.Size(29, 15);
            this.LblUpdateCustomerCPR.TabIndex = 2;
            this.LblUpdateCustomerCPR.Text = "CPR";
            // 
            // LblUpdateCustomerAddress
            // 
            this.LblUpdateCustomerAddress.AutoSize = true;
            this.LblUpdateCustomerAddress.Location = new System.Drawing.Point(25, 100);
            this.LblUpdateCustomerAddress.Name = "LblUpdateCustomerAddress";
            this.LblUpdateCustomerAddress.Size = new System.Drawing.Size(49, 15);
            this.LblUpdateCustomerAddress.TabIndex = 3;
            this.LblUpdateCustomerAddress.Text = "Address";
            // 
            // LblUpdateCustomerCity
            // 
            this.LblUpdateCustomerCity.AutoSize = true;
            this.LblUpdateCustomerCity.Location = new System.Drawing.Point(25, 125);
            this.LblUpdateCustomerCity.Name = "LblUpdateCustomerCity";
            this.LblUpdateCustomerCity.Size = new System.Drawing.Size(28, 15);
            this.LblUpdateCustomerCity.TabIndex = 4;
            this.LblUpdateCustomerCity.Text = "City";
            // 
            // TbUpdateCustomerName
            // 
            this.TbUpdateCustomerName.Location = new System.Drawing.Point(86, 42);
            this.TbUpdateCustomerName.Name = "TbUpdateCustomerName";
            this.TbUpdateCustomerName.Size = new System.Drawing.Size(100, 23);
            this.TbUpdateCustomerName.TabIndex = 5;
            // 
            // TbUpdateCustomerCPR
            // 
            this.TbUpdateCustomerCPR.Location = new System.Drawing.Point(86, 67);
            this.TbUpdateCustomerCPR.Name = "TbUpdateCustomerCPR";
            this.TbUpdateCustomerCPR.Size = new System.Drawing.Size(100, 23);
            this.TbUpdateCustomerCPR.TabIndex = 6;
            // 
            // TbUpdateCustomerAddress
            // 
            this.TbUpdateCustomerAddress.Location = new System.Drawing.Point(86, 92);
            this.TbUpdateCustomerAddress.Name = "TbUpdateCustomerAddress";
            this.TbUpdateCustomerAddress.Size = new System.Drawing.Size(100, 23);
            this.TbUpdateCustomerAddress.TabIndex = 7;
            // 
            // TbUpdateCustomerCity
            // 
            this.TbUpdateCustomerCity.Location = new System.Drawing.Point(86, 117);
            this.TbUpdateCustomerCity.Name = "TbUpdateCustomerCity";
            this.TbUpdateCustomerCity.Size = new System.Drawing.Size(100, 23);
            this.TbUpdateCustomerCity.TabIndex = 8;
            // 
            // BtnUpdateCustomer
            // 
            this.BtnUpdateCustomer.Location = new System.Drawing.Point(59, 146);
            this.BtnUpdateCustomer.Name = "BtnUpdateCustomer";
            this.BtnUpdateCustomer.Size = new System.Drawing.Size(75, 23);
            this.BtnUpdateCustomer.TabIndex = 9;
            this.BtnUpdateCustomer.Text = "Update";
            this.BtnUpdateCustomer.UseVisualStyleBackColor = true;
            this.BtnUpdateCustomer.Click += new System.EventHandler(this.BtnUpdateCustomer_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(140, 146);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 10;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 246);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnUpdateCustomer);
            this.Controls.Add(this.TbUpdateCustomerCity);
            this.Controls.Add(this.TbUpdateCustomerAddress);
            this.Controls.Add(this.TbUpdateCustomerCPR);
            this.Controls.Add(this.TbUpdateCustomerName);
            this.Controls.Add(this.LblUpdateCustomerCity);
            this.Controls.Add(this.LblUpdateCustomerAddress);
            this.Controls.Add(this.LblUpdateCustomerCPR);
            this.Controls.Add(this.LblUpdateCustomerName);
            this.Controls.Add(this.LblUpdateCustomer);
            this.Name = "UpdateForm";
            this.Text = "UpdateForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label LblUpdateCustomer;
        private Label LblUpdateCustomerName;
        private Label LblUpdateCustomerCPR;
        private Label LblUpdateCustomerAddress;
        private Label LblUpdateCustomerCity;
        private TextBox TbUpdateCustomerName;
        private TextBox TbUpdateCustomerCPR;
        private TextBox TbUpdateCustomerAddress;
        private TextBox TbUpdateCustomerCity;
        private Button BtnUpdateCustomer;
        private Button BtnCancel;
    }
}