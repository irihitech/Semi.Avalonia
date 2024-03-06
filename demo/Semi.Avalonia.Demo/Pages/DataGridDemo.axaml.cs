using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Input;
using Avalonia.Input.Raw;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using Semi.Avalonia.Demo.ViewModels;

namespace Semi.Avalonia.Demo.Pages;

public partial class DataGridDemo : UserControl
{
    public DataGridDemo()
    {
        InitializeComponent();
        DataContext = new DataGridDemoViewModel();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}