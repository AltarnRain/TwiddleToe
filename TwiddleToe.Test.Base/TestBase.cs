// <copyright file="TestBase.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Test.Base
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TwiddleToe.Test.Base.API;

    /// <summary>
    /// Base class for all unit tests.
    /// </summary>
    /// <typeparam name="TTestScope">The type of the scope.</typeparam>
    public abstract class TestBase<TTestScope>
        where TTestScope : ITestScope, new()
    {
        /// <summary>
        /// Gets or sets the test context.
        /// </summary>
        /// <value>
        /// The test context.
        /// </value>
        public TestContext TestContext { get; set; }

        /// <summary>
        /// Gets the deploy folder.
        /// </summary>
        /// <value>
        /// The deploy folder.
        /// </value>
        public string DeployFolder
        {
            get
            {
                return this.TestContext.DeploymentDirectory;
            }
        }

        /// <summary>
        /// Starts the test scope.
        /// </summary>
        /// <returns>A test scope</returns>
        public TTestScope StartTest()
        {
            var scope = new TTestScope();
            scope.Start(this.TestContext);
            return scope;
        }
    }
}
