using Newtonsoft.Json;

namespace LilleBank.Models
{
    /// <summary>
    /// Loan Account derived from the Account class.
    /// </summary>
    internal class LoanAccount : Account
    {
        public override string Type { get; protected init; } = "Loan Account"; // Account type.
        protected override decimal MinBalance { get; set; } = -100000000M; // Minimum Balance.
        protected override decimal MaxBalance { get; set; } = 0M; // Maximum Balance.
        protected override decimal NegativeInterestRate { get; set; } = 0.1M; // Interest rate on negative Balance.
        protected override bool IsLoan { get; set; } = true; // True since it's a loan Account.
        protected override bool CanWithdraw { get; set; } = false; // Does not allow withdrawals.

        public LoanAccount() : base()
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
        public LoanAccount(Guid id, string type, List<Customer> owners, decimal balance, List<Transaction> transactions) : base(id, type, owners, balance, transactions)
        {
        }
    }
}
