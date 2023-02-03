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
        IStorageProvider? sp = GetStorageProvider();
        if (sp is null) return;
        var result = await sp.OpenFilePickerAsync(new FilePickerOpenOptions()
        {
            Title = "Open File",
            FileTypeFilter = GetFileTypes(),
            AllowMultiple = true,
        });
    }
    private async void SelectFolderDialog(object sender, RoutedEventArgs args)
    {
        IStorageProvider? sp = GetStorageProvider();
        if (sp is null) return;
        var result = await sp.OpenFolderPickerAsync(new FolderPickerOpenOptions()
        {
            Title = "Select Folder",
            AllowMultiple = true,
        });
    }
    private async void SaveFileDialog(object sender, RoutedEventArgs args)
    {
        IStorageProvider? sp = GetStorageProvider();
        if (sp is null) return;
        var result = await sp.SaveFilePickerAsync(new FilePickerSaveOptions()
        {
            Title = "Open File",
        });
    }
    
    private IStorageProvider? GetStorageProvider()
    {
        var topLevel = TopLevel.GetTopLevel(this);
        return topLevel?.StorageProvider;
    }

    List<FilePickerFileType>? GetFileTypes()
    {
        return new List<FilePickerFileType>
        {
            FilePickerFileTypes.All,
            FilePickerFileTypes.TextPlain
        };
    }
}