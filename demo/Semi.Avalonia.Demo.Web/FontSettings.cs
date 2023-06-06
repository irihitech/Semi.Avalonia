using System;

namespace Semi.Avalonia.Demo.Web;
public class FontSettings
{
    public string DefaultFontFamily = "fonts:AntDesignFontFamilies#Alibaba PuHuiTi 2.0";
    public Uri Key { get; set; } = new Uri("fonts:AntDesignFontFamilies", UriKind.Absolute);
    public Uri Source { get; set; } = new Uri("avares://Semi.Avalonia.Demo.Web/Assets/Fonts/AliBaba", UriKind.Absolute);
}
