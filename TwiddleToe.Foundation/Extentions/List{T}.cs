// <copyright file="List{T}.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Foundation.Extentions
{
    using System.Collections.Generic;
    using System.Linq;
    using TwiddleToe.Foundation.Models;

    /// <summary>
    /// Foundation Extentions
    /// </summary>
    public static partial class ExtentionClass
    {
        /// <summary>
        /// Finds a model based on its identity.
        /// </summary>
        /// <typeparam name="T">Any model that inherits from BaseModel</typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="identity">The identity.</param>
        /// <returns>The search result</returns>
        public static T Find<T>(this IList<T> collection, string identity)
            where T : BaseModel
        {
            return collection.SingleOrDefault(c => c.Identity == identity);
        }
    }
}
