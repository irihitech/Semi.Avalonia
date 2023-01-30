using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Dialogs;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Platform.Storage;

namespace Semi.Avalonia.Demo.Pages;

public partial class ManagedFileChooserDemo : UserControl
{
    public ManagedFileChooserDemo()
    {
        InitializeComponent();
        openFileDialog.Click += OpenFileDialog;
        selectFolderDialog.Click += SelectFolderDialog;
        saveFileDialog.Click += SaveFileDialog;
    }

    private async void OpenFileDialog(object sender, RoutedEventArgs args)
    {
        IStorageProvider sp = GetStorageProvider();
        var result = await sp.OpenFilePickerAsync(new FilePickerOpenOptions()
        {
            Title = "Open File",
            FileTypeFilter = GetFileTypes(),
            AllowMultiple = true,
        });
    }
    private async void SelectFolderDialog(object sender, RoutedEventArgs args)
    {
        IStorageProvider sp = GetStorageProvider();
        var result = await sp.OpenFolderPickerAsync(new FolderPickerOpenOptions()
        {
            Title = "Select Folder",
            AllowMultiple = true,
        });
    }
    private async void SaveFileDialog(object sender, RoutedEventArgs args)
    {
        IStorageProvider sp = GetStorageProvider();
        var result = await sp.SaveFilePickerAsync(new FilePickerSaveOptions()
        {
            Title = "Open File",
        });
    }
    
    private IStorageProvider GetStorageProvider()
    {
        return new ManagedStorageProvider<Window>(GetWindow(), null);
    }

    private static string FullPathOrName(IStorageItem? item)
    {
        if (item is null) return "(null)";
        return item.TryGetUri(out var uri) ? uri.ToString() : item.Name;
    }

    Window GetWindow() => this.VisualRoot as Window ?? throw new NullReferenceException("Invalid Owner");
    TopLevel GetTopLevel() => this.VisualRoot as TopLevel ?? throw new NullReferenceException("Invalid Owner");
    
    List<FilePickerFileType>? GetFileTypes()
    {
        return new List<FilePickerFileType>
        {
            FilePickerFileTypes.All,
            FilePickerFileTypes.TextPlain
        };
    }
}