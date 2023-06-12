using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text.RegularExpressions;

namespace LilleBank.Models
{
    /// <summary>
    /// Bank class. The main object that stores Account objects and Customer objects, as well
    /// as handles most of the logic.
    /// </summary>
    internal class Bank
    {
        private List<Account> _accounts = new List<Account>();
        private List<Customer> _customers = new List<Customer>();

        /// <summary>
        /// ReadOnlyCollection to prevent outside modification of the List of Account.
        /// </summary>
        public ReadOnlyCollection<Account> Accounts
        {
            get { return _accounts.AsReadOnly(); }
        }

        /// <summary>
        /// ReadOnlyCollection to prevent outside modification of the List of Customer.
        /// </summary>
        public ReadOnlyCollection<Customer> Customers
        {
            get { return _customers.AsReadOnly(); }
        }

        /// <summary>
        /// Uses AccountFactory to create the selected type of Account for the Customer with the provided CPR if that person exists, 
        /// and adds the Customer as owner of the Account, then sorts the Account List to maintain alphabetical order.
        /// </summary>
        /// <param name="cpr">CPR number of Customer.</param>
        /// <param name="type">AccountType to be created.</param>
        /// <returns>Result object - Containing a bool to indicate success or failure as well as a message.</returns>
        public Result CreateAccount(string cpr, AccountType type)
        {
            if (!IsValidCPR(cpr))
            {
                return new Result(false, $"{cpr} is not a valid CPR.");
            }

            Customer? customer = _customers.Find(cust => cust.CPR == cpr);
            if (customer == null)
            {
                return new Result(false, $"No customer with CPR: {cpr} could be found.");
            }

            try
            {
                Account account = AccountFactory.CreateAccount(type);
                account.AddOwner(customer);
                _accounts.Add(account);
                _accounts.Sort();
                return new Result(true, $"{account.Type} for customer {customer.Name} with CPR: {customer.CPR} was created.");
            }
            catch (ArgumentException ex)
            {
                return new Result(false, ex.Message);
            }
        }

        /// <summary>
        /// Removes the specified Account if possible. Must be called with an Account object, not null.
        /// </summary>
        /// <param name="account">Account to be deleted.</param>
        /// <returns>Result object - Containing a bool to indicate success or failure as well as a message.</returns>
        public Result DeleteAccount(Account account)
        {
            if (_accounts.Remove(account))
            {
                return new Result(true, $"{account.Type} with ID: {account.ID} has been deleted.");
            }
            return new Result(false, $"{account.Type} with ID: {account.ID} could not be deleted. There might be an issue with the object references. You should contact IT-support.");
        }

        /// <summary>
        /// Tries adding the Customer specified by CPR to the Account specified by Guid.
        /// Checks for valid CPR and valid Guid.
        /// Will fail if the Customer is already an owner of the Account.
        /// Uses the AddOwner method of the specified Account which checks if the Account already has two owners.
        /// </summary>
        /// <param name="cpr">CPR of Customer.</param>
        /// <param name="guid">Guid of Account.</param>
        /// <returns>Result object - Containing a bool to indicate success or failure as well as a message.</returns>
        public Result AddOwnerToAccount(string cpr, string guid)
        {
            if (!IsValidCPR(cpr))
            {
                return new Result(false, $"{cpr} is not a valid CPR.");
            }
            if (!Guid.TryParse(guid, out Guid parsedGuid))
            {
                return new Result(false, $"{guid} is not a valid Guid.");
            }

            Account? account = _accounts.Find(acct => acct.ID == parsedGuid);
            if (account == null)
            {
                return new Result(false, $"No account with Guid: {guid} exists.");
            }

            Customer? customer = _customers.Find(cust => cust.CPR == cpr);
            if (customer == null)
            {
                return new Result(false, $"No customer with CPR: {cpr} exist.");
            }

            if (account.FindOwner(customer)) // Using Account class since Owners can only be accessed outside as ReadOnlyCollection.
            {
                return new Result(false, $"Customer {customer.Name} with CPR: {customer.CPR} is already an owner of {account.Type} with ID: {account.ID}.");
            }
            if (account.AddOwner(customer)) // Using Account class since Owners can only be accessed outside as ReadOnlyCollection.
            {
                return new Result(true, $"Customer {customer.Name} with CPR: {customer.CPR} has been added as owner to {account.Type} with ID: {account.ID}.");
            }
            return new Result(false, $"Account already has two owners. {customer.Name} with CPR: {customer.CPR} not added as owner.");
        }

        /// <summary>
        /// Finds the Account specified by Guid and the Customer specified by CPR. If both are found then it attempts
        /// to remove the Customer as Account owner through the RemoveOwner method in Account.
        /// </summary>
        /// <param name="cpr">CPR of Customer.</param>
        /// <param name="guid">Guid of Account.</param>
        /// <returns>Result object - Containing a bool to indicate success or failure as well as a message.</returns>
        public Result RemoveOwnerFromAccount(string cpr, string guid)
        {
            if (!IsValidCPR(cpr))
            {
                return new Result(false, $"{cpr} is not a valid CPR.");
            }
            if (!Guid.TryParse(guid, out Guid parsedGuid))
            {
                return new Result(false, $"{guid} is not a valid Guid.");
            }

            Account? account = _accounts.Find(acct => acct.ID == parsedGuid);
            if (account == null)
            {
                return new Result(false, $"No account with Guid: {guid} exist.");
            }

            Customer? customer = _customers.Find(cust => cust.CPR == cpr);
            if (customer == null)
            {
                return new Result(false, $"No customer with CPR: {cpr} exist.");
            }

            if (account.RemoveOwner(customer)) // Using Account class since Owners can only be accessed outside as ReadOnlyCollection.
            {
                _accounts.Sort(); // Sorting to ensure Account List remains in alphabetical order.
                return new Result(true, $"Customer: {customer.Name} with CPR: {customer.CPR} was removed as owner of {account.Type} with ID: {account.ID}.");
            }
            return new Result(false, $"Customer: {customer.Name} with CPR: {customer.CPR} was not removed as owner of {account.Type} with ID: {account.ID}. Either (s)he is not owner, or the sole owner.");
        }

        /// <summary>
        /// Validates the input parameters and creates a new Customer if all input is valid and the provided CPR is not already in use.
        /// <param name="name">Name of Customer.</param>
        /// <param name="cpr">CPR of Customer.</param>
        /// <param name="address">Address of Customer.</param>
        /// <param name="city">City of Customer.</param>
        /// <returns>Result object - Containing a bool to indicate success or failure as well as a message.</returns>
        public Result CreateCustomer(string name, string cpr, string address, string city)
        {
            if (!IsValidCPR(cpr))
            {
                return new Result(false, $"{cpr} is not a valid CPR.");
            }
            if (!IsValidName(name))
            {
                return new Result(false, $"{name} is not a valid name.");
            }
            if (!IsValidAddress(address))
            {
                return new Result(false, $"{address} is not a valid address.");
            }
            if (!IsValidCity(city))
            {
                return new Result(false, $"{city} is not a valid postcode and city.");
            }
            if (_customers.Any(cust => cust.CPR == cpr))
            {
                return new Result(false, $"CPR: {cpr} is already in use.");
            }
            Customer customer = new(name, cpr, address, city);
            _customers.Add(customer);
            _customers.Sort(); // Sorting to maintain alphabetical order of Customer List.
            return new Result(true, $"Customer has been created:\nName: {name}\nCPR: {cpr}\nAddress: {address}\nCity: {city}");
        }

        /// <summary>
        /// Deletes the Customer and all related single owner Accounts. If for any reason unable to remove the Customer as
        /// Owner of an Account or unable to delete single-owner Account it will make sure to add this to the message returned.
        /// </summary>
        /// <param name="customer">Customer to be deleted.</param>
        /// <returns>Result object - Containing a bool to indicate success or failure as well as a message.</returns>
        public Result DeleteCustomer(Customer customer)
        {
            string errorMsg = "";
            bool isSuccess = true;

            // Finding all Accounts where the Customer is an owner.
            List<Account> accountsToRemove = _accounts.FindAll(account => account.Owners.Contains(customer));

            foreach (Account account in accountsToRemove)
            {
                if (account.Owners.Count == 1)
                {
                    if (!_accounts.Remove(account))
                    {
                        isSuccess = false;
                        errorMsg += $"Failed to remove {account.Type} with Guid: {account.ID}.\n";
                    }
                }
                else
                {
                    if (!account.RemoveOwner(customer))
                    {
                        isSuccess = false;
                        errorMsg += $"Failed to remove {customer.Name} with CPR: {customer.CPR} as owner of {account.Type} with Guid: {account.ID}.\n";
                    }
                }
            }
            _customers.Remove(customer);
            if (isSuccess)
            {
                return new Result(true, $"Customer {customer.Name} with CPR: {customer.CPR} and all associated single owner accounts have been deleted.");
            }
            else
            {
                return new Result(true, $"Customer {customer.Name} with CPR: {customer.CPR} deleted. However there was an issue with the following accounts. You might want to contact IT-support:\n\n{errorMsg}");
            }
        }

        /// <summary>
        /// Validates input and if checks if a Customer with the given CPR exists. Also checks if a newly entered CPR is
        /// already in use or if no details where changed. If all input is valid a new Customer with updated info is created
        /// and for all Accounts with the original Customer as Owner that is updated to the new Customer.
        /// Reverts changes if something goes wrong along the way.
        /// </summary>
        /// <param name="oldCpr">Old CPR of the Customer.</param>
        /// <param name="name">Updated name.</param>
        /// <param name="cpr">Updated CPR.</param>
        /// <param name="address">Updated address.</param>
        /// <param name="city">Updated city.</param>
        /// <returns>Result object - Containing a bool to indicate success or failure as well as a message.</returns>
        public Result UpdateCustomer(string oldCpr, string name, string cpr, string address, string city)
        {
            if (!IsValidCPR(cpr))
            {
                return new Result(false, $"{cpr} is an invalid CPR number.");
            }
            if (!IsValidName(name))
            {
                return new Result(false, $"{name} is not a valid name.");
            }
            if (!IsValidAddress(address))
            {
                return new Result(false, $"{address} is not a valid address.");
            }
            if (!IsValidCity(city))
            {
                return new Result(false, $"{city} is not a valid postcode and city.");
            }

            Customer? customer = _customers.Find(cust => cust.CPR == oldCpr);

            if (customer == null)
            {
                return new Result(false, $"Update failed. No customer with CPR {oldCpr} was found.");
            }
            else if (cpr != oldCpr && _customers.Find(cust => cust.CPR == cpr) != null)
            {
                return new Result(false, $"Update failed. The specified CPR {cpr} is already in use.");
            }
            else if (name == customer.Name && cpr == customer.CPR && address == customer.Address && city == customer.City)
            {
                return new Result(false, "Update failed. You didn't change any details.");
            }

            Customer updatedCustomer = new Customer(name, cpr, address, city);

            // Finds all accounts for which the Customer to be updated is one of the owners.
            // Lambda expression with a ternary operator. If an Account has two owners it looks for a match with both owners,
            // otherwise it only compares the first owner.
            List<Account> ownedAccounts = _accounts.FindAll(acct =>
                acct.Owners.Count == 2
                ? acct.Owners[0] == customer || acct.Owners[1] == customer
                : acct.Owners[0] == customer);

            // Updating the Customer for all Accounts that Customer owns, but making sure we can revert to the
            // original Customer as Owner in case any updates fail before we are done.
            for (int i = 0; i < ownedAccounts.Count(); i++)
            {
                if (!ownedAccounts[i].UpdateOwner(customer, updatedCustomer))
                {
                    bool isReverted = true;
                    string revertFailureMsg = "";
                    for (int j = 0; j <= i; j++)
                    {
                        if (!ownedAccounts[j].UpdateOwner(updatedCustomer, customer))
                        {
                            // It would be for few accounts so we use direct concatenation over StringBuilder.
                            revertFailureMsg += $"{ownedAccounts[j].Type} with Guid {ownedAccounts[j].ID}.\n";
                            isReverted = false;
                        }
                    }
                    if (isReverted)
                    {
                        return new Result(false, $"Something went wrong with updating accounts for specified customer: {name} with CPR: {cpr}. Changes have been reverted.");
                    }
                    return new Result(false, $"Something went wrong with updating accounts for specified customer: {name} with CPR: {cpr}. Changes have been attempted reverted, but there was problems with the following accounts - Contact IT-Support:\n\n{revertFailureMsg}");
                }
            }
            _customers.Remove(customer);
            _customers.Add(updatedCustomer);
            _customers.Sort(); // Making sure Customer List and Account List are still in alphabetical order.
            _accounts.Sort();
            return new Result(true, "Update of Customer information completed.");
        }

        /// <summary>
        /// Finds the Customer specified by CPR in the List of Customers.
        /// </summary>
        /// <param name="cpr">CPR of Customer to be found.</param>
        /// <returns>ResultData indicating success or failure, including a message and Customer/null.</returns>
        public ResultData<Customer> FindCustomerByCPR(string cpr)
        {
            string message;

            if (!IsValidCPR(cpr))
            {
                message = $"{cpr} is not a valid CPR number.";
                return new ResultData<Customer>(false, message, null!);
            }
            else
            {
                Customer? customer = _customers.Find(cust => cust.CPR == cpr);
                if (customer == null)
                {
                    message = $"No customer with CPR: {cpr} could be found.";
                    return new ResultData<Customer>(false, message, null!);
                }
                message = $"Customer: {customer.Name} with CPR: {customer.CPR} found.";
                return new ResultData<Customer>(true, message, customer);
            }
        }

        /// <summary>
        /// Finds Customers that matches the specified name in the full List of Customers.
        /// </summary>
        /// <param name="name">Name of Customer to be found.</param>
        /// <returns>ResultData indicating success or failure, including a message and a ReadOnlyCollection of Customers</returns>
        public ResultData<ReadOnlyCollection<Customer>> FindCustomerByName(string name)
        {
            string message;

            if (!IsValidName(name))
            {
                message = $"{name} is not a valid name.";
                return new ResultData<ReadOnlyCollection<Customer>>(false, message, null!);
            }
            else
            {
                ReadOnlyCollection<Customer> customers = _customers.FindAll(cust => cust.Name == name).AsReadOnly();
                if (!customers.Any())
                {
                    message = $"No customers with name: {name} could be found.";
                    return new ResultData<ReadOnlyCollection<Customer>>(false, message, customers);
                }
                message = $"{customers.Count} matches found.";
                return new ResultData<ReadOnlyCollection<Customer>>(true, message, customers);
            }
        }

        /// <summary>
        /// Finds the Account specified by Guid in the List of Accounts.
        /// </summary>
        /// <param name="guid">Guid of Account to be found.</param>
        /// <returns>ResultData indicating success or failure and including an Account or null.</returns>
        public ResultData<Account> FindAccount(string guid)
        {
            string message;

            if (!_accounts.Any())
            {
                message = "No accounts exist in the database.";
                return new ResultData<Account>(false, message, null!);
            }
            if (!Guid.TryParse(guid, out Guid parsedGuid))
            {
                message = $"{guid} is not a valid Guid.";
                return new ResultData<Account>(false, message, null!);
            }

            Account? account = _accounts.Find(acct => acct.ID == parsedGuid);
            if (account != null)
            {
                message = $"Account with Guid: {guid} found.";
                return new ResultData<Account>(true, message, account);
            }
            message = $"No account with Guid: {guid} found.";
            return new ResultData<Account>(false, message, null!);
        }

        /// <summary>
        /// Finds all Accounts of which the Customer provided as parameter is an owner.
        /// </summary>
        /// <param name="customer">Customer to find Accounts for.</param>
        /// <returns>ResultData indicating success or failure, including message and a ReadOnlyCollection of Account.</returns>
        public ResultData<ReadOnlyCollection<Account>> FindAccountsByCustomer(Customer customer)
        {
            string message;

            // Lambda expression with a ternary operator. If the Account has two owners it looks for a match in both owners, 
            // otherwise it only compares with the first owner.
            ReadOnlyCollection<Account> foundAccounts = _accounts.FindAll(acct =>
                acct.Owners.Count == 2 ? acct.Owners[0] == customer || acct.Owners[1] == customer : acct.Owners[0] == customer)
                .AsReadOnly();

            if (!foundAccounts.Any())
            {
                message = $"No accounts found for customer: {customer.Name} with CPR: {customer.CPR}.";
                return new ResultData<ReadOnlyCollection<Account>>(false, message, foundAccounts);
            }
            message = $"Accounts found for customer: {customer.Name} with CPR: {customer.CPR}.";
            return new ResultData<ReadOnlyCollection<Account>>(true, message, foundAccounts);
        }

        /// <summary>
        /// Adds interest for all Accounts in the Account List through the Account class's AddInterest method.
        /// To be used on the first opening day of the year immediately upon opening for adding interest before any 
        /// Transactions are made. Ideally should be run with some kind of scheduling system to always be called
        /// immediately after midnight 1/1 in a new year.
        /// </summary>
        /// <returns>Result object - Containing a bool true if any accounts exist, else false, as well as a message.</returns>
        public Result AddInterest()
        {
            if (!_accounts.Any())
            {
                return new Result(false, "No accounts exist in the database");
            }
            foreach (Account account in _accounts)
            {
                account.AddInterest();
            }
            return new Result(true, "Interest added for all existing accounts with transactions.");
        }

        /// <summary>
        /// Tries finding the Account specified by Guid. If found it uses the Account class's AddInterest method to add
        /// interest for that Account.
        /// </summary>
        /// <param name="guid">Guid of Account</param>
        /// <returns>ResultData indicating success or failure and including an Account or null.</returns>
        public ResultData<Account> AddInterest(string guid)
        {
            ResultData<Account> accountResult = FindAccount(guid);

            if (!accountResult.Success)
            {
                return new ResultData<Account>(false, accountResult.Message, null!);
            }

            accountResult.Data.AddInterest();
            return new ResultData<Account>(true, $"Interest added for {accountResult.Data.Type} with Guid: {guid}, if any.", accountResult.Data);
        }

        /// <summary>
        /// Uses JSON serialization and saves the contents of the Account and Customer Lists into a bankData.json file, 
        /// if there is data in any of the Lists. Will handle exceptions and notify the user of problems.
        /// </summary>
        /// <returns>Result object - Containing a bool to indicate success or failure as well as a message.</returns>
        public Result SaveData()
        {
            if (!_accounts.Any() && !_customers.Any())
            {
                return new Result(false, "No accounts and customers exist in the database. Data won't be saved.");
            }

            // Helper class
            BankData bankLists = new BankData { Accounts = _accounts, Customers = _customers };

            string bankFile = $"{AppDomain.CurrentDomain.BaseDirectory}bankData.json";

            try
            {
                if (!File.Exists(bankFile))
                {
                    File.Create(bankFile).Close();
                }

                string serializedBank = JsonConvert.SerializeObject(bankLists, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, Formatting = Formatting.Indented });

                using (StreamWriter sw = new StreamWriter(bankFile, false))
                {
                    sw.WriteLine(serializedBank);
                }
            }
            catch (JsonException ex)
            {
                return new Result(false, $"An error occurred while serializing bank data to JSON: {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                return new Result(false, $"The application does not have permission to access or create the file: {ex.Message}");
            }
            catch (IOException ex)
            {
                return new Result(false, $"An error occurred while accessing the file: {ex.Message}");
            }
            catch (Exception ex)
            {
                return new Result(false, $"There was an error while saving bank data. Don't close the program if possible and contact IT-support with the following error message:\n\n{ex.Message}");
            }
            return new Result(true, "Accounts and customer data has been saved.");
        }


        /// <summary>
        /// Attempts to load data from the bankData.json file into the Accounts and Customers
        /// Lists respectively. Notifies the user of any errors and exceptions.
        /// </summary>
        /// <returns>Result object - Containing a bool to indicate success or failure as well as a message.</returns>
        public Result LoadData()
        {
            string bankFile = $"{AppDomain.CurrentDomain.BaseDirectory}bankData.json";

            if (!File.Exists(bankFile))
            {
                return new Result(false, "The data file wasn't found. Contact IT-support if the problem persists.");
            }

            string serializedBank;

            try
            {
                using (StreamReader sr = new StreamReader(bankFile))
                {
                    serializedBank = sr.ReadToEnd();
                }

                // Helper class.
                BankData? bankLists = JsonConvert.DeserializeObject<BankData>(serializedBank, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });

                if (bankLists == null || bankLists.Customers == null || bankLists.Accounts == null)
                {
                    return new Result(false, "Seems there is no customer or account data or both in the file. Data won't be loaded. You should contact IT-support.");
                }

                _accounts = bankLists.Accounts;     // If data is successfully loaded add to the Bank lists.
                _customers = bankLists.Customers;

                return new Result(true, "Accounts and customer data loaded successfully.");
            }
            catch (JsonException ex)
            {
                return new Result(false, $"An error occurred while deserializing data from the file. You should contact IT-supprt with this message:\n\n{ex.Message}");
            }
            catch (FileLoadException ex)
            {
                return new Result(false, $"Data file can't be loaded! You should contact IT-support and inform them there was a file load exception:\n\n{ex.Message}");
            }
            catch (Exception ex)
            {
                return new Result(false, $"There was an error while loading the data file. You should contact IT-support with the following error message:\n\n{ex.Message}");
            }
        }

        /// <summary>
        /// Checks if a string is a valid Danish name with two or three words, all starting with capital letters.
        /// </summary>
        /// <param name="name">Name to be checked.</param>
        /// <returns>True if valid name, else false.</returns>
        private bool IsValidName(string name)
        {
            // Looks for two or three words with Danish characters. No special characters or numbers allowed
            // and all words must start with capital letter followed by at least one more letter.
            Regex rg = new Regex(@"^([A-ZÆØÅ][a-zæøå]+\s?){2,3}$");
            return rg.IsMatch(name);
        }

        /// <summary>
        /// Checks if the string provided is a valid Danish CPR number.
        /// </summary>
        /// <param name="cpr">CPR string in the format ddMMyy-xxxx.</param>
        /// <returns>True if valid CPR, else false</returns>
        private bool IsValidCPR(string cpr)
        {
            // Checking if the CPR is in a valid format which is 6 numbers then - and finally 4 numbers of which the first must be 1 or 2 - the century of birth.
            Regex rg = new Regex(@"^\d{6}-[1,2]\d{3}$");
            if (rg.IsMatch(cpr))
            {
                string cprDateFormat = "ddMMyy";
                string toCheck = cpr.Substring(0, 6);
                CultureInfo ci = CultureInfo.CurrentCulture;
                ci.Calendar.TwoDigitYearMax = 2099; // Setting up the CultureInfo so years when parsing are considered years after 2000.
                // Checking if the first 6 numbers are valid
                if (DateTime.TryParseExact(toCheck, cprDateFormat, ci, DateTimeStyles.None, out DateTime dateTime))
                {
                    // Checking if the CPR implies a later date than the current date.
                    // If the date is later than the current it's only valid if the last 4 digits indicates
                    // birth in the 19th century.
                    if (cpr.Substring(7, 1) == "1" || dateTime.Date <= DateTime.Now.Date)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if the string provided is a valid address which is defined as starting with a capital letter, then
        /// at least 4 more lowercase Danish characters and then followed by any Danish character, number, "," or ".".
        /// </summary>
        /// <param name="address">Address to be checked.</param>
        /// <returns>True if valid address, else false.</returns>
        private bool IsValidAddress(string address)
        {
            // Capital letter followed by minimum 4 Danish lowercase characters.
            Regex rg = new Regex(@"^[A-ZÆØÅ][a-zæøå]{4,}[a-zæøåA-Zæøå0-9\s,.]*$");
            return rg.IsMatch(address);
        }

        /// <summary>
        /// Checks if the string provided is a valid city which is defined as a number between 1-9 followed by 3 more,
        /// constituting a Danish postcode, then a space and any amount of letters starting with a capital letter.
        /// </summary>
        /// <param name="city">City to be checked.</param>
        /// <returns>True if valid address, else false.</returns>
        private bool IsValidCity(string city)
        {
            // Digit between 1-9 followed by 3 digits, a space, a capital letter and then anything that isn't a digit.
            Regex rg = new Regex(@"^[1-9]\d{3} [A-ZÆØÅ][^\d]*$");
            return rg.IsMatch(city);
        }
    }
}
