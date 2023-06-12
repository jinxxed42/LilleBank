using Newtonsoft.Json;

namespace LilleBank.Models
{
    /// <summary>
    /// Budget Account derived from the Account class.
    /// </summary>
    internal class BudgetAccount : Account
    {
        public override string Type { get; protected init; } = "Budget Account"; // Account type.
        protected override decimal MinBalance { get; set; } = -10000M; // Minimum Balance of Account.

        /// <summary>
        /// Base constructor.
        /// </summary>
        public BudgetAccount() : base()
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
        public BudgetAccount(Guid id, string type, List<Customer> owners, decimal balance, List<Transaction> transactions) : base(id, type, owners, balance, transactions)
        {
        }

    }
}
