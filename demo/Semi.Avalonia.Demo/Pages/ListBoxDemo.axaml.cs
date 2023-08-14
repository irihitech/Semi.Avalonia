using System.Collections;
using System.Collections.Generic;
using Avalonia.Controls;

namespace Semi.Avalonia.Demo.Pages;

public partial class ListBoxDemo : UserControl
{
    public ListBoxDemo()
    {
        InitializeComponent();
    }

    public IEnumerable Items { get; set; } = new List<Panda>
    {
        new() { Name = "Ding", IsAvailable = true },
        new() { Name = "Otter", IsAvailable = true },
        new() { Name = "Husky", IsAvailable = false },
        new() { Name = "Mr.17", IsAvailable = true },
        new() { Name = "Cass", IsAvailable = true },
    };
}

internal record Panda
{
    public string Name { get; set; }
    public bool IsAvailable { get; set; }
}