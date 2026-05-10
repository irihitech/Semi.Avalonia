using System;
using Avalonia;
using Avalonia.Dialogs;
using Avalonia.Media;
using Semi.Avalonia.Demo.Fonts;

namespace Semi.Avalonia.Demo.Desktop;
#pragma warning disable AVALONIA_X11_CSD, AVALONIA_X11_FORCE_CSD

sealed class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UseManagedSystemDialogs()
            .UsePlatformDetect()
            .With(new Win32PlatformOptions())
            .With(new X11PlatformOptions { EnableDrawnDecorations = true, ForceDrawnDecorations = true })
            .WithSourceHanSansCNFont()
            .LogToTrace();
}
