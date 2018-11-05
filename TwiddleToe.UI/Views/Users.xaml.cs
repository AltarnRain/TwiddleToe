// <copyright file="Users.xaml.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.Views
{
    using System.Windows;
    using TwiddleToe.Foundation.Interfaces.Locations;
    using TwiddleToe.UI.Interfaces;

    /// <summary>
    /// Interaction logic for Users.xaml
    /// </summary>
    public partial class Users : Window, ICenterScreen, IView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Users" /> class.
        /// </summary>
        public Users()
        {
            this.InitializeComponent();
        }
    }
}
