// <copyright file="Main.xaml.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.Windows
{
    using System.Windows;
    using TwiddleToe.Foundation.Interfaces;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IShowDialog
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow" /> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();

#if !DEBUG
            this.Top = 0;
            this.Left = 0;
            this.Width = SystemParameters.WorkArea.Width;
#endif
        }
    }
}
