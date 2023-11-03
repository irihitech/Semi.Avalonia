using Avalonia;
using Avalonia.Dialogs;
using Avalonia.Media;
using System;
using System.Linq;
using System.Threading;

namespace Semi.Avalonia.Demo.Drm
{
    internal class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        [STAThread]
        public static void Main(string[] args)
        {
            var builder = BuildAvaloniaApp();
            builder.With(new FontManagerOptions
            {
                FontFallbacks = new[]
                {
                new FontFallback
                {
                    FontFamily = new FontFamily("Microsoft YaHei")
                }
            }
            });
            if (args.Contains("--drm"))
            {
                SilenceConsole();
                builder.StartLinuxDrm(args: args, card: "/dev/dri/card1", scaling: 1);
            }
            else
            {
                builder.StartWithClassicDesktopLifetime(args);
            }
        }

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UseManagedSystemDialogs()
                .UsePlatformDetect()
                .With(new Win32PlatformOptions())
                .LogToTrace();

        private static void SilenceConsole()
        {
            new Thread(() =>
            {
                Console.CursorVisible = false;
                while (true)
                    Console.ReadKey(true);
            })
            { IsBackground = true }.Start();
        }
    }
}