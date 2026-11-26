using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Input;
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
    public ObservableCollection<NavigationSectionViewModel> FilteredSections { get; } = [];
    public bool ShowEmptySearchState => FilteredSections.Count == 0 && !string.IsNullOrWhiteSpace(SearchText);

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
        Sections = _allSections =
        [
            new NavigationSectionViewModel("Overview", LanguageManager.Instance.Section_Overview,
            [
                CreateItem("Overview", LanguageManager.Instance.Item_Overview, static () => new Overview()),
                CreateItem("About Us", LanguageManager.Instance.Item_About_Us, static () => new AboutUs()),
            ]),
            new NavigationSectionViewModel("Resource Browser", LanguageManager.Instance.Section_ResourceBrowser,
            [
                CreateItem("Palette", LanguageManager.Instance.Item_Palette, static () => new PaletteDemo()),
                CreateItem("HighContrastTheme", LanguageManager.Instance.Item_HighContrastTheme, static () => new HighContrastDemo()),
                CreateItem("Variables", LanguageManager.Instance.Item_Variables, static () => new VariablesDemo()),
                CreateItem("Icon", LanguageManager.Instance.Item_Icon, static () => new IconDemo()),
            ]),
            new NavigationSectionViewModel("Separate Pack", LanguageManager.Instance.Section_SeparatePack,
            [
                CreateItem("ColorPicker", LanguageManager.Instance.Item_ColorPicker, static () => new ColorPickerDemo()),
                CreateItem("DataGrid", LanguageManager.Instance.Item_DataGrid, static () => new DataGridDemo()),
            ]),
            new NavigationSectionViewModel("Basic", LanguageManager.Instance.Section_Basic,
            [
                CreateItem("TextBlock", LanguageManager.Instance.Item_TextBlock, static () => new TextBlockDemo()),
                CreateItem("SelectableTextBlock", LanguageManager.Instance.Item_SelectableTextBlock, static () => new SelectableTextBlockDemo()),
                CreateItem("Border", LanguageManager.Instance.Item_Border, static () => new BorderDemo()),
                CreateItem("PathIcon", LanguageManager.Instance.Item_PathIcon, static () => new PathIconDemo()),
            ]),
            new NavigationSectionViewModel("Button", LanguageManager.Instance.Section_Button,
            [
                CreateItem("Button", LanguageManager.Instance.Item_Button, static () => new ButtonDemo()),
                CreateItem("HyperlinkButton", LanguageManager.Instance.Item_HyperlinkButton, static () => new HyperlinkButtonDemo()),
                CreateItem("CheckBox", LanguageManager.Instance.Item_CheckBox, static () => new CheckBoxDemo()),
                CreateItem("RadioButton", LanguageManager.Instance.Item_RadioButton, static () => new RadioButtonDemo()),
                CreateItem("ToggleSwitch", LanguageManager.Instance.Item_ToggleSwitch, static () => new ToggleSwitchDemo()),
            ]),
            new NavigationSectionViewModel("Input", LanguageManager.Instance.Section_Input,
            [
                CreateItem("TextBox", LanguageManager.Instance.Item_TextBox, static () => new TextBoxDemo()),
                CreateItem("AutoCompleteBox", LanguageManager.Instance.Item_AutoCompleteBox, static () => new AutoCompleteBoxDemo()),
                CreateItem("ComboBox", LanguageManager.Instance.Item_ComboBox, static () => new ComboBoxDemo()),
                CreateItem("ButtonSpinner", LanguageManager.Instance.Item_ButtonSpinner, static () => new ButtonSpinnerDemo()),
                CreateItem("NumericUpDown", LanguageManager.Instance.Item_NumericUpDown, static () => new NumericUpDownDemo()),
                CreateItem("Slider", LanguageManager.Instance.Item_Slider, static () => new SliderDemo()),
                CreateItem("ManagedFileChooser", LanguageManager.Instance.Item_ManagedFileChooser, static () => new ManagedFileChooserDemo()),
            ]),
            new NavigationSectionViewModel("Date/Time", LanguageManager.Instance.Section_DateTime,
            [
                CreateItem("Calendar", LanguageManager.Instance.Item_Calendar, static () => new CalendarDemo()),
                CreateItem("CalendarDatePicker", LanguageManager.Instance.Item_CalendarDatePicker, static () => new CalendarDatePickerDemo()),
                CreateItem("DatePicker", LanguageManager.Instance.Item_DatePicker, static () => new DatePickerDemo()),
                CreateItem("TimePicker", LanguageManager.Instance.Item_TimePicker, static () => new TimePickerDemo()),
            ]),
            new NavigationSectionViewModel("Navigation", LanguageManager.Instance.Section_Navigation,
            [
                CreateItem("ContentPage", LanguageManager.Instance.Item_ContentPage, static () => new ContentPageDemo()),
                CreateItem("CarouselPage", LanguageManager.Instance.Item_CarouselPage, static () => new CarouselPageDemo()),
                CreateItem("DrawerPage", LanguageManager.Instance.Item_DrawerPage, static () => new DrawerPageDemo()),
                CreateItem("NavigationPage", LanguageManager.Instance.Item_NavigationPage, static () => new NavigationPageDemo()),
                CreateItem("TabbedPage", LanguageManager.Instance.Item_TabbedPage, static () => new TabbedPageDemo()),
                CreateItem("TabControl", LanguageManager.Instance.Item_TabControl, static () => new TabControlDemo()),
                CreateItem("TabStrip", LanguageManager.Instance.Item_TabStrip, static () => new TabStripDemo()),
                CreateItem("TreeView", LanguageManager.Instance.Item_TreeView, static () => new TreeViewDemo()),
            ]),
            new NavigationSectionViewModel("Show", LanguageManager.Instance.Section_Show,
            [
                CreateItem("Carousel", LanguageManager.Instance.Item_Carousel, static () => new CarouselDemo()),
                CreateItem("PipsPager", LanguageManager.Instance.Item_PipsPager, static () => new PipsPagerDemo()),
                CreateItem("Expander", LanguageManager.Instance.Item_Expander, static () => new ExpanderDemo()),
                CreateItem("Flyout", LanguageManager.Instance.Item_Flyout, static () => new FlyoutDemo()),
                CreateItem("HeaderedContentControl", LanguageManager.Instance.Item_HeaderedContentControl, static () => new HeaderedContentControlDemo()),
                CreateItem("Label", LanguageManager.Instance.Item_Label, static () => new LabelDemo()),
                CreateItem("ListBox", LanguageManager.Instance.Item_ListBox, static () => new ListBoxDemo()),
                CreateItem("SplitView", LanguageManager.Instance.Item_SplitView, static () => new SplitViewDemo()),
                CreateItem("ToolTip", LanguageManager.Instance.Item_ToolTip, static () => new TooltipDemo()),
                CreateItem("TableView", LanguageManager.Instance.Item_TableView, static () => new TableViewDemo()),
            ]),
            new NavigationSectionViewModel("Feedback", LanguageManager.Instance.Section_Feedback,
            [
                CreateItem("DataValidationErrors", LanguageManager.Instance.Item_DataValidationErrors, static () => new DataValidationErrorsDemo()),
                CreateItem("Notification", LanguageManager.Instance.Item_Notification, static () => new NotificationDemo()),
                CreateItem("ProgressBar", LanguageManager.Instance.Item_ProgressBar, static () => new ProgressBarDemo()),
                CreateItem("RefreshContainer", LanguageManager.Instance.Item_RefreshContainer, static () => new RefreshContainerDemo()),
            ]),
            new NavigationSectionViewModel("Other", LanguageManager.Instance.Section_Other,
            [
                CreateItem("CommandBar", LanguageManager.Instance.Item_CommandBar, static () => new CommandBarDemo()),
                CreateItem("GridSplitter", LanguageManager.Instance.Item_GridSplitter, static () => new GridSplitterDemo()),
                CreateItem("Menu", LanguageManager.Instance.Item_Menu, static () => new MenuDemo()),
                CreateItem("ScrollViewer", LanguageManager.Instance.Item_ScrollViewer, static () => new ScrollViewerDemo()),
                CreateItem("ThemeVariantScope", LanguageManager.Instance.Item_ThemeVariantScope, static () => new ThemeVariantDemo()),
            ]),
        ];

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
            if (navigator.NavigationStack.LastOrDefault() is Pages.SettingsPage)
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

    private void RefreshFilteredSections()
    {
        var search = string.IsNullOrWhiteSpace(SearchText) ? string.Empty : SearchText.Trim();

        FilteredSections.Clear();

        foreach (var section in _allSections)
        {
            if (search.Length == 0 ||
                section.Key.Contains(search, StringComparison.InvariantCultureIgnoreCase)
                || ( section.Header as LinguaObservableString)?.CurrentValue?.Contains(search, StringComparison.InvariantCultureIgnoreCase) == true)
            {
                FilteredSections.Add(section);
                continue;
            }

            var matchedItems = section.Items
                .Where(item => item.Key.Contains(search, StringComparison.InvariantCultureIgnoreCase)
                || (item.Title as LinguaObservableString)?.CurrentValue?.Contains(search, StringComparison.InvariantCultureIgnoreCase) == true)
                .ToArray();

            if (matchedItems.Length > 0)
            {
                FilteredSections.Add(new NavigationSectionViewModel(section.Key, section.Header, matchedItems));
            }
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
