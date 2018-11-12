// <copyright file="AddUserViewModelTests.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.ViewModels.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TwiddleToe.Test.Base;
    using TwiddleToe.Tests.TestBase;

    /// <summary>
    /// Tests for the AddUserViewModel
    /// </summary>
    [TestClass]
    public class AddUserViewModelTests : TestBase<TestScope>
    {
        /// <summary>
        /// Test if the AddUserViewModel initializes
        /// </summary>
        [TestMethod]
        public void AddUserViewModelTest()
        {
            using (var scope = this.StartTest())
            {
                var model = scope.AddUserViewModel;

                // Assert
                Assert.IsNotNull(model);
                Assert.IsNull(model.FirstName);
                Assert.IsNull(model.LastName);
                Assert.IsNotNull(model.AddUser);
                Assert.IsNotNull(model.Cancel);
                Assert.IsFalse(model.CanAddNewUser());
            }
        }

        /// <summary>
        /// Determines whether this instance [can now add new user test].
        /// </summary>
        [TestMethod]
        public void CanAddNewUser_NoLastName()
        {
            using (var scope = this.StartTest())
            {
                // Arrange
                var model = scope.AddUserViewModel;
                model.FirstName = "John";

                // Assert
                Assert.IsFalse(model.CanAddNewUser());
            }
        }

        /// <summary>
        /// Determines whether this instance [can now add new user test].
        /// </summary>
        [TestMethod]
        public void CanAddNewUser_FirstAndLastName()
        {
            using (var scope = this.StartTest())
            {
                // Arrange
                var model = scope.AddUserViewModel;
                model.FirstName = "John";
                model.LastName = "Doe";

                // Assert
                Assert.IsTrue(model.CanAddNewUser());
            }
        }
    }
}