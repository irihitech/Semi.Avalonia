using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Semi.Avalonia.Demo.ViewModels;

public class TabControlDemoViewModel: ObservableObject
{
    public ObservableCollection<string> Items { get; set; }

    public TabControlDemoViewModel()
    {
        Items = new ObservableCollection<string>(Enumerable.Range(1, 200).Select(a => "Tab " + a));
    }
}