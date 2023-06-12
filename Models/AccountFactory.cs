namespace LilleBank.Models
{
    /// <summary>
    /// Static AccountFactory for creating Accounts according to the Factory method pattern.
    /// </summary>
    internal static class AccountFactory
    {
        /// <summary>
        /// Creates a new account of the specified type.
        /// </summary>
        /// <param name="type">The type of Account to create.</param>
        /// <returns>The created Account.</returns>
        /// <exception cref="ArgumentException">Thrown when the specified account type is not implemented.</exception>
        public static Account CreateAccount(AccountType type)
        {
            switch (type)
            {
                case AccountType.Salary:
                    return new SalaryAccount();
                case AccountType.Housing:
                    return new HousingAccount();
                case AccountType.Savings:
                    return new SavingsAccount();
                case AccountType.Budget:
                    return new BudgetAccount();
                case AccountType.Loan:
                    return new LoanAccount();
                default:
                    throw new ArgumentException("Invalid type - the specified account type is not implemented.");
            }
        }
    }
}
