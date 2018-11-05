// <copyright file="StringExtentions.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Utilities.Extentions
{
    /// <summary>
    /// Extention class for strings
    /// </summary>
    public partial class ExtentionClass
    {
        /// <summary>
        /// To the plural.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The plural version of a provided value.</returns>
        public static string ToPlural(this string value)
        {
            string returnValue = string.Empty;
            if (value.EndsWith("y"))
            {
                returnValue = value.Substring(0, value.Length - 1) + "ies";
            }
            else
            {
                returnValue = value + "s";
            }

            return returnValue;
        }
    }
}
