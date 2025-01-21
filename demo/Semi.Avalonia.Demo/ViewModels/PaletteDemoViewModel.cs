using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using Avalonia.Controls;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Semi.Avalonia.Demo.Constant;
using Semi.Avalonia.Demo.Converters;
using Semi.Avalonia.Tokens.Palette;

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

    public string CopyText =>
        $"""
         <StaticResource x:Key="" ResourceKey="{ResourceKey}" />
         """;

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

    public string CopyText =>
        $"""
         <StaticResource x:Key="" ResourceKey="{ResourceKey}" />
         """;

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