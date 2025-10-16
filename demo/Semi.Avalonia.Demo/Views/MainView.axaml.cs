using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Styling;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace Semi.Avalonia.Demo.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        this.DataContext = new MainViewModel();
        WeakReferenceMessenger.Default.Register<string, string>(this, "JumpTo", MessageHandler);
    }

    private void MessageHandler(object _, string message)
    {
        foreach (var item in tab.ItemsView)
        {
            if (item is TabItem tabItem && tabItem.Header is not null && tabItem.Header.Equals(message))
            {
                tab.SelectedItem = tabItem;
                break;
            }
        }
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
                Header = "Theme",
                Items =
                [
                    new MenuItemViewModel
                    {
                        Header = "Auto",
                        Command = FollowSystemThemeCommand
                    },
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
            new MenuItemViewModel
            {
                Header = "Locale",
                Items =
                [
                    new MenuItemViewModel
                    {
                        Header = "简体中文",
                        Command = SelectLocaleCommand,
                        CommandParameter = new CultureInfo("zh-CN")
                    },
                    new MenuItemViewModel
                    {
                        Header = "English",
                        Command = SelectLocaleCommand,
                        CommandParameter = new CultureInfo("en-US")
                    },
                    new MenuItemViewModel
                    {
                        Header = "日本語",
                        Command = SelectLocaleCommand,
                        CommandParameter = new CultureInfo("ja-JP")
                    },
                    new MenuItemViewModel
                    {
                        Header = "한국어",
                        Command = SelectLocaleCommand,
                        CommandParameter = new CultureInfo("ko-KR")
                    },
                    new MenuItemViewModel
                    {
                        Header = "English (UK)",
                        Command = SelectLocaleCommand,
                        CommandParameter = new CultureInfo("en-GB")
                    },
                    new MenuItemViewModel
                    {
                        Header = "Italiano",
                        Command = SelectLocaleCommand,
                        CommandParameter = new CultureInfo("it-IT")
                    },
                    new MenuItemViewModel
                    {
                        Header = "Italiano (Switzerland)",
                        Command = SelectLocaleCommand,
                        CommandParameter = new CultureInfo("it-CH")
                    },
                    new MenuItemViewModel
                    {
                        Header = "Nederlands",
                        Command = SelectLocaleCommand,
                        CommandParameter = new CultureInfo("nl-NL")
                    },
                    new MenuItemViewModel
                    {
                        Header = "Nederlands (Belgium)",
                        Command = SelectLocaleCommand,
                        CommandParameter = new CultureInfo("nl-BE")
                    },
                    new MenuItemViewModel
                    {
                        Header = "Українська",
                        Command = SelectLocaleCommand,
                        CommandParameter = new CultureInfo("uk-UA")
                    },
                    new MenuItemViewModel
                    {
                        Header = "Русский",
                        Command = SelectLocaleCommand,
                        CommandParameter = new CultureInfo("ru-RU")
                    },
                    new MenuItemViewModel
                    {
                        Header = "繁體中文",
                        Command = SelectLocaleCommand,
                        CommandParameter = new CultureInfo("zh-TW")
                    },
                    new MenuItemViewModel
                    {
                        Header = "Deutsch",
                        Command = SelectLocaleCommand,
                        CommandParameter = new CultureInfo("de-DE")
                    },
                    new MenuItemViewModel
                    {
                        Header = "Español",
                        Command = SelectLocaleCommand,
                        CommandParameter = new CultureInfo("es-ES")
                    },
                    new MenuItemViewModel
                    {
                        Header = "Polski",
                        Command = SelectLocaleCommand,
                        CommandParameter = new CultureInfo("pl-PL")
                    },
                    new MenuItemViewModel
                    {
                        Header = "Français",
                        Command = SelectLocaleCommand,
                        CommandParameter = new CultureInfo("fr-FR")
                    },
                ]
            }
        ];
    }

    [RelayCommand]
    private void FollowSystemTheme()
    {
        Application.Current?.RegisterFollowSystemTheme();
    }

    [RelayCommand]
    private void ToggleTheme()
    {
        var app = Application.Current;
        if (app is null) return;
        var theme = app.ActualThemeVariant;
        app.RequestedThemeVariant = theme == ThemeVariant.Dark ? ThemeVariant.Light : ThemeVariant.Dark;
        app.UnregisterFollowSystemTheme();
    }

    [RelayCommand]
    private void SelectTheme(object? obj)
    {
        var app = Application.Current;
        if (app is null) return;
        app.RequestedThemeVariant = obj as ThemeVariant;
        app.UnregisterFollowSystemTheme();
    }

    [RelayCommand]
    private void SelectLocale(object? obj)
    {
        var app = Application.Current;
        if (app is null) return;
        SemiTheme.OverrideLocaleResources(app, obj as CultureInfo);
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