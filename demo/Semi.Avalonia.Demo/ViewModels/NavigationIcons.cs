using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Lab = Irihi.Iconica.Semi.Lab;

namespace Semi.Avalonia.Demo.ViewModels;

internal static class NavigationIcons
{
    public static readonly IReadOnlyDictionary<string, Func<Control>> Icons = new Dictionary<string, Func<Control>>(StringComparer.Ordinal)
    {
        ["Overview"] = static () => new Lab.GettingStarted(),
        ["About Us"] = static () => new Lab.Avatar(),
        ["Palette"] = static () => new Lab.ColorPlatte(),
        ["HighContrastTheme"] = static () => new Lab.DarkMode(),
        ["Variables"] = static () => new Lab.Token(),
        ["Icon"] = static () => new Lab.Heart(),
        ["ColorPicker"] = static () => new Lab.ColorPlatteNew(),
        ["DataGrid"] = static () => new Lab.Grid(),
        ["TextBlock"] = static () => new Lab.Typography(),
        ["SelectableTextBlock"] = static () => new Lab.Markdown(),
        ["Border"] = static () => new Lab.Divider(),
        ["PathIcon"] = static () => new Lab.Image(),
        ["Button"] = static () => new Lab.Button(),
        ["HyperlinkButton"] = static () => new Lab.Anchor(),
        ["CheckBox"] = static () => new Lab.Checkbox(),
        ["RadioButton"] = static () => new Lab.Radio(),
        ["ToggleSwitch"] = static () => new Lab.Switch(),
        ["TextBox"] = static () => new Lab.Input(),
        ["AutoCompleteBox"] = static () => new Lab.Autocomplete(),
        ["ComboBox"] = static () => new Lab.Select(),
        ["ButtonSpinner"] = static () => new Lab.Pincode(),
        ["NumericUpDown"] = static () => new Lab.InputNumber(),
        ["Slider"] = static () => new Lab.Slider(),
        ["ManagedFileChooser"] = static () => new Lab.Upload(),
        ["Calendar"] = static () => new Lab.Calendar(),
        ["CalendarDatePicker"] = static () => new Lab.DatePicker(),
        ["DatePicker"] = static () => new Lab.Timeline(),
        ["TimePicker"] = static () => new Lab.TimePicker(),
        ["ContentPage"] = static () => new Lab.Layout(),
        ["CarouselPage"] = static () => new Lab.Carousel(),
        ["DrawerPage"] = static () => new Lab.SideSheet(),
        ["NavigationPage"] = static () => new Lab.Navigation(),
        ["TabbedPage"] = static () => new Lab.Breadcrumb(),
        ["TabControl"] = static () => new Lab.Tabs(),
        ["TabStrip"] = static () => new Lab.Steps(),
        ["TreeView"] = static () => new Lab.Tree(),
        ["Carousel"] = static () => new Lab.Lottie(),
        ["PipsPager"] = static () => new Lab.Pagination(),
        ["Expander"] = static () => new Lab.Collapse(),
        ["Flyout"] = static () => new Lab.Popover(),
        ["HeaderedContentControl"] = static () => new Lab.Card(),
        ["Label"] = static () => new Lab.Tag(),
        ["ListBox"] = static () => new Lab.List(),
        ["SplitView"] = static () => new Lab.Descriptions(),
        ["ToolTip"] = static () => new Lab.Tooltip(),
        ["TableView"] = static () => new Lab.Table(),
        ["DataValidationErrors"] = static () => new Lab.Form(),
        ["Notification"] = static () => new Lab.Notification(),
        ["ProgressBar"] = static () => new Lab.Progress(),
        ["RefreshContainer"] = static () => new Lab.BackTop(),
        ["CommandBar"] = static () => new Lab.Overflow(),
        ["GridSplitter"] = static () => new Lab.Space(),
        ["Menu"] = static () => new Lab.Dropdown(),
        ["ScrollViewer"] = static () => new Lab.ScrollList(),
        ["ThemeVariantScope"] = static () => new Lab.Config(),
    };
}
