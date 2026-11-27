using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Primitives;
using Avalonia.Data;

namespace Semi.Avalonia.Demo.Controls;

/// <summary>
/// A page entry of the navigation drawer. Selection is tracked by <see cref="IsSelected"/>,
/// not by the checked state, so clicking never changes the entry's look by itself.
/// </summary>
[PseudoClasses(":selected")]
public partial class NavItem : ToggleButton
{
    public NavItem()
    {
        UpdatePseudoClasses(IsSelected);
    }

    [GeneratedStyledProperty(DefaultBindingMode = BindingMode.TwoWay)]
    public partial bool IsSelected { get; set; }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        if (change.Property == IsSelectedProperty)
        {
            UpdatePseudoClasses(change.GetNewValue<bool>());
        }
    }

    private void UpdatePseudoClasses(bool isSelected)
    {
        PseudoClasses.Set(":selected", isSelected);
    }
}
