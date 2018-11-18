// <copyright file="BaseAttachedProperty.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.AttachedProperties.Base
{
    using System;
    using System.Windows;

    /// <summary>
    /// A base class for attached properties
    /// </summary>
    /// <typeparam name="Parent">The type of the arent.</typeparam>
    /// <typeparam name="Property">The type of the roperty.</typeparam>
    public abstract class BaseAttachedProperty<Parent, Property>
        where Parent : BaseAttachedProperty<Parent, Property>, new()
    {
        /// <summary>
        /// The value property
        /// </summary>
        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached(
          "Value",
          typeof(Property),
          typeof(BaseAttachedProperty<Parent, Property>),
          new PropertyMetadata(new PropertyChangedCallback(OnValuePropertyChanged)));

        /// <summary>
        /// Stores an instance of the parent class
        /// </summary>
        public static readonly Parent Instance = new Parent();

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="value">The value.</param>
        public static void SetValue(DependencyObject element, Property value)
        {
            element.SetValue(ValueProperty, value);
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <returns>The current value of the property</returns>
        public static Property GetValue(DependencyObject d) => (Property)d.GetValue(ValueProperty);

        /// <summary>
        /// Called when [value changed].
        /// </summary>
        /// <param name="sender">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        public abstract void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e);

        /// <summary>
        /// Called when [value changed].
        /// </summary>
        /// <param name="sender">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnValuePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            Instance.OnValueChanged(sender, e);
        }
    }
}
