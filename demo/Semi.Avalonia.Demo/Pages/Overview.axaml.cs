using Avalonia.Controls;

namespace Semi.Avalonia.Demo.Pages;

public partial class Overview : UserControl
{
    public Overview()
    {
        InitializeComponent();
    }

    public string MainInstall { get; set; } = "dotnet add package Semi.Avalonia";

    public string MainStyle { get; set; } =
        """
        <Application.Styles>
            <semi:SemiTheme Locale="zh-CN" />
        </Application.Styles>
        """;

    public string ColorPickerInstall { get; set; } = "dotnet add package Semi.Avalonia.ColorPicker";

    public string ColorPickerStyle { get; set; } =
        """
        <Application.Styles>
            <semi:ColorPickerSemiTheme />
        </Application.Styles>
        """;

    public string DataGridInstall { get; set; } = "dotnet add package Semi.Avalonia.DataGrid";

    public string DataGridStyle { get; set; } =
        """
        <Application.Styles>
            <semi:DataGridSemiTheme />
        </Application.Styles>
        """;

    public string TreeDataGridInstall { get; set; } = "dotnet add package Semi.Avalonia.TreeDataGrid";

    public string TreeDataGridStyle { get; set; } =
        """
        <Application.Styles>
            <semi:TreeDataGridSemiTheme />
        </Application.Styles>
        """;

    public string DockInstall { get; set; } = "dotnet add package Semi.Avalonia.Dock";

    public string DockStyle { get; set; } =
        """
        <Application.Styles>
            <semi:DockSemiTheme />
        </Application.Styles>
        """;

    public string TabaloniaInstall { get; set; } = "dotnet add package Semi.Avalonia.Tabalonia";

    public string TabaloniaStyle { get; set; } =
        """
        <Application.Styles>
            <semi:TabaloniaSemiTheme />
        </Application.Styles>
        """;

    public string AvaloniaEditInstall { get; set; } = "dotnet add package Semi.Avalonia.AvaloniaEdit";

    public string AvaloniaEditStyle { get; set; } =
        """
        <Application.Styles>
            <semi:AvaloniaEditSemiTheme />
        </Application.Styles>
        """;
}