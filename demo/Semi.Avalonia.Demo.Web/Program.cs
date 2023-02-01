using System.Runtime.Versioning;
using Avalonia;
using Avalonia.Media;
using Avalonia.Web;
using Semi.Avalonia.Demo.Web;

[assembly: SupportedOSPlatform("browser")]

internal partial class Program
{
    private static void Main(string[] args)
    {
        BuildAvaloniaApp();
    }

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>();
}