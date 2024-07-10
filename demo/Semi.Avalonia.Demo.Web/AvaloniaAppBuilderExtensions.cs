using Avalonia;
using Avalonia.Media;

namespace Semi.Avalonia.Demo.Web;

public static class AvaloniaAppBuilderExtensions
{
    private static string DefaultFontFamily => "avares://Semi.Avalonia.Demo.Web/Assets#Source Han Sans CN";

    public static AppBuilder WithSourceHanSansCNFont(this AppBuilder builder) =>
        builder.With(new FontManagerOptions
        {
            DefaultFamilyName = DefaultFontFamily,
            FontFallbacks = new[] { new FontFallback { FontFamily = new FontFamily(DefaultFontFamily) } }
        });
}