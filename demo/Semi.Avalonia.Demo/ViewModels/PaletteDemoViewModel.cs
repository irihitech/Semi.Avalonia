using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

namespace Semi.Avalonia.Demo.ViewModels;

public class PaletteDemoViewModel : ObservableObject
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

    private ColorItemViewModel _selectedColor = null!;

    public ColorItemViewModel SelectedColor
    {
        get => _selectedColor;
        set => SetProperty(ref _selectedColor, value);
    }


    private ObservableCollection<ColorListViewModel>? _lightLists;

    public ObservableCollection<ColorListViewModel>? LightLists
    {
        get => _lightLists;
        set => SetProperty(ref _lightLists, value);
    }

    private ObservableCollection<ColorListViewModel>? _darkLists;

    public ObservableCollection<ColorListViewModel>? DarkLists
    {
        get => _darkLists;
        set => SetProperty(ref _darkLists, value);
    }

    public ObservableCollection<FunctionalColorGroupViewModel> FunctionalColors { get; set; } = [];
    public ObservableCollection<ShadowGroupViewModel> Shadows { get; set; } = [];

    public PaletteDemoViewModel()
    {
        _lightResourceDictionary = new Light.Palette();
        _darkResourceDictionary = new Dark.Palette();
        WeakReferenceMessenger.Default.Register<PaletteDemoViewModel, ColorItemViewModel>(this, OnClickColorItem);
    }

    public void InitializeResources()
    {
        InitializePalette();
        InitializeFunctionalColors();
        InitializeShadows();
    }

    private void InitializePalette()
    {
        LightLists = [];
        foreach (var color in _predefinedColorNames)
        {
            ColorListViewModel s = new ColorListViewModel();
            s.Initialize(_lightResourceDictionary, color, true);
            LightLists.Add(s);
        }

        DarkLists = [];
        foreach (var color in _predefinedColorNames)
        {
            ColorListViewModel s = new ColorListViewModel();
            s.Initialize(_darkResourceDictionary, color, false);
            DarkLists.Add(s);
        }
    }

    private void InitializeFunctionalColors()
    {
        FunctionalColors.Add(new FunctionalColorGroupViewModel("Primary", _lightResourceDictionary, _darkResourceDictionary, ColorTokens.PrimaryTokens));
        FunctionalColors.Add(new FunctionalColorGroupViewModel("Secondary", _lightResourceDictionary, _darkResourceDictionary, ColorTokens.SecondaryTokens));
        FunctionalColors.Add(new FunctionalColorGroupViewModel("Tertiary", _lightResourceDictionary, _darkResourceDictionary, ColorTokens.TertiaryTokens));
        FunctionalColors.Add(new FunctionalColorGroupViewModel("Information", _lightResourceDictionary, _darkResourceDictionary, ColorTokens.InformationTokens));
        FunctionalColors.Add(new FunctionalColorGroupViewModel("Success", _lightResourceDictionary, _darkResourceDictionary, ColorTokens.SuccessTokens));
        FunctionalColors.Add(new FunctionalColorGroupViewModel("Warning", _lightResourceDictionary, _darkResourceDictionary, ColorTokens.WarningTokens));
        FunctionalColors.Add(new FunctionalColorGroupViewModel("Danger", _lightResourceDictionary, _darkResourceDictionary, ColorTokens.DangerTokens));
        FunctionalColors.Add(new FunctionalColorGroupViewModel("Text", _lightResourceDictionary, _darkResourceDictionary, ColorTokens.TextTokens));
        FunctionalColors.Add(new FunctionalColorGroupViewModel("Link", _lightResourceDictionary, _darkResourceDictionary, ColorTokens.LinkTokens));
        FunctionalColors.Add(new FunctionalColorGroupViewModel("Background", _lightResourceDictionary, _darkResourceDictionary, ColorTokens.BackgroundTokens));
        FunctionalColors.Add(new FunctionalColorGroupViewModel("Fill", _lightResourceDictionary, _darkResourceDictionary, ColorTokens.FillTokens));
        FunctionalColors.Add(new FunctionalColorGroupViewModel("Border", _lightResourceDictionary, _darkResourceDictionary, ColorTokens.BorderTokens));
        FunctionalColors.Add(new FunctionalColorGroupViewModel("Disabled", _lightResourceDictionary, _darkResourceDictionary, ColorTokens.DisabledTokens));
    }

    private void InitializeShadows()
    {
        Shadows.Add(new ShadowGroupViewModel("Shadow", _lightResourceDictionary, _darkResourceDictionary, ColorTokens.ShadowTokens));
    }

    private void OnClickColorItem(PaletteDemoViewModel vm, ColorItemViewModel item)
    {
        SelectedColor = item;
    }
}

public class ColorListViewModel : ObservableObject
{
    private ObservableCollection<ColorItemViewModel>? _colors;

    public ObservableCollection<ColorItemViewModel>? Color
    {
        get => _colors;
        set => SetProperty(ref _colors, value);
    }

    private string? _seriesName;

    public string? SeriesName
    {
        get => _seriesName;
        set => SetProperty(ref _seriesName, value);
    }

    internal void Initialize(IResourceDictionary? resourceDictionary, string color, bool light)
    {
        if (resourceDictionary is null)
        {
            return;
        }

        SeriesName = color;
        Color = [];

        for (var i = 0; i < 10; i++)
        {
            var key = "Semi" + color + i;
            if (resourceDictionary.TryGetValue(key, out var value))
            {
                if (value is ISolidColorBrush brush)
                {
                    string name = color + " " + i;
                    var item = new ColorItemViewModel(name, brush, key, light, i);
                    item.ColorResourceKey = item.ResourceKey + "Color";
                    Color.Add(item);
                }
            }
        }
    }
}

public class ColorItemViewModel : ObservableObject
{
    private IBrush _brush = null!;

    public IBrush Brush
    {
        get => _brush;
        set => SetProperty(ref _brush, value);
    }

    private IBrush _textBrush = null!;

    public IBrush TextBrush
    {
        get => _textBrush;
        set => SetProperty(ref _textBrush, value);
    }

    private string _colorDisplayName = null!;

    public string ColorDisplayName
    {
        get => _colorDisplayName;
        set => SetProperty(ref _colorDisplayName, value);
    }

    private string _resourceKey = null!;

    public string ResourceKey
    {
        get => _resourceKey;
        set => SetProperty(ref _resourceKey, value);
    }

    private string _colorResourceKey = null!;

    public string ColorResourceKey
    {
        get => _colorResourceKey;
        set => SetProperty(ref _colorResourceKey, value);
    }

    private string _hex = null!;

    public string Hex
    {
        get => _hex;
        set => SetProperty(ref _hex, value);
    }

    public ColorItemViewModel(string colorDisplayName, ISolidColorBrush brush, string resourceKey, bool light,
        int index)
    {
        ColorDisplayName = colorDisplayName;
        Brush = brush;
        ResourceKey = resourceKey;
        Hex = brush.ToString().ToUpperInvariant();
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

public class FunctionalColorGroupViewModel : ObservableObject
{
    private string _title = null!;

    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }

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

public class ShadowItemViewModel : ObservableObject
{
    private string _shadowDisplayName = null!;

    public string ShadowDisplayName
    {
        get => _shadowDisplayName;
        set => SetProperty(ref _shadowDisplayName, value);
    }

    private string _resourceKey = null!;

    public string ResourceKey
    {
        get => _resourceKey;
        set => SetProperty(ref _resourceKey, value);
    }

    private string _boxShadowValue = null!;

    public string BoxShadowValue
    {
        get => _boxShadowValue;
        set => SetProperty(ref _boxShadowValue, value);
    }

    public ShadowItemViewModel(string shadowDisplayName, BoxShadows boxShadows, string resourceKey)
    {
        ShadowDisplayName = shadowDisplayName;
        ResourceKey = resourceKey;
        BoxShadowValue = boxShadows.ToString();
    }
}

public class ShadowGroupViewModel : ObservableObject
{
    private string _title = null!;

    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }

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