// <copyright file="StateProviderTests.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Tests.Providers
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TwiddleToe.Foundation.Models;
    using TwiddleToe.Tests.Base;

    /// <summary>
    /// Tests the StateProvider.
    /// </summary>
    [TestClass]
    public class StateProviderTests : TestBase<TestScope>
    {
        /// <summary>
        /// Tests the state of the get.
        /// </summary>
        [TestMethod]
        public void TestGetState()
        {
            using (var scope = this.StartTest())
            {
                var state = scope.StateProvider.Current;

                // Assert
                Assert.IsNotNull(state);
                Assert.IsNotNull(state.Questionaires);
                Assert.IsNotNull(state.QuestionareHistories);
                Assert.IsNotNull(state.Questions);
                Assert.IsNotNull(state.Subjects);
                Assert.IsNotNull(state.Users);
            }
        }

        /// <summary>
        /// Tests the state immutability.
        /// </summary>
        [TestMethod]
        public void TestStateImmutability()
        {
            using (var scope = this.StartTest())
            {
                var state = scope.StateProvider.Current;
                state.Questions.Add(new Question { Answer = "Test" });

                var originalState = scope.StateProvider.Current;

                // If the state works with references the number of questions will be equal.
                Assert.AreNotEqual(originalState.Questions.Count, state.Questions.Count);

                // Update the state. This is also done using clones. The state passed into the Set method
                // is cloned so no reference exists.
                scope.StateProvider.Current = state;
                var updatedState = scope.StateProvider.Current;
                Assert.AreEqual(state.Questions.Count, updatedState.Questions.Count);

                state.Questions.Add(new Question { Answer = "Test2" });
                Assert.AreNotEqual(updatedState.Questions.Count, state.Questions.Count);
            }
        }
    }
}
