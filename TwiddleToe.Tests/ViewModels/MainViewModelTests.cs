// <copyright file="MainViewModelTests.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.ViewModels.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TwiddleToe.Tests.TestBase;

    /// <summary>
    /// Tests the MainVieWModel
    /// </summary>
    [TestClass]
    public class MainViewModelTests : TestBase<TestScope>
    {
        /// <summary>
        /// Mains the view model test.
        /// </summary>
        [TestMethod]
        public void TestInitialization()
        {
            using (var scope = this.StartTest())
            {
                // Arrange & Act
                var model = scope.MainViewModel;

                // Assert
                Assert.IsNotNull(model);
                Assert.IsNotNull(model.OpenUsers);
            }
        }
    }
}