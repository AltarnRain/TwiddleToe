// <copyright file="UserProviderTests.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Providers.Providers.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TwiddleToe.Models;
    using TwiddleToe.Tests;
    using TwiddleToe.Tests.TestScopes;

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
                Assert.IsTrue(user.UserId > -1);
            }
        }

        /// <summary>
        /// Creates the test from model.
        /// </summary>
        [TestMethod]
        public void CreateTestFromModel()
        {
            using (var scope = this.StartTest())
            {
                // Arrange
                var user = new User { FirstName = "Onno", LastName = "Invernizzi", UserId = -1 };

                // Act
                var newUserModel = scope.UserProvider.Create(user);

                // Assert
                Assert.AreEqual("Onno", user.FirstName);
                Assert.AreEqual("Invernizzi", user.LastName);
                Assert.IsTrue(user.UserId > -1);
            }
        }
    }
}