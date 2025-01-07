using System.Collections.Generic;
using System.Runtime.InteropServices;
using Avalonia;
using Avalonia.Media;
using Avalonia.Platform;
using Avalonia.Styling;

namespace Semi.Avalonia;

public static class ApplicationExtension
{
    private static Application _app = null!;

    private static readonly Dictionary<Color, ThemeVariant> ColorThemeMap = new()
    {
        [Color.Parse("#8EE3F0")] = SemiTheme.Aquatic,
        [Color.Parse("#903909")] = SemiTheme.Desert,
        [Color.Parse("#A1BFDE")] = SemiTheme.Dusk,
        [Color.Parse("#D6B4FD")] = SemiTheme.NightSky
    };

    public static void RegisterFollowSystemTheme(this Application app)
    {
        _app = app;
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) return;
        if (app.PlatformSettings is null) return;
        app.PlatformSettings.ColorValuesChanged -= OnColorValuesChanged;
        app.PlatformSettings.ColorValuesChanged += OnColorValuesChanged;
        OnColorValuesChanged(null, app.PlatformSettings?.GetColorValues());
    }

    public static void UnregisterFollowSystemTheme(this Application app)
    {
        _app = app;
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) return;
        if (app.PlatformSettings is null) return;
        app.PlatformSettings.ColorValuesChanged -= OnColorValuesChanged;
    }

    private static void OnColorValuesChanged(object? _, PlatformColorValues? args)
    {
        ThemeVariant result;
        if (args?.ContrastPreference is ColorContrastPreference.High)
        {
            result = ColorThemeMap.TryGetValue(args.AccentColor1, out var theme) ? theme : ThemeVariant.Default;
        }
        else
        {
            result = args?.ThemeVariant switch
            {
                PlatformThemeVariant.Light => ThemeVariant.Light,
                PlatformThemeVariant.Dark => ThemeVariant.Dark,
                _ => ThemeVariant.Default
            };
        }

        _app.RequestedThemeVariant = result;
    }
}