# DRM启动步骤

[English](README.md)

(Ubuntu 20.04 live server linux-x64 虚拟机测试成功)  
(Orange Pi Zero2 Ubuntu20.04-arm64 测试成功)

[Avalonia 官方参考文档](https://docs.avaloniaui.net/docs/next/guides/platforms/rpi/running-on-raspbian-lite-via-drm)

## 搭建运行环境

1. Linux端运行命令
```bash
sudo apt update
sudo apt upgrade
sudo reboot
sudo apt-get install libgbm1 libgl1-mesa-dri libegl1-mesa libinput10
```

2. 安装测试工具(出现一个彩色立方体说明环境安装完成)  
```bash
sudo apt-get install kmscube
sudo kmscube
```

3. [安装.net运行时](https://learn.microsoft.com/dotnet/core/install/linux?WT.mc_id=dotnet-35129-website)

4. NuGet里面添加Avalonia.LinuxFramebuffer包

```bash
dotnet add package Avalonia.LinuxFramebuffer
```

5. 添加StartLinuxDrm代码

```csharp
public static int Main(string[] args)
{
    var builder = BuildAvaloniaApp();
    if (args.Contains("--drm"))
    {
        SilenceConsole();
        // By default, Avalonia will try to detect output card automatically.
        // But you can specify one, for example "/dev/dri/card1".
        return builder.StartLinuxDrm(args: args, card: null, scaling: 1.0);
    }

    return builder.StartWithClassicDesktopLifetime(args);
}

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
```

6. 发布程序到Linux

```bash
dotnet publish demo/Semi.Avalonia.Demo.Drm/Semi.Avalonia.Demo.Drm.csproj -c Release -r linux-x64 --sc -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true
```

AOT发布需要在csproj文件中添加以下代码

```xml
<PropertyGroup>
    <PublishAot>true</PublishAot>
    <IncludeNativeLibrariesForSelfExtract>true</IncludeNativeLibrariesForSelfExtract>
</PropertyGroup>
```

```bash
dotnet publish demo/Semi.Avalonia.Demo.Drm/Semi.Avalonia.Demo.Drm.csproj -c Release -r linu-x64
```

7. 运行程序

```bash
sudo ./Semi.Avalonia.Demo.Drm --drm
```

## 报错处理

1. 报错内容

> Unhandled exception. Avalonia.Markup.Xaml.XamlLoadException: No precompiled XAML found for avares://Semi.Avalonia/Themes/Light/Light.axaml (baseUri: avares://Semi.Avalonia/Themes/Index.axaml), make sure to specify x:Class and include your XAML file as AvaloniaResource

解决方法：

如果使用Semi发布文件不要裁剪，如果裁剪会报错。

24.8.18更新：现在已经修复了这个问题。

2. 报错内容

> Unhandled exception. System.TypeInitializationException: The type initializer for 'SkiaSharp.SKImageInfo' threw an exception.**
    **--->System.DllNotFoundException: Unable to load shared library 'libSkiaSharp' or one of its dependencies.In order to help diagnose loading problems, consider setting the LD_DEBUG environment variable: liblibSkiaSharp: cannot open shared object file: No such file or directory
    at SkiaSharp.SkiaApi.sk_colortype_get_default_8888()
    at SkiaSharp.SKImageInfo..cctor()

解决方法：

Linux 命令行安装

```bash
sudo apt-get install -y libfontconfig1  
```

[参考网址](https://github.com/mono/SkiaSharp/issues/509)

3. 报错内容

> Permission denied

解决方法：

添加执行权限
```bash
sudo chmod +x ./Semi.Avalonia.Demo.Drm
```

4. 报错内容

> Unhandled exception. System.ComponentModel.Win32Exception (95): drmModeGetResources failed
at Avalonia.LinuxFramebuffer.Output.DrmResources..ctor(Int32 fd, Boolean connectorsForceProbe) in /_/src/Linux/Avalonia.LinuxFramebuffer/Output/DrmBindings.cs:line 91
at Avalonia.LinuxFramebuffer.Output.DrmCard.GetResources(Boolean connectorsForceProbe) in /_/src/Linux/Avalonia.LinuxFramebuffer/Output/DrmBindings.cs:line 171
at Avalonia.LinuxFramebuffer.Output.DrmOutput..ctor(String path, Boolean connectorsForceProbe, DrmOutputOptions options) in /_/src/Linux/Avalonia.LinuxFramebuffer/Output/DrmOutput.cs:line 60
at LinuxFramebufferPlatformExtensions.StartLinuxDrm(AppBuilder builder, String[] args, String card, Double scaling, IInputBackend inputBackend) in /_/src/Linux/Avalonia.LinuxFramebuffer/LinuxFramebufferPlatform.cs:line 166
at Semi.Avalonia.Demo.Drm.Program.Main(String[] args)

解决方法：

`program.cs`的显卡路径错误，可能不是`dev/dri/card1`，看在`dev/dri`目录下有无其他的显卡如`card0`。

24.8.18更新：现在Avalonia会自动检测显卡路径，所以不需要指定显卡路径。

```csharp
return builder.StartLinuxDrm(args: args, card: null, scaling: 1.0);
```

5. 报错内容
>Unhandled exception. System.ComponentModel.Win32Exception (2): Couldn't open /dev/dri/card1
at Avalonia.LinuxFramebuffer.Output.DrmCard..ctor(String ) in /_/src/Linux/Avalonia.LinuxFramebuffer/Output/DrmBindings.cs:line 167
at Avalonia.LinuxFramebuffer.Output.DrmOutput..ctor(String , Boolean , DrmOutputOptions ) in /_/src/Linux/Avalonia.LinuxFramebuffer/Output/DrmOutput.cs:line 58
at LinuxFramebufferPlatformExtensions.StartLinuxDrm(AppBuilder, String[], String , Double , IInputBackend ) in /_/src/Linux/Avalonia.LinuxFramebuffer/LinuxFramebufferPlatform.cs:line 166
at Semi.Avalonia.Demo.Drm.Program.Main(String[])

解决办法：

找不到显卡路径`dev/dri/card1`，可能是显卡挂载到别的文件夹下了。

24.8.18更新：现在Avalonia会自动检测显卡路径，所以不需要指定显卡路径。

```csharp
return builder.StartLinuxDrm(args: args, card: null, scaling: 1.0);
```