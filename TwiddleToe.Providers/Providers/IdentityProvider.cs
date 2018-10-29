// <copyright file="IdentityProvider.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Providers
{
    using System;

    /// <summary>
    /// This class provides a unique identifiers.
    /// </summary>
    public class IdentityProvider
    {
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>A new unique identifier</returns>
        public string Get()
        {
            return Guid.NewGuid().ToString();
        }
    }
}