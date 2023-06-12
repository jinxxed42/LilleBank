namespace LilleBank
{
    partial class BankForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnCreateCustomer = new System.Windows.Forms.Button();
            this.LblCreateCustomer = new System.Windows.Forms.Label();
            this.TbCreateCustomerName = new System.Windows.Forms.TextBox();
            this.TbCreateCustomerCPR = new System.Windows.Forms.TextBox();
            this.TbCreateCustomerAddress = new System.Windows.Forms.TextBox();
            this.LblCreateCustomerName = new System.Windows.Forms.Label();
            this.LblCreateCustomerCPR = new System.Windows.Forms.Label();
            this.LblCreateCustomerAddress = new System.Windows.Forms.Label();
            this.TbCreateCustomerCity = new System.Windows.Forms.TextBox();
            this.LblCreateCustomerCity = new System.Windows.Forms.Label();
            this.DgvCustomer = new System.Windows.Forms.DataGridView();
            this.BtnShowCustomers = new System.Windows.Forms.Button();
            this.CbCreateAccountType = new System.Windows.Forms.ComboBox();
            this.LblCreateAccount = new System.Windows.Forms.Label();
            this.TbCreateAccountCPR = new System.Windows.Forms.TextBox();
            this.LblCreateAccountCPR = new System.Windows.Forms.Label();
            this.BtnCreateAccount = new System.Windows.Forms.Button();
            this.LblCreateAccountType = new System.Windows.Forms.Label();
            this.DgvAccount = new System.Windows.Forms.DataGridView();
            this.BtnShowAccounts = new System.Windows.Forms.Button();
            this.LblDepositWithdraw = new System.Windows.Forms.Label();
            this.TbDepositWithdrawGuid = new System.Windows.Forms.TextBox();
            this.TbDepositWithdrawAmount = new System.Windows.Forms.TextBox();
            this.LblDepositWithdrawGuid = new System.Windows.Forms.Label();
            this.LblDepositWithdrawAmount = new System.Windows.Forms.Label();
            this.BtnDepositWithdraw = new System.Windows.Forms.Button();
            this.TbShowTransactions = new System.Windows.Forms.TextBox();
            this.LblShowTransactions = new System.Windows.Forms.Label();
            this.LblShowTransactionsGuid = new System.Windows.Forms.Label();
            this.BtnShowTransactions = new System.Windows.Forms.Button();
            this.LblDepositWithdrawTS = new System.Windows.Forms.Label();
            this.TbDepositWithdrawGuidTS = new System.Windows.Forms.TextBox();
            this.TbDepositWithdrawAmountTS = new System.Windows.Forms.TextBox();
            this.TbDepositWithdrawTimeTS = new System.Windows.Forms.TextBox();
            this.BtnDepositWithdrawTS = new System.Windows.Forms.Button();
            this.LblDepositWithdrawGuidTS = new System.Windows.Forms.Label();
            this.LblDepositWithdrawAmountTS = new System.Windows.Forms.Label();
            this.LblDepositWithdrawTimeTS = new System.Windows.Forms.Label();
            this.BtnSave = new System.Windows.Forms.Button();
            this.LblFindCustomer = new System.Windows.Forms.Label();
            this.TbFindCustomerName = new System.Windows.Forms.TextBox();
            this.TbFindCustomerCPR = new System.Windows.Forms.TextBox();
            this.LblFindCustomerName = new System.Windows.Forms.Label();
            this.LblFindCustomerCPR = new System.Windows.Forms.Label();
            this.BtnFindCustomer = new System.Windows.Forms.Button();
            this.BtnLoad = new System.Windows.Forms.Button();
            this.LblAddOwner = new System.Windows.Forms.Label();
            this.TbAddOwnerAccountGuid = new System.Windows.Forms.TextBox();
            this.TbAddOwnerCustomerCPR = new System.Windows.Forms.TextBox();
            this.LblAddOwnerAccountGuid = new System.Windows.Forms.Label();
            this.LblAddOwnerCustomerCPR = new System.Windows.Forms.Label();
            this.BtnAddOwner = new System.Windows.Forms.Button();
            this.LblDeleteCustomer = new System.Windows.Forms.Label();
            this.TbDeleteCustomerCPR = new System.Windows.Forms.TextBox();
            this.LblDeleteCustomerCPR = new System.Windows.Forms.Label();
            this.BtnDeleteCustomer = new System.Windows.Forms.Button();
            this.LblDeleteAccount = new System.Windows.Forms.Label();
            this.TbDeleteAccountGuid = new System.Windows.Forms.TextBox();
            this.LblDeleteAccountGuid = new System.Windows.Forms.Label();
            this.BtnDeleteAccount = new System.Windows.Forms.Button();
            this.TbAddInterest = new System.Windows.Forms.TextBox();
            this.LblAddInterest = new System.Windows.Forms.Label();
            this.LblAddInterestGuid = new System.Windows.Forms.Label();
            this.BtnAddInterest = new System.Windows.Forms.Button();
            this.TbRemoveOwnerAccountGuid = new System.Windows.Forms.TextBox();
            this.TbRemoveOwnerCustomerCPR = new System.Windows.Forms.TextBox();
            this.LblRemoveOwnerAccountGuid = new System.Windows.Forms.Label();
            this.LblRemoveOwnerCustomerCPR = new System.Windows.Forms.Label();
            this.LblRemoveOwner = new System.Windows.Forms.Label();
            this.BtnRemoveOwner = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAccount)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnCreateCustomer
            // 
            this.BtnCreateCustomer.Location = new System.Drawing.Point(64, 193);
            this.BtnCreateCustomer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnCreateCustomer.Name = "BtnCreateCustomer";
            this.BtnCreateCustomer.Size = new System.Drawing.Size(86, 31);
            this.BtnCreateCustomer.TabIndex = 0;
            this.BtnCreateCustomer.Text = "Create";
            this.BtnCreateCustomer.UseVisualStyleBackColor = true;
            this.BtnCreateCustomer.Click += new System.EventHandler(this.BtnCreateCustomer_Click);
            // 
            // LblCreateCustomer
            // 
            this.LblCreateCustomer.AutoSize = true;
            this.LblCreateCustomer.Location = new System.Drawing.Point(64, 12);
            this.LblCreateCustomer.Name = "LblCreateCustomer";
            this.LblCreateCustomer.Size = new System.Drawing.Size(117, 20);
            this.LblCreateCustomer.TabIndex = 1;
            this.LblCreateCustomer.Text = "Create customer";
            // 
            // TbCreateCustomerName
            // 
            this.TbCreateCustomerName.Location = new System.Drawing.Point(64, 36);
            this.TbCreateCustomerName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TbCreateCustomerName.Name = "TbCreateCustomerName";
            this.TbCreateCustomerName.Size = new System.Drawing.Size(114, 27);
            this.TbCreateCustomerName.TabIndex = 2;
            // 
            // TbCreateCustomerCPR
            // 
            this.TbCreateCustomerCPR.Location = new System.Drawing.Point(64, 75);
            this.TbCreateCustomerCPR.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TbCreateCustomerCPR.Name = "TbCreateCustomerCPR";
            this.TbCreateCustomerCPR.Size = new System.Drawing.Size(114, 27);
            this.TbCreateCustomerCPR.TabIndex = 3;
            // 
            // TbCreateCustomerAddress
            // 
            this.TbCreateCustomerAddress.Location = new System.Drawing.Point(64, 113);
            this.TbCreateCustomerAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TbCreateCustomerAddress.Name = "TbCreateCustomerAddress";
            this.TbCreateCustomerAddress.Size = new System.Drawing.Size(114, 27);
            this.TbCreateCustomerAddress.TabIndex = 4;
            // 
            // LblCreateCustomerName
            // 
            this.LblCreateCustomerName.AutoSize = true;
            this.LblCreateCustomerName.Location = new System.Drawing.Point(2, 40);
            this.LblCreateCustomerName.Name = "LblCreateCustomerName";
            this.LblCreateCustomerName.Size = new System.Drawing.Size(49, 20);
            this.LblCreateCustomerName.TabIndex = 5;
            this.LblCreateCustomerName.Text = "Name";
            // 
            // LblCreateCustomerCPR
            // 
            this.LblCreateCustomerCPR.AutoSize = true;
            this.LblCreateCustomerCPR.Location = new System.Drawing.Point(2, 79);
            this.LblCreateCustomerCPR.Name = "LblCreateCustomerCPR";
            this.LblCreateCustomerCPR.Size = new System.Drawing.Size(35, 20);
            this.LblCreateCustomerCPR.TabIndex = 6;
            this.LblCreateCustomerCPR.Text = "CPR";
            // 
            // LblCreateCustomerAddress
            // 
            this.LblCreateCustomerAddress.AutoSize = true;
            this.LblCreateCustomerAddress.Location = new System.Drawing.Point(2, 117);
            this.LblCreateCustomerAddress.Name = "LblCreateCustomerAddress";
            this.LblCreateCustomerAddress.Size = new System.Drawing.Size(62, 20);
            this.LblCreateCustomerAddress.TabIndex = 7;
            this.LblCreateCustomerAddress.Text = "Address";
            // 
            // TbCreateCustomerCity
            // 
            this.TbCreateCustomerCity.Location = new System.Drawing.Point(64, 155);
            this.TbCreateCustomerCity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TbCreateCustomerCity.Name = "TbCreateCustomerCity";
            this.TbCreateCustomerCity.Size = new System.Drawing.Size(114, 27);
            this.TbCreateCustomerCity.TabIndex = 8;
            // 
            // LblCreateCustomerCity
            // 
            this.LblCreateCustomerCity.AutoSize = true;
            this.LblCreateCustomerCity.Location = new System.Drawing.Point(3, 159);
            this.LblCreateCustomerCity.Name = "LblCreateCustomerCity";
            this.LblCreateCustomerCity.Size = new System.Drawing.Size(34, 20);
            this.LblCreateCustomerCity.TabIndex = 9;
            this.LblCreateCustomerCity.Text = "City";
            // 
            // DgvCustomer
            // 
            this.DgvCustomer.AllowUserToAddRows = false;
            this.DgvCustomer.AllowUserToDeleteRows = false;
            this.DgvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCustomer.Location = new System.Drawing.Point(719, 12);
            this.DgvCustomer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DgvCustomer.Name = "DgvCustomer";
            this.DgvCustomer.ReadOnly = true;
            this.DgvCustomer.RowHeadersWidth = 51;
            this.DgvCustomer.RowTemplate.Height = 25;
            this.DgvCustomer.Size = new System.Drawing.Size(933, 277);
            this.DgvCustomer.TabIndex = 10;
            this.DgvCustomer.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvCustomer_CellMouseDoubleClick);
            // 
            // BtnShowCustomers
            // 
            this.BtnShowCustomers.Location = new System.Drawing.Point(1097, 297);
            this.BtnShowCustomers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnShowCustomers.Name = "BtnShowCustomers";
            this.BtnShowCustomers.Size = new System.Drawing.Size(122, 31);
            this.BtnShowCustomers.TabIndex = 11;
            this.BtnShowCustomers.Text = "Show customers";
            this.BtnShowCustomers.UseVisualStyleBackColor = true;
            this.BtnShowCustomers.Click += new System.EventHandler(this.BtnShowCustomers_Click);
            // 
            // CbCreateAccountType
            // 
            this.CbCreateAccountType.DisplayMember = "Text";
            this.CbCreateAccountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbCreateAccountType.FormattingEnabled = true;
            this.CbCreateAccountType.Location = new System.Drawing.Point(257, 79);
            this.CbCreateAccountType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CbCreateAccountType.Name = "CbCreateAccountType";
            this.CbCreateAccountType.Size = new System.Drawing.Size(138, 28);
            this.CbCreateAccountType.TabIndex = 12;
            this.CbCreateAccountType.ValueMember = "Value";
            // 
            // LblCreateAccount
            // 
            this.LblCreateAccount.AutoSize = true;
            this.LblCreateAccount.Location = new System.Drawing.Point(257, 12);
            this.LblCreateAccount.Name = "LblCreateAccount";
            this.LblCreateAccount.Size = new System.Drawing.Size(108, 20);
            this.LblCreateAccount.TabIndex = 13;
            this.LblCreateAccount.Text = "Create account";
            // 
            // TbCreateAccountCPR
            // 
            this.TbCreateAccountCPR.Location = new System.Drawing.Point(257, 36);
            this.TbCreateAccountCPR.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TbCreateAccountCPR.Name = "TbCreateAccountCPR";
            this.TbCreateAccountCPR.Size = new System.Drawing.Size(138, 27);
            this.TbCreateAccountCPR.TabIndex = 14;
            // 
            // LblCreateAccountCPR
            // 
            this.LblCreateAccountCPR.AutoSize = true;
            this.LblCreateAccountCPR.Location = new System.Drawing.Point(207, 40);
            this.LblCreateAccountCPR.Name = "LblCreateAccountCPR";
            this.LblCreateAccountCPR.Size = new System.Drawing.Size(35, 20);
            this.LblCreateAccountCPR.TabIndex = 15;
            this.LblCreateAccountCPR.Text = "CPR";
            // 
            // BtnCreateAccount
            // 
            this.BtnCreateAccount.Location = new System.Drawing.Point(257, 117);
            this.BtnCreateAccount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnCreateAccount.Name = "BtnCreateAccount";
            this.BtnCreateAccount.Size = new System.Drawing.Size(86, 31);
            this.BtnCreateAccount.TabIndex = 16;
            this.BtnCreateAccount.Text = "Create";
            this.BtnCreateAccount.UseVisualStyleBackColor = true;
            this.BtnCreateAccount.Click += new System.EventHandler(this.BtnCreateAccount_Click);
            // 
            // LblCreateAccountType
            // 
            this.LblCreateAccountType.AutoSize = true;
            this.LblCreateAccountType.Location = new System.Drawing.Point(207, 83);
            this.LblCreateAccountType.Name = "LblCreateAccountType";
            this.LblCreateAccountType.Size = new System.Drawing.Size(40, 20);
            this.LblCreateAccountType.TabIndex = 17;
            this.LblCreateAccountType.Text = "Type";
            // 
            // DgvAccount
            // 
            this.DgvAccount.AllowUserToAddRows = false;
            this.DgvAccount.AllowUserToDeleteRows = false;
            this.DgvAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvAccount.Location = new System.Drawing.Point(719, 336);
            this.DgvAccount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DgvAccount.Name = "DgvAccount";
            this.DgvAccount.ReadOnly = true;
            this.DgvAccount.RowHeadersWidth = 51;
            this.DgvAccount.RowTemplate.Height = 25;
            this.DgvAccount.Size = new System.Drawing.Size(933, 397);
            this.DgvAccount.TabIndex = 18;
            this.DgvAccount.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvAccount_CellMouseDoubleClick);
            // 
            // BtnShowAccounts
            // 
            this.BtnShowAccounts.Location = new System.Drawing.Point(1097, 741);
            this.BtnShowAccounts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnShowAccounts.Name = "BtnShowAccounts";
            this.BtnShowAccounts.Size = new System.Drawing.Size(122, 31);
            this.BtnShowAccounts.TabIndex = 19;
            this.BtnShowAccounts.Text = "Show accounts";
            this.BtnShowAccounts.UseVisualStyleBackColor = true;
            this.BtnShowAccounts.Click += new System.EventHandler(this.BtnShowAccounts_Click);
            // 
            // LblDepositWithdraw
            // 
            this.LblDepositWithdraw.AutoSize = true;
            this.LblDepositWithdraw.Location = new System.Drawing.Point(61, 269);
            this.LblDepositWithdraw.Name = "LblDepositWithdraw";
            this.LblDepositWithdraw.Size = new System.Drawing.Size(131, 20);
            this.LblDepositWithdraw.TabIndex = 20;
            this.LblDepositWithdraw.Text = "Deposit/Withdraw";
            // 
            // TbDepositWithdrawGuid
            // 
            this.TbDepositWithdrawGuid.Location = new System.Drawing.Point(64, 293);
            this.TbDepositWithdrawGuid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TbDepositWithdrawGuid.Name = "TbDepositWithdrawGuid";
            this.TbDepositWithdrawGuid.Size = new System.Drawing.Size(114, 27);
            this.TbDepositWithdrawGuid.TabIndex = 21;
            // 
            // TbDepositWithdrawAmount
            // 
            this.TbDepositWithdrawAmount.Location = new System.Drawing.Point(64, 332);
            this.TbDepositWithdrawAmount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TbDepositWithdrawAmount.Name = "TbDepositWithdrawAmount";
            this.TbDepositWithdrawAmount.Size = new System.Drawing.Size(114, 27);
            this.TbDepositWithdrawAmount.TabIndex = 22;
            // 
            // LblDepositWithdrawGuid
            // 
            this.LblDepositWithdrawGuid.AutoSize = true;
            this.LblDepositWithdrawGuid.Location = new System.Drawing.Point(3, 297);
            this.LblDepositWithdrawGuid.Name = "LblDepositWithdrawGuid";
            this.LblDepositWithdrawGuid.Size = new System.Drawing.Size(40, 20);
            this.LblDepositWithdrawGuid.TabIndex = 23;
            this.LblDepositWithdrawGuid.Text = "Guid";
            // 
            // LblDepositWithdrawAmount
            // 
            this.LblDepositWithdrawAmount.AutoSize = true;
            this.LblDepositWithdrawAmount.Location = new System.Drawing.Point(2, 336);
            this.LblDepositWithdrawAmount.Name = "LblDepositWithdrawAmount";
            this.LblDepositWithdrawAmount.Size = new System.Drawing.Size(62, 20);
            this.LblDepositWithdrawAmount.TabIndex = 24;
            this.LblDepositWithdrawAmount.Text = "Amount";
            // 
            // BtnDepositWithdraw
            // 
            this.BtnDepositWithdraw.Location = new System.Drawing.Point(64, 371);
            this.BtnDepositWithdraw.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnDepositWithdraw.Name = "BtnDepositWithdraw";
            this.BtnDepositWithdraw.Size = new System.Drawing.Size(86, 31);
            this.BtnDepositWithdraw.TabIndex = 25;
            this.BtnDepositWithdraw.Text = "Do";
            this.BtnDepositWithdraw.UseVisualStyleBackColor = true;
            this.BtnDepositWithdraw.Click += new System.EventHandler(this.BtnDepositWithdraw_Click);
            // 
            // TbShowTransactions
            // 
            this.TbShowTransactions.Location = new System.Drawing.Point(64, 507);
            this.TbShowTransactions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TbShowTransactions.Name = "TbShowTransactions";
            this.TbShowTransactions.Size = new System.Drawing.Size(114, 27);
            this.TbShowTransactions.TabIndex = 26;
            // 
            // LblShowTransactions
            // 
            this.LblShowTransactions.AutoSize = true;
            this.LblShowTransactions.Location = new System.Drawing.Point(64, 483);
            this.LblShowTransactions.Name = "LblShowTransactions";
            this.LblShowTransactions.Size = new System.Drawing.Size(128, 20);
            this.LblShowTransactions.TabIndex = 27;
            this.LblShowTransactions.Text = "Show transactions";
            // 
            // LblShowTransactionsGuid
            // 
            this.LblShowTransactionsGuid.AutoSize = true;
            this.LblShowTransactionsGuid.Location = new System.Drawing.Point(3, 511);
            this.LblShowTransactionsGuid.Name = "LblShowTransactionsGuid";
            this.LblShowTransactionsGuid.Size = new System.Drawing.Size(40, 20);
            this.LblShowTransactionsGuid.TabIndex = 28;
            this.LblShowTransactionsGuid.Text = "Guid";
            // 
            // BtnShowTransactions
            // 
            this.BtnShowTransactions.Location = new System.Drawing.Point(64, 545);
            this.BtnShowTransactions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnShowTransactions.Name = "BtnShowTransactions";
            this.BtnShowTransactions.Size = new System.Drawing.Size(86, 31);
            this.BtnShowTransactions.TabIndex = 29;
            this.BtnShowTransactions.Text = "Show";
            this.BtnShowTransactions.UseVisualStyleBackColor = true;
            this.BtnShowTransactions.Click += new System.EventHandler(this.BtnShowTransactions_Click);
            // 
            // LblDepositWithdrawTS
            // 
            this.LblDepositWithdrawTS.AutoSize = true;
            this.LblDepositWithdrawTS.Location = new System.Drawing.Point(207, 231);
            this.LblDepositWithdrawTS.Name = "LblDepositWithdrawTS";
            this.LblDepositWithdrawTS.Size = new System.Drawing.Size(197, 20);
            this.LblDepositWithdrawTS.TabIndex = 30;
            this.LblDepositWithdrawTS.Text = "Deposit/Withdraw with time";
            // 
            // TbDepositWithdrawGuidTS
            // 
            this.TbDepositWithdrawGuidTS.Location = new System.Drawing.Point(257, 255);
            this.TbDepositWithdrawGuidTS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TbDepositWithdrawGuidTS.Name = "TbDepositWithdrawGuidTS";
            this.TbDepositWithdrawGuidTS.Size = new System.Drawing.Size(114, 27);
            this.TbDepositWithdrawGuidTS.TabIndex = 31;
            // 
            // TbDepositWithdrawAmountTS
            // 
            this.TbDepositWithdrawAmountTS.Location = new System.Drawing.Point(257, 293);
            this.TbDepositWithdrawAmountTS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TbDepositWithdrawAmountTS.Name = "TbDepositWithdrawAmountTS";
            this.TbDepositWithdrawAmountTS.Size = new System.Drawing.Size(114, 27);
            this.TbDepositWithdrawAmountTS.TabIndex = 32;
            // 
            // TbDepositWithdrawTimeTS
            // 
            this.TbDepositWithdrawTimeTS.Location = new System.Drawing.Point(257, 332);
            this.TbDepositWithdrawTimeTS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TbDepositWithdrawTimeTS.Name = "TbDepositWithdrawTimeTS";
            this.TbDepositWithdrawTimeTS.Size = new System.Drawing.Size(114, 27);
            this.TbDepositWithdrawTimeTS.TabIndex = 33;
            // 
            // BtnDepositWithdrawTS
            // 
            this.BtnDepositWithdrawTS.Location = new System.Drawing.Point(257, 371);
            this.BtnDepositWithdrawTS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnDepositWithdrawTS.Name = "BtnDepositWithdrawTS";
            this.BtnDepositWithdrawTS.Size = new System.Drawing.Size(86, 31);
            this.BtnDepositWithdrawTS.TabIndex = 34;
            this.BtnDepositWithdrawTS.Text = "Do";
            this.BtnDepositWithdrawTS.UseVisualStyleBackColor = true;
            this.BtnDepositWithdrawTS.Click += new System.EventHandler(this.BtnDepositWithdrawTS_Click);
            // 
            // LblDepositWithdrawGuidTS
            // 
            this.LblDepositWithdrawGuidTS.AutoSize = true;
            this.LblDepositWithdrawGuidTS.Location = new System.Drawing.Point(194, 259);
            this.LblDepositWithdrawGuidTS.Name = "LblDepositWithdrawGuidTS";
            this.LblDepositWithdrawGuidTS.Size = new System.Drawing.Size(40, 20);
            this.LblDepositWithdrawGuidTS.TabIndex = 35;
            this.LblDepositWithdrawGuidTS.Text = "Guid";
            // 
            // LblDepositWithdrawAmountTS
            // 
            this.LblDepositWithdrawAmountTS.AutoSize = true;
            this.LblDepositWithdrawAmountTS.Location = new System.Drawing.Point(194, 297);
            this.LblDepositWithdrawAmountTS.Name = "LblDepositWithdrawAmountTS";
            this.LblDepositWithdrawAmountTS.Size = new System.Drawing.Size(62, 20);
            this.LblDepositWithdrawAmountTS.TabIndex = 36;
            this.LblDepositWithdrawAmountTS.Text = "Amount";
            // 
            // LblDepositWithdrawTimeTS
            // 
            this.LblDepositWithdrawTimeTS.AutoSize = true;
            this.LblDepositWithdrawTimeTS.Location = new System.Drawing.Point(194, 336);
            this.LblDepositWithdrawTimeTS.Name = "LblDepositWithdrawTimeTS";
            this.LblDepositWithdrawTimeTS.Size = new System.Drawing.Size(42, 20);
            this.LblDepositWithdrawTimeTS.TabIndex = 37;
            this.LblDepositWithdrawTimeTS.Text = "Time";
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(355, 769);
            this.BtnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(86, 31);
            this.BtnSave.TabIndex = 38;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // LblFindCustomer
            // 
            this.LblFindCustomer.AutoSize = true;
            this.LblFindCustomer.Location = new System.Drawing.Point(261, 428);
            this.LblFindCustomer.Name = "LblFindCustomer";
            this.LblFindCustomer.Size = new System.Drawing.Size(102, 20);
            this.LblFindCustomer.TabIndex = 39;
            this.LblFindCustomer.Text = "Find customer";
            // 
            // TbFindCustomerName
            // 
            this.TbFindCustomerName.Location = new System.Drawing.Point(257, 452);
            this.TbFindCustomerName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TbFindCustomerName.Name = "TbFindCustomerName";
            this.TbFindCustomerName.Size = new System.Drawing.Size(114, 27);
            this.TbFindCustomerName.TabIndex = 40;
            // 
            // TbFindCustomerCPR
            // 
            this.TbFindCustomerCPR.Location = new System.Drawing.Point(257, 491);
            this.TbFindCustomerCPR.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TbFindCustomerCPR.Name = "TbFindCustomerCPR";
            this.TbFindCustomerCPR.Size = new System.Drawing.Size(114, 27);
            this.TbFindCustomerCPR.TabIndex = 41;
            // 
            // LblFindCustomerName
            // 
            this.LblFindCustomerName.AutoSize = true;
            this.LblFindCustomerName.Location = new System.Drawing.Point(207, 456);
            this.LblFindCustomerName.Name = "LblFindCustomerName";
            this.LblFindCustomerName.Size = new System.Drawing.Size(49, 20);
            this.LblFindCustomerName.TabIndex = 42;
            this.LblFindCustomerName.Text = "Name";
            // 
            // LblFindCustomerCPR
            // 
            this.LblFindCustomerCPR.AutoSize = true;
            this.LblFindCustomerCPR.Location = new System.Drawing.Point(207, 495);
            this.LblFindCustomerCPR.Name = "LblFindCustomerCPR";
            this.LblFindCustomerCPR.Size = new System.Drawing.Size(35, 20);
            this.LblFindCustomerCPR.TabIndex = 43;
            this.LblFindCustomerCPR.Text = "CPR";
            // 
            // BtnFindCustomer
            // 
            this.BtnFindCustomer.Location = new System.Drawing.Point(257, 529);
            this.BtnFindCustomer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnFindCustomer.Name = "BtnFindCustomer";
            this.BtnFindCustomer.Size = new System.Drawing.Size(86, 31);
            this.BtnFindCustomer.TabIndex = 44;
            this.BtnFindCustomer.Text = "Find";
            this.BtnFindCustomer.UseVisualStyleBackColor = true;
            this.BtnFindCustomer.Click += new System.EventHandler(this.BtnFindCustomer_Click);
            // 
            // BtnLoad
            // 
            this.BtnLoad.Location = new System.Drawing.Point(448, 769);
            this.BtnLoad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnLoad.Name = "BtnLoad";
            this.BtnLoad.Size = new System.Drawing.Size(86, 31);
            this.BtnLoad.TabIndex = 45;
            this.BtnLoad.Text = "Load";
            this.BtnLoad.UseVisualStyleBackColor = true;
            this.BtnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // LblAddOwner
            // 
            this.LblAddOwner.AutoSize = true;
            this.LblAddOwner.Location = new System.Drawing.Point(473, 12);
            this.LblAddOwner.Name = "LblAddOwner";
            this.LblAddOwner.Size = new System.Drawing.Size(156, 20);
            this.LblAddOwner.TabIndex = 46;
            this.LblAddOwner.Text = "Add owner to account";
            // 
            // TbAddOwnerAccountGuid
            // 
            this.TbAddOwnerAccountGuid.Location = new System.Drawing.Point(473, 36);
            this.TbAddOwnerAccountGuid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TbAddOwnerAccountGuid.Name = "TbAddOwnerAccountGuid";
            this.TbAddOwnerAccountGuid.Size = new System.Drawing.Size(114, 27);
            this.TbAddOwnerAccountGuid.TabIndex = 47;
            // 
            // TbAddOwnerCustomerCPR
            // 
            this.TbAddOwnerCustomerCPR.Location = new System.Drawing.Point(473, 79);
            this.TbAddOwnerCustomerCPR.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TbAddOwnerCustomerCPR.Name = "TbAddOwnerCustomerCPR";
            this.TbAddOwnerCustomerCPR.Size = new System.Drawing.Size(114, 27);
            this.TbAddOwnerCustomerCPR.TabIndex = 48;
            // 
            // LblAddOwnerAccountGuid
            // 
            this.LblAddOwnerAccountGuid.AutoSize = true;
            this.LblAddOwnerAccountGuid.Location = new System.Drawing.Point(430, 41);
            this.LblAddOwnerAccountGuid.Name = "LblAddOwnerAccountGuid";
            this.LblAddOwnerAccountGuid.Size = new System.Drawing.Size(40, 20);
            this.LblAddOwnerAccountGuid.TabIndex = 49;
            this.LblAddOwnerAccountGuid.Text = "Guid";
            // 
            // LblAddOwnerCustomerCPR
            // 
            this.LblAddOwnerCustomerCPR.AutoSize = true;
            this.LblAddOwnerCustomerCPR.Location = new System.Drawing.Point(431, 81);
            this.LblAddOwnerCustomerCPR.Name = "LblAddOwnerCustomerCPR";
            this.LblAddOwnerCustomerCPR.Size = new System.Drawing.Size(35, 20);
            this.LblAddOwnerCustomerCPR.TabIndex = 50;
            this.LblAddOwnerCustomerCPR.Text = "CPR";
            // 
            // BtnAddOwner
            // 
            this.BtnAddOwner.Location = new System.Drawing.Point(473, 117);
            this.BtnAddOwner.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnAddOwner.Name = "BtnAddOwner";
            this.BtnAddOwner.Size = new System.Drawing.Size(86, 31);
            this.BtnAddOwner.TabIndex = 51;
            this.BtnAddOwner.Text = "Add";
            this.BtnAddOwner.UseVisualStyleBackColor = true;
            this.BtnAddOwner.Click += new System.EventHandler(this.BtnAddOwner_Click);
            // 
            // LblDeleteCustomer
            // 
            this.LblDeleteCustomer.AutoSize = true;
            this.LblDeleteCustomer.Location = new System.Drawing.Point(481, 359);
            this.LblDeleteCustomer.Name = "LblDeleteCustomer";
            this.LblDeleteCustomer.Size = new System.Drawing.Size(118, 20);
            this.LblDeleteCustomer.TabIndex = 52;
            this.LblDeleteCustomer.Text = "Delete customer";
            // 
            // TbDeleteCustomerCPR
            // 
            this.TbDeleteCustomerCPR.Location = new System.Drawing.Point(473, 383);
            this.TbDeleteCustomerCPR.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TbDeleteCustomerCPR.Name = "TbDeleteCustomerCPR";
            this.TbDeleteCustomerCPR.Size = new System.Drawing.Size(114, 27);
            this.TbDeleteCustomerCPR.TabIndex = 53;
            // 
            // LblDeleteCustomerCPR
            // 
            this.LblDeleteCustomerCPR.AutoSize = true;
            this.LblDeleteCustomerCPR.Location = new System.Drawing.Point(433, 387);
            this.LblDeleteCustomerCPR.Name = "LblDeleteCustomerCPR";
            this.LblDeleteCustomerCPR.Size = new System.Drawing.Size(35, 20);
            this.LblDeleteCustomerCPR.TabIndex = 54;
            this.LblDeleteCustomerCPR.Text = "CPR";
            // 
            // BtnDeleteCustomer
            // 
            this.BtnDeleteCustomer.Location = new System.Drawing.Point(473, 417);
            this.BtnDeleteCustomer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnDeleteCustomer.Name = "BtnDeleteCustomer";
            this.BtnDeleteCustomer.Size = new System.Drawing.Size(86, 31);
            this.BtnDeleteCustomer.TabIndex = 55;
            this.BtnDeleteCustomer.Text = "Delete";
            this.BtnDeleteCustomer.UseVisualStyleBackColor = true;
            this.BtnDeleteCustomer.Click += new System.EventHandler(this.BtnDeleteCustomer_Click);
            // 
            // LblDeleteAccount
            // 
            this.LblDeleteAccount.AutoSize = true;
            this.LblDeleteAccount.Location = new System.Drawing.Point(481, 471);
            this.LblDeleteAccount.Name = "LblDeleteAccount";
            this.LblDeleteAccount.Size = new System.Drawing.Size(109, 20);
            this.LblDeleteAccount.TabIndex = 56;
            this.LblDeleteAccount.Text = "Delete account";
            // 
            // TbDeleteAccountGuid
            // 
            this.TbDeleteAccountGuid.Location = new System.Drawing.Point(473, 495);
            this.TbDeleteAccountGuid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TbDeleteAccountGuid.Name = "TbDeleteAccountGuid";
            this.TbDeleteAccountGuid.Size = new System.Drawing.Size(114, 27);
            this.TbDeleteAccountGuid.TabIndex = 57;
            // 
            // LblDeleteAccountGuid
            // 
            this.LblDeleteAccountGuid.AutoSize = true;
            this.LblDeleteAccountGuid.Location = new System.Drawing.Point(427, 499);
            this.LblDeleteAccountGuid.Name = "LblDeleteAccountGuid";
            this.LblDeleteAccountGuid.Size = new System.Drawing.Size(40, 20);
            this.LblDeleteAccountGuid.TabIndex = 58;
            this.LblDeleteAccountGuid.Text = "Guid";
            // 
            // BtnDeleteAccount
            // 
            this.BtnDeleteAccount.Location = new System.Drawing.Point(473, 529);
            this.BtnDeleteAccount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnDeleteAccount.Name = "BtnDeleteAccount";
            this.BtnDeleteAccount.Size = new System.Drawing.Size(86, 31);
            this.BtnDeleteAccount.TabIndex = 59;
            this.BtnDeleteAccount.Text = "Delete";
            this.BtnDeleteAccount.UseVisualStyleBackColor = true;
            this.BtnDeleteAccount.Click += new System.EventHandler(this.BtnDeleteAccount_Click);
            // 
            // TbAddInterest
            // 
            this.TbAddInterest.Location = new System.Drawing.Point(64, 703);
            this.TbAddInterest.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TbAddInterest.Name = "TbAddInterest";
            this.TbAddInterest.Size = new System.Drawing.Size(114, 27);
            this.TbAddInterest.TabIndex = 60;
            // 
            // LblAddInterest
            // 
            this.LblAddInterest.AutoSize = true;
            this.LblAddInterest.Location = new System.Drawing.Point(64, 679);
            this.LblAddInterest.Name = "LblAddInterest";
            this.LblAddInterest.Size = new System.Drawing.Size(123, 20);
            this.LblAddInterest.TabIndex = 61;
            this.LblAddInterest.Text = "Add interest";
            // 
            // LblAddInterestGuid
            // 
            this.LblAddInterestGuid.AutoSize = true;
            this.LblAddInterestGuid.Location = new System.Drawing.Point(3, 707);
            this.LblAddInterestGuid.Name = "LblAddInterestGuid";
            this.LblAddInterestGuid.Size = new System.Drawing.Size(40, 20);
            this.LblAddInterestGuid.TabIndex = 62;
            this.LblAddInterestGuid.Text = "Guid";
            // 
            // BtnAddInterest
            // 
            this.BtnAddInterest.Location = new System.Drawing.Point(64, 741);
            this.BtnAddInterest.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnAddInterest.Name = "BtnAddInterest";
            this.BtnAddInterest.Size = new System.Drawing.Size(86, 31);
            this.BtnAddInterest.TabIndex = 63;
            this.BtnAddInterest.Text = "Add";
            this.BtnAddInterest.UseVisualStyleBackColor = true;
            this.BtnAddInterest.Click += new System.EventHandler(this.BtnAddInterest_Click);
            // 
            // TbRemoveOwnerAccountGuid
            // 
            this.TbRemoveOwnerAccountGuid.Location = new System.Drawing.Point(473, 195);
            this.TbRemoveOwnerAccountGuid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TbRemoveOwnerAccountGuid.Name = "TbRemoveOwnerAccountGuid";
            this.TbRemoveOwnerAccountGuid.Size = new System.Drawing.Size(114, 27);
            this.TbRemoveOwnerAccountGuid.TabIndex = 64;
            // 
            // TbRemoveOwnerCustomerCPR
            // 
            this.TbRemoveOwnerCustomerCPR.Location = new System.Drawing.Point(473, 233);
            this.TbRemoveOwnerCustomerCPR.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TbRemoveOwnerCustomerCPR.Name = "TbRemoveOwnerCustomerCPR";
            this.TbRemoveOwnerCustomerCPR.Size = new System.Drawing.Size(114, 27);
            this.TbRemoveOwnerCustomerCPR.TabIndex = 65;
            // 
            // LblRemoveOwnerAccountGuid
            // 
            this.LblRemoveOwnerAccountGuid.AutoSize = true;
            this.LblRemoveOwnerAccountGuid.Location = new System.Drawing.Point(431, 199);
            this.LblRemoveOwnerAccountGuid.Name = "LblRemoveOwnerAccountGuid";
            this.LblRemoveOwnerAccountGuid.Size = new System.Drawing.Size(40, 20);
            this.LblRemoveOwnerAccountGuid.TabIndex = 66;
            this.LblRemoveOwnerAccountGuid.Text = "Guid";
            // 
            // LblRemoveOwnerCustomerCPR
            // 
            this.LblRemoveOwnerCustomerCPR.AutoSize = true;
            this.LblRemoveOwnerCustomerCPR.Location = new System.Drawing.Point(434, 237);
            this.LblRemoveOwnerCustomerCPR.Name = "LblRemoveOwnerCustomerCPR";
            this.LblRemoveOwnerCustomerCPR.Size = new System.Drawing.Size(35, 20);
            this.LblRemoveOwnerCustomerCPR.TabIndex = 67;
            this.LblRemoveOwnerCustomerCPR.Text = "CPR";
            // 
            // LblRemoveOwner
            // 
            this.LblRemoveOwner.AutoSize = true;
            this.LblRemoveOwner.Location = new System.Drawing.Point(473, 165);
            this.LblRemoveOwner.Name = "LblRemoveOwner";
            this.LblRemoveOwner.Size = new System.Drawing.Size(200, 20);
            this.LblRemoveOwner.TabIndex = 68;
            this.LblRemoveOwner.Text = "Remove owner from account";
            // 
            // BtnRemoveOwner
            // 
            this.BtnRemoveOwner.Location = new System.Drawing.Point(473, 272);
            this.BtnRemoveOwner.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnRemoveOwner.Name = "BtnRemoveOwner";
            this.BtnRemoveOwner.Size = new System.Drawing.Size(86, 31);
            this.BtnRemoveOwner.TabIndex = 69;
            this.BtnRemoveOwner.Text = "Remove";
            this.BtnRemoveOwner.UseVisualStyleBackColor = true;
            this.BtnRemoveOwner.Click += new System.EventHandler(this.BtnRemoveOwner_Click);
            // 
            // BankForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1665, 843);
            this.Controls.Add(this.BtnRemoveOwner);
            this.Controls.Add(this.LblRemoveOwner);
            this.Controls.Add(this.LblRemoveOwnerCustomerCPR);
            this.Controls.Add(this.LblRemoveOwnerAccountGuid);
            this.Controls.Add(this.TbRemoveOwnerCustomerCPR);
            this.Controls.Add(this.TbRemoveOwnerAccountGuid);
            this.Controls.Add(this.BtnAddInterest);
            this.Controls.Add(this.LblAddInterestGuid);
            this.Controls.Add(this.LblAddInterest);
            this.Controls.Add(this.TbAddInterest);
            this.Controls.Add(this.BtnDeleteAccount);
            this.Controls.Add(this.LblDeleteAccountGuid);
            this.Controls.Add(this.TbDeleteAccountGuid);
            this.Controls.Add(this.LblDeleteAccount);
            this.Controls.Add(this.BtnDeleteCustomer);
            this.Controls.Add(this.LblDeleteCustomerCPR);
            this.Controls.Add(this.TbDeleteCustomerCPR);
            this.Controls.Add(this.LblDeleteCustomer);
            this.Controls.Add(this.BtnAddOwner);
            this.Controls.Add(this.LblAddOwnerCustomerCPR);
            this.Controls.Add(this.LblAddOwnerAccountGuid);
            this.Controls.Add(this.TbAddOwnerCustomerCPR);
            this.Controls.Add(this.TbAddOwnerAccountGuid);
            this.Controls.Add(this.LblAddOwner);
            this.Controls.Add(this.BtnLoad);
            this.Controls.Add(this.BtnFindCustomer);
            this.Controls.Add(this.LblFindCustomerCPR);
            this.Controls.Add(this.LblFindCustomerName);
            this.Controls.Add(this.TbFindCustomerCPR);
            this.Controls.Add(this.TbFindCustomerName);
            this.Controls.Add(this.LblFindCustomer);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.LblDepositWithdrawTimeTS);
            this.Controls.Add(this.LblDepositWithdrawAmountTS);
            this.Controls.Add(this.LblDepositWithdrawGuidTS);
            this.Controls.Add(this.BtnDepositWithdrawTS);
            this.Controls.Add(this.TbDepositWithdrawTimeTS);
            this.Controls.Add(this.TbDepositWithdrawAmountTS);
            this.Controls.Add(this.TbDepositWithdrawGuidTS);
            this.Controls.Add(this.LblDepositWithdrawTS);
            this.Controls.Add(this.BtnShowTransactions);
            this.Controls.Add(this.LblShowTransactionsGuid);
            this.Controls.Add(this.LblShowTransactions);
            this.Controls.Add(this.TbShowTransactions);
            this.Controls.Add(this.BtnDepositWithdraw);
            this.Controls.Add(this.LblDepositWithdrawAmount);
            this.Controls.Add(this.LblDepositWithdrawGuid);
            this.Controls.Add(this.TbDepositWithdrawAmount);
            this.Controls.Add(this.TbDepositWithdrawGuid);
            this.Controls.Add(this.LblDepositWithdraw);
            this.Controls.Add(this.BtnShowAccounts);
            this.Controls.Add(this.DgvAccount);
            this.Controls.Add(this.LblCreateAccountType);
            this.Controls.Add(this.BtnCreateAccount);
            this.Controls.Add(this.LblCreateAccountCPR);
            this.Controls.Add(this.TbCreateAccountCPR);
            this.Controls.Add(this.LblCreateAccount);
            this.Controls.Add(this.CbCreateAccountType);
            this.Controls.Add(this.BtnShowCustomers);
            this.Controls.Add(this.DgvCustomer);
            this.Controls.Add(this.LblCreateCustomerCity);
            this.Controls.Add(this.TbCreateCustomerCity);
            this.Controls.Add(this.LblCreateCustomerAddress);
            this.Controls.Add(this.LblCreateCustomerCPR);
            this.Controls.Add(this.LblCreateCustomerName);
            this.Controls.Add(this.TbCreateCustomerAddress);
            this.Controls.Add(this.TbCreateCustomerCPR);
            this.Controls.Add(this.TbCreateCustomerName);
            this.Controls.Add(this.LblCreateCustomer);
            this.Controls.Add(this.BtnCreateCustomer);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BankForm";
            this.Text = "LilleBank A/S";
            ((System.ComponentModel.ISupportInitialize)(this.DgvCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAccount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button BtnCreateCustomer;
        private Label LblCreateCustomer;
        private TextBox TbCreateCustomerName;
        private TextBox TbCreateCustomerCPR;
        private TextBox TbCreateCustomerAddress;
        private Label LblCreateCustomerName;
        private Label LblCreateCustomerCPR;
        private Label LblCreateCustomerAddress;
        private TextBox TbCreateCustomerCity;
        private Label LblCreateCustomerCity;
        private DataGridView DgvCustomer;
        private Button BtnShowCustomers;
        private ComboBox CbCreateAccountType;
        private Label LblCreateAccount;
        private TextBox TbCreateAccountCPR;
        private Label LblCreateAccountCPR;
        private Button BtnCreateAccount;
        private Label LblCreateAccountType;
        private DataGridView DgvAccount;
        private Button BtnShowAccounts;
        private Label LblDepositWithdraw;
        private TextBox TbDepositWithdrawGuid;
        private TextBox TbDepositWithdrawAmount;
        private Label LblDepositWithdrawGuid;
        private Label LblDepositWithdrawAmount;
        private Button BtnDepositWithdraw;
        private TextBox TbShowTransactions;
        private Label LblShowTransactions;
        private Label LblShowTransactionsGuid;
        private Button BtnShowTransactions;
        private Label LblDepositWithdrawTS;
        private TextBox TbDepositWithdrawGuidTS;
        private TextBox TbDepositWithdrawAmountTS;
        private TextBox TbDepositWithdrawTimeTS;
        private Button BtnDepositWithdrawTS;
        private Label LblDepositWithdrawGuidTS;
        private Label LblDepositWithdrawAmountTS;
        private Label LblDepositWithdrawTimeTS;
        private Button BtnSave;
        private Label LblFindCustomer;
        private TextBox TbFindCustomerName;
        private TextBox TbFindCustomerCPR;
        private Label LblFindCustomerName;
        private Label LblFindCustomerCPR;
        private Button BtnFindCustomer;
        private Button BtnLoad;
        private Label LblAddOwner;
        private TextBox TbAddOwnerAccountGuid;
        private TextBox TbAddOwnerCustomerCPR;
        private Label LblAddOwnerAccountGuid;
        private Label LblAddOwnerCustomerCPR;
        private Button BtnAddOwner;
        private Label LblDeleteCustomer;
        private TextBox TbDeleteCustomerCPR;
        private Label LblDeleteCustomerCPR;
        private Button BtnDeleteCustomer;
        private Label LblDeleteAccount;
        private TextBox TbDeleteAccountGuid;
        private Label LblDeleteAccountGuid;
        private Button BtnDeleteAccount;
        private TextBox TbAddInterest;
        private Label LblAddInterest;
        private Label LblAddInterestGuid;
        private Button BtnAddInterest;
        private TextBox TbRemoveOwnerAccountGuid;
        private TextBox TbRemoveOwnerCustomerCPR;
        private Label LblRemoveOwnerAccountGuid;
        private Label LblRemoveOwnerCustomerCPR;
        private Label LblRemoveOwner;
        private Button BtnRemoveOwner;
    }
}