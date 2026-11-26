using Semi.Avalonia.Demo.Pages;

namespace Semi.Avalonia.Demo.ViewModels;

public partial class MainViewModel
{
    private NavigationSectionViewModel[] CreateSections()
    {
        return
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
    }
}
