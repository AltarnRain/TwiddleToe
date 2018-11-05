// <copyright file="Subjects.xaml.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.Windows
{
    using System.Windows;
    using TwiddleToe.Foundation.Interfaces.Locations;
    using TwiddleToe.UI.Interfaces;

    /// <summary>
    /// Interaction logic for Subjects.xaml
    /// </summary>
    public partial class Subjects : Window, ICenterScreen, IView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Subjects"/> class.
        /// </summary>
        public Subjects()
        {
            this.InitializeComponent();
        }
    }
}
