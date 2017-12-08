using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIS.Pool.Utilities
{
    public static class Extensions
    {
        /// <summary>
        /// Determines if an object meets a specified predicate.
        /// </summary>
        /// <typeparam name="T">The type of object.</typeparam>
        /// <param name="value">The item to</param>
        /// <param name="predicate">The predicate Function to determine the validity.</param>
        /// <returns>The object or a default value.</returns>
        public static T WhereOrDefault<T>(this T value, Func<T, bool> predicate)
        {
            Assertions.IsNullOrDefault(predicate, "Predicate Func cannot be null.");

            return ((!Utilities.IsNullOrDefault<T>(value)) && (predicate.Invoke(value))) ? value : default(T);
        }


        #region String Extensions

        /// <summary>
        /// Removes all whitespace from a string.
        /// </summary>
        /// <param name="value">The string to remove whitespace.</param>
        /// <returns>A string with all whitespace characters removed.</returns>
        public static string RemoveWhitespace(this string value)
        {
            return (String.IsNullOrWhiteSpace(value)) ? value : new string(value.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }


        /// <summary>
        /// Determines whether two specified System.String objects have the same value. A parameter specifies the culture, case, and sort rules used in the comparison.
        /// </summary>
        /// <param name="value">The string to compare, or null.</param>
        /// <param name="other">The second string to compare, or null.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the comparison.</param>
        /// <returns>true if the value parameter is equal to the value of the other parameter; otherwise, false.</returns>
        public static bool EqualsWithoutWhitespace(this string value, string other, StringComparison comparisonType = StringComparison.InvariantCultureIgnoreCase)
        {
            return
                (String.Equals(value.RemoveWhitespace(), other.RemoveWhitespace(),
                    comparisonType));
        }


        /// <summary>
        /// Returns the number of characters from the LHS of a string.
        /// </summary>
        /// <param name="value">The string value.</param>
        /// <param name="count">The number of characters from the LHS.</param>
        /// <returns>A string that is equivalent to the substring of length length that begins at 0 in this instance, or System.String.Empty if startIndex is equal to the length of this instance and length is zero.</returns>
        public static string Left(this string value, int count)
        {
            return ((String.IsNullOrWhiteSpace(value)) || (value.Length <= count)) ? value : value.Substring(0, count);
        }


        /// <summary>
        /// Returns the number of characters from the RHS of a string.
        /// </summary>
        /// <param name="value">The string value.</param>
        /// <param name="count">The number of characters from the LHS.</param>
        /// <returns>A string that is equivalent to the substring of length length that begins at 0 in this instance, or System.String.Empty if startIndex is equal to the length of this instance and length is zero.</returns>
        public static string Right(this string value, int count)
        {
            return ((String.IsNullOrWhiteSpace(value)) || (value.Length <= count)) ? value : value.Substring((value.Length - count), count);
        }
        

        #endregion
        

        #region Object Extensions

        /// <summary>
        /// Searches for the public property with the specified name.
        /// </summary>
        /// <param name="obj">The object containing the public property to get.</param>
        /// <param name="name">The string containing the name of the public property to get.</param>
        /// <returns>An object representing the public property with the specified name, if found; otherwise, null.</returns>
        public static object GetPropertyValue(this object obj, string name)
        {
            Assertions.IsNullEmptyOrWhitespace(name, "Property Name cannot be null, empty or contain only whitespace.");

            foreach (var part in name.Split('.'))
            {
                if (obj == null)
                    return null;

                var type = obj.GetType();
                var info = type.GetProperty(part);
                if (info == null)
                    return null;

                obj = info.GetValue(obj, null);
            }
            return obj;
        }


        /// <summary>
        /// Searches for the public property with the specified name.
        /// </summary>
        /// <typeparam name="T">The type of the object to return.</typeparam>
        /// <param name="obj">The object containing the public property to get.</param>
        /// <param name="name">The string containing the name of the public property to get.</param>
        /// <returns>An object of type T representing the public property with the specified name, if found; otherwise, null or default(T)(.</returns>
        public static T GetPropertyValue<T>(this object obj, string name)
        {
            var value = GetPropertyValue(obj, name);
            if (value == null)
                return default(T);

            return (T)value;
        }

        #endregion
        

        #region Enum Extensions

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to an equivalent enumerated object.
        /// </summary>
        /// <typeparam name="TEnum">An enumeration type.</typeparam>
        /// <param name="value">A string containing the name or value to convert.</param>
        /// <returns>An enumerated value of type TEnum whose value is represented by value.</returns>
        public static TEnum GetEnumeration<TEnum>(this string value) where TEnum : struct, IConvertible
        {
            if (!typeof(TEnum).IsEnum)
                throw new ArgumentException("Type must be an enumeration.");

            return (TEnum)Enum.Parse(typeof(TEnum), value);
        }


        /// <summary>
        /// Retrieves the name of the constant in the specified enumeration that has the specified value.
        /// </summary>
        /// <typeparam name="TEnum">An enumeration type.</typeparam>
        /// <param name="enumValue">The enumerated value.</param>
        /// <returns>A string containing the name of the enumerated constant in enumType whose value is value; or null if no such constant is found.</returns>
        public static string GetName<TEnum>(this TEnum enumValue) where TEnum : struct, IConvertible
        {
            if (!typeof(TEnum).IsEnum)
                throw new ArgumentException("Type must be an enumeration.");

            return Enum.GetName(typeof(TEnum), enumValue);
        }

        #endregion

        #region Int  Extensions

        /// <summary>
        /// Converts any Int32 value into the Negative equivilent.
        /// </summary>
        /// <param name="value">The Int32 value</param>
        /// <returns>A negative Int32 value.</returns>
        public static Int32 ToNegative(this Int32 value)
        {
            return (Math.Abs(value) * (-1));
        }

        #endregion

        #region Collection Extentions
        public static bool IsNullOrEmptyCollection<T>(this ICollection<T> value, int minimum = 1)
        {
            return ((value == null) || (value.Count < minimum) || (value.AnyNull()));
        }

        /// <summary>
        /// Checks if any of the items in the collection are null;
        /// </summary>
        /// <typeparam name="T">The type of the elements in the collection.</typeparam>
        /// <param name="value">The collection of items to check for null.</param>
        /// <returns>True of any items in the collection are null, otherwise false.</returns>
        public static bool AnyNull<T>(this ICollection<T> value)
        {
            if (value == null)
                throw new ArgumentNullException("ICollection cannot be null.");

            if (typeof(T) == typeof(string))
                return value.Any(item => (string.IsNullOrWhiteSpace(item as string)));

            return value.Any(item => (item == null));
        }


        /// <summary>
        /// Checks if any item in a collection of strings is null, empty or only whitespace.
        /// </summary>
        /// <param name="value">The collection of strings to check for null.</param>
        /// <returns>True of any items in the collection are null, otherwise false.</returns>
        public static bool AnyNullEmptyOrWhitespace(this ICollection<string> value)
        {
            if (value == null)
                throw new ArgumentNullException("ICollection cannot be null.");

            return value.Any(string.IsNullOrEmpty);
        }


        /// <summary>
        /// Compares two collections for Equality.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the collection.</typeparam>
        /// <param name="value">The collection of items to compare.</param>
        /// <param name="other">The collection of items to be compared against.</param>
        /// <returns></returns>
        public static bool AreEqual<T>(this ICollection<T> value, ICollection<T> other)
        {
            if (value == null)
                return other == null;

            if (other == null)
                return false;

            if (ReferenceEquals(value, other))
                return true;

            if (value.Count != other.Count)
                return false;

            if (value.Count == 0)
                return true;

            return !HaveMismatchedElement(value, other);
        }


        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            return (dictionary.ContainsKey(key)) ? dictionary[key] : default(TValue);
        }


        public static IList<TValue> GetValueOrEmpty<TKey, TValue>(this IDictionary<TKey, IList<TValue>> dictionary, TKey key)
        {
            return (dictionary.ContainsKey(key)) ? dictionary[key] : new List<TValue>();
        }


        private static bool HaveMismatchedElement<T>(ICollection<T> first, ICollection<T> second)
        {
            int firstNullCount;
            int secondNullCount;

            var firstElementCounts = GetElementCounts(first, out firstNullCount);
            var secondElementCounts = GetElementCounts(second, out secondNullCount);

            if (firstNullCount != secondNullCount || firstElementCounts.Count != secondElementCounts.Count)
                return true;

            foreach (var kvp in firstElementCounts)
            {
                var firstElementCount = kvp.Value;
                int secondElementCount;
                secondElementCounts.TryGetValue(kvp.Key, out secondElementCount);

                if (firstElementCount != secondElementCount)
                    return true;
            }

            return false;
        }

        private static Dictionary<T, int> GetElementCounts<T>(ICollection<T> enumerable, out int nullCount)
        {
            var dictionary = new Dictionary<T, int>();
            nullCount = 0;

            foreach (T element in enumerable)
            {
                if (element == null)
                {
                    nullCount++;
                }
                else
                {
                    int num;
                    dictionary.TryGetValue(element, out num);
                    num++;
                    dictionary[element] = num;
                }
            }

            return dictionary;
        }
        #endregion
    }
}
