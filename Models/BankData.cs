using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LilleBank.Models
{
    /// <summary>
    /// Helper class defining properties used for JSON serialization and deserialization.
    /// </summary>
    internal class BankData
    {
        public List<Account>? Accounts { get; init; }
        public List<Customer>? Customers { get; init; }
    }
}
