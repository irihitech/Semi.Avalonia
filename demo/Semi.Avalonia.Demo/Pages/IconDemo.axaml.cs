using System;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Shapes;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Threading;

namespace Semi.Avalonia.Demo.Pages;

public partial class IconDemo : UserControl
{
    public IconDemo()
    {
        InitializeComponent();
    }

    protected override async void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);
        await Dispatcher.UIThread.InvokeAsync(LoadIcons);
    }

    private void LoadIcons()
    {
        IResourceDictionary? resources =
            AvaloniaXamlLoader.Load(new Uri("avares://Semi.Avalonia/Themes/Shared/Icon.axaml")) as ResourceDictionary;
        if (resources is null) return;

        var stackPanel = this.FindControl<StackPanel>("IconsPanel");
        foreach (var key in resources.Keys)
        {
            if (resources[key] is not Geometry geometry) continue;
            var iconControl = new Path
            {
                Data = geometry,
                Fill = Brushes.Black,
                Width = 48,
                Height = 48
            };

            stackPanel?.Children.Add(iconControl);
        }
    }
}