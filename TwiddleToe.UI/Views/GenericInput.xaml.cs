﻿// <copyright file="GenericInput.xaml.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.Views
{
    using System.Windows;
    using TwiddleToe.Foundation.Interfaces.Display;
    using TwiddleToe.Foundation.Interfaces.Locations;
    using TwiddleToe.UI.Interfaces;

    /// <summary>
    /// Generic input view.
    /// </summary>
    /// <seealso cref="Window" />
    /// <seealso cref="IView" />
    /// <seealso cref="ICenterScreen" />
    /// <seealso cref="IShowDialog" />
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