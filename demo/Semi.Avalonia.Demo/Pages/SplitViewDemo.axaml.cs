using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Semi.Avalonia.Demo.Pages;

public partial class SplitViewDemo : UserControl
{
    public SplitViewDemo()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}