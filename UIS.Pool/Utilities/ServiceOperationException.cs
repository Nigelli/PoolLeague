using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIS.Pool.Utilities
{
    /// <summary>
    /// Represents an exception that is thrown when an underlying Service operation throws an unhandled exception.
    /// </summary>
    public class ServiceOperationException: Exception
    {
        public ServiceOperationException(string message) : base(message) { }

        public ServiceOperationException(string message, Exception innerException) : base(message, innerException) { }
    }
}
