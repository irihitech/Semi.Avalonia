using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Chrome;
using Avalonia.Styling;
using CommunityToolkit.Mvvm.ComponentModel;
using Irihi.Lingua;

namespace Semi.Avalonia.Demo.ViewModels;

public partial class SettingsPageViewModel : ObservableObject
{
    private Window? _window;
    private bool _initialized;
    private bool _syncingTitleBarDecorations;

    // The demo app registers follow-system on startup, before this page exists.
    private bool _followsSystemTheme = true;

    public IObservable<string?> GroupGeneral => LanguageManager.Instance.Settings_Group_General;
    public IObservable<string?> GroupWindow => LanguageManager.Instance.Settings_Group_Window;
    public IObservable<string?> GroupTitleBar => LanguageManager.Instance.Settings_Group_TitleBar;
    public IObservable<string?> ThemeHeader => LanguageManager.Instance.Menu_Theme;
    public IObservable<string?> LocaleHeader => LanguageManager.Instance.Menu_Locale;

    public IReadOnlyList<ThemeItem> Themes { get; } =
    [
        new(LanguageManager.Instance.Theme_Auto, ThemeVariant.Default),
        new(LinguaObservableString.FromLiteral("Light"), ThemeVariant.Light),
        new(LinguaObservableString.FromLiteral("Dark"), ThemeVariant.Dark),
        new(LanguageManager.Instance.Theme_Aquatic, SemiTheme.Aquatic),
        new(LanguageManager.Instance.Theme_Desert, SemiTheme.Desert),
        new(LanguageManager.Instance.Theme_Dusk, SemiTheme.Dusk),
        new(LanguageManager.Instance.Theme_NightSky, SemiTheme.NightSky),
    ];

    public IReadOnlyList<LocaleItem> Locales { get; } =
    [
        new("简体中文", new CultureInfo("zh-CN")),
        new("English", new CultureInfo("en-US")),
        new("日本語", new CultureInfo("ja-JP")),
        new("한국어", new CultureInfo("ko-KR")),
        new("English (UK)", new CultureInfo("en-GB")),
        new("Italiano", new CultureInfo("it-IT")),
        new("Italiano (Switzerland)", new CultureInfo("it-CH")),
        new("Nederlands", new CultureInfo("nl-NL")),
        new("Nederlands (Belgium)", new CultureInfo("nl-BE")),
        new("Українська", new CultureInfo("uk-UA")),
        new("Русский", new CultureInfo("ru-RU")),
        new("繁體中文", new CultureInfo("zh-TW")),
        new("Deutsch", new CultureInfo("de-DE")),
        new("Español", new CultureInfo("es-ES")),
        new("Polski", new CultureInfo("pl-PL")),
        new("Français", new CultureInfo("fr-FR")),
    ];

    [ObservableProperty] public partial ThemeItem? SelectedTheme { get; set; }

    [ObservableProperty] public partial LocaleItem? SelectedLocale { get; set; }

    [ObservableProperty] public partial bool IsTitleVisible { get; set; }

    [ObservableProperty] public partial bool IsMinimizeButtonVisible { get; set; }

    [ObservableProperty] public partial bool IsMaximizeButtonVisible { get; set; }

    [ObservableProperty] public partial bool IsCloseButtonVisible { get; set; }

    [ObservableProperty] public partial bool IsFullScreenButtonVisible { get; set; }

    public SettingsPageViewModel()
    {
        // Only reflect the running app here; applying anything is left to the user's selection.
        SelectedTheme = _followsSystemTheme
            ? Themes[0]
            : Themes.FirstOrDefault(item => item.Theme == Application.Current?.RequestedThemeVariant) ?? Themes[0];

        var currentCulture = CultureInfo.CurrentUICulture.Name;
        SelectedLocale = Locales.FirstOrDefault(item =>
            string.Equals(item.Culture.Name, currentCulture, StringComparison.OrdinalIgnoreCase));

        _initialized = true;
    }

    /// <summary>
    /// Follows the hosting window. The page instance outlives navigation, so the title bar
    /// switches are refreshed from the window whenever the page is attached again.
    /// </summary>
    public void Attach(Window? window)
    {
        _window = window;
        if (window is null)
        {
            return;
        }

        var decorations = WindowDrawnDecorations.GetTitleBarDecorations(window);
        _syncingTitleBarDecorations = true;
        try
        {
            IsTitleVisible = decorations.HasFlag(TitleBarDecorations.Title);
            IsMinimizeButtonVisible = decorations.HasFlag(TitleBarDecorations.MinimizeButton);
            IsMaximizeButtonVisible = decorations.HasFlag(TitleBarDecorations.MaximizeButton);
            IsCloseButtonVisible = decorations.HasFlag(TitleBarDecorations.CloseButton);
            IsFullScreenButtonVisible = decorations.HasFlag(TitleBarDecorations.FullScreenButton);
        }
        finally
        {
            _syncingTitleBarDecorations = false;
        }
    }

    partial void OnSelectedThemeChanged(ThemeItem? value)
    {
        if (!_initialized || value is null)
        {
            return;
        }

        var app = Application.Current;
        if (app is null)
        {
            return;
        }

        _followsSystemTheme = value.Theme == ThemeVariant.Default;
        app.RequestedThemeVariant = value.Theme;
        if (_followsSystemTheme)
        {
            app.RegisterFollowSystemTheme();
        }
        else
        {
            app.UnregisterFollowSystemTheme();
        }
    }

    partial void OnSelectedLocaleChanged(LocaleItem? value)
    {
        if (!_initialized || value is null)
        {
            return;
        }

        var app = Application.Current;
        if (app is not null)
        {
            SemiTheme.OverrideLocaleResources(app, value.Culture);
        }

        // culture mapping, example: zh-CN to zh-Hans
        LanguageManager.Instance.UpdateCulture(value.Culture);
    }

    // WindowDrawnDecorations.TitleBarDecorations is one flags value, so the five switches share it.
    partial void OnIsTitleVisibleChanged(bool value) => ApplyTitleBarDecorations();

    partial void OnIsMinimizeButtonVisibleChanged(bool value) => ApplyTitleBarDecorations();

    partial void OnIsMaximizeButtonVisibleChanged(bool value) => ApplyTitleBarDecorations();

    partial void OnIsCloseButtonVisibleChanged(bool value) => ApplyTitleBarDecorations();

    partial void OnIsFullScreenButtonVisibleChanged(bool value) => ApplyTitleBarDecorations();

    private void ApplyTitleBarDecorations()
    {
        if (!_initialized || _syncingTitleBarDecorations || _window is null)
        {
            return;
        }

        var decorations = TitleBarDecorations.None;
        if (IsTitleVisible)
        {
            decorations |= TitleBarDecorations.Title;
        }

        if (IsMinimizeButtonVisible)
        {
            decorations |= TitleBarDecorations.MinimizeButton;
        }

        if (IsMaximizeButtonVisible)
        {
            decorations |= TitleBarDecorations.MaximizeButton;
        }

        if (IsCloseButtonVisible)
        {
            decorations |= TitleBarDecorations.CloseButton;
        }

        if (IsFullScreenButtonVisible)
        {
            decorations |= TitleBarDecorations.FullScreenButton;
        }

        WindowDrawnDecorations.SetTitleBarDecorations(_window, decorations);
    }
}

public record ThemeItem(IObservable<string?> Name, ThemeVariant Theme);

public record LocaleItem(string Name, CultureInfo Culture);
