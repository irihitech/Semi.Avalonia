using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Data;

namespace Semi.Avalonia.Demo.Controls;

/// <summary>
/// The header of a navigation section, toggling the section's page list.
/// </summary>
public partial class NavSectionHeader : ToggleButton
{
    [GeneratedStyledProperty(DefaultBindingMode = BindingMode.TwoWay)]
    public partial bool IsExpanded { get; set; }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        if (change.Property == IsExpandedProperty)
        {
            SetCurrentValue(IsCheckedProperty, IsExpanded);
        }
        else if (change.Property == IsCheckedProperty)
        {
            SetCurrentValue(IsExpandedProperty, IsChecked == true);
        }
    }
}
