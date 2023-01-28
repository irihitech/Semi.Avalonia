using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Semi.Avalonia.Demo.Pages;

public partial class DatePickerDemo : UserControl
{
    public DatePickerDemo()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}