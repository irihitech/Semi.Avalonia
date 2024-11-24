using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Semi.Avalonia.Demo.Pages;

public partial class GridSplitterDemo : UserControl
{
    public GridSplitterDemo()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}