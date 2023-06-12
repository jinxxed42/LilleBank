using LilleBank.Models;
using System.Collections.ObjectModel;


namespace LilleBank
{
    /// <summary>
    /// The main form.
    /// </summary>
    internal partial class BankForm : Form
    {
        private Bank _bank = new Bank(); // Creating the Bank object immediately, since it's needed for everything.

        private BindingSource _dgvAccountBindingSource = new BindingSource();
        private BindingSource _dgvCustomerBindingSource = new BindingSource();

        /// <summary>
        /// Constructor.
        /// </summary>
        public BankForm()
        {
            InitializeComponent();

            // Adding all entries found in the AccountTypes enumerator to the selectable Account types for creation.
            // typeof returns the System.Type object that is needed by GetValues.
            foreach (AccountType accountType in Enum.GetValues(typeof(AccountType)))
            {
                CbCreateAccountType.Items.Add(accountType);
            }


            TbCreateCustomerName.Text = "Claus Dam";
            TbCreateCustomerCPR.Text = "280279-1139";
            TbCreateCustomerAddress.Text = "Randomvej 12, 1.th";
            TbCreateCustomerCity.Text = "6000 Kolding";

            TbCreateAccountCPR.Text = "280279-1139";

            DgvAccount.DataSource = _dgvAccountBindingSource;
            DgvCustomer.DataSource = _dgvCustomerBindingSource;

            UpdateDgvAccount(_bank.Accounts);
            UpdateDgvCustomer(_bank.Customers);
        }

        /// <summary>
        /// Eventhandler for clicks on the BtnCreateCustomer button. 
        /// Checks if input was provided in all fields. Utilizes the Bank class's CreateCustomer method to validate input
        /// and create Customer. Notifies user with a textbox whether successful or not.
        /// Updates the DgvCustomer DataGridView to reflect changes if successful.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void BtnCreateCustomer_Click(object sender, EventArgs e)
        {
            string name = TbCreateCustomerName.Text;
            string cpr = TbCreateCustomerCPR.Text;
            string address = TbCreateCustomerAddress.Text;
            string city = TbCreateCustomerCity.Text;
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(cpr)
                || string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(city))
            {
                MessageBox.Show("Please provide input in all fields.");
            }
            else
            {
                Result result = _bank.CreateCustomer(name, cpr, address, city);
                if (result.Success)
                {
                    MessageBox.Show($"Success.\n\n{result.Message}");
                    UpdateDgvCustomer(_bank.Customers);
                }
                else
                {
                    MessageBox.Show($"Failure.\n\n{result.Message}");
                }
            }
        }

        /// <summary>
        /// Eventhandler for clicks on the BtnFindCustomer button. Checks if any input was given. Then depending on if something
        /// was entered as CPR it uses the Bank class's FindCustomerByCPR method to try finding the Customer. If nothing was
        /// entered as CPR it does a search by name. If a single Customer is found it uses the Bank class's FindAccountsByCustomer
        /// method to find Accounts for that Customer and calls UpdateDgvAccount to show the Accounts. Notifies the user
        /// through a MessageBox of any errors.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void BtnFindCustomer_Click(object sender, EventArgs e)
        {
            string name = TbFindCustomerName.Text;
            string cpr = TbFindCustomerCPR.Text;
            if (string.IsNullOrWhiteSpace(name) && string.IsNullOrWhiteSpace(cpr))
            {
                MessageBox.Show("Please provide input in one of the fields.");
            }
            else if (!string.IsNullOrWhiteSpace(cpr))
            {
                ResultData<Customer> customerResult = _bank.FindCustomerByCPR(cpr);
                if (!customerResult.Success)
                {
                    MessageBox.Show($"Failure.\n\n{customerResult.Message}");
                }
                else
                {
                    string message = string.Empty;
                    if (!string.IsNullOrWhiteSpace(name))
                    {
                        message += "Searched by CPR.\n\n";
                    }
                    UpdateDgvCustomer(customerResult.Data);
                    ResultData<ReadOnlyCollection<Account>> accountsResult = _bank.FindAccountsByCustomer(customerResult.Data);

                    UpdateDgvAccount(accountsResult.Data);
                    MessageBox.Show($"{message}{accountsResult.Message}");
                }
            }
            else
            {
                ResultData<ReadOnlyCollection<Customer>> customersResult = _bank.FindCustomerByName(name);
                if (!customersResult.Success)
                {
                    MessageBox.Show($"Failure.\n\n{customersResult.Message}");
                }
                else
                {
                    UpdateDgvCustomer(customersResult.Data);
                    if (customersResult.Data.Count == 1)
                    {
                        ResultData<ReadOnlyCollection<Account>> accountsResult = _bank.FindAccountsByCustomer(customersResult.Data[0]);
                        UpdateDgvAccount(accountsResult.Data);
                        MessageBox.Show($"{accountsResult.Message}");
                    }
                    else
                    {
                        MessageBox.Show($"{customersResult.Message}\n\nSearch by CPR for a specific match and account list.");
                    }
                }
            }
        }

        /// <summary>
        /// Eventhandler for clicks on the BtnDeleteCustomer button. Checks if any input was given and if so uses the Bank 
        /// class's FindCustomerByCPR method to find the specified Customer. If found notifies the user through a Dialog 
        /// that Customer will be deleted along with all associated single-Owner Accounts, and asks for confirmation. If given
        /// uses the Bank class's DeleteCustomer method to perform deletion. Notifies user through a MessageBox of the
        /// result. Updates DgvCustomer and DgvAccount DataGridView to reflect changes if successful.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void BtnDeleteCustomer_Click(object sender, EventArgs e)
        {
            string cpr = TbDeleteCustomerCPR.Text;
            if (string.IsNullOrWhiteSpace(cpr))
            {
                MessageBox.Show("Please provide some input.");
            }
            else
            {
                ResultData<Customer> customerResult = _bank.FindCustomerByCPR(cpr);
                if (!customerResult.Success)
                {
                    MessageBox.Show($"Failure.\n\n{customerResult.Message}");
                }
                else
                {
                    DialogResult dialogResult =
                        MessageBox.Show($"This will delete everything associated with customer: {customerResult.Data.Name} with CPR: {customerResult.Data.CPR} - except accounts with multiple owners. Are you sure?",
                        "Delete customer",
                        MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Result result = _bank.DeleteCustomer(customerResult.Data);
                        if (result.Success)
                        {
                            MessageBox.Show($"Success.\n\n{result.Message}");
                            UpdateDgvCustomer(_bank.Customers);
                            UpdateDgvAccount(_bank.Accounts);
                        }
                        else
                        {
                            MessageBox.Show($"Failure.\n\n{result.Message}");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Eventhandler for clicks on the BtnCreateAccount button. Checks if any input was given and an Account type 
        /// selected. Utilizes the bank class's CreateAccount method to validate input and create Account for Customer specified
        /// by CPR. Notifies user with a MessageBox whether successful or not.
        /// Updates DgvAccount DataGridView if successful to reflect changes.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void BtnCreateAccount_Click(object sender, EventArgs e)
        {
            string cpr = TbCreateAccountCPR.Text;
            if (string.IsNullOrWhiteSpace(cpr))
            {
                MessageBox.Show("Please input a CPR number.");
            }
            else if (CbCreateAccountType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an account type.");
            }
            else
            {
                AccountType selectedAccount = (AccountType)CbCreateAccountType.SelectedItem; // Typecast object to enum

                Result result = _bank.CreateAccount(cpr, selectedAccount);
                if (result.Success)
                {
                    MessageBox.Show($"Success.\n\n{result.Message}");
                    UpdateDgvAccount(_bank.Accounts);
                }
                else
                {
                    MessageBox.Show($"Failure.\n\n{result.Message}");
                }
            }
        }

        /// <summary>
        /// Eventhandler for clicks on the BtnDeleteAccount button. Checks if any input was given and if so uses the Bank 
        /// class's FindAccount method to find the specified Account. If found notifies the user through a Dialog that the
        /// Account will be deleted, and asks for confirmation. If given uses the Bank class's DeleteAccount method to
        /// perform deletion. Notifies user through a MessageBox of the result.
        /// Updates DgvAccount DataGridView if successful to reflect changes.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void BtnDeleteAccount_Click(object sender, EventArgs e)
        {
            string guid = TbDeleteAccountGuid.Text;
            if (string.IsNullOrWhiteSpace(guid))
            {
                MessageBox.Show("Please provide some input.");
            }
            else
            {
                ResultData<Account> accountResult = _bank.FindAccount(guid);
                if (!accountResult.Success)
                {
                    MessageBox.Show($"Failure. {accountResult.Message}");
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show($"This will delete {accountResult.Data.Type} with ID: {guid} including balance and all associated transactions. Are you sure?",
                    "Delete account",
                    MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Result result = _bank.DeleteAccount(accountResult.Data);
                        if (result.Success)
                        {
                            MessageBox.Show($"Success.\n\n{result.Message}");
                            UpdateDgvAccount(_bank.Accounts);
                        }
                        else
                        {
                            MessageBox.Show($"Failure.\n\n{result.Message}");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Eventhandler for clicks on the BtnAddOwner button. Checks if any input is given. If so uses the Bank class's 
        /// AddOwnerToAccount method to attempt adding Customer specified by CPR as Owner of Account specified by Guid.
        /// Alerts user with a MessageBox whether successful or not.
        /// Updates DgvAccount DataGridView if successful to reflect changes.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void BtnAddOwner_Click(object sender, EventArgs e)
        {
            string guid = TbAddOwnerAccountGuid.Text;
            string cpr = TbAddOwnerCustomerCPR.Text;
            if (string.IsNullOrWhiteSpace(guid) || string.IsNullOrWhiteSpace(cpr))
            {
                MessageBox.Show("Please provide input in both fields.");
            }
            else
            {
                Result result = _bank.AddOwnerToAccount(cpr, guid);
                if (result.Success)
                {
                    MessageBox.Show($"Success.\n\n{result.Message}");
                    UpdateDgvAccount(_bank.Accounts);
                }
                else
                {
                    MessageBox.Show($"Failure.\n\n{result.Message}");
                }
            }
        }

        /// <summary>
        /// Eventhandler for clicks on the BtnRemoveOwner button. Checks if input was given in both fields. If so it uses
        /// the Bank class's RemoveOwnerFromAccount method to attempt removing the Customer specified by CPR as Owner of
        /// the Account specified by Guid. Notifies user through a MessageBox of the result.
        /// Updates DgvAccount DataGridView if successful to reflect changes.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void BtnRemoveOwner_Click(object sender, EventArgs e)
        {
            string guid = TbRemoveOwnerAccountGuid.Text;
            string cpr = TbRemoveOwnerCustomerCPR.Text;
            if (string.IsNullOrWhiteSpace(guid) || string.IsNullOrWhiteSpace(cpr))
            {
                MessageBox.Show("Please provide some input in both fields.");
            }
            Result result = _bank.RemoveOwnerFromAccount(cpr, guid);
            if (result.Success)
            {
                MessageBox.Show($"Success.\n\n{result.Message}");
                UpdateDgvAccount(_bank.Accounts);
            }
            else
            {
                MessageBox.Show($"Failure.\n\n{result.Message}");
            }
        }

        /// <summary>
        /// Eventhandler for clicks on the Show customers button. Uses UpdateDgvCustomer to show all 
        /// current customers in the DgvCustomer DataGridView.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void BtnShowCustomers_Click(object sender, EventArgs e)
        {
            UpdateDgvCustomer(_bank.Customers);
        }

        /// <summary>
        /// Eventhandler for clicks on the Show accounts button. Uses UpdateDgvAccoun to show all
        /// accounts in the DgvAccount DataGridView.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void BtnShowAccounts_Click(object sender, EventArgs e)
        {
            UpdateDgvAccount(_bank.Accounts);
        }

        /// <summary>
        /// Eventhandler for clicks on the BtnShowTransactions button. Checks if any input was given. 
        /// Uses UpdateDgvAccountTransactions to show found Transactions in the DgvAccount DataGridView
        /// or a MessageBox with an error message if not successful.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void BtnShowTransactions_Click(object sender, EventArgs e)
        {
            string guid = TbShowTransactions.Text;
            if (string.IsNullOrWhiteSpace(guid))
            {
                MessageBox.Show("Please provide a valid Guid as input.");
            }
            else
            {
                ResultData<Account> accountResult = _bank.FindAccount(guid);
                if (!accountResult.Success)
                {
                    MessageBox.Show($"Failure.\n\n{accountResult.Message}");
                }
                else
                {
                    UpdateDgvAccountTransactions(accountResult.Data);
                }
            }
        }

        /// <summary>
        /// Eventhandler for clicks on the Deposit/Withdraw button. Checks if input was given in both fields. If so it uses
        /// the Bank class's FindAccount method to find the Account and calls the Account's DepositOrWithdraw method to do the
        /// transaction. Notifies the user with a MessageBox whether successful or not.
        /// Updates the DgvAccount DataGridView to show Transactions for the Account if successful.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void BtnDepositWithdraw_Click(object sender, EventArgs e)
        {
            string guid = TbDepositWithdrawGuid.Text;
            string amount = TbDepositWithdrawAmount.Text;

            if (string.IsNullOrWhiteSpace(guid) || string.IsNullOrWhiteSpace(amount))
            {
                MessageBox.Show("Please provide input in all fields.");
            }
            else
            {
                ResultData<Account> accountResult = _bank.FindAccount(guid);
                if (accountResult.Success)
                {
                    Result result = accountResult.Data.DepositOrWithdraw(amount);
                    if (result.Success)
                    {
                        MessageBox.Show($"Successful transaction.\n\n{result.Message}");
                        UpdateDgvAccountTransactions(accountResult.Data);
                    }
                    else
                    {
                        MessageBox.Show($"Transaction failed.\n\n{result.Message}");
                    }
                }
                else
                {
                    MessageBox.Show($"Transaction failed.\n\n{accountResult.Message}");
                }
            }
        }

        /// <summary>
        /// Eventhandler for clicks on the BtnDepositWithdrawTS button. Checks if input was given in all fields. If so it uses
        /// the Bank class's FindAccount method to find the Account and calls the Account's DepositOrWithdraw method to do the
        /// Transaction at the specified date and time. Notifies the user with a MessageBox whether successful or not.
        /// Updates the DgvAccount DataGridView to show Transactions for the Account if successful.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void BtnDepositWithdrawTS_Click(object sender, EventArgs e)
        {
            string guid = TbDepositWithdrawGuidTS.Text;
            string amount = TbDepositWithdrawAmountTS.Text;
            string time = TbDepositWithdrawTimeTS.Text;
            if (string.IsNullOrWhiteSpace(guid) || string.IsNullOrWhiteSpace(amount) || string.IsNullOrWhiteSpace(time))
            {
                MessageBox.Show("Please provide input in all fields.");
            }
            else
            {
                ResultData<Account> accountResult = _bank.FindAccount(guid);
                if (!accountResult.Success)
                {
                    MessageBox.Show($"Transaction failed.\n\n{accountResult.Message}");
                }
                else
                {
                    Result result = accountResult.Data.DepositOrWithdraw(amount, time);
                    if (result.Success)
                    {
                        MessageBox.Show($"Successful transaction.\n\n{result.Message}");
                        UpdateDgvAccountTransactions(accountResult.Data);
                    }
                    else
                    {
                        MessageBox.Show($"Transaction failed.\n\n{result.Message}");
                    }
                }
            }
        }

        /// <summary>
        /// Eventhandler for the BtnAddInterest button. Checks if any input is given. Depending on whether input was given
        /// it uses one of the Bank class's overloaded AddInterest methods to add interest for the specified Account or all.
        /// Will print error messages if given invalid input or no matching Accounts are found. Notifies the user through
        /// a MessageBox of the result.
        /// If a Guid was entered and it was successful for a single Account it updates the DgvAccount DataGridView to show
        /// Transactions for that account.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void BtnAddInterest_Click(object sender, EventArgs e)
        {
            string guid = TbAddInterest.Text;
            if (string.IsNullOrWhiteSpace(guid))
            {
                Result result = _bank.AddInterest();

                if (result.Success)
                {
                    MessageBox.Show($"Success.\n\n{result.Message}");
                }
                else
                {
                    MessageBox.Show($"Failure.\n\n{result.Message}");
                }
            }
            else
            {
                ResultData<Account> accountResult = _bank.AddInterest(guid);
                if (accountResult.Success)
                {
                    MessageBox.Show($"Success.\n\n{accountResult.Message}");
                    UpdateDgvAccountTransactions(accountResult.Data);
                }
                else
                {
                    MessageBox.Show($"Failure.\n\n{accountResult.Message}");
                }
            }
        }

        /// <summary>
        /// Eventhandler for doubleclicks on cells in the DgvCustomer DataGridView. Uses the Bank class's 
        /// FindCustomerByCPR method to find the Customer specified by CPR in the row clicked.
        /// Opens a new form for updating Customer data of any Customer that was doubleclicked, if found.
        /// Notifies the user if the header or an invalid row was doubleclicked. Reloads DgvCustomer
        /// and DgvAccount after update to reflect changes.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void DgvCustomer_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                MessageBox.Show("You doubleclicked the header.");
                return;
            }

            // Gets the value from the CPR cell in the doubleclicked row.
            string cellValue = DgvCustomer.Rows[e.RowIndex].Cells["CPR"].Value.ToString()!; // Always contains something, so null warning suppressed.

            ResultData<Customer> customerResult = _bank.FindCustomerByCPR(cellValue);

            if (customerResult.Success)
            {
                UpdateForm updateForm = new(customerResult.Data, _bank);
                DialogResult dialogResult = updateForm.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    UpdateDgvCustomer(_bank.Customers);
                    UpdateDgvAccount(_bank.Accounts);
                }
            }
            else
            {
                MessageBox.Show($"Failure.\n\n{customerResult.Message}");
            }
        }

        /// <summary>
        /// Eventhandler for doubleclicks on cells in the DgvAccount DataGridView.
        /// Uses the Bank class's FindAccount method to find the Account specified by Guid
        /// in the row clicked. Then shows Transactions for that Account or shows 
        /// all Accounts if doubleclicking in a Transaction window. Utilizes the 
        /// UpdateDgvAccountTransactions and UpdateDgvAccount methods respectively. 
        /// Notifies the user if the header or an invalid row was doubleclicked.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void DgvAccount_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                MessageBox.Show("You doubleclicked the header.");
                return;
            }

            // If we are on a Transaction screen we just go back and show accounts.
            if (DgvAccount.Columns.Contains("TransactionType"))
            {
                UpdateDgvAccount(_bank.Accounts);
            }
            else
            {
                string cellValue = DgvAccount.Rows[e.RowIndex].Cells["ID"].Value.ToString()!; // Always contains something, so null warning suppressed.

                ResultData<Account> accountResult = _bank.FindAccount(cellValue);

                if (accountResult.Success)
                {
                    UpdateDgvAccountTransactions(accountResult.Data);
                }
                else
                {
                    MessageBox.Show($"Failure.\n\n{accountResult.Message}");
                }
            }
        }

        /// <summary>
        /// Eventhandler for clicks on the BtnSave button. Uses the SaveData method of the Bank class to save data. Displays a
        /// MessageBox with the result.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            Result result = _bank.SaveData();
            if (result.Success)
            {
                MessageBox.Show($"Success.\n\n{result.Message}");
            }
            else
            {
                MessageBox.Show($"Save failed.\n\n{result.Message}");
            }
        }

        /// <summary>
        /// Eventhandler for clicks on the BtnLoad button. Uses the LoadData method of the Bank class to load data. Displays a
        /// MessageBox with the result.
        /// Updates the DgvCustomer and DgvAccount DataGridViews to show the loaded data.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void BtnLoad_Click(object sender, EventArgs e)
        {
            Result result = _bank.LoadData();
            if (result.Success)
            {
                MessageBox.Show($"Success.\n\n{result.Message}");
                UpdateDgvCustomer(_bank.Customers);
                UpdateDgvAccount(_bank.Accounts);
            }
            else
            {
                MessageBox.Show($"Load failed.\n\n{result.Message}");
            }
        }

        /// <summary>
        /// Method for showing a single Customer's data in the DgvCustomer DataGridView. Only to be called with an
        /// existing Customer object, not a null reference.
        /// </summary>
        /// <param name="customer">Customer to be shown.</param>
        private void UpdateDgvCustomer(Customer customer)
        {
            _dgvCustomerBindingSource.DataSource = customer;
            DgvCustomer.Columns["Name"].DisplayIndex = 0;
            DgvCustomer.Columns["CPR"].DisplayIndex = 1;
            DgvCustomer.Columns["Address"].DisplayIndex = 2;
            DgvCustomer.Columns["City"].DisplayIndex = 3;
            for (int i = 0; i < DgvCustomer.ColumnCount; i++)
            {
                DgvCustomer.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Making all columns equal size.
            }
        }

        /// <summary>
        /// Method for showing a ReadOnlyCollection of Customer in the DgvCustomer DataGridView. Handles empty collection.
        /// </summary>
        /// <param name="customers">ReadOnlyCollection of Customer to be shown.</param>
        private void UpdateDgvCustomer(ReadOnlyCollection<Customer> customers)
        {
            // If the List is not empty show the information, else show a "N/A" row.
            if (customers.Any())
            {
                // Using LINQ Select to project the values we want to display.
                // For each element a new anonymous type object is created with the defined properties,
                // which is then returned as an IEnumerable to be used as DataSource.
                _dgvCustomerBindingSource.DataSource = customers.Select(cust => new
                {
                    Name = cust.Name,
                    CPR = cust.CPR,
                    Address = cust.Address,
                    City = cust.City
                });
            }
            else
            {
                _dgvCustomerBindingSource.DataSource = new { Name = "N/A", CPR = "N/A", Address = "N/A", City = "N/A" };
            }
            DgvCustomer.Columns["Name"].DisplayIndex = 0;
            DgvCustomer.Columns["CPR"].DisplayIndex = 1;
            DgvCustomer.Columns["Address"].DisplayIndex = 2;
            DgvCustomer.Columns["City"].DisplayIndex = 3;
            for (int i = 0; i < DgvCustomer.ColumnCount; i++)
            {
                DgvCustomer.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Making all columns equal size.
            }
        }

        /// <summary>
        /// Method for showing a ReadOnlyCollection of Account in the DgvAccount DataGridView. Handles empty collection.
        /// </summary>
        /// <param name="accounts">ReadOnlyCollection of Account to be shown.</param>
        private void UpdateDgvAccount(ReadOnlyCollection<Account> accounts)
        {
            // If the List is not empty show the information, else show a "N/A" row.
            if (accounts.Any())
            {
                // Using LINQ Select to project the values we want to display.
                // For each element a new anonymous type object is created with the defined properties,
                // which is then returned as an IEnumerable to be used as DataSource.
                _dgvAccountBindingSource.DataSource = accounts.Select(acct => new
                {
                    Type = acct.Type,
                    ID = acct.ID,
                    Balance = string.Format("{0:0.00}", acct.Balance),
                    Owner1 = acct.Owners[0].Name,
                    Owner2 = acct.Owners.Count == 2 ? acct.Owners[1].Name : "None"

                });
            }
            else
            {
                _dgvAccountBindingSource.DataSource = new { Type = "N/A", ID = "N/A", Balance = "N/A", Owner1 = "N/A", Owner2 = "N/A" };
            }
            DgvAccount.Columns["Type"].DisplayIndex = 0;
            DgvAccount.Columns["ID"].DisplayIndex = 1;
            DgvAccount.Columns["Balance"].DisplayIndex = 2;
            DgvAccount.Columns["Owner1"].DisplayIndex = 3;
            DgvAccount.Columns["Owner2"].DisplayIndex = 4;
            DgvAccount.Columns[0].HeaderText = "Account type"; // Setting up more informative header text.
            DgvAccount.Columns[1].HeaderText = "Account ID";
            DgvAccount.Columns[2].HeaderText = "Account balance";
            DgvAccount.Columns[3].HeaderText = "1st account owner";
            DgvAccount.Columns[4].HeaderText = "2nd account owner";
            for (int i = 0; i < DgvAccount.ColumnCount; i++)
            {
                DgvAccount.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Making all columns equal size.
            }
        }

        /// <summary>
        /// Method for showing Transactions for the Account specified in the DgvAccount DataGridView. Handles empty collection.
        /// </summary>
        /// <param name="account">Account to show Transactions for.</param>
        private void UpdateDgvAccountTransactions(Account account)
        {
            if (account.Transactions.Any())
            {
                // Using LINQ Select to project the values we want to display.
                // For each element a new anonymous type object is created with the defined properties,
                // which is then returned as an IEnumerable to be used as DataSource.
                _dgvAccountBindingSource.DataSource = account.Transactions.Select(trans => new
                {
                    TransactionType = trans.Type,
                    Amount = string.Format("{0:0.00}", trans.Amount),
                    Balance = string.Format("{0:0.00}", trans.Balance),
                    Time = trans.DateAndTime.ToString(),
                    Interest = string.Format("{0:0.00}", trans.Interest)
                });

            }
            else
            {
                _dgvAccountBindingSource.DataSource = new { TransactionType = "N/A", Amount = "N/A", Balance = "N/A", Time = "N/A", Interest = "N/A" };
            }
            DgvAccount.Columns["TransactionType"].DisplayIndex = 0;
            DgvAccount.Columns["Amount"].DisplayIndex = 1;
            DgvAccount.Columns["Balance"].DisplayIndex = 2;
            DgvAccount.Columns["Time"].DisplayIndex = 3;
            DgvAccount.Columns["Interest"].DisplayIndex = 4;
            DgvAccount.Columns[0].HeaderText = "Transaction type"; // Setting up more descriptive header text.
            DgvAccount.Columns[1].HeaderText = "Amount";
            DgvAccount.Columns[2].HeaderText = "Balance";
            DgvAccount.Columns[3].HeaderText = "Time";
            DgvAccount.Columns[4].HeaderText = "Interest";
            for (int i = 0; i < DgvAccount.ColumnCount; i++)
            {
                DgvAccount.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Making columns same size.
            }
        }

    }
}