using System.Collections.ObjectModel;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Semi.Avalonia.Demo.Pages;

public partial class ComboBoxDemo : UserControl
{
    public ComboBoxDemo()
    {
        InitializeComponent();
        this.DataContext = new ComboBoxDemoViewModel();
    }
}

public class ComboBoxDemoViewModel : ObservableObject
{
    public ObservableCollection<string> Items { get; set; } = ["Ding", "Otter", "Husky", "Mr.17", "Cass"];
}