using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIS.Pool.Utilities
{
    /// <summary>
    /// Represents the exception that is thrown when an object is not present or null.
    /// </summary>
    public class ObjectNotFoundException: Exception
    {
        public ObjectNotFoundException(string message): base(message){ }

        public ObjectNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
