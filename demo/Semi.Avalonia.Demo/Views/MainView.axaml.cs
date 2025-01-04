using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
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
}

public partial class MainViewModel : ObservableObject
{
    public string DocumentationUrl => "https://docs.irihi.tech/semi";
    public string RepoUrl => "https://github.com/irihitech/Semi.Avalonia";
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
                        Header = "Dusk",
                        Command = SelectThemeCommand,
                        CommandParameter = SemiTheme.Dusk
                    },
                    new MenuItemViewModel
                    {
                        Header = "NightSky",
                        Command = SelectThemeCommand,
                        CommandParameter = SemiTheme.NightSky
                    },
                ]
            },
            new MenuItemViewModel()
            {
                Header = "Locale",
                Items=
                [
                    new MenuItemViewModel
                    {
                        Header = "简体中文",
                        Command = SelectLocaleCommand,
                        CommandParameter = new System.Globalization.CultureInfo("zh-cn")
                    },
                    new MenuItemViewModel
                    {
                        Header = "English",
                        Command = SelectLocaleCommand,
                        CommandParameter = new System.Globalization.CultureInfo("en-us")
                    },
                    new MenuItemViewModel
                    {
                        Header = "日本語",
                        Command = SelectLocaleCommand,
                        CommandParameter = new System.Globalization.CultureInfo("ja-jp")
                    },
                    new MenuItemViewModel
                    {
                        Header = "Українська",
                        Command = SelectLocaleCommand,
                        CommandParameter = new System.Globalization.CultureInfo("uk-ua")
                    },
                    new MenuItemViewModel
                    {
                        Header = "Русский",
                        Command = SelectLocaleCommand,
                        CommandParameter = new System.Globalization.CultureInfo("ru-ru")
                    },
                    new MenuItemViewModel
                    {
                        Header = "繁體中文",
                        Command = SelectLocaleCommand,
                        CommandParameter = new System.Globalization.CultureInfo("zh-tw")
                    },
                    new MenuItemViewModel
                    {
                        Header = "Deutsch",
                        Command = SelectLocaleCommand,
                        CommandParameter = new System.Globalization.CultureInfo("de-de")
                    },
                ]
            }
        ];
    }

    [RelayCommand]
    private void ToggleTheme()
    {
        var app = Application.Current;
        if (app is null) return;
        var theme = app.ActualThemeVariant;
        app.RequestedThemeVariant = theme == ThemeVariant.Dark ? ThemeVariant.Light : ThemeVariant.Dark;
    }

    [RelayCommand]
    private void SelectTheme(object? obj)
    {
        var app = Application.Current;
        if (app is not null)
        {
            app.RequestedThemeVariant = obj as ThemeVariant;
        }
    }
    
    [RelayCommand]
    private void SelectLocale(object? obj)
    {
        var app = Application.Current;
        if (app is not null)
        {
            SemiTheme.OverrideLocaleResources(app, obj as System.Globalization.CultureInfo);
        }
    }

    [RelayCommand]
    private static async Task OpenUrl(string url)
    {
        var launcher = ResolveDefaultTopLevel()?.Launcher;
        if (launcher is not null)
        {
            await launcher.LaunchUriAsync(new Uri(url));
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

public class MenuItemViewModel
{
    public string? Header { get; set; }
    public ICommand? Command { get; set; }
    public object? CommandParameter { get; set; }
    public IList<MenuItemViewModel>? Items { get; set; }
}