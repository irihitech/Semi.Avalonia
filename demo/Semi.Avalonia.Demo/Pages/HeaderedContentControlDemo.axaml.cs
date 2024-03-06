using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Semi.Avalonia.Demo.Pages;

public partial class HeaderedContentControlDemo : UserControl
{
    public HeaderedContentControlDemo()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}