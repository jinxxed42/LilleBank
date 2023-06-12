using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Globalization;

namespace LilleBank.Models
{
    /// <summary>
    /// Abstract class that implements an Account.
    /// </summary>
    internal abstract class Account : IComparable<Account>
    {
        protected List<Customer> _owners = new List<Customer>(); // List of Customers that are owners of the Account
        protected List<Transaction> _transactions = new List<Transaction>(); // List of Transactions of the Account.

        public abstract string Type { get; protected init; } // Account type. Must be defined in derived classes.

        public Guid ID { get; protected init; } // Guid to provide a unique identifier. 

        public decimal Balance { get; protected set; } = 0M; // Current Account balance.

        // Returning a ReadOnlyCollection to prevent outside modification of the Owners.
        public ReadOnlyCollection<Customer> Owners
        {
            get { return _owners.AsReadOnly(); }
        }

        // Returning a ReadOnlyCollection to prevent outside modification of the Transactions.
        public ReadOnlyCollection<Transaction> Transactions
        {
            get { return _transactions.AsReadOnly(); }
        }

        protected virtual decimal MinBalance { get; set; } = -10000M; // The minimum balance of the Account.

        protected virtual decimal MaxBalance { get; set; } = 100000000M; // The maximum balance of the Account.

        protected virtual decimal NegativeInterestLimit { get; set; } = 0M; // Below this limit the Account will give negative interest.

        protected virtual decimal PositiveInterestLimit { get; set; } = 0M; // Above this limit the Account will give positive interest.

        protected virtual decimal InterestRate { get; set; } = 0M; // Default interest rate if the balance is positive is above the positive interest limit.

        protected virtual decimal NegativeInterestRate { get; set; } = 0.15M; // Default interest rate if the balance is below the negative interest limit.

        protected virtual bool WithDrawalLimits { get; set; } = false; // False if the account allows unlimited withdrawals without fee, else true.

        protected virtual int MaxNumOfWithdrawals { get; set; } = 1; // Maximum number of withdrawals allowed before incuring a fee.

        protected virtual decimal ExtraWithdrawalFee { get; set; } = -100M; // The fee if exceeding the maximum number of withdrawals.

        protected virtual bool IsLoan { get; set; } = false; // Is it considered a Loan Account?

        protected virtual bool CanWithdraw { get; set; } = true; // Can you withdraw from the Account? Used with loans.

        /// <summary>
        /// Constructur. Assigns a random Guid to the Account upon creation.
        /// </summary>
        public Account()
        {
            ID = Guid.NewGuid();
        }

        /// <summary>
        /// JsonConstructor used for loading data from the Json files.
        /// </summary>
        /// <param name="id">Id for the Account.</param>
        /// <param name="type">Type of Account.</param>
        /// <param name="owners">List of Customers that own the Account.</param>
        /// <param name="balance">Balance of the Account.</param>
        /// <param name="transactions">List of Transactions for the Account.</param>
        [JsonConstructor]
        public Account(Guid id, string type, List<Customer> owners, decimal balance, List<Transaction> transactions)
        {
            ID = id;
            Type = type;
            _owners = owners;
            Balance = balance;
            _transactions = transactions;
        }

        /// <summary>
        /// Updates the Customer data for an Owner of the Account. Keeps the index in the list of owners.
        /// </summary>
        /// <param name="customer">Old customer data</param>
        /// <param name="updatedCustomer">Updated customer data</param>
        /// <returns>True if successful, false if not.</returns>
        public bool UpdateOwner(Customer customer, Customer updatedCustomer)
        {
            int ownerIndex = _owners.FindIndex(cust => cust == customer);
            if (ownerIndex == -1) // Customer wasn't found.
            {
                return false;
            }
            _owners.Remove(customer);
            _owners.Insert(ownerIndex, updatedCustomer);
            return true;
        }

        /// <summary>
        /// Checks if the specified Customer is an Owner of the Account.
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <returns>True if Owner, else false</returns>
        public bool FindOwner(Customer customer)
        {
            return _owners.Any(cust => cust == customer);
        }

        /// <summary>
        /// Adds the specified Customer as owner to the Account if the Account has only 1 owner.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>True if successful, else false</returns>
        public bool AddOwner(Customer customer)
        {
            if (_owners.Count == 2)
            {
                return false;
            }
            _owners.Add(customer);
            return true;
        }

        /// <summary>
        /// Removes the specified Customer as owner of the Account if there are 2 owners and the Customer is one of them.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>True if successful, else false</returns>
        public bool RemoveOwner(Customer customer)
        {
            return _owners.Count == 2 ? _owners.Remove(customer) : false;
        }

        /// <summary>
        /// Performs a deposit or withdrawal from the Account based on the provided amount.
        /// Checks for valid amount as input. Also checks transaction restrictions, and balance limits through helper
        /// methods. Adds a fee if the maximum number of withdrawals is exceeded.
        /// Finally calls CalculateInterest to update the interest on the Account.
        /// </summary>
        /// <param name="amount">The amount to be deposited or withdrawn.</param>
        /// <returns>A Result object indicating the success or failure of the Transaction.</returns>
        public Result DepositOrWithdraw(string amount)
        {
            if (amount == "0" || !decimal.TryParse(amount, out decimal parsedAmount))
            {
                return new Result(false, $"{amount} is not a valid value that is non-zero.");
            }

            DateTime dateTime = DateTime.Now;

            // Check if exceeding balance limits on the Account.
            if (!IsBalanceWithinLimits(parsedAmount))
            {
                return new Result(false, $"You are exceeding the balance limits on the account. For an account of type: {Type} they are {MinBalance} and {MaxBalance}.");
            }

            if (IsLoan)
            {
                if (!_transactions.Any())
                {
                    if (parsedAmount > 0)
                    {
                        return new Result(false, $"The first transaction for a {Type} must be a negative value - the loan amount.");
                    }
                    AddInitialLoanTransaction(parsedAmount, dateTime);
                    return new Result(true, $"Initial loan of {-parsedAmount} added to {Type} with ID: {ID}.");
                }
            }

            if (!CanWithdraw && parsedAmount < 0)
            {
                return new Result(false, $"You can't withdraw from an account of type: {Type}.");
            }

            if (IsDuplicateTransaction(dateTime))
            {
                return new Result(false, "You can't make two transactions at the exact same time.");
            }

            string fee = "";

            // If there's a limit on the maximum number of withdrawals and the number is being exceeded
            // then add a fee.
            if (WithDrawalLimits && parsedAmount < 0 && ExceedsMaxNumOfWithdrawals(dateTime))
            {
                if (!IsBalanceWithinLimits(parsedAmount + ExtraWithdrawalFee))
                {
                    return new Result(false, $"With the fee of {ExtraWithdrawalFee}kr the account will go below the minimum balance of {MinBalance}kr.");
                }
                fee = $"\n\nMaximum number of withdrawals for current month have been exceeded and a fee of {ExtraWithdrawalFee}kr has been added.";
                AddWithdrawalFeeUpdateBalance(dateTime);
            }
            Balance += parsedAmount;

            AddTransaction(parsedAmount, dateTime);

            CalculateInterest();

            return new Result(true, $"Transaction of {amount}kr for {Type} with ID: {ID} has been completed.{fee}");
        }

        /// <summary>
        /// Performs a deposit or withdrawal from the Account based on the provided amount and at the specified time.
        /// Checks for valid amount and DateTime as input. The DateTime format should be dd-MM-yyyy with time xx:xx:xx optional.
        /// If no specific time is entered default will be 00:00:00. Also checks transaction restrictions, and balance limits 
        /// through helper methods. Adds a fee if the maximum number of withdrawals is exceeded.
        /// Finally calls CalculateInterest with the DateTime of the Transaction to update the interest on the Account.
        /// </summary>
        /// <param name="amount">The amount to be deposited or withdrawn.</param>
        /// <param name="dateTime">The DateTime of the Transaction.</param>
        /// <returns>A Result object indicating the success or failure of the Transaction.</returns>
        public Result DepositOrWithdraw(string amount, string dateTime)
        {
            if (amount == "0" || !decimal.TryParse(amount, out decimal parsedAmount))
            {
                return new Result(false, $"{amount} is not a valid value that is non-zero.");
            }

            string[] formats = { "dd-MM-yyyy", "dd-MM-yyyy HH:mm:ss" };

            if (!DateTime.TryParseExact(dateTime, formats, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime parsedDateTime) || parsedDateTime > DateTime.Now)            
            {
                return new Result(false, "The date and time is not valid. It's either wrong format, an invalid date or in the future. The format is dd-MM-yyyy and optional time: xx:xx:xx. Default time is 00:00:00.");
            }

            if (!IsBalanceWithinLimits(parsedAmount, parsedDateTime))
            {
                return new Result(false, $"You are exceeding the balance limits on the account. For an account of type: {Type} they are {MinBalance} and {MaxBalance}.");
            }

            if (IsLoan)
            {
                if (!_transactions.Any())
                {
                    if (parsedAmount > 0)
                    {
                        return new Result(false, $"The first transaction for a {Type} must be a negative value - the loan amount.");
                    }
                    AddInitialLoanTransaction(parsedAmount, parsedDateTime);
                    return new Result(true, $"Initial loan of {-parsedAmount} added to {Type} with ID: {ID}.");
                }
            }

            if (!CanWithdraw && parsedAmount < 0)
            {
                return new Result(false, $"You can't withdraw from an account of type: {Type}.");
            }

            if (IsDuplicateTransaction(parsedDateTime))
            {
                return new Result(false, "You can't make two transactions at the exact same time.");
            }

            string fee = "";

            if (WithDrawalLimits && parsedAmount < 0 && ExceedsMaxNumOfWithdrawals(parsedDateTime))
            {
                decimal totalAmount = parsedAmount + ExtraWithdrawalFee;
                // Checking if the balance limit on the account is exceeded at the time of transaction or
                // at the final balance.
                if (!IsBalanceWithinLimits(totalAmount) || !IsBalanceWithinLimits(totalAmount, parsedDateTime))
                {
                    return new Result(false, $"With the fee of {ExtraWithdrawalFee}kr, the account will go below the minimum balance of {MinBalance}kr.");
                }

                fee = $"\n\nMaximum number of withdrawals for the current month has been exceeded, and a fee of {ExtraWithdrawalFee}kr has been added.";
                AddWithdrawalFee(parsedDateTime);
            }

            Balance += parsedAmount;
            AddTransaction(parsedAmount, parsedDateTime);
            _transactions.Sort(); // Sort to ensure correct order of Transactions.
            UpdateTransactionBalances(parsedDateTime.Year); // Update all Transaction Balances from the time of the Transaction.

            CalculateInterest(parsedDateTime);

            return new Result(true, $"Transaction of {parsedAmount}kr for {Type} with ID: {ID} has been completed.{fee}");
        }

        /// <summary>
        /// Adds a Withdrawal Fee Transaction with value of the ExtraWithdrawalFee property. 
        /// To be used with Deposit or Withdraw when the Transaction is made
        /// at any given time. Balances must be updated afterwards.
        /// </summary>
        /// <param name="dateTime">DateTime of the Transaction.</param>
        protected void AddWithdrawalFee(DateTime dateTime)
        {
            _transactions.Add(new Transaction(ExtraWithdrawalFee, dateTime, "Withdrawal fee"));
        }

        /// <summary>
        /// Adds a Withdrawal Fee Transaction with value of the ExtraWithdrawlFee property and updates the Balance 
        /// of the Account. To be used with Deposit or Withdraw when it's the latest Transaction.
        /// </summary>
        /// <param name="dateTime">DateTime of the Transaction.</param>
        protected void AddWithdrawalFeeUpdateBalance(DateTime dateTime)
        {
            Balance += ExtraWithdrawalFee;
            _transactions.Add(new Transaction(ExtraWithdrawalFee, dateTime, "Withdrawal fee", Balance));
        }

        /// <summary>
        /// Adds a Transaction to the Account with the specified values.
        /// </summary>
        /// <param name="amount">Amount of Transaction.</param>
        /// <param name="dateTime">DateTime of Transaction.</param>
        /// <param name="type">Type of Transaction.</param>
        /// <param name="interest">Interest from last Transaction till this.</param>
        /// <param name="balance">Balance after the Transaction.</param>
        protected void AddTransaction(decimal amount, DateTime dateTime, string type, decimal interest, decimal balance)
        {
            _transactions.Add(new Transaction(amount, dateTime, type, interest, balance));
        }

        /// <summary>
        /// Adds a Transaction to the Account with the specified values.
        /// </summary>
        /// <param name="amount">Amount of Transaction.</param>
        /// <param name="dateTime">DateTime of Transaction.</param>
        protected void AddTransaction(decimal amount, DateTime dateTime)
        {
            _transactions.Add(new Transaction(amount, dateTime, Balance));
        }

        /// <summary>
        /// Adds the initial loan Transaction to the Account with the specified values.
        /// To be used with Accounts with IsLoan property true.
        /// </summary>
        /// <param name="amount">Amount of Transaction.</param>
        /// <param name="dateTime">DateTime of Transaction.</param>
        protected void AddInitialLoanTransaction(decimal amount, DateTime dateTime)
        {
            AddTransaction(amount, dateTime, "Loan", 0, amount);
            Balance += amount;
            // If not in current year we need to calculate interest until current year.
            if (dateTime.Year != DateTime.Now.Year)
            {
                CalculateInterest(dateTime);
            }
        }

        /// <summary>
        /// Method for adding interest for last year. Will not do anything if interest was already added or if there
        /// was no Transactions in the Account.
        /// </summary>
        public void AddInterest()
        {
            int year = DateTime.Now.Year;
            if (_transactions.Any(trans => trans.Type == "Interest" && trans.DateAndTime.Year == year))
            {
                return;
            }

            List<Transaction> lastYearTransactions = _transactions.FindAll(trans => trans.DateAndTime.Year == year - 1);

            // If no transactions last year then nothing has happened in the account, because interest
            // is added yearly, and thus there is no interest to add.
            if (lastYearTransactions.Any())
            {
                DateTime endDay = new DateTime(year, 1, 1, 0, 0, 0);
                Transaction lastTransaction = lastYearTransactions.Last(); // Will find something due to Any() check.
                decimal startBalance = lastTransaction.Balance;
                // The year until last transaction. Since interest already is calculated between all Transactions we can just sum.
                decimal interestForYear = lastYearTransactions.Sum(trans => trans.Interest);
                decimal interestForLastPeriod = CalculateInterestForLastPeriod(lastTransaction, startBalance, year, endDay);

                decimal totalInterest = interestForYear + interestForLastPeriod;
                decimal endBalance = startBalance + totalInterest;

                AddTransaction(totalInterest, endDay, "Interest", interestForLastPeriod, endBalance);
                Balance += totalInterest;
            }
        }

        /// <summary>
        /// Calculates interest between the two last Transactions.
        /// </summary>
        protected void CalculateInterest()
        {
            int count = _transactions.Count;

            if (count == 1) // If only one transaction there's no interest to calculate.
            {
                return;
            }

            int endIndex = count - 1;
            int startIndex = endIndex - 1;

            // If there's a withdrawal fee there's made a withdrawal at the exact same time,
            // so we calculate from 1 index earlier in the List.           
            if (_transactions[startIndex].Type == "Withdrawal fee")
            {
                endIndex--;
                startIndex--;
            }

            Transaction previousTransaction = _transactions[startIndex];
            Transaction currentTransaction = _transactions[endIndex];

            decimal daysInYear = DateTime.IsLeapYear(previousTransaction.DateAndTime.Year) ? 366M : 365M; 
            decimal startBalance = previousTransaction.Balance;

            decimal interestRate = GetInterestRate(startBalance);
            decimal calcBalance = GetInterestBalance(startBalance);

            decimal periodDays = (decimal)(currentTransaction.DateAndTime - previousTransaction.DateAndTime).TotalDays;

            decimal interest = calcBalance * interestRate * periodDays / daysInYear;
            currentTransaction.Interest = interest;
        }

        /// <summary>
        /// Calculates or updates interest for the Account from the DateTime provided and onwards. Adds interest 
        /// Transactions for every new year until current year.
        /// </summary>
        /// <param name="dateTime">DateTime of year to be calculated from.</param>
        protected void CalculateInterest(DateTime dateTime)
        {
            int calculationYear = dateTime.Year;
            int currentYear = DateTime.Now.Year;
            _transactions.RemoveAll(trans => trans.Type == "Interest" && trans.DateAndTime.Year > calculationYear);

            while (calculationYear <= currentYear)
            {
                List<Transaction> yearlyTransactions = _transactions.FindAll(trans => trans.DateAndTime.Year == calculationYear);
                decimal totalInterest = CalculateInterestBetweenTransactions(yearlyTransactions, calculationYear);
                // Interest from last transaction till next year and adding interest transaction
                // for all years except current.
                if (calculationYear != currentYear)
                {
                    Transaction lastTransaction = yearlyTransactions.Last(); // Always finds something since we start from year of a transaction and add interest transactions yearly.
                    DateTime startOfNextYear = new DateTime(calculationYear + 1, 1, 1, 0, 0, 0);
                    decimal startBalance = lastTransaction.Balance; // We can be sure a transaction is found in each iteration, since we add interest transactions.

                    decimal interestForLastPeriod = CalculateInterestForLastPeriod(lastTransaction, startBalance, calculationYear, startOfNextYear);
                    totalInterest += interestForLastPeriod;
                    decimal endBalance = startBalance + totalInterest;
                    AddTransaction(totalInterest, startOfNextYear, "Interest", interestForLastPeriod, endBalance);
                    _transactions.Sort(); // Sorting each time a Transaction is added to maintain correct order of the List.             
                    UpdateTransactionBalances(calculationYear + 1); // Update the Transaction balances for the year specified.
                }
                calculationYear++;
            }
            Balance = _transactions.Last().Balance; // Update final Balance of Account.
        }

        /// <summary>
        /// Calculates the interest between all Transactions in the year. The List of Transactions should always
        /// be for the year provided as input. Just returns 0 if less than 2 Transactions for the year.
        /// </summary>
        /// <param name="transactions">List of Transaction to calculate interest between.</param>
        /// <param name="year">Year of Transactions.</param>
        /// <returns>Interest for the period.</returns>
        protected decimal CalculateInterestBetweenTransactions(List<Transaction> transactions, int year)
        {
            decimal daysInYear = DateTime.IsLeapYear(year) ? 366M : 365M; 
            decimal totalInterest = 0;

            for (int i = 1; i < transactions.Count; i++)
            {
                Transaction previousTransaction = transactions[i - 1];
                Transaction currentTransaction = transactions[i];

                decimal startBalance = previousTransaction.Balance;
                decimal interestRate = GetInterestRate(startBalance);
                if (interestRate == 0)
                {
                    currentTransaction.Interest = 0;
                    continue;
                }
                decimal interestBalance = GetInterestBalance(startBalance);
                decimal daysInPeriod = (decimal)(currentTransaction.DateAndTime - previousTransaction.DateAndTime).TotalDays;
                decimal interestForPeriod = interestBalance * interestRate * daysInPeriod / daysInYear;
                currentTransaction.Interest = interestForPeriod;
                totalInterest += interestForPeriod;
            }
            return totalInterest;
        }

        /// <summary>
        /// Calculates interest for the last transaction of the year specified and till the start of next year.
        /// </summary>
        /// <param name="lastTransaction">Last transaction of the year to calculate from.</param>
        /// <param name="startBalance">Balance afterthe Transaction provided.</param>
        /// <param name="year">Year of the Transaction lastTransaction.</param>
        /// <param name="startOfNextYear">First day of next year.</param>
        /// <returns>Interest for the period.</returns>
        protected decimal CalculateInterestForLastPeriod(Transaction lastTransaction, decimal startBalance, int year, DateTime startOfNextYear)
        {
            decimal daysInYear = DateTime.IsLeapYear(year) ? 366M : 365M; 
            decimal interest = 0;

            decimal interestRate = GetInterestRate(startBalance);
            if (interestRate != 0)
            {
                decimal interestBalance = GetInterestBalance(startBalance);
                decimal periodDays = (decimal)(startOfNextYear - lastTransaction.DateAndTime).TotalDays;
                interest = interestBalance * interestRate * periodDays / daysInYear;
            }
            return interest;
        }

        /// <summary>
        /// Method for returning the InterestRate depending on if the Account Balance is above
        /// the PositiveInterestLimit or below the NegativeInterestLimit.
        /// </summary>
        /// <param name="balance">Balance of the Account</param>
        /// <returns>The InterestRate to be used.</returns>
        protected decimal GetInterestRate(decimal balance)
        {
            if (balance > PositiveInterestLimit)
            {
                return InterestRate;
            }
            else if (balance < NegativeInterestLimit)
            {
                return NegativeInterestRate;
            }
            return 0;
        }

        /// <summary>
        /// Method for returning the Balance to calculate interest from. It subtracts the limit whether
        /// PositiveInterestLimit or NegativeInterestLimit and returns the Balance.
        /// </summary>
        /// <param name="balance">Balance to calculate interest from.</param>
        /// <returns>The interest Balance to be used.</returns>
        protected decimal GetInterestBalance(decimal balance)
        {
            if (balance > PositiveInterestLimit)
            {
                return balance - PositiveInterestLimit;
            }
            else if (balance < NegativeInterestLimit)
            {
                return balance - NegativeInterestLimit;
            }
            return 0;
        }

        /// <summary>
        /// Updates all Transaction balances for the year specified. Used when depositing/withdrawing earlier than current
        /// time for ensuring correct balances after deposit/withdraw and for interest calculation.
        /// </summary>
        /// <param name="year">Year to update balances for.</param>
        protected void UpdateTransactionBalances(int year)
        {
            List<Transaction> yearlyTransactionsList = _transactions.FindAll(trans => trans.DateAndTime.Year == year);
            Transaction? priorTransaction = _transactions.FindLast(trans => trans.DateAndTime.Year < year);
            decimal balance = priorTransaction?.Balance ?? 0;
            foreach (Transaction transaction in yearlyTransactionsList)
            {
                balance += transaction.Amount;
                transaction.Balance = balance;
            }
        }

        /// <summary>
        /// Checks if another Transaction exists at the same time for the Account.
        /// </summary>
        /// <param name="dateTime">DateTime to be checked</param>
        /// <returns>true if another Transaction exists at the same time, else false.</returns>
        protected bool IsDuplicateTransaction(DateTime dateTime)
        {
            return _transactions.Any(trans => trans.DateAndTime == dateTime);
        }

        /// <summary>
        /// Checks if the Balance is within the Account limits at specified DateTime after depositing or withdrawing
        /// the specified amount.
        /// </summary>
        /// <param name="amount">Amount to be deposited or withdrawn.</param>
        /// <param name="dateTime">DateTime of the intended Transaction.</param>
        /// <returns>true if within limits, else false.</returns>
        protected bool IsBalanceWithinLimits(decimal amount, DateTime dateTime)
        {
            Transaction? lastTransaction = _transactions.FindLast(trans => trans.DateAndTime < dateTime);
            decimal checkBalance = lastTransaction?.Balance ?? 0M; // Check for null, if null set value to 0.
            decimal totalBalance = checkBalance + amount;
            return totalBalance <= MaxBalance && totalBalance >= MinBalance;
        }

        /// <summary>
        /// Checks if the final Balance is within the Account limits after depositing or withdrawing
        /// the specified amount.
        /// </summary>
        /// <param name="amount">Amount to be deposited or withdrawn.</param>
        /// <returns>true if within limits, else false.</returns>
        protected bool IsBalanceWithinLimits(decimal amount)
        {
            Transaction? lastTransaction = _transactions.LastOrDefault(); // Null if nothing found
            decimal checkBalance = lastTransaction?.Balance ?? 0M; // Check for null, if null set value to 0.
            decimal totalBalance = checkBalance + amount;
            return totalBalance <= MaxBalance && totalBalance >= MinBalance;
        }

        /// <summary>
        /// Checks if the specified maximum number of withdrawals for the Account is being exceeded in the month of the 
        /// DateTime specified.
        /// </summary>
        /// <param name="dateTime">DateTime of month to check.</param>
        /// <returns>true if maximum number of withdrawals are exceeded, else false.</returns>
        protected bool ExceedsMaxNumOfWithdrawals(DateTime dateTime)
        {
            int withdrawalCount = _transactions.Count(trans => trans.Type == "Withdrawal" && trans.DateAndTime.Month == dateTime.Month && trans.DateAndTime.Year == dateTime.Year);
            return withdrawalCount >= MaxNumOfWithdrawals;
        }
       
        /// <summary>
        /// Required by IComparable. Used by List.Sort() to ensure Accounts are sorted by alphabetical 1st Owner names.
        /// They are furthermore sorted by Account type for the same Owner.
        /// </summary>
        /// <param name="other">Account to be compared against.</param>
        /// <returns>
        /// A value indicating the relative order of the current Account compared to another Account.
        /// Returns -1 if the current Account should be sorted before the other Account.
        /// Returns 0 if both Accounts should be considered equal in terms of sorting order.
        /// Returns 1 if the current Account should be sorted after the other Account.
        /// </returns>
        public int CompareTo(Account? other)
        {
            // By definition, any object compares greater than (or follows) null.
            if (other is null)
            {
                return 1;
            }

            int ownerNameComparison = string.Compare(Owners[0].Name, other.Owners[0].Name); // Compare 1st Owner names
            return ownerNameComparison != 0 ? ownerNameComparison : string.Compare(Type, other.Type); // If equal compare Account Types
        }
    }
}
