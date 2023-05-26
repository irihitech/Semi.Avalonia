using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Semi.Avalonia.Demo.Pages;

public partial class TreeViewDemo : UserControl
{
    public TreeViewDemo()
    {
        InitializeComponent();
        this.DataContext = new TreeViewVm();
    }
}

public class TreeViewVm : ObservableObject
{
    public ObservableCollection<TreeViewItemVm> Items { get; set; }

    public TreeViewVm()
    {
        Items = new ObservableCollection<TreeViewItemVm>()
        {
            new TreeViewItemVm() {Name = "Item 1", Id = "1"},
            new TreeViewItemVm() {Name = "Item 2", Id = "2"},
            new TreeViewItemVm() {Name = "Item 3", Id = "3", Items = new ObservableCollection<TreeViewItemVm>()
            {
                new TreeViewItemVm() {Name = "Item 3.1", Id = "3.1"},
                new TreeViewItemVm() {Name = "Item 3.2", Id = "3.2"},
                new TreeViewItemVm() {Name = "Item 3.3", Id = "3.3"},
            },
            },
        };
    }
}

public partial class TreeViewItemVm : ObservableObject
{
    public ObservableCollection<TreeViewItemVm> Items { get; set; }
    public string Name { get; set; }
    public string Id { get; set; }
}