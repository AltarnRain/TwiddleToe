﻿// <copyright file="Modules.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Providers
{
    using Ninject.Modules;

    /// <summary>
    /// Bindings for Modules.
    /// </summary>
    /// <seealso cref="Ninject.Modules.NinjectModule" />
    public class Modules : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            this.Kernel.Bind<IdentityProvider>().ToSelf().InSingletonScope();
            this.Kernel.Bind<StateProvider>().ToSelf().InSingletonScope();
            this.Kernel.Bind<ProgramInformation>().ToSelf().InSingletonScope();
        }
    }
}
