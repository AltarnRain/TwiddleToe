// <copyright file="ViewRegistryTests.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Foundation.Registries.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TwiddleToe.Tests.TestBase;
    using TwiddleToe.Tests.TestClasses.Views;

    /// <summary>
    /// Tests for <see cref="ViewRegistry"/>
    /// </summary>
    [TestClass]
    public class ViewRegistryTests : TestBase<TestScope>
    {
        /// <summary>
        /// Tests if the ViewRegistry is construectd
        /// </summary>
        [TestMethod]
        public void Initialize()
        {
            using (var scope = this.StartTest())
            {
                // Arrange & Act
                var registry = scope.ViewRegistry;
            }
        }

        /// <summary>
        /// Tests if the <see cref="ViewRegistry"/> registers a view when it is activated
        /// </summary>
        [TestMethod]
        public void ActivatedTest()
        {
            using (var scope = this.StartTest())
            {
                // Arrange
                var registry = scope.ViewRegistry;
                var view = new ViewTestImplentation();

                var numberOfActiveView = registry.NumberOfActiveViews;

                // Act
                registry.Activated(view);

                // Assert
                Assert.AreEqual(numberOfActiveView + 1, registry.NumberOfActiveViews);
            }
        }

        /// <summary>
        /// Tests if a view is removed from the view registry.
        /// </summary>
        [TestMethod]
        public void DeactivatedTest()
        {
            using (var scope = this.StartTest())
            {
                // Arrange
                var registry = scope.ViewRegistry;
                var view = new ViewTestImplentation();

                registry.Activated(view);
                var numberOfActiveView = registry.NumberOfActiveViews;

                // Act
                registry.Deactivated(view);

                // Assert
                Assert.AreEqual(numberOfActiveView - 1, registry.NumberOfActiveViews);
            }
        }

        /// <summary>
        /// Determines whether a view is active.
        /// </summary>
        [TestMethod]
        public void IsActiveTest()
        {
            using (var scope = this.StartTest())
            {
                // Arrange
                var registry = scope.ViewRegistry;
                var view = new ViewTestImplentation();

                registry.Activated(view);

                // Act
                var active = registry.IsActive(typeof(ViewTestImplentation));

                // Assert
                Assert.IsTrue(active);
            }
        }

        /// <summary>
        /// Gets the active view test.
        /// </summary>
        [TestMethod]
        public void GetActiveViewTest()
        {
            using (var scope = this.StartTest())
            {
                // Arrange
                var registry = scope.ViewRegistry;
                var view = new ViewTestImplentation();

                registry.Activated(view);

                // Act
                var foundView = registry.GetActiveView(typeof(ViewTestImplentation));

                // Assert
                Assert.AreSame(view, foundView);
            }
        }
    }
}