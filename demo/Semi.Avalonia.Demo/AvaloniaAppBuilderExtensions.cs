using System;
using Avalonia;
using Avalonia.Media;
using Avalonia.Media.Fonts;

namespace Semi.Avalonia.Demo;

public static class AvaloniaAppBuilderExtensions
{
    public static AppBuilder WithSemiFont(this AppBuilder builder) =>
        builder.With(new FontManagerOptions
        {
            DefaultFamilyName = FontSettings.DefaultFontFamily,
            FontFallbacks = new[]
            {
                new FontFallback
                {
                    FontFamily = new FontFamily(FontSettings.DefaultFontFamily)
                }
            }
        }).ConfigureFonts(manager =>
            manager.AddFontCollection(new EmbeddedFontCollection(FontSettings.Key, FontSettings.Source)));
}

public static class FontSettings
{
    public static string DefaultFontFamily { get; set; } =
        "fonts:Alibaba PuHuiTi#Alibaba PuHuiTi 2.0";

    public static Uri Key { get; set; } = new Uri("fonts:Alibaba PuHuiTi", UriKind.Absolute);

    public static Uri Source { get; set; } =
        new Uri("avares://Semi.Avalonia.Demo/Assets/Fonts", UriKind.Absolute);
}