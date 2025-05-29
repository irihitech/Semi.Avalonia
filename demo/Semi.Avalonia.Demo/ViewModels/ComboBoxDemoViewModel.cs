using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Semi.Avalonia.Demo.ViewModels;

public class ComboBoxDemoViewModel : ObservableObject
{
    public ObservableCollection<string> Items { get; set; } = ["Ding", "Otter", "Husky", "Mr.17", "Cass"];
}