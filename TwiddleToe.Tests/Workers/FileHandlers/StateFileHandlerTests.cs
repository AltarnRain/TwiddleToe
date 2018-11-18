// <copyright file="StateFileHandlerTests.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Workers.FileHandlers.Tests
{
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TwiddleToe.Test.Base;
    using TwiddleToe.Tests.TestBase;

    /// <summary>
    /// Tests the <see cref="StateFileHandler"/>
    /// </summary>
    [TestClass]
    public class StateFileHandlerTests : TestBase<TestScope>
    {
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestMethod]
        public void Initialize()
        {
            using (var scope = this.StartTest())
            {
                // Arrang & Act
                var provider = scope.StateFileHandler;

                // Assert
                Assert.IsNotNull(provider);
            }
        }

        /// <summary>
        /// Gets the state.
        /// </summary>
        [TestMethod]
        public void GetState()
        {
            using (var scope = this.StartTest())
            {
                // Arrang & Act
                var provider = scope.StateFileHandler;

                var state = provider.Get();

                // Assert
                Assert.IsNotNull(state);
            }
        }

        /// <summary>
        /// Gets the state.
        /// </summary>
        [TestMethod]
        public void SaveStateToFile()
        {
            using (var scope = this.StartTest())
            {
                // Arrang & Act
                var provider = scope.StateFileHandler;
                var userProvider = scope.UserProvider;
                var programInformationProvider = scope.ProgramInformationProvider;

                var state = provider.Get();

                var newUser = userProvider.Get("John", "Doe");

                state.Users.Add(newUser);

                provider.SaveStateToFile(state);

                // Assert
                var expetedFileName = this.TestContext.DeploymentDirectory + @"\TestData.json";
                var fileExists = File.Exists(expetedFileName);
                Assert.IsTrue(fileExists);
            }
        }

        /// <summary>
        /// Retrieves the state from file.
        /// </summary>
        [TestMethod]
        public void RetrieveStateFromFile()
        {
            using (var scope = this.StartTest())
            {
                // Arrange
                var provider = scope.StateFileHandler;
                var userProvider = scope.UserProvider;
                var programInformationProvider = scope.ProgramInformationProvider;

                var state = provider.Get();

                var newUser = userProvider.Get("John", "Doe");

                state.Users.Add(newUser);

                provider.SaveStateToFile(state);

                // Act
                var updatedState = provider.Get();

                // Assert
                Assert.AreEqual(state.Users.Count, updatedState.Users.Count);
            }
        }
    }
}