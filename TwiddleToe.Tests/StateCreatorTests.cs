// <copyright file="StateCreatorTests.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace StateDefinition.Tests
{
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TwiddleToe.StateDefinition;
    using TwiddleToe.Test.Base;
    using TwiddleToe.Tests.TestBase;

    /// <summary>
    /// Tests for the state builder.
    /// </summary>
    [TestClass]
    public class StateCreatorTests : TestBase<TestScope>
    {
        /// <summary>
        /// Tests the state builder constructor.
        /// </summary>
        [DeploymentItem(@"TestData\StateSchema.xml")]
        [TestMethod]
        public void StateBuilderTest()
        {
            // Arrange
            var stateFile = Path.Combine(this.DeployFolder, "StateSchema.xml");
            var stateCsFile = @"D:\Reps\TwiddleToe\TwiddleToe.Foundation\State.cs";

            var stateBuilder = new StateCreator(stateFile);

            // Act
            stateBuilder.BuildState(stateCsFile);

            // Assert
            Assert.IsTrue(File.Exists(stateCsFile));
        }
    }
}