// <copyright file="Main.xaml.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.Windows
{
    using System.Windows;
    using TwiddleToe.UI.Factories;
    using TwiddleToe.UI.ViewModels;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow" /> class.
        /// </summary>
        /// <param name="viewFactory">The view factory.</param>
        public MainWindow(ViewFactory viewFactory)
        {
            this.InitializeComponent();
            this.DataContext = viewFactory.GetViewModel<MainViewModel>(() => this.Close());
#if !DEBUG
            this.Top = 0;
            this.Left = 0;
            this.Width = SystemParameters.WorkArea.Width;
#endif
        }
    }
}
