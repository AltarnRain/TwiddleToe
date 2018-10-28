﻿// <copyright file="ProgramInformationTests.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Models.Tests
{
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TwiddleToe.Tests;

    /// <summary>
    /// Tests the ProgramInformation class
    /// </summary>
    [TestClass]
    public class ProgramInformationTests : TestBase<ProviderTestScope>
    {
        /// <summary>
        /// Tests the programm information get method.
        /// </summary>
        [TestMethod]
        public void TestProgrammInformationGet()
        {
            using (var scope = this.StartTest())
            {
                // Act
                var programInformation = scope.ProgramInformation;

                // Assert
                Assert.IsTrue(programInformation.DataFolder.EndsWith(@"\Data\"));
                Assert.IsTrue(Directory.Exists(programInformation.DataFolder));
                Assert.IsNotNull(programInformation.DataFile);
            }
        }
    }
}