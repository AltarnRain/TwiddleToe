// <copyright file="ViewProviderTests.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.Tests
{
    using System.Windows;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
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
                var viewProvider = scope.ViewProvider;

                // Act
                var view = viewProvider.Show<ViewTestImplentation, BaseViewModelTestImplentation>();

                // Assert
                Assert.IsTrue(view.ShowCalled);
                Assert.AreEqual(0, view.Top);
                Assert.AreEqual(ResizeMode.NoResize, view.ResizeMode);
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
                Assert.AreEqual(ResizeMode.NoResize, view.ResizeMode);
            }
        }
    }
}