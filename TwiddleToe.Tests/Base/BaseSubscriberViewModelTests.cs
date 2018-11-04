// <copyright file="BaseSubscriberViewModelTests.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Tests.Base
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TwiddleToe.Tests.TestBase;

    /// <summary>
    /// Tests for the BaseSubscriberViewModel
    /// </summary>
    [TestClass]
    public class BaseSubscriberViewModelTests : TestBase<TestScope>
    {
        /// <summary>
        /// Tests if the BaseSubscriberViewModel initializes
        /// </summary>
        [TestMethod]
        public void Initializes()
        {
            using (var scope = this.StartTest())
            {
                // Arrange & Act
                var model = scope.BaseSubscriberViewModelTestImplentation;

                // Assert
                Assert.IsNotNull(model);
            }
        }

        /// <summary>
        /// Tests the that it registers itself to state updates and handles them.
        /// </summary>
        [TestMethod]
        public void TestThatItRegistersItselfToStateUpdates()
        {
            using (var scope = this.StartTest())
            {
                var stateProvider = scope.StateProvider;
                var model = scope.BaseSubscriberViewModelTestImplentation;

                var stateUpdated = model.StateUpdated;

                // Act
                // Trigger State update. No need to set a state.
                stateProvider.Current = scope.StateProvider.Current;

                // Assert
                Assert.IsTrue(model.StateUpdated);
            }
        }

        /// <summary>
        /// Tests the that it registers itself to state updates.
        /// </summary>
        [TestMethod]
        public void TestThatItDeRegistersItselfFromStateUpdates()
        {
            using (var scope = this.StartTest())
            {
                var stateProvider = scope.StateProvider;
                var registry = scope.ViewModelRegistry;

                var activeViewModels = registry.NumberOfActiveViewModels;

                var model = scope.BaseSubscriberViewModelTestImplentation;

                var activeViewModelsAfterCreation = registry.NumberOfActiveViewModels;

                // Act
                // Trigger State update. No need to set a state.
                model.Dispose();

                // Assert
                var activeViewModelsAfterDispose = registry.NumberOfActiveViewModels;
            }
        }
    }
}
