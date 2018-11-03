﻿// <copyright file="TestScopeBase.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Tests.Base
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Ninject;

    /// <summary>
    /// Test scope for provider unit tests.
    /// </summary>
    public abstract class TestScopeBase : ITestScope, IDisposable
    {
        /// <summary>
        /// Gets or sets the test scope.
        /// </summary>
        /// <value>
        /// The test scope.
        /// </value>
        protected TestContext TestContext { get; set; }

        /// <summary>
        /// Gets the kernel
        /// </summary>
        protected StandardKernel Kernel { get; private set; }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Kernel.Dispose();
        }

        /// <summary>
        /// Starts this a test scope.
        /// </summary>
        /// <param name="testContext">The test context.</param>
        public virtual void Start(TestContext testContext)
        {
            this.Kernel = new StandardKernel();
            this.TestContext = testContext;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestScopeBase" /> class.
        /// </summary>
        protected virtual void RegisterServices()
        {
            // No implementation yet
        }
    }
}
