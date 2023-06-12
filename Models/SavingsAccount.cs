using Newtonsoft.Json;

namespace LilleBank.Models
{
    /// <summary>
    /// Savings Account derived from the Account class.
    /// </summary>
    internal class SavingsAccount : Account
    {
        public override string Type { get; protected init; } = "Savings Account"; // Account type.
        protected override decimal MinBalance { get; set; } = 0M; // Minimum Balance of the Account.
        protected override decimal InterestRate { get; set; } = 0.02M; // Positive interest rate.
        protected override bool WithDrawalLimits { get; set; } = true; // True since the Account does not allow unlimited withdrawals without fee.

        /// <summary>
        /// Base constructor.
        /// </summary>
        public SavingsAccount() : base()
        {
        }       

        /// <summary>
        /// JsonConstructor. Uses the JsonConstructor base from the abstract Account class. Used for loading JSON data.
        /// </summary>
        /// <param name="id">Id for the Account.</param>
        /// <param name="type">Type of Account.</param>
        /// <param name="owners">List of Customers that own the Account.</param>
        /// <param name="balance">Balance of the Account.</param>
        /// <param name="transactions">List of Transactions for the Account.</param>
        [JsonConstructor]
        public SavingsAccount(Guid id, string type, List<Customer> owners, decimal balance, List<Transaction> transactions) : base(id, type, owners, balance, transactions)
        {
        }

    }
}
