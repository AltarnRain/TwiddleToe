// <copyright file="SubjectViewModelTests.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Tests.ViewModels
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TwiddleToe.Test.Base;
    using TwiddleToe.Tests.TestBase;

    /// <summary>
    /// Tests the Subject view model
    /// </summary>
    [TestClass]
    public class SubjectViewModelTests : TestBase<TestScope>
    {
        /// <summary>
        /// Tests if the Subject view model can be initialized
        /// </summary>
        [TestMethod]
        public void Initializes()
        {
            using (var scope = this.StartTest())
            {
                // Arrange & Act
                var model = scope.SubjectViewModel;

                // Assert
                Assert.IsNotNull(model);
            }
        }

        /// <summary>
        /// Loads the state.
        /// </summary>
        [TestMethod]
        public void LoadState()
        {
            using (var scope = this.StartTest())
            {
                // Arrange
                var model = scope.SubjectViewModel;
                var currentNumberOfSubjects = model.Subjects.Count;
                var stateProvider = scope.StateProvider;
                var currentState = stateProvider.Current;
                var subjectProvider = scope.SubjectProvider;

                var newSubject = subjectProvider.Create("Test subject");
                currentState.Subjects.Add(newSubject);

                // Act
                stateProvider.Current = currentState;

                // Assert
                Assert.AreEqual(model.Subjects.Count - 1, currentNumberOfSubjects);
            }
        }
    }
}
