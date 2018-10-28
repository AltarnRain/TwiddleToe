// <copyright file="UsersViewModelTests.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.ViewModels.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TwiddleToe.Models;
    using TwiddleToe.Tests;
    using TwiddleToe.Tests.TestScopes;

    /// <summary>
    /// Test for the UsersViewModel
    /// </summary>
    [TestClass]
    public class UsersViewModelTests : TestBase<ViewModelsTestScope>
    {
        /// <summary>
        /// Get the view model
        /// </summary>
        [TestMethod]
        public void UsersViewModelTest()
        {
            using (var scope = this.StartTest())
            {
                // Act
                var viewModel = scope.UserViewModel;

                // Assert
                Assert.IsNotNull(viewModel);
            }
        }

        /// <summary>
        /// Tests if there is a current user.
        /// </summary>
        [TestMethod]
        public void UserSelectedTest()
        {
            using (var scope = this.StartTest())
            {
                var viewModel = scope.UserViewModel;

                Assert.IsFalse(viewModel.UserIsSelected());

                viewModel.CurrentUser = new UserListItemViewModel(new User() { FirstName = "Test", LastName = "test", UserId = 1 });

                Assert.IsTrue(viewModel.UserIsSelected());
            }
        }
    }
}