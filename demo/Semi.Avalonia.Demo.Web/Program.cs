using System.Runtime.Versioning;
using Avalonia;
using Avalonia.Media;
using Semi.Avalonia.Demo.Web;
using Avalonia.Browser;

[assembly: SupportedOSPlatform("browser")]

internal partial class Program
{
    private static void Main(string[] args)
    {
        BuildAvaloniaApp(); //.SetupBrowserApp("out");
    }

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>();
}