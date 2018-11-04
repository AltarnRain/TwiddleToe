// <copyright file="App.xaml.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.Windows
{
    using System.Windows;
    using Ninject;
    using TwiddleToe.Foundation.Registries;
    using TwiddleToe.UI.ViewModels;
    using TwiddleToe.Workers.Factories;
    using TwiddleToe.Workers.Providers;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Handles the Startup event of the App control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.StartupEventArgs" /> instance containing the event data.</param>
        public void App_Startup(object sender, StartupEventArgs e)
        {
            using (var kernel = new StandardKernel(new Modules()))
            {
                var viewProvider = kernel.Get<ViewProvider>();
                var viewModelRegistry = kernel.Get<ViewModelRegistry>();
                var stateProvider = kernel.Get<StateProvider>();
                viewProvider.Show<MainWindow, MainViewModel>();

                // Use the view model registry to issue a command to all active view models that their
                // bound views should issue a close command.
                viewModelRegistry.CloseAllActive();

                // Flush the state to a file to file.
                stateProvider.Flush();
            }
        }
    }
}
