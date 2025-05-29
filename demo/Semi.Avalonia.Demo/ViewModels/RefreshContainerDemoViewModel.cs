using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Semi.Avalonia.Demo.ViewModels;

public class RefreshContainerDemoViewModel : ObservableObject
{
    public ObservableCollection<string> Items { get; }

    public RefreshContainerDemoViewModel()
    {
        Items = new ObservableCollection<string>(Enumerable.Range(1, 200).Select(i => $"Item {i}"));
    }

    public async Task AddToTop()
    {
        await Task.Delay(1000);
        Items.Insert(0, $"Item {200 - Items.Count}");
    }
}