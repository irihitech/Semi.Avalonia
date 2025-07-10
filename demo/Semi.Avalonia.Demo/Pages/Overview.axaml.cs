using Avalonia.Controls;

namespace Semi.Avalonia.Demo.Pages;

public partial class Overview : UserControl
{
    public Overview()
    {
        InitializeComponent();
    }

    public string MainInstall { get; set; } = "dotnet add package Semi.Avalonia --version 11.2.1.8";

    public string MainStyle { get; set; } =
        """
        <Application.Styles>
            <semi:SemiTheme Locale="zh-CN" />
        </Application.Styles>
        """;

    public string ColorPickerInstall { get; set; } = "dotnet add package Semi.Avalonia.ColorPicker --version 11.2.1.8";

    public string ColorPickerStyle { get; set; } =
        """
        <Application.Styles>
            <semi:ColorPickerSemiTheme />
        </Application.Styles>
        """;

    public string DataGridInstall { get; set; } = "dotnet add package Semi.Avalonia.DataGrid --version 11.2.1.8";

    public string DataGridStyle { get; set; } =
        """
        <Application.Styles>
            <semi:DataGridSemiTheme />
        </Application.Styles>
        """;

    public string TreeDataGridInstall { get; set; } = "dotnet add package Semi.Avalonia.TreeDataGrid --version 11.0.10.4";

    public string TreeDataGridStyle { get; set; } =
        """
        <Application.Styles>
            <semi:TreeDataGridSemiTheme />
        </Application.Styles>
        """;

    public string DockInstall { get; set; } = "dotnet add package Semi.Avalonia.Dock --version 11.3.0";

    public string DockStyle { get; set; } =
        """
        <Application.Styles>
            <semi:DockSemiTheme />
        </Application.Styles>
        """;

    public string TabaloniaInstall { get; set; } = "dotnet add package Semi.Avalonia.Tabalonia --version 11.0.0-beta1";

    public string TabaloniaStyle { get; set; } =
        """
        <Application.Styles>
            <semi:TabaloniaSemiTheme />
        </Application.Styles>
        """;

    public string AvaloniaEditInstall { get; set; } = "dotnet add package Semi.Avalonia.AvaloniaEdit --version 11.2.0";

    public string AvaloniaEditStyle { get; set; } =
        """
        <Application.Styles>
            <semi:AvaloniaEditSemiTheme />
        </Application.Styles>
        """;
}