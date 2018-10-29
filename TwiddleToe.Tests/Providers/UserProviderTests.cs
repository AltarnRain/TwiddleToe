// <copyright file="UserProviderTests.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Providers.Providers.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TwiddleToe.Tests;

    /// <summary>
    /// Tests the <see cref="UserProvider"/>
    /// </summary>
    [TestClass]
    public class UserProviderTests : TestBase<ProviderTestScope>
    {
        /// <summary>
        /// Creates the test.
        /// </summary>
        [TestMethod]
        public void CreateTestWithNames()
        {
            using (var scope = this.StartTest())
            {
                // Act
                var user = scope.UserProvider.Create("Onno", "Invernizzi");

                // Assert
                Assert.AreEqual("Onno", user.FirstName);
                Assert.AreEqual("Invernizzi", user.LastName);
                Assert.IsTrue(user.UserId != string.Empty);
            }
        }
    }
}