using Avalonia;
using Avalonia.Dialogs;
using Avalonia.Media;
using System;
using System.Linq;
using System.Threading;

namespace Semi.Avalonia.Demo.Desktop;

class Program
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

        //DRM启动步骤(Ubuntu18.04Server版本 虚拟机测试OK)
        //官方文档：https://docs.avaloniaui.net/docs/next/guides/platforms/rpi/running-on-raspbian-lite-via-drm

        //1.Linux端运行命令
        //sudo apt update
        //sudo apt upgrade
        //sudo reboot
        //sudo apt - get install libgbm1 libgl1 - mesa - dri libegl1 - mesa libinput10

        //2.安装测试工具测试(出现一个彩色立方体说明环境安装完成)
        //sudo apt-get install kmscube
        //sudo kmscube

        //3.添加StartLinuxDrm代码

        //4.发布程序，复制到Linux系统(安装.net，怎么运行这些省略)
        //发布文件不要裁剪，如果裁剪会报错
        //Unhandled exception. Avalonia.Markup.Xaml.XamlLoadException: No precompiled XAML found for avares
        //://Semi.Avalonia/Themes/Light/Light.axaml (baseUri: avares://Semi.Avalonia/Themes/Index.axaml), m
        //ake sure to specify x:Class and include your XAML file as AvaloniaResource

        //5.运行

        //运行报错点：
        //Unhandled exception. System.TypeInitializationException: The type initializer for 'SkiaSharp.SKImageInfo' threw an exception.
        //--->System.DllNotFoundException: Unable to load shared library 'libSkiaSharp' or one of its dependencies.In order to help diagnose loading problems, consider setting the LD_DEBUG environment variable: liblibSkiaSharp: cannot open shared object file: No such file or directory
        //at SkiaSharp.SkiaApi.sk_colortype_get_default_8888()
        //at SkiaSharp.SKImageInfo..cctor()

        //解决方法：
        //Linux命令行安装一下 apt-get install -y libfontconfig1
        //网址：https://github.com/mono/SkiaSharp/issues/509

        if (args.Contains("--drm"))
        {
            SilenceConsole();
            builder.StartLinuxDrm(args: args, card: "/dev/dri/card0", scaling: 1);
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
