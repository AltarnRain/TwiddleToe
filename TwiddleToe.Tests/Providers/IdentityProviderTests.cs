﻿// <copyright file="IdentityProviderTests.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Providers.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TwiddleToe.Tests;

    /// <summary>
    /// Tests the identity provider.
    /// </summary>
    [TestClass]
    public class IdentityProviderTests : TestBase<ProviderTestScope>
    {
        /// <summary>
        /// Tests the getting a new identifier.
        /// </summary>
        [TestMethod]
        public void TestGettingANewIdentifier()
        {
            using (var scope = this.StartTest())
            {
                // Act
                var identity = scope.IdentityProvider.Get();

                // Assert
                Assert.IsTrue(identity != string.Empty);
            }
        }
    }
}