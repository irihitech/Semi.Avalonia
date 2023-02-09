using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;

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

    public override void Render(DrawingContext context)
    {
        base.Render(context);
    }
}