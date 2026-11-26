using System;
using System.Collections.Generic;
using Irihi.Lingua;

namespace Semi.Avalonia.Demo.ViewModels;

public class NavigationSectionViewModel
{
    public NavigationSectionViewModel(string key, IObservable<string?> header, IReadOnlyList<NavigationItemViewModel> items)
    {
        Key = key;
        Header = header;
        Items = items;
    }

    public string Key { get; }

    public IObservable<string?> Header { get; }

    public IReadOnlyList<NavigationItemViewModel> Items { get; }
}
