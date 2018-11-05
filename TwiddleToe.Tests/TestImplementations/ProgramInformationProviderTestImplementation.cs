// <copyright file="ProgramInformationProviderTestImplementation.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Tests.TestImplementations
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TwiddleToe.Foundation.Models;
    using TwiddleToe.Workers.Providers;

    /// <summary>
    /// A ProgramInformation Provider used in unit tests.
    /// </summary>
    /// <seealso cref="TwiddleToe.Workers.Providers.IProgramInformationProvider" />
    internal class ProgramInformationProviderTestImplementation : IProgramInformationProvider
    {
        /// <summary>
        /// The test context
        /// </summary>
        private TestContext testContext;

        /// <summary>
        /// Get's a <see cref="T:TwiddleToe.Foundation.Models.ProgramInformation" /> object
        /// </summary>
        /// <returns>
        /// A ProgramInformation object
        /// </returns>
        public ProgramInformation Get()
        {
            var returnValue = new ProgramInformation
            {
                DataFolder = this.testContext.DeploymentDirectory + @"\"
            };

            returnValue.DataFile = returnValue.DataFolder + "TestData.json";

            return returnValue;
        }

        /// <summary>
        /// Tests the test context.
        /// </summary>
        /// <param name="testContext">The test context.</param>
        public void SetTestContext(TestContext testContext)
        {
            this.testContext = testContext;
        }
    }
}
