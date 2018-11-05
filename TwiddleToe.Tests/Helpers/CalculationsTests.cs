// <copyright file="CalculationsTests.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Utilities.Helpers.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests the calculation helper class
    /// </summary>
    [TestClass]
    public class CalculationsTests
    {
        /// <summary>
        /// Gets the center coordinate test.
        /// </summary>
        [TestMethod]
        public void GetCenterCoordinateTest()
        {
            // Act
            var result = Calculations.GetCenterCoordinate(1000, 500);

            // Assert
            Assert.AreEqual(250, result);
        }
    }
}