using System;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Semi.Avalonia.Demo.ViewModels;

public partial class IconDemoViewModel : ObservableObject
{
    private readonly IResourceDictionary? _resources =
        AvaloniaXamlLoader.Load(new Uri("avares://Semi.Avalonia/Themes/Shared/Icon.axaml")) as ResourceDictionary;

    public ObservableCollection<IconItem> Icons { get; set; } = [];

    public void InitializeResources()
    {
        LoadIcons();
    }

    private void LoadIcons()
    {
        if (_resources is null) return;

        foreach (var key in _resources.Keys)
        {
            if (_resources[key] is Geometry geometry)
            {
                var icon = new IconItem { ResourceKey = key.ToString(), Geometry = geometry };
                Icons.Add(icon);
            }
        }
    }
}

public class IconItem
{
    public string? ResourceKey { get; set; }
    public Geometry? Geometry { get; set; }
}