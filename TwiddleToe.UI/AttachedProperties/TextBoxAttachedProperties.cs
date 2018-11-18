// <copyright file="TextBoxAttachedProperties.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.AttachedProperties
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using TwiddleToe.UI.AttachedProperties.Base;

    /// <summary>
    /// Attached property for handling focus changes in the UI
    /// </summary>
    public class TextBoxAttachedProperties : BaseAttachedProperty<TextBoxAttachedProperties, bool>
    {
        /// <summary>
        /// Called when [value changed].
        /// </summary>
        /// <param name="sender">The d.</param>
        /// <param name="e">The <see cref="T:System.Windows.DependencyPropertyChangedEventArgs" /> instance containing the event data.</param>
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
               if (e.NewValue is bool newValue)
                {
                    if (newValue == true)
                    {
                        textBox.Focus();
                    }
                }
            }
        }
    }
}
