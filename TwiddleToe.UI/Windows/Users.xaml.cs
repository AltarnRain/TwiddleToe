// <copyright file="Users.xaml.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.Windows
{
    using System.Windows;
    using TwiddleToe.Foundation.Interfaces;

    /// <summary>
    /// Interaction logic for Users.xaml
    /// </summary>
    public partial class Users : Window, IBaseView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Users" /> class.
        /// </summary>
        public Users()
        {
            this.InitializeComponent();

            this.Show();
        }
    }
}
