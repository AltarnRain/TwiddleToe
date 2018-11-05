// <copyright file="Main.xaml.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.Views
{
    using System.Windows;
    using TwiddleToe.UI.Interfaces.Display;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// <seealso cref="Window" />
    /// <seealso cref="IMainMenu" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class MainWindow : Window, IMainMenu
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow" /> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }
    }
}
