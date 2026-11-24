using System.Collections;
using Avalonia;
using Avalonia.Controls.Primitives;

namespace Semi.Avalonia.Demo.Controls;

public partial class ShadowGroupControl : TemplatedControl
{
    [GeneratedStyledProperty] public partial string? Title { get; set; }
    [GeneratedDirectProperty] public partial IEnumerable? LightShadows { get; set; }
    [GeneratedDirectProperty] public partial IEnumerable? DarkShadows { get; set; }
}