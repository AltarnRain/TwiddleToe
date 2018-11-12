// <copyright file="ITestScope.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Test.Base.API
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Base interface for all test scopes.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface ITestScope : IDisposable
    {
        /// <summary>
        /// Starts this a test scope.
        /// </summary>
        /// <param name="testContext">The test context.</param>
        void Start(TestContext testContext);
    }
}
