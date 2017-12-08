using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;

namespace UIS.Pool.Utilities
{
    public static class Assertions
    {
            /// <summary>
            /// Indicates whether a specified string is null, empty, or consists only of white-space characters.
            /// </summary>
            /// <param name="value">The string to test.</param>
            /// <param name="message">The error message that explains the reason for the exception.</param>
            public static void IsNullEmptyOrWhitespace(string value, string message)
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(message);
            }

            /// <summary>
            /// Indicates whether a specified Guid is Empty.
            /// </summary>
            /// <param name="value">The Guid to test.</param>
            /// <param name="message">The error message that explains the reason for the exception.</param>
            public static void IsEmpty(Guid value, string message)
            {
                if (value == Guid.Empty)
                    throw new ArgumentException(message);
            }

            /// <summary>
            /// Indicates whether a value is null.
            /// </summary>
            /// <param name="value">The value to test.</param>
            /// <param name="message">The error message that explains the reason for the exception.</param>
            public static void IsNull<T>(T value, string message) where T : class
            {
                if (value == null)
                    throw new ArgumentNullException(typeof(T).Name, message);
            }


            /// <summary>
            /// Indicates whether a value is null.
            /// </summary>
            /// <param name="value">The value to test.</param>
            /// <param name="message">The error message that explains the reason for the exception.</param>
            public static void IsNullOrDefault<T>(T value, string message)
            {
                if (Utilities.IsNullOrDefault(value))
                    throw new ArgumentException(message);
            }


            /// <summary>
            /// Indicates whether a collection is null, contains minimum number of elements or any item in a collection is null.
            /// </summary>
            /// <param name="value">The collection to check.</param>
            /// <param name="message">The error message that explains the reason for the exception.</param>
            /// <param name="minimum">The minimum number of elements in the collection.</param>
            public static void IsNullOrEmptyCollection<T>(ICollection<T> value, string message, int minimum = 1)
            {
                if (value == null)
                    throw new ArgumentNullException(typeof(ICollection<T>).Name, message);

                if (value.IsNullOrEmptyCollection(minimum))
                    throw new ArgumentException(message);
            }


            /// <summary>
            /// Indicates whether any item in a collection is null.
            /// </summary>
            /// <param name="value">The collection to test.</param>
            /// <param name="message">The error message that explains the reason for the exception.</param>
            public static void IsNullAny<T>(ICollection<T> value, string message)
            {
                if (value == null)
                    throw new ArgumentNullException(typeof(ICollection<T>).Name, message);

                if (value.AnyNull())
                    throw new ArgumentNullException(typeof(ICollection<T>).Name, message);
            }


            /// <summary>
            /// Indicates whether any item in a collection of strings is null, empty or only whitespace.
            /// </summary>
            /// <param name="value">The collection to test.</param>
            /// <param name="message">The error message that explains the reason for the exception.</param>
            public static void IsNullEmptyOrWhitespace(ICollection<string> value, string message)
            {
                if (value == null)
                    throw new ArgumentNullException(string.Empty, message);

                if (value.AnyNullEmptyOrWhitespace())
                    throw new ArgumentNullException(string.Empty, message);
            }


            /// <summary>
            /// Checks if an Object is null and throws an ObjectNotFoundException if so.  
            /// </summary>
            /// <typeparam name="T">The object Type.</typeparam>
            /// <param name="value">The object to check for null.</param>
            /// <param name="message">The message property for the ObjectNotFoundException.</param>
            /// <returns>The value if the object is not null, otherwise throws an ObjectNotFoundException with the specific message.</returns>
            public static T ObjectNotFound<T>(this T value, string message) where T : class
            {
                if (value == null)
                    throw new ObjectNotFoundException(message);

                return value;
            }


            /// <summary>
            /// Checks if an Object and Property of the object is null and throws an ObjectNotFoundException if so. 
            /// </summary>
            /// <typeparam name="T">The object Type.</typeparam>
            /// <typeparam name="TProperty">The property to check for null.</typeparam>
            /// <param name="value">The object to check for null.</param>
            /// <param name="property">The Object Property to check for null.</param>
            /// <param name="message">The message property for the ObjectNotFoundException.</param>
            /// <returns>The value if the object is not null, otherwise throws an ObjectNotFoundException with the specific message.</returns>
            public static T ObjectOrPropertyNotFound<T, TProperty>(this T value, Expression<Func<T, TProperty>> property, string message) where T : class
            {
                if ((value == null) || (property == null) || (((PropertyInfo)((MemberExpression)property.Body).Member).GetValue(value) == null))
                    throw new ObjectNotFoundException(message);

                return value;
            }

            /// <summary>
            /// Determines whether an enum value is set to invalid
            /// </summary>
            /// <typeparam name="T">The type of enum</typeparam>
            /// <param name="value">The value of the enum</param>
            /// <param name="message">An error message</param>
            /// <returns>A <see cref="bool"/>.</returns>
            public static void IsInvalid<T>(T value, string message = null) where T : struct, IConvertible
            {
                // Validate type parameter
                if (!typeof(T).IsEnum)
                {
                    throw new ArgumentException("T must be an enumerated type");
                }

                // Determine
                if (string.Equals(value.ToString(CultureInfo.InvariantCulture), "Invalid",
                    StringComparison.InvariantCultureIgnoreCase))
                {
                    throw new InvalidOperationException(string.IsNullOrWhiteSpace(message) ? "value cannot be set to \"Invalid\"" : message);
                }
            }
        }
}