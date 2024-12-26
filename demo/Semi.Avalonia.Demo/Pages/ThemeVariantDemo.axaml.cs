using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Styling;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Semi.Avalonia.Demo.Pages;

public partial class ThemeVariantDemo : UserControl
{
    public ThemeVariantDemo()
    {
        InitializeComponent();
        this.DataContext = new ThemeVariantDemoViewModel();
    }
}

public partial class ThemeVariantDemoViewModel : ObservableObject
{
    [ObservableProperty] private ThemeVariant? _selectedThemeVariant;

    public IEnumerable<ThemeVariant> ThemeVariants =>
    [
        ThemeVariant.Default,
        ThemeVariant.Light,
        ThemeVariant.Dark,
        SemiTheme.Aquatic,
        SemiTheme.Desert,
        SemiTheme.Dusk,
        SemiTheme.NightSky,
    ];
}