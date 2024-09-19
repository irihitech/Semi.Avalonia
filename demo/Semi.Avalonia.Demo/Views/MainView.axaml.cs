using System;
using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Styling;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Semi.Avalonia.Demo.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        this.DataContext = new MainViewModel();
    }

    private void ToggleButton_OnIsCheckedChanged(object sender, RoutedEventArgs e)
    {
        var app = Application.Current;
        if (app is not null)
        {
            var theme = app.ActualThemeVariant;
            app.RequestedThemeVariant = theme == ThemeVariant.Dark ? ThemeVariant.Light : ThemeVariant.Dark;
        }
    }

    private async void OpenRepository(object sender, RoutedEventArgs e)
    {
        var top = TopLevel.GetTopLevel(this);
        if (top is null) return;
        var launcher = top.Launcher;
        await launcher.LaunchUriAsync(new Uri("https://github.com/irihitech/Semi.Avalonia"));
    }

    private async void OpenDocumentation(object sender, RoutedEventArgs e)
    {
        var top = TopLevel.GetTopLevel(this);
        if (top is null) return;
        var launcher = top.Launcher;
        await launcher.LaunchUriAsync(new Uri("https://docs.irihi.tech/semi"));
    }
}

public partial class MainViewModel: ObservableObject
{
    public ObservableCollection<ThemeItem> Themes { get; } = new()
    {
        new ThemeItem("Light", ThemeVariant.Light),
        new ThemeItem("Dark", ThemeVariant.Dark),
        new ThemeItem("Aquatic", SemiTheme.Aquatic),
        new ThemeItem("Desert", SemiTheme.Desert),
        new ThemeItem("Dust", SemiTheme.Dust),
        new ThemeItem("NightSky", SemiTheme.NightSky),
    };
    
    [ObservableProperty] private ThemeItem? _selectedTheme;
    
    partial void OnSelectedThemeChanged(ThemeItem? oldValue, ThemeItem? newValue)
    {
        if (newValue is null) return;
        var app = Application.Current;
        if (app is not null)
        {
            app.RequestedThemeVariant = newValue.Theme;
        }
    }
    
}

public class ThemeItem(string name, ThemeVariant theme)
{
    public string Name { get; set; } = name;
    public ThemeVariant Theme { get; set; } = theme;
}