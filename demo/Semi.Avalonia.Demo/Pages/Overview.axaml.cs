using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;

namespace Semi.Avalonia.Demo.Pages;

public partial class Overview : UserControl
{
    public Overview()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public string MainInstall { get; set; } = "dotnet add package Semi.Avalonia --version 11.0.7";

    public string MainStyle { get; set; } = """
<Application.Styles>
    <StyleInclude Source="avares://Semi.Avalonia/Themes/Index.axaml" />
</Application.Styles>
""";

    public string ColorPickerInstall { get; set; } = "dotnet add package Semi.Avalonia.ColorPicker --version 11.0.7";

    public string ColorPickerStyle { get; set; } = """
<Application.Styles>
    <StyleInclude Source="avares://Semi.Avalonia.ColorPicker/Index.axaml" />
</Application.Styles>
""";

    public string DataGridInstall { get; set; } = "dotnet add package Semi.Avalonia.DataGrid --version 11.0.7";

    public string DataGridStyle { get; set; } = """
<Application.Styles>
    <StyleInclude Source="avares://Semi.Avalonia.DataGrid/Index.axaml" />
</Application.Styles>
""";

    public string TreeDataGridInstall { get; set; } = "dotnet add package Semi.Avalonia.TreeDataGrid --version 11.0.7";

    public string TreeDataGridStyle { get; set; } = """
<Application.Styles>
    <StyleInclude Source="avares://Semi.Avalonia.TreeDataGrid/Index.axaml" />
</Application.Styles>
""";
}