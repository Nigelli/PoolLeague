using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIS.Pool.Utilities
{

    /// <summary>
    /// Represents an exception that is thrown when a method input parameters in invalid.
    /// </summary>
    public class InvalidParameterException: Exception
    {
        
        public InvalidParameterException(string message) : base(message) { }

        public InvalidParameterException(string message, Exception innerException) : base(message, innerException) { }
    }
}
