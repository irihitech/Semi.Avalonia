using System.Collections;
using Avalonia;
using Avalonia.Controls.Primitives;

namespace Semi.Avalonia.Demo.Controls;

public partial class FunctionalColorGroupControl : TemplatedControl
{
    [GeneratedStyledProperty] public partial string? Title { get; set; }
    [GeneratedDirectProperty] public partial IEnumerable? LightColors { get; set; }
    [GeneratedDirectProperty] public partial IEnumerable? DarkColors { get; set; }
}