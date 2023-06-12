namespace LilleBank.Models
{
    /// <summary>
    /// Result class used for returning Boolean whether something was successful or not along with a message.
    /// </summary>
    internal class Result
    {
        public bool Success { get; init; }
        public string Message { get; init; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="success">Boolean - True if successful, else false.</param>
        /// <param name="message">String - Any information to passed along with the result.</param>
        public Result(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
