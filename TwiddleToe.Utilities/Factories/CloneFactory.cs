// <copyright file="CloneFactory.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A factory for creating clones of objects
    /// </summary>
    public static class CloneFactory
    {
        /// <summary>
        /// Makes the clone.
        /// </summary>
        /// <typeparam name="ClonableModel">The type of the lonable model.</typeparam>
        /// <param name="cloneable">The cloneable.</param>
        /// <returns>A Clones object</returns>
        public static ClonableModel MakeClone<ClonableModel>(ClonableModel cloneable)
            where ClonableModel : class, ICloneable
        {
            return cloneable.Clone() as ClonableModel;
        }

        /// <summary>
        /// Makes the clone.
        /// </summary>
        /// <typeparam name="TClonableModel">A Clonable model</typeparam>
        /// <param name="list">The list.</param>
        /// <returns>A clone of a list</returns>
        public static List<TClonableModel> MakeClone<TClonableModel>(List<TClonableModel> list)
            where TClonableModel : class, ICloneable
        {
            return CloneList(list) as List<TClonableModel>;
        }

        /// <summary>
        /// Clones the list.
        /// </summary>
        /// <typeparam name="TClonable">A clonable model</typeparam>
        /// <param name="list">The list.</param>
        /// <returns>A copy of the list with new instances of the objects in it.</returns>
        private static List<TClonable> CloneList<TClonable>(List<TClonable> list)
            where TClonable : class, ICloneable
        {
            return list.Select(l => l.Clone() as TClonable).ToList();
        }
    }
}
