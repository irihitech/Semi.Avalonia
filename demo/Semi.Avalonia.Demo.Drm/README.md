# DRM Start Steps

[中文](README_CN.md)

(Ubuntu 20.04 live server linux-x64 Virtual Machine Test Success)  
(Orange Pi Zero2 Ubuntu20.04-arm64 Test Success)

[Avalonia Official Reference Document](https://docs.avaloniaui.net/docs/next/guides/platforms/rpi/running-on-raspbian-lite-via-drm)

## Setup Running Environment

1. Run the following commands on the Linux side
```bash
sudo apt update
sudo apt upgrade
sudo reboot
sudo apt-get install libgbm1 libgl1-mesa-dri libegl1-mesa libinput10
```

2. Install the test tool (if a colored cube appears, the environment is installed)
```bash
sudo apt-get install kmscube
sudo kmscube
```

3. [Install .NET Runtime](https://learn.microsoft.com/dotnet/core/install/linux?WT.mc_id=dotnet-35129-website)

4. Add the Avalonia.LinuxFramebuffer package in NuGet

```bash
dotnet add package Avalonia.LinuxFramebuffer
```

5. Add StartLinuxDrm code

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

6. Publish the app to Linux

```bash
dotnet publish demo/Semi.Avalonia.Demo.Drm/Semi.Avalonia.Demo.Drm.csproj -c Release -r linux-x64 --sc -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true
```

Add the following code to the csproj file for AOT publishing

```xml
<PropertyGroup>
    <PublishAot>true</PublishAot>
    <IncludeNativeLibrariesForSelfExtract>true</IncludeNativeLibrariesForSelfExtract>
</PropertyGroup>
```

```bash
dotnet publish demo/Semi.Avalonia.Demo.Drm/Semi.Avalonia.Demo.Drm.csproj -c Release -r linu-x64
```

7. Run the program

```bash
sudo ./Semi.Avalonia.Demo.Drm --drm
```

## Troubleshooting

1. Error message

> Unhandled exception. Avalonia.Markup.Xaml.XamlLoadException: No precompiled XAML found for avares://Semi.Avalonia/Themes/Light/Light.axaml (baseUri: avares://Semi.Avalonia/Themes/Index.axaml), make sure to specify x:Class and include your XAML file as AvaloniaResource

Solution:

If you use the Semi release file, do not trim it, otherwise an error will occur.

24.8.18 update: This issue has been fixed.

2. Error message

> Unhandled exception. System.TypeInitializationException: The type initializer for 'SkiaSharp.SKImageInfo' threw an exception.**
    **--->System.DllNotFoundException: Unable to load shared library 'libSkiaSharp' or one of its dependencies.In order to help diagnose loading problems, consider setting the LD_DEBUG environment variable: liblibSkiaSharp: cannot open shared object file: No such file or directory
    at SkiaSharp.SkiaApi.sk_colortype_get_default_8888()
    at SkiaSharp.SKImageInfo..cctor()

Solution:

Linux CLI installation

```bash
sudo apt-get install -y libfontconfig1  
```
[Reference](https://github.com/mono/SkiaSharp/issues/509)

3. Error message

> Permission denied

Solution:

add permission

```bash
sudo chmod +x ./Semi.Avalonia.Demo.Drm
```

4. Error message

> Unhandled exception. System.ComponentModel.Win32Exception (95): drmModeGetResources failed
at Avalonia.LinuxFramebuffer.Output.DrmResources..ctor(Int32 fd, Boolean connectorsForceProbe) in /_/src/Linux/Avalonia.LinuxFramebuffer/Output/DrmBindings.cs:line 91
at Avalonia.LinuxFramebuffer.Output.DrmCard.GetResources(Boolean connectorsForceProbe) in /_/src/Linux/Avalonia.LinuxFramebuffer/Output/DrmBindings.cs:line 171
at Avalonia.LinuxFramebuffer.Output.DrmOutput..ctor(String path, Boolean connectorsForceProbe, DrmOutputOptions options) in /_/src/Linux/Avalonia.LinuxFramebuffer/Output/DrmOutput.cs:line 60
at LinuxFramebufferPlatformExtensions.StartLinuxDrm(AppBuilder builder, String[] args, String card, Double scaling, IInputBackend inputBackend) in /_/src/Linux/Avalonia.LinuxFramebuffer/LinuxFramebufferPlatform.cs:line 166
at Semi.Avalonia.Demo.Drm.Program.Main(String[] args)

Solution:

The `program.cs` graphics card path is incorrect, it may not be `dev/dri/card1`, see if there are other graphics cards in the `dev/dri` directory such as `card0`.

24.8.18 update: Avalonia will now automatically detect the graphics card path, so you don't need to specify the graphics card path.

```csharp
return builder.StartLinuxDrm(args: args, card: null, scaling: 1.0);
```

5. Error message
>Unhandled exception. System.ComponentModel.Win32Exception (2): Couldn't open /dev/dri/card1
at Avalonia.LinuxFramebuffer.Output.DrmCard..ctor(String ) in /_/src/Linux/Avalonia.LinuxFramebuffer/Output/DrmBindings.cs:line 167
at Avalonia.LinuxFramebuffer.Output.DrmOutput..ctor(String , Boolean , DrmOutputOptions ) in /_/src/Linux/Avalonia.LinuxFramebuffer/Output/DrmOutput.cs:line 58
at LinuxFramebufferPlatformExtensions.StartLinuxDrm(AppBuilder, String[], String , Double , IInputBackend ) in /_/src/Linux/Avalonia.LinuxFramebuffer/LinuxFramebufferPlatform.cs:line 166
at Semi.Avalonia.Demo.Drm.Program.Main(String[])

Solution:

Unable to open `/dev/dri/card1`, may be the graphics card is mounted to another folder.

24.8.18 update: Avalonia will now automatically detect the graphics card path, so you don't need to specify the graphics card path.

```csharp
return builder.StartLinuxDrm(args: args, card: null, scaling: 1.0);
```