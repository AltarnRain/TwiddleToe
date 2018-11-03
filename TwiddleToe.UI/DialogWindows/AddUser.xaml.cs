// <copyright file="AddUser.xaml.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.DialogWindows
{
    using System.Windows;
    using TwiddleToe.UI.DialogWindows.ViewModels;
    using TwiddleToe.Workers.Factories;

    /// <summary>
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddUser" /> class.
        /// </summary>
        /// <param name="viewModelFactory">The view model factory.</param>
        public AddUser(ViewModelFactory viewModelFactory)
        {
            this.InitializeComponent();
            var viewModel = viewModelFactory.GetViewModel<AddUserViewModel>(() => this.Close());
            this.DataContext = viewModel;
        }
    }
}
