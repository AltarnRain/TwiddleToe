// <copyright file="Subjects.xaml.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.Views
{
    using System.Windows;
    using TwiddleToe.UI.Interfaces.Display;

    /// <summary>
    /// Interaction logic for Subjects.xaml
    /// </summary>
    public partial class Subjects : Window, IEntryView
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
