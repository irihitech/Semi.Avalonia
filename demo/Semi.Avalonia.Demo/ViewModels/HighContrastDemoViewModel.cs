using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Media;
using Avalonia.Styling;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

namespace Semi.Avalonia.Demo.ViewModels;

public partial class HighContrastDemoViewModel : ObservableObject
{
    [ObservableProperty] private ThemeVariant? _selectedThemeVariant;
    [ObservableProperty] private ColorResource _selectedColorResource = null!;

    public IEnumerable<ThemeVariant> ThemeVariants { get; }
    public ObservableCollection<ColorResource> ColorResources { get; set; }

    public HighContrastDemoViewModel()
    {
        ThemeVariants =
        [
            SemiTheme.Aquatic,
            SemiTheme.Desert,
            SemiTheme.Dusk,
            SemiTheme.NightSky,
        ];
        ColorResources =
        [
            new ColorResource
            {
                ResourceKey = "WindowColor",
                Brush = new SolidColorBrush(Color.Parse("#202020")),
                Hex = "#FF202020",
                Description = "Background of pages, panes, popups, and windows.",
                PairWith = "WindowTextColor"
            },
            new ColorResource
            {
                ResourceKey = "WindowTextColor",
                Brush = new SolidColorBrush(Color.Parse("#FFFFFF")),
                Hex = "WHITE",
                Description = "Headings, body copy, lists, placeholder text, app and window borders.",
                PairWith = "WindowColor"
            },
            new ColorResource
            {
                ResourceKey = "HotlightColor",
                Brush = new SolidColorBrush(Color.Parse("#75E9FC")),
                Hex = "#FF75E9FC",
                Description = "Hyperlinks.",
                PairWith = "WindowColor"
            },
            new ColorResource
            {
                ResourceKey = "GrayTextColor",
                Brush = new SolidColorBrush(Color.Parse("#A6A6A6")),
                Hex = "#FFA6A6A6",
                Description = "Inactive (disabled) UI.",
                PairWith = "WindowColor"
            },
            new ColorResource
            {
                ResourceKey = "HighlightTextColor",
                Brush = new SolidColorBrush(Color.Parse("#263B50")),
                Hex = "#FF263B50",
                Description =
                    "Foreground color for text or UI that is in selected, interacted with (hover, pressed), or in progress.",
                PairWith = "HighlightColor"
            },
            new ColorResource
            {
                ResourceKey = "HighlightColor",
                Brush = new SolidColorBrush(Color.Parse("#8EE3F0")),
                Hex = "#FF8EE3F0",
                Description =
                    "Background or accent color for UI that is in selected, interacted with (hover, pressed), or in progress.",
                PairWith = "HighlightTextColor"
            },
            new ColorResource
            {
                ResourceKey = "ButtonTextColor",
                Brush = new SolidColorBrush(Color.Parse("#FFFFFF")),
                Hex = "WHITE",
                Description = "Foreground color for buttons and any UI that can be interacted with.",
                PairWith = "ButtonFaceColor"
            },
            new ColorResource
            {
                ResourceKey = "ButtonFaceColor",
                Brush = new SolidColorBrush(Color.Parse("#202020")),
                Hex = "#FF202020",
                Description = "Background color for buttons and any UI that can be interacted with.",
                PairWith = "ButtonTextColor"
            },
        ];
        WeakReferenceMessenger.Default.Register<HighContrastDemoViewModel, ColorResource>
            (this, (_, item) => SelectedColorResource = item);
        SelectedThemeVariant = SemiTheme.Aquatic;
    }

    partial void OnSelectedThemeVariantChanged(ThemeVariant? value)
    {
        var topLevel = ResolveDefaultTopLevel();
        if (value is null) return;
        foreach (var colorResource in ColorResources)
        {
            if (colorResource.ResourceKey is null) continue;
            if (topLevel?.TryFindResource(colorResource.ResourceKey, value, out var o) == true && o is Color color)
            {
                colorResource.Brush = new SolidColorBrush(color);
                colorResource.Hex = color.ToString().ToUpperInvariant();
            }
        }
    }

    private static TopLevel? ResolveDefaultTopLevel()
    {
        return Application.Current?.ApplicationLifetime switch
        {
            IClassicDesktopStyleApplicationLifetime desktopLifetime => desktopLifetime.MainWindow,
            ISingleViewApplicationLifetime singleView => TopLevel.GetTopLevel(singleView.MainView),
            _ => null
        };
    }
}

public partial class ColorResource : ObservableObject
{
    [ObservableProperty] private string? _resourceKey;
    [ObservableProperty] private SolidColorBrush? _brush;
    [ObservableProperty] private string? _hex;
    [ObservableProperty] private string? _description;
    [ObservableProperty] private string? _pairWith;
}