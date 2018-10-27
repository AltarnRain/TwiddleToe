// <copyright file="TestScopeBase.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Providers.Tests
{
    using System;
    using Ninject;
    using TwiddleToe.Test.Base;

    /// <summary>
    /// Test scope for provider unit tests.
    /// </summary>
    /// <seealso cref="TwiddleToe.Test.Base.ITestScope" />
    public abstract class TestScopeBase : ITestScope, IDisposable
    {
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
        public virtual void Start()
        {
            this.Kernel = new StandardKernel();
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
