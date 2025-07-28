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
    private static readonly Dictionary<CultureInfo, ResourceDictionary> _localeToResource = new()
    {
        { new CultureInfo("zh-cn"), new zh_cn() },
        { new CultureInfo("en-us"), new en_us() },
        { new CultureInfo("ja-jp"), new ja_jp() },
        { new CultureInfo("uk-ua"), new uk_ua() },
        { new CultureInfo("ru-ru"), new ru_ru() },
        { new CultureInfo("zh-tw"), new zh_tw() },
        { new CultureInfo("de-de"), new de_de() },
        { new CultureInfo("es-es"), new es_es() },
        { new CultureInfo("pl-pl"), new pl_pl() },
        { new CultureInfo("fr-fr"), new fr_fr() },
    };

    private static readonly ResourceDictionary _defaultResource = new zh_cn();

    private CultureInfo? _locale;

    public SemiTheme(IServiceProvider? provider = null)
    {
        AvaloniaXamlLoader.Load(provider, this);
    }

    public static ThemeVariant Aquatic => new(nameof(Aquatic), ThemeVariant.Dark);
    public static ThemeVariant Desert => new(nameof(Desert), ThemeVariant.Light);
    public static ThemeVariant Dusk => new(nameof(Dusk), ThemeVariant.Dark);
    public static ThemeVariant NightSky => new(nameof(NightSky), ThemeVariant.Dark);

    public CultureInfo? Locale
    {
        get => _locale;
        set
        {
            try
            {
                if (TryGetLocaleResource(value, false, out var resource) && resource is not null)
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
        return TryGetLocaleResource(locale, false, out resourceDictionary);
    }

    private static bool TryGetLocaleResource(CultureInfo? locale, bool enableParentCultureFallback, out ResourceDictionary? resourceDictionary)
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

        // Try exact match first
        if (_localeToResource.TryGetValue(locale, out var resource))
        {
            resourceDictionary = resource;
            return true;
        }

        // If enabled, try to find a culture that has this locale as parent or that shares the same parent
        if (enableParentCultureFallback)
        {
            // Look for any supported culture that has this locale as its parent
            foreach (var supportedCulture in _localeToResource.Keys)
            {
                if (Equals(supportedCulture.Parent, locale))
                {
                    resourceDictionary = _localeToResource[supportedCulture];
                    return true;
                }
            }
            
            // If this locale has a parent (and it's not invariant), try to find 
            // a supported culture that shares the same parent
            var targetParent = locale.Parent;
            if (!Equals(targetParent, CultureInfo.InvariantCulture))
            {
                foreach (var supportedCulture in _localeToResource.Keys)
                {
                    if (Equals(supportedCulture.Parent, targetParent))
                    {
                        resourceDictionary = _localeToResource[supportedCulture];
                        return true;
                    }
                }
            }
        }

        resourceDictionary = _defaultResource;
        return false;
    }

    public static void OverrideLocaleResources(Application application, CultureInfo? culture)
    {
        OverrideLocaleResources(application, culture, false);
    }

    public static void OverrideLocaleResources(Application application, CultureInfo? culture, bool enableParentCultureFallback)
    {
        if (culture is null) return;
        if (!TryGetLocaleResource(culture, enableParentCultureFallback, out var resources)) return;
        if (resources is null) return;
        foreach (var kv in resources)
        {
            application.Resources[kv.Key] = kv.Value;
        }
    }

    public static void OverrideLocaleResources(StyledElement element, CultureInfo? culture)
    {
        OverrideLocaleResources(element, culture, false);
    }

    public static void OverrideLocaleResources(StyledElement element, CultureInfo? culture, bool enableParentCultureFallback)
    {
        if (culture is null) return;
        if (!TryGetLocaleResource(culture, enableParentCultureFallback, out var resources)) return;
        if (resources is null) return;
        foreach (var kv in resources)
        {
            element.Resources[kv.Key] = kv.Value;
        }
    }
}
