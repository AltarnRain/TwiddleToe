// <copyright file="ViewProviderTests.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Windows;
    using TwiddleToe.Tests.TestBase;
    using TwiddleToe.Tests.TestClasses;

    /// <summary>
    /// Tests the view provider.
    /// </summary>
    [TestClass]
    public class ViewProviderTests : TestBase<TestScope>
    {
        /// <summary>
        /// Tests the load view method.
        /// </summary>
        [TestMethod]
        public void TestShowView()
        {
            using (var scope = this.StartTest())
            {
                // Arrange.
                var viewFactory = scope.ViewProvider;

                // Act
                var view = viewFactory.Show<ViewTestImplentation, BaseViewModelTestImplentation>();

                // Assert
                Assert.IsTrue(view.ShowCalled);
            }
        }

        /// <summary>
        /// Tests the load view method.
        /// </summary>
        [TestMethod]
        public void TestShowViewAsDialog()
        {
            using (var scope = this.StartTest())
            {
                // Arrange.
                var viewFactory = scope.ViewProvider;

                // Act
                var view = viewFactory.Show<DialogViewTestImplemtation, BaseViewModelTestImplentation>();

                // Assert
                Assert.IsTrue(view.ShowDialogCalled);
                Assert.AreEqual(WindowStartupLocation.CenterScreen, view.WindowStartupLocation);
                Assert.AreEqual(ResizeMode.NoResize, view.ResizeMode);
            }
        }
    }
}