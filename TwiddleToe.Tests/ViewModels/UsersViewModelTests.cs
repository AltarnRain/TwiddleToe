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
    }
}