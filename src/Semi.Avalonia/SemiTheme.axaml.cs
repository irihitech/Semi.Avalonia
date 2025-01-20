using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;
using Semi.Avalonia.Locale;

namespace Semi.Avalonia;

public class SemiTheme : Styles
{
    public static ThemeVariant Aquatic => new ThemeVariant(nameof(Aquatic), ThemeVariant.Dark);
    public static ThemeVariant Desert => new ThemeVariant(nameof(Desert), ThemeVariant.Light);
    public static ThemeVariant Dusk => new ThemeVariant(nameof(Dusk), ThemeVariant.Dark);
    public static ThemeVariant NightSky => new ThemeVariant(nameof(NightSky), ThemeVariant.Dark);
    
    private static readonly ResourceDictionary _defaultResource = new zh_cn();
    
    private static readonly Dictionary<CultureInfo, ResourceDictionary> _localeToResource = new()
    {
        { new CultureInfo("zh-cn"), new zh_cn() },
        { new CultureInfo("en-us"), new en_us() },
        { new CultureInfo("ja-jp"), new ja_jp() },
        { new CultureInfo("uk-ua"), new uk_ua() },
        { new CultureInfo("ru-ru"), new ru_ru() },
        { new CultureInfo("zh-tw"), new zh_tw() },
        { new CultureInfo("de-de"), new de_de() },
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
            try
            {
                if (TryGetLocaleResource(value, out var resource) && resource is not null)
                {
                    _locale = value;
                    foreach (var kv in resource) Resources[kv.Key] = kv.Value;
                }
                else
                {
                    _locale = new CultureInfo("zh-CN");
                    foreach (var kv in _defaultResource) Resources[kv.Key] = kv.Value;
                }
            }
            catch
            {
                _locale = CultureInfo.InvariantCulture;
            }
        }
    }

    private static bool TryGetLocaleResource(CultureInfo? locale, out ResourceDictionary? resourceDictionary)
    {
        if (Equals(locale, CultureInfo.InvariantCulture))
        {
            resourceDictionary = _defaultResource;
            return true;
        }

        if (locale is null)
        {
            resourceDictionary = _defaultResource;
            return false;
        }

        if (_localeToResource.TryGetValue(locale, out var resource))
        {
            resourceDictionary = resource;
            return true;
        }

        resourceDictionary = _defaultResource;
        return false;
    }

    public static void OverrideLocaleResources(Application application, CultureInfo? culture)
    {
        if (culture is null) return;
        if (!_localeToResource.TryGetValue(culture, out var resources)) return;
        foreach (var kv in resources)
        {
            application.Resources[kv.Key] = kv.Value;
        }
    }
    
    public static void OverrideLocaleResources(StyledElement element, CultureInfo? culture)
    {
        if (culture is null) return;
        if (!_localeToResource.TryGetValue(culture, out var resources)) return;
        foreach (var kv in resources)
        {
            element.Resources[kv.Key] = kv.Value;
        }
    }
}