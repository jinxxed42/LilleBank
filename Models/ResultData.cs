using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LilleBank.Models
{
    /// <summary>
    /// Class for returning a bool Success to indicate success or failure, a string Message with information
    /// and a found object or collection as Data if Success is true. If Success is false Data should be null or an empty
    /// collection. In that case Data should not be accessed.
    /// </summary>
    /// <typeparam name="Data">Object or collection found, if nothing then null or empty collection</typeparam>
    internal class ResultData<T>
    {
        public bool Success { get; init; }
        public string Message { get; init; }
        public T Data { get; init; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="success">Boolean - True if successful, else false.</param>
        /// <param name="message">String - Any information to be passed along with the result.</param>
        /// <param name="data">If success is true then it should contain the found object. Else null</param>
        public ResultData(bool success, string message, T data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}
