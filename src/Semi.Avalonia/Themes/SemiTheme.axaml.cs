using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;
using Semi.Avalonia.Locale;

namespace Semi.Avalonia;

public class SemiTheme : Styles
{
    public static ThemeVariant Aquatic => new ThemeVariant(nameof(Aquatic), ThemeVariant.Dark);
    public static ThemeVariant Desert => new ThemeVariant(nameof(Desert), ThemeVariant.Light);
    public static ThemeVariant Dust => new ThemeVariant(nameof(Dust), ThemeVariant.Dark);
    public static ThemeVariant NightSky => new ThemeVariant(nameof(NightSky), ThemeVariant.Dark);
    
    private static readonly Dictionary<CultureInfo, ResourceDictionary> _localeToResource = new()
    {
        { new CultureInfo("zh-cn"), new zh_cn() },
        { new CultureInfo("en-us"), new en_us() },
        { new CultureInfo("ja-jp"), new ja_jp() },
        { new CultureInfo("ru-ru"), new ru_ru() },
    };

    private readonly IServiceProvider? sp;
    public SemiTheme(IServiceProvider? provider = null)
    {
        sp = provider;
        AvaloniaXamlLoader.Load(provider, this);
    }

    private CultureInfo? _locale;
    public CultureInfo? Locale
    {
        get => _locale;
        set
        {
            _locale = value;
            var resource = TryGetLocaleResource(value);
            if (resource is null) return;
            foreach (var kv in resource)
            {
                this.Resources.Add(kv);
            }
        }
    }

    private static ResourceDictionary? TryGetLocaleResource(CultureInfo? locale)
    {
        if (locale is null)
        {
            return _localeToResource[new CultureInfo("zh-cn")];
        }
        if (_localeToResource.TryGetValue(locale, out var resource))
        {
            return resource;
        }
        return _localeToResource[new CultureInfo("zh-cn")];
    }
}