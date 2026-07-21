using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Layout;
using Avalonia.Styling;
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
    public IReadOnlyList<MenuItemViewModel> MenuItems { get; }
    public IReadOnlyList<NavigationSectionViewModel> Sections { get; }

    // Lingua i18n observable properties
    public IObservable<string?> AppName => LanguageManager.Instance.App_Name;
    public IObservable<string?> AppTitle => LanguageManager.Instance.App_Title;
    public IObservable<string?> SearchPlaceholder => LanguageManager.Instance.Search_Placeholder;
    public IObservable<string?> EmptySearchMessage => LanguageManager.Instance.Empty_Search_Message;
    public ObservableCollection<NavigationSectionViewModel> FilteredSections { get; } = [];
    public bool ShowEmptySearchState => FilteredSections.Count == 0 && !string.IsNullOrWhiteSpace(SearchText);
    public ContentPage? CurrentPage => SelectedItem?.Page;
    public IObservable<string?> SelectedPageTitle => SelectedItem?.Title ?? LanguageManager.Instance.Default_Page_Title;

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
                OnPropertyChanged(nameof(CurrentPage));
                OnPropertyChanged(nameof(SelectedPageTitle));
            }
        }
    }

    public MainViewModel()
    {
        MenuItems =
        [
            new MenuItemViewModel
            {
                Header = LanguageManager.Instance.Menu_Theme,
                Items =
                [
                    new MenuItemViewModel { Header = LanguageManager.Instance.Theme_Auto, Command = FollowSystemThemeCommand },
                    new MenuItemViewModel { Header = LanguageManager.Instance.Theme_Aquatic, Command = SelectThemeCommand, CommandParameter = SemiTheme.Aquatic },
                    new MenuItemViewModel { Header = LanguageManager.Instance.Theme_Desert, Command = SelectThemeCommand, CommandParameter = SemiTheme.Desert },
                    new MenuItemViewModel { Header = LanguageManager.Instance.Theme_Dusk, Command = SelectThemeCommand, CommandParameter = SemiTheme.Dusk },
                    new MenuItemViewModel { Header = LanguageManager.Instance.Theme_NightSky, Command = SelectThemeCommand, CommandParameter = SemiTheme.NightSky },
                ]
            },
            new MenuItemViewModel
            {
                Header = LanguageManager.Instance.Menu_Locale,
                Items =
                [
                    new MenuItemViewModel { Header = LinguaObservableString.FromLiteral("简体中文"), Command = SelectLocaleCommand, CommandParameter = new CultureInfo("zh-CN") },
                    new MenuItemViewModel { Header = LinguaObservableString.FromLiteral("English"), Command = SelectLocaleCommand, CommandParameter = new CultureInfo("en-US") },
                    new MenuItemViewModel { Header = LinguaObservableString.FromLiteral("日本語"), Command = SelectLocaleCommand, CommandParameter = new CultureInfo("ja-JP") },
                    new MenuItemViewModel { Header = LinguaObservableString.FromLiteral("한국어"), Command = SelectLocaleCommand, CommandParameter = new CultureInfo("ko-KR") },
                    new MenuItemViewModel { Header = LinguaObservableString.FromLiteral("English (UK)"), Command = SelectLocaleCommand, CommandParameter = new CultureInfo("en-GB") },
                    new MenuItemViewModel { Header = LinguaObservableString.FromLiteral("Italiano"), Command = SelectLocaleCommand, CommandParameter = new CultureInfo("it-IT") },
                    new MenuItemViewModel { Header = LinguaObservableString.FromLiteral("Italiano (Switzerland)"), Command = SelectLocaleCommand, CommandParameter = new CultureInfo("it-CH") },
                    new MenuItemViewModel { Header = LinguaObservableString.FromLiteral("Nederlands"), Command = SelectLocaleCommand, CommandParameter = new CultureInfo("nl-NL") },
                    new MenuItemViewModel { Header = LinguaObservableString.FromLiteral("Nederlands (Belgium)"), Command = SelectLocaleCommand, CommandParameter = new CultureInfo("nl-BE") },
                    new MenuItemViewModel { Header = LinguaObservableString.FromLiteral("Українська"), Command = SelectLocaleCommand, CommandParameter = new CultureInfo("uk-UA") },
                    new MenuItemViewModel { Header = LinguaObservableString.FromLiteral("Русский"), Command = SelectLocaleCommand, CommandParameter = new CultureInfo("ru-RU") },
                    new MenuItemViewModel { Header = LinguaObservableString.FromLiteral("繁體中文"), Command = SelectLocaleCommand, CommandParameter = new CultureInfo("zh-TW") },
                    new MenuItemViewModel { Header = LinguaObservableString.FromLiteral("Deutsch"), Command = SelectLocaleCommand, CommandParameter = new CultureInfo("de-DE") },
                    new MenuItemViewModel { Header = LinguaObservableString.FromLiteral("Español"), Command = SelectLocaleCommand, CommandParameter = new CultureInfo("es-ES") },
                    new MenuItemViewModel { Header = LinguaObservableString.FromLiteral("Polski"), Command = SelectLocaleCommand, CommandParameter = new CultureInfo("pl-PL") },
                    new MenuItemViewModel { Header = LinguaObservableString.FromLiteral("Français"), Command = SelectLocaleCommand, CommandParameter = new CultureInfo("fr-FR") },
                ]
            }
        ];
        
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
                CreateItem("ToolTip", LanguageManager.Instance.Item_ToolTip, static () => new ToolTipDemo()),
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
                CreateItem("WindowCustomizationsPage", LanguageManager.Instance.Item_WindowCustomizationsPage, static () => new WindowCustomizationsPage()),
            ]),
        ];

        SelectedItem = Sections[0].Items[0];
        RefreshFilteredSections();
    }

    public bool TryNavigateTo(string key)
    {
        if (_itemsByKey.TryGetValue(key, out var item))
        {
            SelectedItem = item;
            return true;
        }

        return false;
    }

    partial void OnSearchTextChanged(string? value)
    {
        RefreshFilteredSections();
    }

    [RelayCommand]
    private void NavigateTo(object? parameter)
    {
        if (parameter is NavigationItemViewModel item)
        {
            SelectedItem = item;
        }
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
        if (obj is not CultureInfo culture) return;

        var app = Application.Current;
        if (app is not null)
        {
            SemiTheme.OverrideLocaleResources(app, culture);
        }
        // culture mapping, example: zh-CN to zh-Hans
        LanguageManager.Instance.UpdateCulture(culture);
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

    private NavigationItemViewModel CreateItem(string key, IObservable<string?> title, Func<Control> contentFactory)
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

public class NavigationSectionViewModel
{
    public NavigationSectionViewModel(string key, IObservable<string?> header, IReadOnlyList<NavigationItemViewModel> items)
    {
        Key = key;
        Header = header;
        Items = items;
    }

    public string Key { get; }

    public IObservable<string?> Header { get; }

    public IReadOnlyList<NavigationItemViewModel> Items { get; }
}

public partial class NavigationItemViewModel : ObservableObject
{
    private readonly Func<Control> _contentFactory;

    public NavigationItemViewModel(string key, IObservable<string?> title, ICommand navigateCommand, Func<Control> contentFactory)
    {
        Key = key;
        Title = title;
        NavigateCommand = navigateCommand;
        _contentFactory = contentFactory;
    }

    public string Key { get; }

    public IObservable<string?> Title { get; }

    public ICommand NavigateCommand { get; }

    public ContentPage Page
    {
        get
        {
            if (field is null)
            {
                field = new ContentPage
                {
                    Background = null,
                    HorizontalContentAlignment = HorizontalAlignment.Stretch,
                    VerticalContentAlignment = VerticalAlignment.Stretch,
                    Content = _contentFactory()
                };
                Title.Subscribe(new PageHeaderObserver(field));
            }
            return field;
        }
    }

    [ObservableProperty] public partial bool IsSelected { get; set; }

    private sealed class PageHeaderObserver(ContentPage page) : IObserver<string?>
    {
        public void OnNext(string? value) => page.Header = value;
        public void OnCompleted() { }
        public void OnError(Exception error) { }
    }
}

public class MenuItemViewModel
{
    public IObservable<string?>? Header { get; set; }
    public ICommand? Command { get; set; }
    public object? CommandParameter { get; set; }
    public IList<MenuItemViewModel>? Items { get; set; }
}
