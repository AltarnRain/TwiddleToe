// <copyright file="SubjectViewModelTests.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Tests.ViewModels
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}
