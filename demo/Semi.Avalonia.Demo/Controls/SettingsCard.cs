using Avalonia;
using Avalonia.Controls;

namespace Semi.Avalonia.Demo.Controls;

public partial class SettingsCard : ContentControl
{
    [GeneratedStyledProperty] public partial object? Icon { get; set; }
    [GeneratedStyledProperty] public partial object? Description { get; set; }
    [GeneratedStyledProperty] public partial object? RightContent { get; set; }
}
