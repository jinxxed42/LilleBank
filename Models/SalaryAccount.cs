using Newtonsoft.Json;

namespace LilleBank.Models
{
    /// <summary>
    /// Salary Account derived from the Account class.
    /// </summary>
    internal class SalaryAccount : Account
    {
        public override string Type { get; protected init; } = "Salary Account"; // Account type
        protected override decimal InterestRate { get; set; } = 0.01M; // Positive interest rate if above limit.
        protected override decimal NegativeInterestRate { get; set; } = 0.15M; // Negative interest rate.
        protected override decimal PositiveInterestLimit { get; set; } = 20000M; // Limit - above this positive interest is given.

        /// <summary>
        /// Base constructor.
        /// </summary>
        public SalaryAccount() : base()
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
        public SalaryAccount(Guid id, string type, List<Customer> owners, decimal balance, List<Transaction> transactions) : base(id, type, owners, balance, transactions)
        {
        }



    }
}
