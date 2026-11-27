using System;
using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Semi.Avalonia.Demo.ViewModels;

public partial class NavigationSectionViewModel : ObservableObject
{
    public NavigationSectionViewModel(string key, IObservable<string?> header, IReadOnlyList<NavigationItemViewModel> items)
    {
        Key = key;
        Header = header;
        Items = items;
        foreach (var item in items)
        {
            item.Section = this;
        }
    }

    public string Key { get; }

    public IObservable<string?> Header { get; }

    public IReadOnlyList<NavigationItemViewModel> Items { get; }

    [ObservableProperty] public partial bool IsVisible { get; set; } = true;

    [ObservableProperty] public partial bool IsExpanded { get; set; } = true;
}
