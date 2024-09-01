using System.Runtime.Versioning;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Browser;

[assembly: SupportedOSPlatform("browser")]

namespace Semi.Avalonia.Demo.Web;

internal sealed partial class Program
{
    private static Task Main(string[] args) => BuildAvaloniaApp()
        .WithSourceHanSansCNFont()
        .StartBrowserAppAsync("out", new BrowserPlatformOptions
        {
            RenderingMode = [ BrowserRenderingMode.WebGL2, BrowserRenderingMode.WebGL1, BrowserRenderingMode.Software2D],
        });

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>();
}