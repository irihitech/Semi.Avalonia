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

    public ObservableCollection<FirstItem>? MultipleLevelItems { get; set; }

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

        MultipleLevelItems = new();
        for (int i = 1; i < 6; i++)
        {
            FirstItem firstItem = new FirstItem { Id = i, Name = $"FirstItem {i}" };
            firstItem.SecondItems = new();
            for (int j = 1; j < 6; j++)
            {
                SecondItem secondItem = new SecondItem { Id = j, Name = $"SecondItem {j}" };
                secondItem.ThirdItemItems = new();
                for (int k = 1; k < 6; k++)
                {
                    ThirdItem thirdItem = new ThirdItem { Id = k, Name = $"ThirdItem {k}" };
                    secondItem.ThirdItemItems.Add(thirdItem);
                }
                firstItem.SecondItems.Add(secondItem);
            }
            MultipleLevelItems.Add(firstItem);
        }
    }
}

public partial class TreeViewItemVm : ObservableObject
{
    public ObservableCollection<TreeViewItemVm> Items { get; set; }
    public string Name { get; set; }
    public string Id { get; set; }
}

public class ItemBase
{
    public int Id { get; set; }
    public string? Name { get; set; }
}
public class FirstItem : ItemBase
{
    public ObservableCollection<SecondItem>? SecondItems { get; set; }
}
public class SecondItem : ItemBase
{
    public ObservableCollection<ThirdItem>? ThirdItemItems { get; set; }

}
public class ThirdItem : ItemBase
{
}



