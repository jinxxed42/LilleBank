using Newtonsoft.Json;

namespace LilleBank.Models
{
    internal class Transaction : IComparable<Transaction>
    {
        public decimal Amount { get; set; } // Amount of the Transaction.
        public DateTime DateAndTime { get; set; } // Date and time of the Transaction.
        public string Type { get; set; } // Type of Transaction.

        public decimal Interest { get; set; } // Interest from the last till the current Transaction.

        public decimal Balance { get; set; } // Balance after the Transaction.

        /// <summary>
        /// Constructor. Sets the type to deposit or withdrawal depending if the amount is positive or negative.
        /// </summary>
        /// <param name="amount">Amount deposited or withdrawn.</param>
        /// <param name="dateAndTime">DateTime of the Transaction.</param>
        /// <param name="balance">Balance after the transaction.</param>
        public Transaction(decimal amount, DateTime dateAndTime, decimal balance)
        {
            Amount = amount;
            DateAndTime = dateAndTime;
            Balance = balance;
            if (amount >= 0)
            {
                Type = "Deposit";
            }
            else
            {
                Type = "Withdrawal";
            }
        }

        /// <summary>
        /// Constructor which can specify type - used for interest and fee Transactions.
        /// </summary>
        /// <param name="amount">Amount deposited or withdrawn.</param>
        /// <param name="dateAndTime">DateTime of the Transaction.</param>
        /// <param name="type">Type of Transaction.</param>
        public Transaction(decimal amount, DateTime dateAndTime, string type)
        {
            Amount = amount;
            DateAndTime = dateAndTime;
            Type = type;
        }

        /// <summary>
        /// Constructor that can specify Type and include a Balance after Transaction.
        /// </summary>
        /// <param name="amount">Amount deposited or withdrawn.</param>
        /// <param name="dateAndTime">DateTime of the Transaction.</param>
        /// <param name="type">Type of Transaction.</param>
        /// <param name="balance">Balance after the Transaction.</param>
        public Transaction(decimal amount, DateTime dateAndTime, string type, decimal balance)
        {
            Amount = amount;
            DateAndTime = dateAndTime;
            Type = type;
            Balance = balance;
        }

        /// <summary>
        /// JsonConstructor used for loading data.
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="dateAndTime"></param>
        /// <param name="type"></param>
        /// <param name="interest"></param>
        /// <param name="balance"></param>
        [JsonConstructor]
        public Transaction(decimal amount, DateTime dateAndTime, string type, decimal interest, decimal balance)
        {
            Amount = amount;
            DateAndTime = dateAndTime;
            Type = type;
            Interest = interest;
            Balance = balance;
        }

        /// <summary>
        /// Required by IComparable and used by List.Sort() to ensure Transactions are sorted by Date in ascending order.
        /// Handles null Transactions. Sorts "Interest" or "Withdrawal fee" type Transactions before normal ones.
        /// </summary>
        /// <param name="other">Transaction to be compared against.</param>
        /// <returns>
        /// A value indicating the relative order of the current Transaction compared to another Transaction.
        /// Returns -1 if the current Transaction should be sorted before the other Transaction.
        /// If both are equal additionally checks if the current Transaction is an "Interest" or "Withdrawal fee"
        /// Transaction - if so returns -1 putting current Transaction first. Otherwise if other Transaction is
        /// "Interest" or "Withdrawal fee" it returns 1 putting current Transaction after that. If neither is one of these
        /// Transaction types returns 0 making them equal.
        /// Returns 1 if current Transaction should be sorted after the other Transaction.
        /// </returns>
        public int CompareTo(Transaction? other)
        {
            // By definition, any object compares greater than (or follows) null.
            if (other == null)
            {
                return 1;
            }
            // An Interest or Fee Transaction will be sorted before another Transaction if they occurred at the same time.
            int order = DateAndTime.CompareTo(other.DateAndTime);
            if (order == 0)
            {
                if (Type == "Interest" || Type == "Withdrawal fee")
                {
                    return -1;
                }
                else if (other.Type == "Interest" || other.Type == "Withdrawal fee")
                {
                    return 1;
                }
            }
            return order;
        }
    }
}
