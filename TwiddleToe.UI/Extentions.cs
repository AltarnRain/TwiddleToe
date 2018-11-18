// <copyright file="Extentions.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI
{
    using System.Collections.Generic;
    using System.Linq;
    using TwiddleToe.UI.Interfaces.Input.API;

    /// <summary>
    /// Extentions methods for the UI project
    /// </summary>
    public static partial class ExtentionClass
    {
        /// <summary>
        /// Attempts to retrieve a value from an GenericInput list and cast it to the specified type.
        /// </summary>
        /// <typeparam name="TReturnType">The type of the return type.</typeparam>
        /// <param name="input">The input.</param>
        /// <param name="label">The label.</param>
        /// <returns>A TReturnType</returns>
        public static TReturnType ValueByLabel<TReturnType>(this IList<IGenericInput> input, string label)
            where TReturnType : class, IGenericInput
        {
            var foundValue = input.SingleOrDefault(i => i.Label == label);
            return foundValue as TReturnType;
        }
    }
}
