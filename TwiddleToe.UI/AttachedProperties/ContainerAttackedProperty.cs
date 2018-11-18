namespace TwiddleToe.UI.AttachedProperties
{
    using System.Windows;
    using System.Windows.Controls;
    using TwiddleToe.UI.AttachedProperties.Base;

    public class ContainerAttackedProperty : BaseAttachedProperty<ContainerAttackedProperty, int>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender is Panel panel)
            {
                if (e.NewValue is int index)
                {
                    if (panel.Children[index] is UIElement element)
                    {
                        element.Focus();
                    }
                }
            }
        }
    }
}
