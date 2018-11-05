// <copyright file="ExtentionTests.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Utilities.Extentions.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TwiddleToe.Utilities.Extentions;

    /// <summary>
    /// Provides test for the name provider.
    /// </summary>
    [TestClass]
    public class ExtentionTests
    {
        /// <summary>
        /// Tests the string extention tests.
        /// </summary>
        [TestMethod]
        public void GetPluralTest()
        {
            // Act
            var users = "user".ToPlural();
            var histories = "history".ToPlural();

            // Assert
            Assert.AreEqual("users", users);
            Assert.AreEqual("histories", histories);
        }
    }
}