using System.Runtime.Versioning;
using Avalonia;
using Avalonia.Media;
using Avalonia.Web;
using Semi.Avalonia.Demo.Web;

[assembly: SupportedOSPlatform("browser")]

internal partial class Program
{
    private static void Main(string[] args) => BuildAvaloniaApp()
        .With(new FontManagerOptions
        {
            FontFallbacks = new[]
            {
                new FontFallback
                {
                    FontFamily = new FontFamily("avares://Semi.Avalonia.Demo.Web/Assets/SourceHanSansCN-Regular.otf#Source Han Sans CN")
                }
            }
        })
        .SetupBrowserApp("out");

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>();
}