// <copyright file="ITestScope.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Test.Base
{
    using System;

    /// <summary>
    /// Base interface for all test scopes.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface ITestScope : IDisposable
    {
        /// <summary>
        /// Starts this a test scope.
        /// </summary>
        void Start();
    }
}
