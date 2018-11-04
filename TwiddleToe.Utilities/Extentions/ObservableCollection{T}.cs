// <copyright file="ObservableCollection{T}.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Utilities.Extentions
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    /// An extention class
    /// </summary>
    public static partial class ExtentionClass
    {
        /// <summary>
        /// Adds a range of objects to an observable collection.
        /// </summary>
        /// <typeparam name="T">An object</typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="data">The data.</param>
        public static void AddRange<T>(this ObservableCollection<T> collection, IEnumerable<T> data)
        {
            foreach (var value in data)
            {
                collection.Add(value);
            }
        }
    }
}
