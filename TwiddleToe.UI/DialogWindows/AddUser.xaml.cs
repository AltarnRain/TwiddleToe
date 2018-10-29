// <copyright file="AddUser.xaml.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.DialogWindows
{
    using System.Windows;
    using TwiddleToe.UI.DialogWindows.ViewModels;
    using TwiddleToe.UI.Factories;

    /// <summary>
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddUser" /> class.
        /// </summary>
        /// <param name="viewFactory">The view factory.</param>
        public AddUser(ViewFactory viewFactory)
        {
            this.InitializeComponent();
            var viewModel = viewFactory.GetViewModel<AddUserViewModel>(() => this.Close());
            this.DataContext = viewModel;

            viewModel.OnRequestClose += () => { this.Close(); };
        }
    }
}
