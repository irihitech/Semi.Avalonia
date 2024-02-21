using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;

namespace Semi.Avalonia;

public class SemiTheme: Styles
{
    private static readonly Dictionary<CultureInfo, string> _localeToResource = new()
    {
        { new CultureInfo("zh-CN"), "avares://Semi.Avalonia/Locale/zh-CN.axaml" },
        { new CultureInfo("en-US"), "avares://Semi.Avalonia/Locale/en-US.axaml" },
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
            var d = AvaloniaXamlLoader.Load(sp, new Uri(resource)) as ResourceDictionary;
            if (d is null) return;
            foreach (var kv in d)
            {
                this.Resources.Add(kv);
            }
        }
    }
    
    private static string TryGetLocaleResource(CultureInfo? locale)
    {
        if (locale is null)
        {
            return _localeToResource[new CultureInfo("zh-CN")];
        }

        if (_localeToResource.TryGetValue(locale, out var resource))
        {
            return resource;
        }
        return _localeToResource[new CultureInfo("zh-CN")];
    }
}