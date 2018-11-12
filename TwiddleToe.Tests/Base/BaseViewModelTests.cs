// <copyright file="BaseViewModelTests.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Tests.UI.Base
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TwiddleToe.Test.Base;
    using TwiddleToe.Tests.TestBase;

    /// <summary>
    /// Tests the base view model
    /// </summary>
    [TestClass]
    public class BaseViewModelTests : TestBase<TestScope>
    {
        /// <summary>
        /// Initializes the base view model.
        /// </summary>
        [TestMethod]
        public void Initialize()
        {
            using (var scope = this.StartTest())
            {
                // Arrange & act
                var model = scope.BaseViewModelTestImplentation;

                // Assert
                Assert.IsNotNull(model);
            }
        }

        /// <summary>
        /// Tests if the Base View Model registers itself in the view model regitry
        /// </summary>
        [TestMethod]
        public void TestThatItRegisters()
        {
            using (var scope = this.StartTest())
            {
                // Arrange
                var registry = scope.ViewModelRegistry;

                var currentActiveViewModels = registry.NumberOfActiveViewModels;

                // Act
                var model = scope.BaseViewModelTestImplentation;

                // Assert
                var currentActiveViewModelsAfterCreation = registry.NumberOfActiveViewModels;
                Assert.AreEqual(currentActiveViewModels + 1, currentActiveViewModelsAfterCreation);
            }
        }

        /// <summary>
        /// Tests if the base view model unregisters itself when it is disposed.
        /// </summary>
        [TestMethod]
        public void TestThatItUnRegisters()
        {
            using (var scope = this.StartTest())
            {
                // Arrange
                var registry = scope.ViewModelRegistry;

                var viewModelsBeforeCreation = registry.NumberOfActiveViewModels;
                var model = scope.BaseViewModelTestImplentation;

                var viewModelsAfterCreation = registry.NumberOfActiveViewModels;

                // Act
                model.Dispose();

                // Assert
                var viewModelsAfterDispose = registry.NumberOfActiveViewModels;
                Assert.AreEqual(viewModelsBeforeCreation + 1, viewModelsAfterCreation);
                Assert.AreEqual(viewModelsBeforeCreation, viewModelsAfterDispose);
            }
        }
    }
}