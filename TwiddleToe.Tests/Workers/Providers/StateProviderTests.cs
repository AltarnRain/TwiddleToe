// <copyright file="StateProviderTests.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Workers.Providers.Tests
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TwiddleToe.Foundation.Models;
    using TwiddleToe.Test.Base;
    using TwiddleToe.Tests.TestBase;
    using TwiddleToe.Tests.TestImplementations;

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

        /// <summary>
        /// Tests the state provider registration.
        /// </summary>
        [TestMethod]
        public void TestStateProviderRegistration()
        {
            using (var scope = this.StartTest())
            {
                // Arrange
                var provider = scope.StateProvider;
                var testClass = new SubscriberTestImplementation();
                provider.Subscribe(testClass);
                var stateDispatchedBefore = testClass.StateUpdated;

                var state = scope.StateProvider.Current;

                // Act
                provider.Current = state;

                // Assert
                Assert.IsFalse(stateDispatchedBefore);
                Assert.IsTrue(testClass.StateUpdated);
            }
        }

        /// <summary>
        /// Tests the state provider registration.
        /// </summary>
        [TestMethod]
        public void TestStateProviderReRegistration()
        {
            using (var scope = this.StartTest())
            {
                // Arrange
                var provider = scope.StateProvider;
                var testClass = new SubscriberTestImplementation();
                provider.Subscribe(testClass);
                var stateDispatchedBefore = testClass.StateUpdated;
                provider.Unsubscribe(testClass);

                var state = scope.StateProvider.Current;

                // Act
                provider.Current = state;

                // Assert
                Assert.IsFalse(stateDispatchedBefore);
                Assert.IsFalse(testClass.StateUpdated);
            }
        }

        /// <summary>
        /// Removes from state.
        /// </summary>
        [TestMethod]
        public void RemoveFromStateWithIDeletable()
        {
            using (var scope = this.StartTest())
            {
                var stateProvider = scope.StateProvider;
                var userProvider = scope.UserProvider;

                var state = new State();
                var user = userProvider.Get("John", "Doe");

                state.Users.Add(user);

                stateProvider.Current = state;

                // Act
                stateProvider.Remove(user);

                // Assert
                var deletedRecord = stateProvider.Current.Users.Single(u => u.Identity == user.Identity);
                Assert.IsTrue(deletedRecord.Deleted);
            }
        }

        /// <summary>
        /// Removes from state.
        /// </summary>
        [TestMethod]
        public void RemoveFromStateWithoutIDeletable()
        {
            using (var scope = this.StartTest())
            {
                var stateProvider = scope.StateProvider;

                var questionaire = new Questionaire
                {
                    Identity = scope.IdentityProvider.Get()
                };

                var state = new State();
                state.Questionaires.Add(questionaire);

                stateProvider.Current = state;

                // Act
                stateProvider.Remove(questionaire);

                // Assert
                var deletedRecord = stateProvider.Current.Users.SingleOrDefault(u => u.Identity == questionaire.Identity);
                Assert.IsNull(deletedRecord);
            }
        }

        /// <summary>
        /// Tests the update.
        /// </summary>
        [TestMethod]
        public void TestUpdate()
        {
            using (var scope = this.StartTest())
            {
                var stateProvider = scope.StateProvider;
                var userProvider = scope.UserProvider;

                var state = new State();
                var user = userProvider.Get("John", "Doe");

                state.Users.Add(user);

                stateProvider.Current = state;

                user.FirstName = "Peter";
                user.LastName = "Smith";

                // Act
                stateProvider.Update(user);

                // Assert
                var updatedUser = stateProvider.Current.Users.Single(u => u.Identity == user.Identity);
                Assert.AreEqual(user.FirstName, updatedUser.FirstName);
                Assert.AreEqual(user.LastName, updatedUser.LastName);
            }
        }

        /// <summary>
        /// Tests adding to the state.
        /// </summary>
        [TestMethod]
        public void TestAdd()
        {
            using (var scope = this.StartTest())
            {
                var stateProvider = scope.StateProvider;
                var userProvider = scope.UserProvider;

                var newUser = userProvider.Get("John", "Doe");

                var currentStateCountForUsers = stateProvider.Current.Users.Count();

                // Act
                stateProvider.Add(newUser);

                // Assert
                var currentStateAfterUserAddition = stateProvider.Current.Users.Count();

                Assert.AreEqual(0, currentStateCountForUsers);
                Assert.AreEqual(1, currentStateAfterUserAddition);
            }
        }
    }
}