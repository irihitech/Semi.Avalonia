using Avalonia.Controls;

namespace Semi.Avalonia.Demo.Pages;

public partial class Overview : UserControl
{
    public Overview()
    {
        InitializeComponent();
    }

    public string MainInstall { get; set; } = "dotnet add package Semi.Avalonia --version 11.2.1.7";

    public string MainStyle { get; set; } =
        """
        <Application.Styles>
            <semi:SemiTheme Locale="zh-CN" />
        </Application.Styles>
        """;

    public string ColorPickerInstall { get; set; } = "dotnet add package Semi.Avalonia.ColorPicker --version 11.2.1.7";

    public string ColorPickerStyle { get; set; } =
        """
        <Application.Styles>
            <semi:ColorPickerSemiTheme />
        </Application.Styles>
        """;

    public string DataGridInstall { get; set; } = "dotnet add package Semi.Avalonia.DataGrid --version 11.2.1.7";

    public string DataGridStyle { get; set; } =
        """
        <Application.Styles>
            <semi:DataGridSemiTheme />
        </Application.Styles>
        """;

    public string TreeDataGridInstall { get; set; } = "dotnet add package Semi.Avalonia.TreeDataGrid --version 11.0.10.3";

    public string TreeDataGridStyle { get; set; } =
        """
        <Application.Styles>
            <semi:TreeDataGridSemiTheme />
        </Application.Styles>
        """;
}