using System.Collections.Generic;
using System.Globalization;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Styling;
using Semi.Avalonia.Locale;

namespace Semi.Avalonia;

public class SemiTheme : Styles
{
    public static ThemeVariant Aquatic => new(nameof(Aquatic), ThemeVariant.Dark);
    public static ThemeVariant Desert => new(nameof(Desert), ThemeVariant.Light);
    public static ThemeVariant Dusk => new(nameof(Dusk), ThemeVariant.Dark);
    public static ThemeVariant NightSky => new(nameof(NightSky), ThemeVariant.Dark);

    private static readonly Dictionary<CultureInfo, ResourceDictionary> LocaleToResource = new()
    {
        { new CultureInfo("zh-CN"), new zh_cn() },
        { new CultureInfo("en-US"), new en_us() },
        { new CultureInfo("en-GB"), new en_gb() },
        { new CultureInfo("it-IT"), new it_it() },
        { new CultureInfo("it-CH"), new it_ch() },
        { new CultureInfo("nl-BE"), new nl_be() },
        { new CultureInfo("nl-NL"), new nl_nl() },
        { new CultureInfo("ja-JP"), new ja_jp() },
        { new CultureInfo("ko-KR"), new ko_kr() },
        { new CultureInfo("uk-UA"), new uk_ua() },
        { new CultureInfo("ru-RU"), new ru_ru() },
        { new CultureInfo("zh-TW"), new zh_tw() },
        { new CultureInfo("de-DE"), new de_de() },
        { new CultureInfo("es-ES"), new es_es() },
        { new CultureInfo("pl-PL"), new pl_pl() },
        { new CultureInfo("fr-FR"), new fr_fr() },
    };

    private static readonly ResourceDictionary DefaultResource = new zh_cn();

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
                    (Resources as ResourceDictionary)?.SetItems(resource);
                }
                else
                {
                    _locale = new CultureInfo("zh-CN");
                    (Resources as ResourceDictionary)?.SetItems(DefaultResource);
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
            resourceDictionary = DefaultResource;
            return true;
        }

        if (locale is null)
        {
            resourceDictionary = DefaultResource;
            return false;
        }

        if (LocaleToResource.TryGetValue(locale, out var resource))
        {
            resourceDictionary = resource;
            return true;
        }

        resourceDictionary = DefaultResource;
        return false;
    }

    public static void OverrideLocaleResources(Application application, CultureInfo? culture)
    {
        if (culture is null) return;
        if (!LocaleToResource.TryGetValue(culture, out var resources)) return;
        (application.Resources as ResourceDictionary)?.SetItems(resources);
    }

    public static void OverrideLocaleResources(StyledElement element, CultureInfo? culture)
    {
        if (culture is null) return;
        if (!LocaleToResource.TryGetValue(culture, out var resources)) return;
        (element.Resources as ResourceDictionary)?.SetItems(resources);
    }
}