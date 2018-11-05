// <copyright file="GenericInput.xaml.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.Windows
{
    using System.Windows;
    using TwiddleToe.Foundation.Interfaces;
    using TwiddleToe.Foundation.Interfaces.Locations;
    using TwiddleToe.UI.Interfaces;

    /// <summary>
    /// Interaction logic for GenericInput.xaml
    /// </summary>
    /// <seealso cref="System.Windows.Window" />
    /// <seealso cref="TwiddleToe.Foundation.Interfaces.IBaseView" />
    /// <seealso cref="TwiddleToe.Foundation.Interfaces.Locations.ICenterScreen" />
    /// <seealso cref="TwiddleToe.Foundation.Interfaces.IShowDialog" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class GenericInput : Window, IView, ICenterScreen, IShowDialog
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GenericInput"/> class.
        /// </summary>
        public GenericInput()
        {
            this.InitializeComponent();
        }
    }
}
