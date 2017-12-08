using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UIS.Pool.Utilities
{
    public static class Utilities
    {
        private static readonly HashSet<Type> numericTypes = new HashSet<Type>
        {
            typeof(int),  typeof(double),  typeof(decimal),
            typeof(long), typeof(short),   typeof(sbyte),
            typeof(byte), typeof(ulong),   typeof(ushort),
            typeof(uint), typeof(float)
        };


        /// <summary>
        /// Determines if an object is null or a Default value type. 
        /// </summary>
        /// <typeparam name="T">Type of </typeparam>
        /// <param name="value">The object to be checked.</param>
        /// <returns>True of an object is null or Default value; otherwise false.</returns>
        public static bool IsNullOrDefault<T>(T value)
        {
            if (value == null)
                return true;

            if (object.Equals(value, default(T)))
                return true;

            Type methodType = typeof(T);
            if (Nullable.GetUnderlyingType(methodType) != null)
                return false;

            Type argumentType = value.GetType();
            if (argumentType.IsValueType && argumentType != methodType)
            {
                object obj = Activator.CreateInstance(value.GetType());
                return obj.Equals(value);
            }

            return false;
        }


        /// <summary>
        /// Exchanges the object on the LHS for the object on the RHS and vice versa.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lhs">The object to be moved to the right.</param>
        /// <param name="rhs">The object to be moved to the left.</param>
        public static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
        
        
        /// <summary>
        /// Checks if an object is a numeric type.
        /// </summary>
        /// <param name="value">The object to be checked if it is a numeric type.</param>
        /// <returns>True if the value type is a numeric type.</returns>
        public static bool IsNumeric(object value)
        {
            Assertions.IsNull(value, "Value cannot be null.");
            var type = value.GetType();
            return numericTypes.Contains(Nullable.GetUnderlyingType(type) ?? type);
        }
    }
}
