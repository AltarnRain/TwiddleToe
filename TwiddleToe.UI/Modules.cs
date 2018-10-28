// <copyright file="Modules.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI
{
    using Ninject.Modules;
    using TwiddleToe.Providers;
    using TwiddleToe.Utilities.Factories;

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
            this.Kernel.Bind<ProgramInformationProvider>().ToSelf().InSingletonScope();
            this.Kernel.Bind<ViewFactory>().ToSelf().InSingletonScope();
        }
    }
}