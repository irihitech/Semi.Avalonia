using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Irihi.Lingua;
using Semi.Avalonia.Demo.Pages;

namespace Semi.Avalonia.Demo.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly Dictionary<string, NavigationItemViewModel> _itemsByKey = new(StringComparer.Ordinal);
    private readonly IReadOnlyList<NavigationSectionViewModel> _allSections;

    [ObservableProperty] public partial string? SearchText { get; set; }

    public string DocumentationUrl => "https://docs.irihi.tech/semi";
    public string RepoUrl => "https://github.com/irihitech/Semi.Avalonia";

    /// <summary>
    /// The version of the Semi.Avalonia assembly this demo runs against. The SDK appends
    /// the source revision after '+', which is not part of the published version.
    /// </summary>
    public string SemiVersion { get; } = "v" + typeof(SemiTheme).Assembly
        .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion.Split('+')[0];

    public IReadOnlyList<NavigationSectionViewModel> Sections { get; }

    // Lingua i18n observable properties
    public IObservable<string?> AppTitle => LanguageManager.Instance.App_Title;
    public IObservable<string?> SearchPlaceholder => LanguageManager.Instance.Search_Placeholder;
    public IObservable<string?> EmptySearchMessage => LanguageManager.Instance.Empty_Search_Message;
    public IObservable<string?> DocumentationTooltip => LanguageManager.Instance.Tooltip_Documentation;
    public IObservable<string?> RepositoryTooltip => LanguageManager.Instance.Tooltip_Repository;
    public bool ShowEmptySearchState => Sections.All(s => !s.IsVisible);

    /// <summary>
    /// The <see cref="NavigationPage"/> that hosts demo pages, injected by the view.
    /// </summary>
    public INavigation? Navigator { get; internal set; }

    public NavigationItemViewModel? SelectedItem
    {
        get;
        private set
        {
            if (ReferenceEquals(field, value))
            {
                return;
            }

            var previous = field;
            if (SetProperty(ref field, value))
            {
                previous?.IsSelected = false;
                value?.IsSelected = true;
            }
        }
    }

    /// <summary>
    /// The settings page, reached from the drawer footer instead of the navigation list.
    /// </summary>
    public NavigationItemViewModel SettingsItem
    {
        get;
        private set;
    }

    public MainViewModel()
    {
        Sections = _allSections = CreateSections();

        SettingsItem = CreateItem("Settings", LanguageManager.Instance.Item_Settings, static () => new SettingsPage());

        SelectedItem = Sections[0].Items[0];
        RefreshFilteredSections();
    }

    /// <summary>
    /// Navigates to the page owned by <paramref name="item"/> by replacing the
    /// current page on the navigation stack, mirroring ControlCatalog's behavior.
    /// </summary>
    public async Task NavigateToItemAsync(NavigationItemViewModel item)
    {
        SelectedItem = item;

        // Reveal the page when the section holding it was collapsed by a filter.
        if (item.Section is { } section)
        {
            section.IsExpanded = true;
        }

        if (Navigator is { } navigator)
        {
            if (ReferenceEquals(navigator.NavigationStack.LastOrDefault(), item.Page))
            {
                return;
            }

            if (ReferenceEquals(item, SettingsItem))
            {
                // Pushed on top of the current page, so the navigation bar offers a back button.
                await navigator.PushAsync(item.Page);
                return;
            }

            // Settings is pushed, not replaced, so leave it before another page takes its place.
            if (navigator.NavigationStack.LastOrDefault() is SettingsPage)
            {
                await navigator.PopToRootAsync();
            }

            await navigator.ReplaceAsync(item.Page);
        }
    }

    public async Task<bool> TryNavigateTo(string key)
    {
        if (_itemsByKey.TryGetValue(key, out var item))
        {
            await NavigateToItemAsync(item);
            return true;
        }

        return false;
    }

    partial void OnSearchTextChanged(string? value)
    {
        RefreshFilteredSections();
    }

    [RelayCommand]
    private async Task NavigateTo(object? parameter)
    {
        if (parameter is NavigationItemViewModel item)
        {
            await NavigateToItemAsync(item);
        }
    }

    [RelayCommand]
    private Task NavigateToSettings()
    {
        return NavigateToItemAsync(SettingsItem);
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

    private NavigationItemViewModel CreateItem(string key, IObservable<string?> title, Func<ContentPage> contentFactory)
    {
        var item = new NavigationItemViewModel(key, title, NavigateToCommand, contentFactory);
        _itemsByKey.Add(key, item);
        return item;
    }

    private static bool Matches(string key, IObservable<string?> title, string search)
    {
        return key.Contains(search, StringComparison.InvariantCultureIgnoreCase)
               || (title as LinguaObservableString)?.CurrentValue?.Contains(search, StringComparison.InvariantCultureIgnoreCase) == true;
    }

    private void RefreshFilteredSections()
    {
        var search = string.IsNullOrWhiteSpace(SearchText) ? string.Empty : SearchText.Trim();
        var isSearching = search.Length > 0;

        foreach (var section in _allSections)
        {
            var sectionMatches = Matches(section.Key, section.Header, search);

            foreach (var item in section.Items)
            {
                item.IsVisible = !isSearching || sectionMatches || Matches(item.Key, item.Title, search);
            }

            section.IsVisible = !isSearching || sectionMatches || section.Items.Any(i => i.IsVisible);

            // A search closes the sections without a match; clearing it opens them all again.
            section.IsExpanded = !isSearching || section.IsVisible;
        }

        OnPropertyChanged(nameof(ShowEmptySearchState));
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
