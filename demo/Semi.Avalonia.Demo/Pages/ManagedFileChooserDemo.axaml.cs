using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;

namespace Semi.Avalonia.Demo.Pages;

public partial class ManagedFileChooserDemo : UserControl
{
    public ManagedFileChooserDemo()
    {
        InitializeComponent();
        OpenFileButton.Click += OpenFileDialog;
        SelectFolderButton.Click += SelectFolderDialog;
        SaveFileButton.Click += SaveFileDialog;
    }

    private async void OpenFileDialog(object? sender, RoutedEventArgs args)
    {
        var sp = GetStorageProvider();
        if (sp is null) return;
        var result = await sp.OpenFilePickerAsync(new FilePickerOpenOptions()
        {
            Title = "Open File",
            FileTypeFilter = GetFileTypes(),
            AllowMultiple = true,
        });
    }

    private async void SelectFolderDialog(object? sender, RoutedEventArgs args)
    {
        var sp = GetStorageProvider();
        if (sp is null) return;
        var result = await sp.OpenFolderPickerAsync(new FolderPickerOpenOptions()
        {
            Title = "Select Folder",
            AllowMultiple = true,
        });
    }

    private async void SaveFileDialog(object? sender, RoutedEventArgs args)
    {
        var sp = GetStorageProvider();
        if (sp is null) return;
        var result = await sp.SaveFilePickerAsync(new FilePickerSaveOptions()
        {
            Title = "Save File",
        });
    }

    private IStorageProvider? GetStorageProvider()
    {
        var topLevel = TopLevel.GetTopLevel(this);
        return topLevel?.StorageProvider;
    }

    List<FilePickerFileType>? GetFileTypes()
    {
        return
        [
            FilePickerFileTypes.All,
            FilePickerFileTypes.TextPlain
        ];
    }
}