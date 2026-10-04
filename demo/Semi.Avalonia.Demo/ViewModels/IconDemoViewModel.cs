using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using Semi.Avalonia.Demo.Constant;

namespace Semi.Avalonia.Demo.ViewModels;

public partial class IconDemoViewModel : ObservableObject
{
    private readonly Icons _resources = new();
    private readonly DispatcherTimer _searchDebounce = new() { Interval = TimeSpan.FromMilliseconds(180) };

    private readonly Dictionary<string, IconItem> _fillIcons = new();
    private readonly Dictionary<string, IconItem> _strokedIcons = new();
    private readonly Dictionary<string, IconItem> _aiIcons = new();

    public IconDemoViewModel() => _searchDebounce.Tick += (_, _) =>
    {
        _searchDebounce.Stop();
        ApplyFilter();
    };

    [ObservableProperty] public partial string? SearchText { get; set; }
    [ObservableProperty] public partial IconTab? SelectedTab { get; set; }
    public ObservableCollection<IconTab> IconTabs { get; } = [];

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

        if (IconTabs.Count == 0)
        {
            IconTabs.Add(new IconTab("Fill Icons", _fillIcons));
            IconTabs.Add(new IconTab("Stroked Icons", _strokedIcons));
            IconTabs.Add(new IconTab("AI Icons", _aiIcons));
            SelectedTab = IconTabs[0];
        }

        ApplyFilter();
    }

    private string CurrentSearch =>
        string.IsNullOrWhiteSpace(SearchText) ? string.Empty : SearchText.Trim();

    // Typing is debounced: filtering refills the icon collections of the visible tab, and doing that
    // on every keystroke would block the UI thread once per character.
    partial void OnSearchTextChanged(string? value)
    {
        _searchDebounce.Stop();
        _searchDebounce.Start();
    }

    // Switching tabs refreshes that tab: its icons were left stale while it was hidden.
    partial void OnSelectedTabChanged(IconTab? value) => ApplyFilter();

    /// <summary>
    /// Refilters the visible tab only. The other tabs keep the icons they had and are refreshed on
    /// selection, so a keystroke never pays for the two tabs nobody is looking at.
    /// </summary>
    private void ApplyFilter()
    {
        var search = CurrentSearch;
        var active = SelectedTab ?? IconTabs.FirstOrDefault();
        if (active is null || !active.IsStale(search)) return;

        active.ApplyFilter(search);
    }
}

public sealed class IconTab
{
    private readonly Dictionary<string, IconCategory> _categories = new(StringComparer.Ordinal);
    private string? _appliedSearch;

    public IconTab(string header, IReadOnlyDictionary<string, IconItem> icons)
    {
        Header = header;

        // One stable category object per design category: rebuilding them on every keystroke would
        // recreate the expander containers and throw away the expansion state.
        foreach (var name in IconMeta.CategoryOrder)
        {
            var category = new IconCategory(name);
            _categories[name] = category;
            Categories.Add(category);
        }

        foreach (var pair in icons)
        {
            var name = IconMeta.Categories.GetValueOrDefault(pair.Key, IconMeta.FallbackCategory);
            if (_categories.TryGetValue(name, out var category))
            {
                category.Add(pair.Value);
            }
        }
    }

    public string Header { get; }

    public ObservableCollection<IconCategory> Categories { get; } = [];

    public bool IsStale(string search) => !string.Equals(_appliedSearch, search, StringComparison.Ordinal);

    public void ApplyFilter(string search)
    {
        _appliedSearch = search;
        foreach (var category in Categories)
        {
            category.ApplyFilter(search);
        }
    }
}

public partial class IconCategory : ObservableObject
{
    private readonly List<IconItem> _all = [];
    private IReadOnlyList<IconItem> _visible = [];

    public IconCategory(string name) => Name = name;

    public string Name { get; }

    public ObservableCollection<IconItem> Items { get; } = [];

    /// <summary>Categories that match nothing are hidden instead of being removed from the list.</summary>
    [ObservableProperty] public partial bool IsVisible { get; set; }

    public string Title => $"{Name} ({_visible.Count})";

    public void Add(IconItem item) => _all.Add(item);

    public void ApplyFilter(string search)
    {
        _visible = search.Length == 0
            ? _all
            : _all.Where(item => Matches(item, search)).ToArray();

        IsVisible = _visible.Count > 0;
        OnPropertyChanged(nameof(Title));

        Items.Clear();
        foreach (var item in _visible)
        {
            Items.Add(item);
        }
    }

    private bool Matches(IconItem item, string search) =>
        (item.ResourceKey?.Contains(search, StringComparison.InvariantCultureIgnoreCase) ?? false) ||
        Name.Contains(search, StringComparison.InvariantCultureIgnoreCase);
}

public class IconItem
{
    public string? ResourceKey { get; set; }
    public Geometry? Geometry { get; set; }
}
