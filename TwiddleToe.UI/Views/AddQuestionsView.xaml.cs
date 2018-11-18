// <copyright file="AddQuestionsView.xaml.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.Views
{
    using System.Windows;
    using TwiddleToe.Foundation.Interfaces.Locations;
    using TwiddleToe.UI.Interfaces;

    /// <summary>
    /// Interaction logic for AddQuestionsView.xaml
    /// </summary>
    public partial class AddQuestionsView : Window, IView, ICenterScreen
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddQuestionsView"/> class.
        /// </summary>
        public AddQuestionsView()
        {
            this.InitializeComponent();
        }
    }
}
