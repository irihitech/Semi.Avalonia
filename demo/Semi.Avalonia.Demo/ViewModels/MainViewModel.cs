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
using Semi.Avalonia.Demo.Pages;

namespace Semi.Avalonia.Demo.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly Dictionary<string, NavigationItemViewModel> _itemsByTitle = new(StringComparer.Ordinal);
    private readonly IReadOnlyList<NavigationSectionViewModel> _allSections;

    [ObservableProperty] public partial string? SearchText { get; set; }

    public string DocumentationUrl => "https://docs.irihi.tech/semi";
    public string RepoUrl => "https://github.com/irihitech/Semi.Avalonia";
    public IReadOnlyList<MenuItemViewModel> MenuItems { get; }
    public IReadOnlyList<NavigationSectionViewModel> Sections { get; }
    public ObservableCollection<NavigationSectionViewModel> FilteredSections { get; } = [];
    public bool ShowEmptySearchState => FilteredSections.Count == 0 && !string.IsNullOrWhiteSpace(SearchText);
    public ContentPage? CurrentPage => SelectedItem?.Page;
    public string SelectedPageTitle => SelectedItem?.Title ?? "Overview";

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
                Header = "Theme",
                Items =
                [
                    new MenuItemViewModel { Header = "Auto", Command = FollowSystemThemeCommand },
                    new MenuItemViewModel { Header = "Aquatic", Command = SelectThemeCommand, CommandParameter = SemiTheme.Aquatic },
                    new MenuItemViewModel { Header = "Desert", Command = SelectThemeCommand, CommandParameter = SemiTheme.Desert },
                    new MenuItemViewModel { Header = "Dusk", Command = SelectThemeCommand, CommandParameter = SemiTheme.Dusk },
                    new MenuItemViewModel { Header = "NightSky", Command = SelectThemeCommand, CommandParameter = SemiTheme.NightSky },
                ]
            },
            new MenuItemViewModel
            {
                Header = "Locale",
                Items =
                [
                    new MenuItemViewModel { Header = "简体中文", Command = SelectLocaleCommand, CommandParameter = new CultureInfo("zh-CN") },
                    new MenuItemViewModel { Header = "English", Command = SelectLocaleCommand, CommandParameter = new CultureInfo("en-US") },
                    new MenuItemViewModel { Header = "日本語", Command = SelectLocaleCommand, CommandParameter = new CultureInfo("ja-JP") },
                    new MenuItemViewModel { Header = "한국어", Command = SelectLocaleCommand, CommandParameter = new CultureInfo("ko-KR") },
                    new MenuItemViewModel { Header = "English (UK)", Command = SelectLocaleCommand, CommandParameter = new CultureInfo("en-GB") },
                    new MenuItemViewModel { Header = "Italiano", Command = SelectLocaleCommand, CommandParameter = new CultureInfo("it-IT") },
                    new MenuItemViewModel { Header = "Italiano (Switzerland)", Command = SelectLocaleCommand, CommandParameter = new CultureInfo("it-CH") },
                    new MenuItemViewModel { Header = "Nederlands", Command = SelectLocaleCommand, CommandParameter = new CultureInfo("nl-NL") },
                    new MenuItemViewModel { Header = "Nederlands (Belgium)", Command = SelectLocaleCommand, CommandParameter = new CultureInfo("nl-BE") },
                    new MenuItemViewModel { Header = "Українська", Command = SelectLocaleCommand, CommandParameter = new CultureInfo("uk-UA") },
                    new MenuItemViewModel { Header = "Русский", Command = SelectLocaleCommand, CommandParameter = new CultureInfo("ru-RU") },
                    new MenuItemViewModel { Header = "繁體中文", Command = SelectLocaleCommand, CommandParameter = new CultureInfo("zh-TW") },
                    new MenuItemViewModel { Header = "Deutsch", Command = SelectLocaleCommand, CommandParameter = new CultureInfo("de-DE") },
                    new MenuItemViewModel { Header = "Español", Command = SelectLocaleCommand, CommandParameter = new CultureInfo("es-ES") },
                    new MenuItemViewModel { Header = "Polski", Command = SelectLocaleCommand, CommandParameter = new CultureInfo("pl-PL") },
                    new MenuItemViewModel { Header = "Français", Command = SelectLocaleCommand, CommandParameter = new CultureInfo("fr-FR") },
                ]
            }
        ];

        Sections = _allSections =
        [
            new NavigationSectionViewModel("Overview",
            [
                CreateItem("Overview", static () => new Overview()),
                CreateItem("About Us", static () => new AboutUs()),
            ]),
            new NavigationSectionViewModel("Resource Browser",
            [
                CreateItem("Palette", static () => new PaletteDemo()),
                CreateItem("HighContrastTheme", static () => new HighContrastDemo()),
                CreateItem("Variables", static () => new VariablesDemo()),
                CreateItem("Icon", static () => new IconDemo()),
            ]),
            new NavigationSectionViewModel("Separate Pack",
            [
                CreateItem("ColorPicker", static () => new ColorPickerDemo()),
                CreateItem("DataGrid", static () => new DataGridDemo()),
            ]),
            new NavigationSectionViewModel("Basic",
            [
                CreateItem("TextBlock", static () => new TextBlockDemo()),
                CreateItem("SelectableTextBlock", static () => new SelectableTextBlockDemo()),
                CreateItem("Border", static () => new BorderDemo()),
                CreateItem("PathIcon", static () => new PathIconDemo()),
            ]),
            new NavigationSectionViewModel("Button",
            [
                CreateItem("Button", static () => new ButtonDemo()),
                CreateItem("HyperlinkButton", static () => new HyperlinkButtonDemo()),
                CreateItem("CheckBox", static () => new CheckBoxDemo()),
                CreateItem("RadioButton", static () => new RadioButtonDemo()),
                CreateItem("ToggleSwitch", static () => new ToggleSwitchDemo()),
            ]),
            new NavigationSectionViewModel("Input",
            [
                CreateItem("TextBox", static () => new TextBoxDemo()),
                CreateItem("AutoCompleteBox", static () => new AutoCompleteBoxDemo()),
                CreateItem("ComboBox", static () => new ComboBoxDemo()),
                CreateItem("ButtonSpinner", static () => new ButtonSpinnerDemo()),
                CreateItem("NumericUpDown", static () => new NumericUpDownDemo()),
                CreateItem("Slider", static () => new SliderDemo()),
                CreateItem("ManagedFileChooser", static () => new ManagedFileChooserDemo()),
            ]),
            new NavigationSectionViewModel("Date/Time",
            [
                CreateItem("Calendar", static () => new CalendarDemo()),
                CreateItem("CalendarDatePicker", static () => new CalendarDatePickerDemo()),
                CreateItem("DatePicker", static () => new DatePickerDemo()),
                CreateItem("TimePicker", static () => new TimePickerDemo()),
            ]),
            new NavigationSectionViewModel("Navigation",
            [
                CreateItem("ContentPage", static () => new ContentPageDemo()),
                CreateItem("CarouselPage", static () => new CarouselPageDemo()),
                CreateItem("DrawerPage", static () => new DrawerPageDemo()),
                CreateItem("NavigationPage", static () => new NavigationPageDemo()),
                CreateItem("TabbedPage", static () => new TabbedPageDemo()),
                CreateItem("TabControl", static () => new TabControlDemo()),
                CreateItem("TabStrip", static () => new TabStripDemo()),
                CreateItem("TreeView", static () => new TreeViewDemo()),
            ]),
            new NavigationSectionViewModel("Show",
            [
                CreateItem("Carousel", static () => new CarouselDemo()),
                CreateItem("PipsPager", static () => new PipsPagerDemo()),
                CreateItem("Expander", static () => new ExpanderDemo()),
                CreateItem("Flyout", static () => new FlyoutDemo()),
                CreateItem("HeaderedContentControl", static () => new HeaderedContentControlDemo()),
                CreateItem("Label", static () => new LabelDemo()),
                CreateItem("ListBox", static () => new ListBoxDemo()),
                CreateItem("SplitView", static () => new SplitViewDemo()),
                CreateItem("ToolTip", static () => new ToolTipDemo()),
            ]),
            new NavigationSectionViewModel("Feedback",
            [
                CreateItem("DataValidationErrors", static () => new DataValidationErrorsDemo()),
                CreateItem("Notification", static () => new NotificationDemo()),
                CreateItem("ProgressBar", static () => new ProgressBarDemo()),
                CreateItem("RefreshContainer", static () => new RefreshContainerDemo()),
            ]),
            new NavigationSectionViewModel("Other",
            [
                CreateItem("CommandBar", static () => new CommandBarDemo()),
                CreateItem("GridSplitter", static () => new GridSplitterDemo()),
                CreateItem("Menu", static () => new MenuDemo()),
                CreateItem("ScrollViewer", static () => new ScrollViewerDemo()),
                CreateItem("ThemeVariantScope", static () => new ThemeVariantDemo()),
                CreateItem("WindowCustomizationsPage", static () => new WindowCustomizationsPage()),
            ]),
        ];

        SelectedItem = Sections[0].Items[0];
        RefreshFilteredSections();
    }

    public bool TryNavigateTo(string title)
    {
        if (_itemsByTitle.TryGetValue(title, out var item))
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

    private NavigationItemViewModel CreateItem(string title, Func<Control> contentFactory)
    {
        var item = new NavigationItemViewModel(title, NavigateToCommand, contentFactory);
        _itemsByTitle.Add(title, item);
        return item;
    }

    private void RefreshFilteredSections()
    {
        var search = string.IsNullOrWhiteSpace(SearchText) ? string.Empty : SearchText.Trim();

        FilteredSections.Clear();

        foreach (var section in _allSections)
        {
            if (search.Length == 0 ||
                section.Header.Contains(search, StringComparison.InvariantCultureIgnoreCase))
            {
                FilteredSections.Add(section);
                continue;
            }

            var matchedItems = section.Items
                .Where(item => item.Title.Contains(search, StringComparison.InvariantCultureIgnoreCase))
                .ToArray();

            if (matchedItems.Length > 0)
            {
                FilteredSections.Add(new NavigationSectionViewModel(section.Header, matchedItems));
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
    public NavigationSectionViewModel(string header, IReadOnlyList<NavigationItemViewModel> items)
    {
        Header = header;
        Items = items;
    }

    public string Header { get; }

    public IReadOnlyList<NavigationItemViewModel> Items { get; }
}

public partial class NavigationItemViewModel : ObservableObject
{
    private readonly Func<Control> _contentFactory;

    public NavigationItemViewModel(string title, ICommand navigateCommand, Func<Control> contentFactory)
    {
        Title = title;
        NavigateCommand = navigateCommand;
        _contentFactory = contentFactory;
    }

    public string Title { get; }

    public ICommand NavigateCommand { get; }

    public ContentPage Page => field ??= new ContentPage
    {
        Header = Title,
        Background = null,
        HorizontalContentAlignment = HorizontalAlignment.Stretch,
        VerticalContentAlignment = VerticalAlignment.Stretch,
        Content = _contentFactory()
    };

    [ObservableProperty] public partial bool IsSelected { get; set; }
}

public class MenuItemViewModel
{
    public string? Header { get; set; }
    public ICommand? Command { get; set; }
    public object? CommandParameter { get; set; }
    public IList<MenuItemViewModel>? Items { get; set; }
}
