// <copyright file="Users.xaml.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.Windows
{
    using System.Windows;
    using TwiddleToe.UI.Factories;
    using TwiddleToe.UI.ViewModels;

    /// <summary>
    /// Interaction logic for Users.xaml
    /// </summary>
    public partial class Users : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Users" /> class.
        /// </summary>
        /// <param name="viewModelFactory">The view model factory.</param>
        public Users(ViewFactory viewModelFactory)
        {
            this.InitializeComponent();
            this.DataContext = viewModelFactory.GetViewModel<UsersViewModel>(() => { });
        }
    }
}
