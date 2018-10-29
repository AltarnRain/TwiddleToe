// <copyright file="App.xaml.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.Windows
{
    using System.Windows;
    using Ninject;
    using TwiddleToe.UI.Factories;

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
                var viewFactory = kernel.Get<ViewFactory>();
                var mainWindow = viewFactory.GetView<MainWindow>();
                mainWindow.ShowDialog();
            }
        }
    }
}
