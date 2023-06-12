using Newtonsoft.Json;

namespace LilleBank.Models
{
    /// <summary>
    /// Customer object. Implements IEquatable and two Customers are the same if their CPR is the same, since it's a unique ID.
    /// </summary>
    /// 
    internal class Customer : IEquatable<Customer>, IComparable<Customer>
    {

        public string Name { get; protected set; } // Name of the Customer.
        public string CPR { get; protected set; } // CPR of the Customer.
        public string Address { get; protected set; } // Address of the Customer.
        public string City { get; protected set; } // City of the Customer.

        /// <summary>
        /// Constructor. Also specified as JsonConstructor.
        /// </summary>
        [JsonConstructor]
        public Customer(string name, string cpr, string address, string city)
        {
            Name = name;
            CPR = cpr;
            Address = address;
            City = city;
        }

        /// <summary>
        /// Overrides the Equals method of the base object class.
        /// Checks if the specified object is equal to the current Customer object.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>true if the specified object is equal to the current Customer object, false otherwise.</returns>
        public override bool Equals(object? obj)
        {
            return Equals(obj as Customer);
        }

        /// <summary>
        /// Equality comparison for two Customers. They are the same if their CPR is the same.
        /// </summary>
        /// <param name="other">The Customer object to compare.</param>
        /// <returns>true if the Customers are equal, false otherwise.</returns>
        public bool Equals(Customer? other)
        {
            return other != null &&
                   CPR == other.CPR;
        }

        /// <summary>
        /// Overrides the == operator for comparing two Customer instances.
        /// </summary>
        /// <param name="left">The left operand of the comparison.</param>
        /// <param name="right">The right operand of the comparison.</param>
        /// <returns>true if the left and right operands are equal, otherwise false.</returns>
        public static bool operator ==(Customer? left, Customer? right)
        {
            return EqualityComparer<Customer>.Default.Equals(left, right);
        }

        /// <summary>
        /// Overrides the != operator for comparing two Customer instances.
        /// </summary>
        /// <param name="left">The left operand of the comparison.</param>
        /// <param name="right">The right operand of the comparison.</param>
        /// <returns>true if the left and right operands are not equal, otherwise false.</returns>
        public static bool operator !=(Customer? left, Customer? right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Required by IComparable. Used by List.Sort() to ensure Customers are sorted by alphabetical names.
        /// </summary>
        /// <param name="other">Customer to be compared against.</param>
        /// <returns>
        /// A value indicating the relative order of the current Customer compared to another Customer.
        /// Returns -1 if the current Customer should be sorted before the other Customer.
        /// Returns 0 if both Customers should be considered equal in terms of sorting order.
        /// Returns 1 if the current Customer should be sorted after the other Customer.
        /// </returns>
        public int CompareTo(Customer? other)
        {
            // By definition, any object compares greater than (or follows) null.
            if (other == null)
            {
                return 1;
            }
            return string.Compare(Name, other.Name);
        }

    }
}
