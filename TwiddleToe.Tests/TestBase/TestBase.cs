// <copyright file="TestBase.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Tests.TestBase
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Ninject;

    /// <summary>
    /// Base class for all unit tests.
    /// </summary>
    /// <typeparam name="TTestScope">The type of the scope.</typeparam>
    public abstract class TestBase<TTestScope>
        where TTestScope : ITestScope, new()
    {
        /// <summary>
        /// The kernel
        /// </summary>
        private IKernel kernel;

        /// <summary>
        /// Gets or sets the test context.
        /// </summary>
        /// <value>
        /// The test context.
        /// </value>
        public TestContext TestContext { get; set; }

        /// <summary>
        /// Starts the test scope.
        /// </summary>
        /// <returns>A test scope</returns>
        public TTestScope StartTest()
        {
            this.kernel = new StandardKernel();

            var scope = new TTestScope();
            scope.Start(this.TestContext);
            return scope;
        }
    }
}
