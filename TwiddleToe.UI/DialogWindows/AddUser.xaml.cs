// <copyright file="AddUser.xaml.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.DialogWindows
{
    using System.Windows;
    using TwiddleToe.Foundation.Interfaces;
    using TwiddleToe.UI.Interfaces;

    /// <summary>
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Window, IView, IShowDialog
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddUser" /> class.
        /// </summary>
        public AddUser()
        {
            this.InitializeComponent();
        }
    }
}
