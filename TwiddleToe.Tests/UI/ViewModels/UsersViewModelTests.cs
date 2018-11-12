// <copyright file="UsersViewModelTests.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.ViewModels.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TwiddleToe.Test.Base;
    using TwiddleToe.Tests.TestBase;

    /// <summary>
    /// Test for the UsersViewModel
    /// </summary>
    [TestClass]
    public class UsersViewModelTests : TestBase<TestScope>
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
        /// Gets the and set current user.
        /// </summary>
        [TestMethod]
        public void GetAndSetSelectedValue()
        {
            using (var scope = this.StartTest())
            {
                // Arrange
                var stateProvider = scope.StateProvider;
                var user = scope.UserProvider.Create("John", "Doe");
                var currentState = stateProvider.Current;

                currentState.Users.Add(user);

                stateProvider.Current = currentState;

                var model = scope.UserViewModel;

                Assert.AreEqual(null, model.SelectedValue);

                model.SelectedValue = user.Identity;

                Assert.AreEqual(model.CurrentUser.FirstName, "John");
                Assert.AreEqual(model.CurrentUser.LastName, "Doe");
            }
        }

        /// <summary>
        /// Gets the and set current user.
        /// </summary>
        [TestMethod]
        public void LoadsStateChange()
        {
            using (var scope = this.StartTest())
            {
                // Arrange
                var stateProvider = scope.StateProvider;
                var user = scope.UserProvider.Create("John", "Doe");
                var currentState = stateProvider.Current;

                currentState.Users.Add(user);

                var model = scope.UserViewModel;

                Assert.AreEqual(currentState.Users.Count - 1, model.Users.Count);

                stateProvider.Current = currentState;

                Assert.AreEqual(currentState.Users.Count, model.Users.Count);
            }
        }
    }
}