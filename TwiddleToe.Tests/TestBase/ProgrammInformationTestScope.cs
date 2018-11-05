// <copyright file="ProgrammInformationTestScope.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Tests.TestBase
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Ninject;
    using TwiddleToe.Workers.Providers;

    /// <summary>
    /// Test scope for the ProgramInformation Unit testr
    /// </summary>
    /// <seealso cref="TwiddleToe.Tests.TestBase.TestScopeBase" />
    public class ProgrammInformationTestScope : TestScopeBase
    {
        /// <summary>
        /// Gets the programm information provider.
        /// </summary>
        /// <value>
        /// The programm information provider.
        /// </value>
        public IProgramInformationProvider ProgrammInformationProvider => this.Kernel.Get<IProgramInformationProvider>();

        /// <summary>
        /// Starts this a test scope.
        /// </summary>
        /// <param name="testContext">The test context.</param>
        public override void Start(TestContext testContext)
        {
            base.Start(testContext);

            this.Kernel.Load(new TwiddleToe.UI.Modules());
        }
    }
}
