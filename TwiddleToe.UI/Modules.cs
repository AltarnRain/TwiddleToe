// <copyright file="Modules.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI
{
    using Ninject.Modules;
    using TwiddleToe.Foundation;
    using TwiddleToe.Foundation.Registries;
    using TwiddleToe.Workers.Factories;
    using TwiddleToe.Workers.FileHandlers;
    using TwiddleToe.Workers.Providers;

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
            this.Bind<IdentityProvider>().ToSelf().InSingletonScope();
            this.Bind<StateProvider>().ToSelf().InSingletonScope();
            this.Bind<StateFileHandler>().ToSelf().InSingletonScope();
            this.Bind<IProgramInformationProvider>().To<ProgramInformationProvider>().InSingletonScope();
            this.Bind<UserProvider>().ToSelf().InSingletonScope();
            this.Bind<ViewModelFactory>().ToSelf().InSingletonScope();
            this.Bind<ViewModelRegistry>().ToSelf().InSingletonScope();
            this.Bind<SubjectProvider>().ToSelf().InSingletonScope();
            this.Bind<ViewProvider>().ToSelf().InSingletonScope();
        }
    }
}