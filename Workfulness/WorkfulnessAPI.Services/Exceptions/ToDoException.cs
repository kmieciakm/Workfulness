using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WorkfulnessAPI.Services.Exceptions
{
    public class ToDoException : Exception
    {
        public List<string> Details { get; set; } = new List<string>();
        public ExceptionCause Cause { get; }

        public ToDoException(string message, ExceptionCause cause = ExceptionCause.Unknown)
           : base(message)
        {
            Cause = cause;
        }

        public ToDoException(string message, Exception innerException, ExceptionCause cause = ExceptionCause.Unknown)
            : base(message, innerException)
        {
            Cause = cause;
        }

        public ToDoException(string message, List<string> details, ExceptionCause cause = ExceptionCause.Unknown)
            : base(message)
        {
            Details = details;
            Cause = cause;
        }

        public ToDoException(string message, List<string> details, Exception innerException, ExceptionCause cause = ExceptionCause.Unknown)
            : base(message, innerException)
        {
            Details = details;
            Cause = cause;
        }
    }
}
