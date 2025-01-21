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
                ResourceKey = "SemiColorWindow",
                Brush = new SolidColorBrush(Color.Parse("#202020")),
                Description = "Background of pages, panes, popups, and windows.",
                PairWith = "WindowTextColor"
            },
            new ColorResource
            {
                ResourceKey = "SemiColorWindowText",
                Brush = new SolidColorBrush(Color.Parse("#FFFFFF")),
                Description = "Headings, body copy, lists, placeholder text, app and window borders.",
                PairWith = "WindowColor"
            },
            new ColorResource
            {
                ResourceKey = "SemiColorHotlight",
                Brush = new SolidColorBrush(Color.Parse("#75E9FC")),
                Description = "Hyperlinks.",
                PairWith = "WindowColor"
            },
            new ColorResource
            {
                ResourceKey = "SemiColorGrayText",
                Brush = new SolidColorBrush(Color.Parse("#A6A6A6")),
                Description = "Inactive (disabled) UI.",
                PairWith = "WindowColor"
            },
            new ColorResource
            {
                ResourceKey = "SemiColorHighlightText",
                Brush = new SolidColorBrush(Color.Parse("#263B50")),
                Description =
                    "Foreground color for text or UI that is in selected, interacted with (hover, pressed), or in progress.",
                PairWith = "HighlightColor"
            },
            new ColorResource
            {
                ResourceKey = "SemiColorHighlight",
                Brush = new SolidColorBrush(Color.Parse("#8EE3F0")),
                Description =
                    "Background or accent color for UI that is in selected, interacted with (hover, pressed), or in progress.",
                PairWith = "HighlightTextColor"
            },
            new ColorResource
            {
                ResourceKey = "SemiColorButtonText",
                Brush = new SolidColorBrush(Color.Parse("#FFFFFF")),
                Description = "Foreground color for buttons and any UI that can be interacted with.",
                PairWith = "ButtonFaceColor"
            },
            new ColorResource
            {
                ResourceKey = "SemiColorButtonFace",
                Brush = new SolidColorBrush(Color.Parse("#202020")),
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
            if (topLevel?.TryFindResource(colorResource.ResourceKey, value, out var o) == true
                && o is ISolidColorBrush color)
            {
                colorResource.Brush = color;
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
    [ObservableProperty] private ISolidColorBrush? _brush;
    [ObservableProperty] private string? _description;
    [ObservableProperty] private string? _pairWith;

    public string CopyText =>
        $"""
         <StaticResource x:Key="" ResourceKey="{ResourceKey}" />
         """;
}