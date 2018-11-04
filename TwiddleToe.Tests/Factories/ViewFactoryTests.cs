// <copyright file="ViewFactoryTests.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Workers.Factories.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TwiddleToe.Tests.TestBase;
    using TwiddleToe.Tests.TestClasses;

    /// <summary>
    /// Tests for the view factory.
    /// </summary>
    [TestClass]
    public class ViewFactoryTests : TestBase<TestScope>
    {
        /// <summary>
        /// Test the initialization of the view factory..
        /// </summary>
        [TestMethod]
        public void Initialize()
        {
            using (var scope = this.StartTest())
            {
                // Arrange & Act.
                var viewFactory = scope.ViewFactory;

                // Assert
                Assert.IsNotNull(viewFactory);
            }
        }

        /// <summary>
        /// Tests the load view method.
        /// </summary>
        [TestMethod]
        public void TestLoadView()
        {
            using (var scope = this.StartTest())
            {
                // Arrange.
                var viewFactory = scope.ViewFactory;

                // Act
                var view = viewFactory.Create<ViewTestImplentation, BaseViewModelTestImplentation>();

                // Assert
                Assert.IsNotNull(view);
                Assert.IsNotNull(view.DataContext);
                Assert.IsTrue(view.ClosedWasSet());
            }
        }
    }
}