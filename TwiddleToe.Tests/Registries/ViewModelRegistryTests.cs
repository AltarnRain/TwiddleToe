// <copyright file="ViewModelRegistryTests.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Foundation.Registries.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TwiddleToe.Tests.TestBase;

    /// <summary>
    /// Tests the ViewModelRegistry
    /// </summary>
    [TestClass]
    public class ViewModelRegistryTests : TestBase<TestScope>
    {
        /// <summary>
        /// Views the model registry test.
        /// </summary>
        [TestMethod]
        public void Initialize()
        {
            using (var scope = this.StartTest())
            {
                // Arrange & Act
                var registry = scope.ViewModelRegistry;

                // Assert
                Assert.IsNotNull(registry);
            }
        }

        /// <summary>
        /// Tests if a activated view model is registerd
        /// </summary>
        [TestMethod]
        public void ActivatedTest()
        {
            using (var scope = this.StartTest())
            {
                // Arrange
                var testViewModel = scope.BaseViewModelTestImplentation;
                var registry = scope.ViewModelRegistry;

                var activeViewModels = registry.NumberOfActiveViewModels;

                // Act
                registry.Activated(testViewModel);

                // Assert
                Assert.AreEqual(activeViewModels + 1, registry.NumberOfActiveViewModels);
            }
        }

        /// <summary>
        /// Tests if a view model is deregistered.
        /// </summary>
        [TestMethod]
        public void DeactivatedTest()
        {
            using (var scope = this.StartTest())
            {
                // Arrange
                var testViewModel = scope.BaseViewModelTestImplentation;
                var registry = scope.ViewModelRegistry;
                registry.Activated(testViewModel);

                var activeViewModels = registry.NumberOfActiveViewModels;

                // Act
                registry.Deactivated(testViewModel);

                // Assert
                Assert.AreEqual(activeViewModels - 1, registry.NumberOfActiveViewModels);
            }
        }

        /// <summary>
        /// Tests if the ViewModelRegistry's CloseAllActive tests dispatches a close event.
        /// </summary>
        [TestMethod]
        public void CloseAllActiveTest()
        {
            using (var scope = this.StartTest())
            {
                // Arrange
                var testViewModel = scope.BaseViewModelTestImplentation;
                var registry = scope.ViewModelRegistry;
                bool eventWasCalled = false;

                testViewModel.OnRequestClose += () =>
                {
                    eventWasCalled = true;
                };

                registry.CloseAllActive();

                Assert.IsTrue(eventWasCalled);
            }
        }
    }
}