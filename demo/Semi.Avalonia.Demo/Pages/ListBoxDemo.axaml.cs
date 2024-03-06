using System.Collections;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Semi.Avalonia.Demo.Pages;

public partial class ListBoxDemo : UserControl
{
    public ListBoxDemo()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public IEnumerable Items { get; set; } = new List<string> { "Ding", "Otter", "Husky", "Mr.17", "Cass", };
}