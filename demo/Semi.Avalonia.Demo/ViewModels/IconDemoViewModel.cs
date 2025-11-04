using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Semi.Avalonia.Demo.ViewModels;

public partial class IconDemoViewModel : ObservableObject
{
    private readonly Icons _resources = new();

    private readonly Dictionary<string, IconItem> _fillIcons = new();
    private readonly Dictionary<string, IconItem> _strokedIcons = new();
    private readonly Dictionary<string, IconItem> _aiIcons = new();

    [ObservableProperty] private string? _searchText;

    public ObservableCollection<IconTab> IconTabs { get; } = [];
    public ObservableCollection<IconItem> FilteredFillIcons { get; set; } = [];
    public ObservableCollection<IconItem> FilteredStrokedIcons { get; set; } = [];
    public ObservableCollection<IconItem> FilteredAIIcons { get; set; } = [];

    public void InitializeResources()
    {
        foreach (var provider in _resources.MergedDictionaries)
        {
            if (provider is not ResourceDictionary dic) continue;

            foreach (var key in dic.Keys)
            {
                if (dic[key] is not Geometry geometry) continue;
                var resourceKey = key.ToString() ?? string.Empty;
                var icon = new IconItem
                {
                    ResourceKey = resourceKey,
                    Geometry = geometry
                };

                if (resourceKey.StartsWith("SemiIconAI"))
                    _aiIcons[resourceKey] = icon;
                else if (resourceKey.EndsWith("Stroked", StringComparison.InvariantCultureIgnoreCase))
                    _strokedIcons[resourceKey] = icon;
                else
                    _fillIcons[resourceKey] = icon;
            }
        }

        OnSearchTextChanged(string.Empty);

        IconTabs.Clear();
        IconTabs.Add(new IconTab("Fill Icons", FilteredFillIcons));
        IconTabs.Add(new IconTab("Stroked Icons", FilteredStrokedIcons));
        IconTabs.Add(new IconTab("AI Icons", FilteredAIIcons));
    }

    partial void OnSearchTextChanged(string? value)
    {
        var search = string.IsNullOrWhiteSpace(value) ? string.Empty : value.Trim();

        FilteredFillIcons.Clear();
        foreach (var pair in _fillIcons.Where(kv => kv.Key.Contains(search, StringComparison.InvariantCultureIgnoreCase)))
        {
            FilteredFillIcons.Add(pair.Value);
        }

        FilteredStrokedIcons.Clear();
        foreach (var pair in _strokedIcons.Where(kv => kv.Key.Contains(search, StringComparison.InvariantCultureIgnoreCase)))
        {
            FilteredStrokedIcons.Add(pair.Value);
        }

        FilteredAIIcons.Clear();
        foreach (var pair in _aiIcons.Where(kv => kv.Key.Contains(search, StringComparison.InvariantCultureIgnoreCase)))
        {
            FilteredAIIcons.Add(pair.Value);
        }
    }
}

public class IconTab(string header, ObservableCollection<IconItem> iconItems)
{
    public string Header { get; set; } = header;
    public ObservableCollection<IconItem> IconItems { get; set; } = iconItems;
}

public class IconItem
{
    public string? ResourceKey { get; set; }
    public Geometry? Geometry { get; set; }
}