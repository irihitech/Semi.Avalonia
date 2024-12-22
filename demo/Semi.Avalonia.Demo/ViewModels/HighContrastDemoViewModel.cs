using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Media;
using Avalonia.Styling;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Semi.Avalonia.Demo.ViewModels;

public partial class HighContrastDemoViewModel : ObservableObject
{
    [ObservableProperty] private ThemeVariant? _selectedThemeVariant;
    public IEnumerable<ThemeVariant> ThemeVariants { get; }
    public ObservableCollection<ColorResource> ColorResources { get; set; }

    public HighContrastDemoViewModel()
    {
        ThemeVariants =
        [
            SemiTheme.Aquatic,
            SemiTheme.Desert,
            SemiTheme.Dust,
            SemiTheme.NightSky,
        ];
        ColorResources =
        [
            new ColorResource
            {
                ResourceKey = "WindowColor",
                Brush = new SolidColorBrush(Color.Parse("#202020")),
                Description = "Background of pages, panes, popups, and windows.",
                PairWith = "WindowTextColor"
            },
            new ColorResource
            {
                ResourceKey = "WindowTextColor",
                Brush = new SolidColorBrush(Color.Parse("#FFFFFF")),
                Description = "Headings, body copy, lists, placeholder text, app and window borders.",
                PairWith = "WindowColor"
            },
            new ColorResource
            {
                ResourceKey = "HotlightColor",
                Brush = new SolidColorBrush(Color.Parse("#75E9FC")),
                Description = "Hyperlinks.",
                PairWith = "WindowColor"
            },
            new ColorResource
            {
                ResourceKey = "GrayTextColor",
                Brush = new SolidColorBrush(Color.Parse("#A6A6A6")),
                Description = "Inactive (disabled) UI.",
                PairWith = "WindowColor"
            },
            new ColorResource
            {
                ResourceKey = "HighlightTextColor",
                Brush = new SolidColorBrush(Color.Parse("#263B50")),
                Description =
                    "Foreground color for text or UI that is in selected, interacted with (hover, pressed), or in progress.",
                PairWith = "HighlightColor"
            },
            new ColorResource
            {
                ResourceKey = "HighlightColor",
                Brush = new SolidColorBrush(Color.Parse("#8EE3F0")),
                Description =
                    "Background or accent color for UI that is in selected, interacted with (hover, pressed), or in progress.",
                PairWith = "HighlightTextColor"
            },
            new ColorResource
            {
                ResourceKey = "ButtonTextColor",
                Brush = new SolidColorBrush(Color.Parse("#FFFFFF")),
                Description = "Foreground color for buttons and any UI that can be interacted with.",
                PairWith = "ButtonFaceColor"
            },
            new ColorResource
            {
                ResourceKey = "ButtonFaceColor",
                Brush = new SolidColorBrush(Color.Parse("#202020")),
                Description = "Background color for buttons and any UI that can be interacted with.",
                PairWith = "ButtonTextColor"
            },
        ];
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
    [ObservableProperty] private string? _description;
    [ObservableProperty] private string? _pairWith;
}