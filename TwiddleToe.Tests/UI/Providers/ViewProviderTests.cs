// <copyright file="ViewProviderTests.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.Providers.Tests
{
    using System.Windows;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TwiddleToe.Test.Base;
    using TwiddleToe.Tests;
    using TwiddleToe.Tests.TestBase;
    using TwiddleToe.Tests.TestClasses;
    using TwiddleToe.Tests.TestClasses.Views;
    using TwiddleToe.Utilities.Helpers;

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
            }
        }

        /// <summary>
        /// Tests the load view method.
        /// </summary>
        [TestMethod]
        public void TestIShowDialog()
        {
            using (var scope = this.StartTest())
            {
                // Arrange.
                var viewFactory = scope.ViewProvider;

                // Act
                var view = viewFactory.Show<ViewIShowDialog, BaseViewModelTestImplentation>();

                // Assert
                Assert.IsTrue(view.ShowDialogCalled);
            }
        }

        /// <summary>
        /// Tests the load view method.
        /// </summary>
        [TestMethod]
        public void TestICenterHorizantal()
        {
            using (var scope = this.StartTest())
            {
                // Arrange.
                var viewFactory = scope.ViewProvider;

                // Act
                var view = viewFactory.Show<ViewICenterHorizantal, BaseViewModelTestImplentation>();

                // Assert
                var expectedLeft = Calculations.GetCenterCoordinate(Constants.WorkAreaWidth, Constants.TestViewWidth);

                Assert.AreEqual(expectedLeft, view.Left);
            }
        }

        /// <summary>
        /// Tests the load view method.
        /// </summary>
        [TestMethod]
        public void TestICenterVertical()
        {
            using (var scope = this.StartTest())
            {
                // Arrange.
                var viewFactory = scope.ViewProvider;

                // Act
                var view = viewFactory.Show<ViewICenterVertical, BaseViewModelTestImplentation>();

                // Assert
                var expectedTop = Calculations.GetCenterCoordinate(Constants.WorkAreaHeight, Constants.TestViewHeight);

                Assert.AreEqual(expectedTop, view.Top);
            }
        }

        /// <summary>
        /// Tests the load view method.
        /// </summary>
        [TestMethod]
        public void TestITop()
        {
            using (var scope = this.StartTest())
            {
                // Arrange.
                var viewFactory = scope.ViewProvider;

                // Act
                var view = viewFactory.Show<ViewITop, BaseViewModelTestImplentation>();

                // Assert
                Assert.AreEqual(0, view.Top);
            }
        }

        /// <summary>
        /// Tests the load view method.
        /// </summary>
        [TestMethod]
        public void TestIResizable()
        {
            using (var scope = this.StartTest())
            {
                // Arrange.
                var viewFactory = scope.ViewProvider;

                // Act
                var view = viewFactory.Show<ViewIResizable, BaseViewModelTestImplentation>();

                // Assert
                Assert.AreEqual(ResizeMode.CanResize, view.ResizeMode);
            }
        }

        /// <summary>
        /// Tests the load view method.
        /// </summary>
        [TestMethod]
        public void TestICanMinimize()
        {
            using (var scope = this.StartTest())
            {
                // Arrange.
                var viewFactory = scope.ViewProvider;

                // Act
                var view = viewFactory.Show<ViewICanMinimize, BaseViewModelTestImplentation>();

                // Assert
                Assert.AreEqual(ResizeMode.CanMinimize, view.ResizeMode);
            }
        }

        /// <summary>
        /// Tests the load view method.
        /// </summary>
        [TestMethod]
        public void TestIShowInTaskBar()
        {
            using (var scope = this.StartTest())
            {
                // Arrange.
                var viewFactory = scope.ViewProvider;

                // Act
                var view = viewFactory.Show<ViewIShowInTaskbar, BaseViewModelTestImplentation>();

                // Assert
                Assert.IsTrue(view.ShowInTaskbar);
            }
        }

        /// <summary>
        /// Tests the load view method.
        /// </summary>
        [TestMethod]
        public void TestIDoNotShowInTaskBar()
        {
            using (var scope = this.StartTest())
            {
                // Arrange.
                var viewFactory = scope.ViewProvider;

                // Act
                var view = viewFactory.Show<ViewICanMinimize, BaseViewModelTestImplentation>();

                // Assert
                Assert.IsFalse(view.ShowInTaskbar);
            }
        }
    }
}