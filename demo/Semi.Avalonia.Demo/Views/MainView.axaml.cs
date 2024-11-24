using System;
using System.Collections.Generic;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Styling;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

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

public partial class MainViewModel : ObservableObject
{
    public IReadOnlyList<MenuItemViewModel> MenuItems { get; }

    public MainViewModel()
    {
        MenuItems =
        [
            new MenuItemViewModel
            {
                Header = "High Contrast Theme",
                Items =
                [
                    new MenuItemViewModel
                    {
                        Header = "Aquatic",
                        Command = SelectThemeCommand,
                        CommandParameter = SemiTheme.Aquatic
                    },
                    new MenuItemViewModel
                    {
                        Header = "Desert",
                        Command = SelectThemeCommand,
                        CommandParameter = SemiTheme.Desert
                    },
                    new MenuItemViewModel
                    {
                        Header = "Dust",
                        Command = SelectThemeCommand,
                        CommandParameter = SemiTheme.Dust
                    },
                    new MenuItemViewModel
                    {
                        Header = "NightSky",
                        Command = SelectThemeCommand,
                        CommandParameter = SemiTheme.NightSky
                    },
                ]
            }
        ];
    }

    [RelayCommand]
    public void SelectTheme(object? obj)
    {
        var app = Application.Current;
        if (app is not null)
        {
            app.RequestedThemeVariant = obj as ThemeVariant;
        }
    }
}

public class MenuItemViewModel
{
    public string? Header { get; set; }
    public ICommand? Command { get; set; }
    public object? CommandParameter { get; set; }
    public IList<MenuItemViewModel>? Items { get; set; }
}