using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Semi.Avalonia.Demo.Pages;

public partial class CalendarDemo : UserControl
{
    public CalendarDemo()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}