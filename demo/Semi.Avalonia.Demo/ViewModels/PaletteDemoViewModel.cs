using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using Avalonia.Controls;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Semi.Avalonia.Tokens.Palette;
using Semi.Avalonia.Demo.Converters;

namespace Semi.Avalonia.Demo.ViewModels;

public partial class PaletteDemoViewModel : ObservableObject
{
    private readonly string[] _predefinedColorNames =
    [
        "Red", "Pink", "Purple", "Violet", "Indigo",
        "Blue", "LightBlue", "Cyan", "Teal", "Green",
        "LightGreen", "Lime", "Yellow", "Amber", "Orange",
        "Grey"
    ];

    private readonly IResourceDictionary? _lightResourceDictionary;
    private readonly IResourceDictionary? _darkResourceDictionary;

    [ObservableProperty] private ColorItemViewModel? _selectedColor;

    public ObservableCollection<ColorListViewModel> LightLists { get; set; } = [];
    public ObservableCollection<ColorListViewModel> DarkLists { get; set; } = [];
    public ObservableCollection<FunctionalColorGroupViewModel> FunctionalColors { get; set; } = [];
    public ObservableCollection<ShadowGroupViewModel> Shadows { get; set; } = [];

    public PaletteDemoViewModel()
    {
        _lightResourceDictionary = new Light();
        _darkResourceDictionary = new Dark();
        WeakReferenceMessenger.Default.Register<ColorItemViewModel>(this, (_, item) => SelectedColor = item);
    }

    public void InitializeResources()
    {
        InitializePalette();
        InitializeFunctionalColors();
        InitializeShadows();
    }

    private void InitializePalette()
    {
        foreach (var color in _predefinedColorNames)
        {
            ColorListViewModel s = new ColorListViewModel();
            s.Initialize(_lightResourceDictionary, color, true);
            LightLists.Add(s);
        }

        foreach (var color in _predefinedColorNames)
        {
            ColorListViewModel s = new ColorListViewModel();
            s.Initialize(_darkResourceDictionary, color, false);
            DarkLists.Add(s);
        }
    }

    private void InitializeFunctionalColors()
    {
        FunctionalColors.Add(new FunctionalColorGroupViewModel(
            "Primary", _lightResourceDictionary, _darkResourceDictionary, ColorTokens.PrimaryTokens));
        FunctionalColors.Add(new FunctionalColorGroupViewModel(
            "Secondary", _lightResourceDictionary, _darkResourceDictionary, ColorTokens.SecondaryTokens));
        FunctionalColors.Add(new FunctionalColorGroupViewModel(
            "Tertiary", _lightResourceDictionary, _darkResourceDictionary, ColorTokens.TertiaryTokens));
        FunctionalColors.Add(new FunctionalColorGroupViewModel(
            "Information", _lightResourceDictionary, _darkResourceDictionary, ColorTokens.InformationTokens));
        FunctionalColors.Add(new FunctionalColorGroupViewModel(
            "Success", _lightResourceDictionary, _darkResourceDictionary, ColorTokens.SuccessTokens));
        FunctionalColors.Add(new FunctionalColorGroupViewModel(
            "Warning", _lightResourceDictionary, _darkResourceDictionary, ColorTokens.WarningTokens));
        FunctionalColors.Add(new FunctionalColorGroupViewModel(
            "Danger", _lightResourceDictionary, _darkResourceDictionary, ColorTokens.DangerTokens));
        FunctionalColors.Add(new FunctionalColorGroupViewModel(
            "Text", _lightResourceDictionary, _darkResourceDictionary, ColorTokens.TextTokens));
        FunctionalColors.Add(new FunctionalColorGroupViewModel(
            "Link", _lightResourceDictionary, _darkResourceDictionary, ColorTokens.LinkTokens));
        FunctionalColors.Add(new FunctionalColorGroupViewModel(
            "Background", _lightResourceDictionary, _darkResourceDictionary, ColorTokens.BackgroundTokens));
        FunctionalColors.Add(new FunctionalColorGroupViewModel(
            "Fill", _lightResourceDictionary, _darkResourceDictionary, ColorTokens.FillTokens));
        FunctionalColors.Add(new FunctionalColorGroupViewModel(
            "Border", _lightResourceDictionary, _darkResourceDictionary, ColorTokens.BorderTokens));
        FunctionalColors.Add(new FunctionalColorGroupViewModel(
            "Disabled", _lightResourceDictionary, _darkResourceDictionary, ColorTokens.DisabledTokens));
    }

    private void InitializeShadows()
    {
        Shadows.Add(new ShadowGroupViewModel(
            "Shadow", _lightResourceDictionary, _darkResourceDictionary, ColorTokens.ShadowTokens));
    }
}

public partial class ColorListViewModel : ObservableObject
{
    public ObservableCollection<ColorItemViewModel> Color { get; set; } = [];

    [ObservableProperty] private string? _seriesName;

    internal void Initialize(IResourceDictionary? resourceDictionary, string color, bool light)
    {
        if (resourceDictionary is null) return;

        SeriesName = color;

        for (var i = 0; i < 10; i++)
        {
            var key = $"Semi{color}{i}";
            if (resourceDictionary.TryGetValue(key, out var value) && value is ISolidColorBrush brush)
            {
                var name = $"{color} {i}";
                var item = new ColorItemViewModel(name, brush, key, light, i);
                item.ColorResourceKey = $"{item.ResourceKey}Color";
                Color.Add(item);
            }
        }
    }
}

public partial class ColorItemViewModel : ObservableObject
{
    [ObservableProperty] private IBrush? _brush;
    [ObservableProperty] private IBrush? _textBrush;
    [ObservableProperty] private string? _colorDisplayName;
    [ObservableProperty] private string? _resourceKey;
    [ObservableProperty] private string? _colorResourceKey;
    [ObservableProperty] private string? _hex;

    public ColorItemViewModel(string colorDisplayName, ISolidColorBrush brush, string resourceKey, bool light,
        int index)
    {
        ColorDisplayName = colorDisplayName;
        Brush = brush;
        ResourceKey = resourceKey;
        var hex = ColorConverter.ToHex.Convert(brush.Color, typeof(string), false, CultureInfo.InvariantCulture);
        Hex = hex as string ?? string.Empty;
        if ((light && index < 5) || (!light && index >= 5))
        {
            TextBrush = Brushes.Black;
        }
        else
        {
            TextBrush = Brushes.White;
        }
    }
}

public partial class FunctionalColorGroupViewModel : ObservableObject
{
    [ObservableProperty] private string? _title;
    public ObservableCollection<ColorItemViewModel> LightColors { get; set; } = [];
    public ObservableCollection<ColorItemViewModel> DarkColors { get; set; } = [];

    public FunctionalColorGroupViewModel(string title, IResourceDictionary? lightDictionary,
        IResourceDictionary? darkDictionary, IReadOnlyList<Tuple<string, string>> tokens)
    {
        Title = title;
        foreach (var (key, name) in tokens)
        {
            if (lightDictionary?.TryGetValue(key, out var lightValue) ?? false)
            {
                if (lightValue is ISolidColorBrush lightBrush)
                {
                    LightColors.Add(new ColorItemViewModel(name, lightBrush, key, true, 0));
                }
            }

            if (darkDictionary?.TryGetValue(key, out var darkValue) ?? false)
            {
                if (darkValue is ISolidColorBrush darkBrush)
                {
                    DarkColors.Add(new ColorItemViewModel(name, darkBrush, key, true, 0));
                }
            }
        }
    }
}

public partial class ShadowItemViewModel : ObservableObject
{
    [ObservableProperty] private string? _shadowDisplayName;
    [ObservableProperty] private string? _resourceKey;
    [ObservableProperty] private string? _boxShadowValue;

    public ShadowItemViewModel(string shadowDisplayName, BoxShadows boxShadows, string resourceKey)
    {
        ShadowDisplayName = shadowDisplayName;
        ResourceKey = resourceKey;
        BoxShadowValue = boxShadows.ToString();
    }
}

public partial class ShadowGroupViewModel : ObservableObject
{
    [ObservableProperty] private string? _title;
    public ObservableCollection<ShadowItemViewModel> LightShadows { get; set; } = [];
    public ObservableCollection<ShadowItemViewModel> DarkShadows { get; set; } = [];


    public ShadowGroupViewModel(string title, IResourceDictionary? lightDictionary,
        IResourceDictionary? darkDictionary, IReadOnlyList<Tuple<string, string>> tokens)
    {
        Title = title;
        foreach (var (key, name) in tokens)
        {
            if (lightDictionary?.TryGetValue(key, out var lightValue) ?? false)
            {
                if (lightValue is BoxShadows lightShadow)
                {
                    LightShadows.Add(new ShadowItemViewModel(name, lightShadow, key));
                }
            }

            if (darkDictionary?.TryGetValue(key, out var darkValue) ?? false)
            {
                if (darkValue is BoxShadows darkShadow)
                {
                    DarkShadows.Add(new ShadowItemViewModel(name, darkShadow, key));
                }
            }
        }
    }
}

public static class ColorTokens
{
    public static IReadOnlyList<Tuple<string, string>> PrimaryTokens { get; } = new List<Tuple<string, string>>
    {
        new("SemiColorPrimary", "Primary"),
        new("SemiColorPrimaryPointerover", "Primary Pointerover"),
        new("SemiColorPrimaryActive", "Primary Active"),
        new("SemiColorPrimaryDisabled", "Primary Disabled"),
        new("SemiColorPrimaryLight", "Primary Light"),
        new("SemiColorPrimaryLightPointerover", "Primary Light Pointerover"),
        new("SemiColorPrimaryLightActive", "Primary Light Active"),
    };

    public static IReadOnlyList<Tuple<string, string>> SecondaryTokens { get; } = new List<Tuple<string, string>>
    {
        new("SemiColorSecondary", "Secondary"),
        new("SemiColorSecondaryPointerover", "Secondary Pointerover"),
        new("SemiColorSecondaryActive", "Secondary Active"),
        new("SemiColorSecondaryDisabled", "Secondary Disabled"),
        new("SemiColorSecondaryLight", "Secondary Light"),
        new("SemiColorSecondaryLightPointerover", "Secondary Light Pointerover"),
        new("SemiColorSecondaryLightActive", "Secondary Light Active"),
    };

    public static IReadOnlyList<Tuple<string, string>> TertiaryTokens { get; } = new List<Tuple<string, string>>
    {
        new("SemiColorTertiary", "Tertiary"),
        new("SemiColorTertiaryPointerover", "Tertiary Pointerover"),
        new("SemiColorTertiaryActive", "Tertiary Active"),
        new("SemiColorTertiaryLight", "Tertiary Light"),
        new("SemiColorTertiaryLightPointerover", "Tertiary Light Pointerover"),
        new("SemiColorTertiaryLightActive", "Tertiary Light Active"),
    };

    public static IReadOnlyList<Tuple<string, string>> InformationTokens { get; } = new List<Tuple<string, string>>
    {
        new("SemiColorInformation", "Information"),
        new("SemiColorInformationPointerover", "Information Pointerover"),
        new("SemiColorInformationActive", "Information Active"),
        new("SemiColorInformationDisabled", "Information Disabled"),
        new("SemiColorInformationLight", "Information Light"),
        new("SemiColorInformationLightPointerover", "Information Light Pointerover"),
        new("SemiColorInformationLightActive", "Information Light Active"),
    };

    public static IReadOnlyList<Tuple<string, string>> SuccessTokens { get; } = new List<Tuple<string, string>>
    {
        new("SemiColorSuccess", "Success"),
        new("SemiColorSuccessPointerover", "Success Pointerover"),
        new("SemiColorSuccessActive", "Success Active"),
        new("SemiColorSuccessDisabled", "Success Disabled"),
        new("SemiColorSuccessLight", "Success Light"),
        new("SemiColorSuccessLightPointerover", "Success Light Pointerover"),
        new("SemiColorSuccessLightActive", "Success Light Active"),
    };

    public static IReadOnlyList<Tuple<string, string>> WarningTokens { get; } = new List<Tuple<string, string>>
    {
        new("SemiColorWarning", "Warning"),
        new("SemiColorWarningPointerover", "Warning Pointerover"),
        new("SemiColorWarningActive", "Warning Active"),
        new("SemiColorWarningLight", "Warning Light"),
        new("SemiColorWarningLightPointerover", "Warning Light Pointerover"),
        new("SemiColorWarningLightActive", "Warning Light Active"),
    };

    public static IReadOnlyList<Tuple<string, string>> DangerTokens { get; } = new List<Tuple<string, string>>
    {
        new("SemiColorDanger", "Danger"),
        new("SemiColorDangerPointerover", "Danger Pointerover"),
        new("SemiColorDangerActive", "Danger Active"),
        new("SemiColorDangerLight", "Danger Light"),
        new("SemiColorDangerLightPointerover", "Danger Light Pointerover"),
        new("SemiColorDangerLightActive", "Danger Light Active"),
    };

    public static IReadOnlyList<Tuple<string, string>> TextTokens { get; } = new List<Tuple<string, string>>
    {
        new("SemiColorText0", "Text 0"),
        new("SemiColorText1", "Text 1"),
        new("SemiColorText2", "Text 2"),
        new("SemiColorText3", "Text 3"),
    };

    public static IReadOnlyList<Tuple<string, string>> LinkTokens { get; } = new List<Tuple<string, string>>
    {
        new("SemiColorLink", "Link"),
        new("SemiColorLinkPointerover", "Link Pointerover"),
        new("SemiColorLinkActive", "Link Active"),
        new("SemiColorLinkVisited", "Link Visited"),
    };

    public static IReadOnlyList<Tuple<string, string>> BackgroundTokens { get; } = new List<Tuple<string, string>>
    {
        new("SemiColorBackground0", "Background 0"),
        new("SemiColorBackground1", "Background 1"),
        new("SemiColorBackground2", "Background 2"),
        new("SemiColorBackground3", "Background 3"),
        new("SemiColorBackground4", "Background 4"),
    };

    public static IReadOnlyList<Tuple<string, string>> FillTokens { get; } = new List<Tuple<string, string>>
    {
        new("SemiColorFill0", "Fill 0"),
        new("SemiColorFill1", "Fill 1"),
        new("SemiColorFill2", "Fill 2"),
    };

    public static IReadOnlyList<Tuple<string, string>> BorderTokens { get; } = new List<Tuple<string, string>>
    {
        new("SemiColorBorder", "Border"),
    };

    public static IReadOnlyList<Tuple<string, string>> DisabledTokens { get; } = new List<Tuple<string, string>>
    {
        new("SemiColorDisabledText", "Disabled Text"),
        new("SemiColorDisabledBorder", "Disabled Border"),
        new("SemiColorDisabledBackground", "Disabled Background"),
        new("SemiColorDisabledFill", "Disabled Fill"),
    };

    public static IReadOnlyList<Tuple<string, string>> ShadowTokens { get; } = new List<Tuple<string, string>>
    {
        new("SemiColorShadow", "Shadow"),
        new("SemiShadowElevated", "Shadow Elevated"),
    };
}