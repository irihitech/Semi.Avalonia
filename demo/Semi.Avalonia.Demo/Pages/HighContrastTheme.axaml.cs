using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Styling;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Semi.Avalonia.Demo.Pages;

public partial class HighContrastTheme : UserControl
{
    public HighContrastTheme()
    {
        InitializeComponent();
        this.DataContext = new HighContrastThemeViewModel();
    }
}

public partial class HighContrastThemeViewModel : ObservableObject
{
    [ObservableProperty] private ThemeVariant? _selectedThemeVariant = SemiTheme.Aquatic;

    public IEnumerable<ThemeVariant> ThemeVariants =>
    [
        SemiTheme.Aquatic,
        SemiTheme.Desert,
        SemiTheme.Dust,
        SemiTheme.NightSky,
    ];
}