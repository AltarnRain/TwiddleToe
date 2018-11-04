// <copyright file="SubjectProviderTests.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Workers.Providers.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TwiddleToe.Tests.TestBase;

    /// <summary>
    /// Tests the subject provider.
    /// </summary>
    [TestClass]
    public class SubjectProviderTests : TestBase<TestScope>
    {
        private const string Description = "Subject description";

        /// <summary>
        /// Tests the create subject.
        /// </summary>
        [TestMethod]
        public void TestCreateSubject()
        {
            using (var scope = this.StartTest())
            {
                // Arrange
                var provider = scope.SubjectProvider;

                // Act
                var subject = provider.Create(Description);

                // Assert
                Assert.IsNotNull(subject.Identity);
                Assert.AreEqual(Description, subject.Description);
            }
        }
    }
}