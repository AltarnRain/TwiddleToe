// <copyright file="IdentityProviderTests.cs" company="Onno Invernizzi">
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
                var firstResult = scope.IdentityProvider.Get();
                var secondResult = scope.IdentityProvider.Get();

                // Assert
                Assert.IsTrue(secondResult - firstResult == 1);
            }
        }
    }
}