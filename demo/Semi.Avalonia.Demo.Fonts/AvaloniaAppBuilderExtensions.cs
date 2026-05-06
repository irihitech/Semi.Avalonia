using Avalonia;
using Avalonia.Media;

namespace Semi.Avalonia.Demo.Fonts;

public static class AvaloniaAppBuilderExtensions
{
    public static AppBuilder WithSourceHanSansCNFont(this AppBuilder builder)
    {
        const string uri = "avares://Semi.Avalonia.Demo.Fonts/Assets#Source Han Sans CN";
        return builder.With(new FontManagerOptions
        {
            DefaultFamilyName = uri, FontFallbacks = [new FontFallback { FontFamily = new FontFamily(uri) }]
        });
    }
}
