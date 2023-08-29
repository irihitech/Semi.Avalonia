using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Avalonia.Controls;
using Avalonia.Controls.Models.TreeDataGrid;
using Avalonia.Controls.Selection;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Semi.Avalonia.TreeDataGrid.Demo.ViewModels;

public class FilesPageViewModel: ObservableObject
{
    public IList<string> Drives { get; }
    private string _selectedDrive;
    private string? _selectedPath;
    private FileNodeViewModel? _root;
    public string SelectedDrive
    {
        get => _selectedDrive;
        set
        {
            SetProperty(ref _selectedDrive, value);
            _root = new FileNodeViewModel(_selectedDrive, isDirectory: true, isRoot: true);
            Source.Items = new[] { _root };
        }
    }
    
    public string? SelectedPath
    {
        get => _selectedPath;
        set => SetSelectedPath(value);
    }
    
    public HierarchicalTreeDataGridSource<FileNodeViewModel> Source { get; }

    public FilesPageViewModel()
    {
        Drives= DriveInfo.GetDrives().Select(x => x.Name).ToList();
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            _selectedDrive = "C:\\";
        }
        else
        {
            _selectedDrive = Drives.FirstOrDefault() ?? "/";
        }

        Source = new HierarchicalTreeDataGridSource<FileNodeViewModel>(Array.Empty<FileNodeViewModel>())
        {
            Columns =
            {
                new CheckBoxColumn<FileNodeViewModel>(
                    null,
                    x => x.IsChecked,
                    (o, v) => o.IsChecked = v,
                    options: new()
                    {
                        CanUserResizeColumn = false,
                    }),
                new HierarchicalExpanderColumn<FileNodeViewModel>(
                    new TemplateColumn<FileNodeViewModel>(
                        "Name",
                        "FileNameCell",
                        "FileNameEditCell",
                        new GridLength(1, GridUnitType.Star),
                        new()
                        {
                            CompareAscending = FileNodeViewModel.SortAscending(x => x.Name),
                            CompareDescending = FileNodeViewModel.SortDescending(x => x.Name),
                            IsTextSearchEnabled = true,
                            TextSearchValueSelector = x => x.Name
                        }),
                    x => x.Children,
                    x => x.HasChildren,
                    x => x.IsExpanded),
                new TextColumn<FileNodeViewModel, long?>(
                    "Size",
                    x => x.Size,
                    options: new()
                    {
                        CompareAscending = FileNodeViewModel.SortAscending(x => x.Size),
                        CompareDescending = FileNodeViewModel.SortDescending(x => x.Size),
                    }),
                new TextColumn<FileNodeViewModel, DateTimeOffset?>(
                    "Modified",
                    x => x.Modified,
                    options: new()
                    {
                        CompareAscending = FileNodeViewModel.SortAscending(x => x.Modified),
                        CompareDescending = FileNodeViewModel.SortDescending(x => x.Modified),
                    }),
            }
        };
        Source.RowSelection!.SingleSelect = false;
        Source.RowSelection.SelectionChanged += SelectionChanged;
    }
    
    private void SelectionChanged(object? sender, TreeSelectionModelSelectionChangedEventArgs<FileNodeViewModel> e)
    {
        var selectedPath = Source.RowSelection?.SelectedItem?.Path;
        this.SetProperty(ref _selectedPath, selectedPath, nameof(SelectedPath));

        foreach (var i in e.DeselectedItems)
            System.Diagnostics.Trace.WriteLine($"Deselected '{i?.Path}'");
        foreach (var i in e.SelectedItems)
            System.Diagnostics.Trace.WriteLine($"Selected '{i?.Path}'");
    }
    
    private void SetSelectedPath(string? value)
    {
        if (string.IsNullOrEmpty(value))
        {
            Source.RowSelection!.Clear();
            return;
        }

        var path = value;
        var components = new Stack<string>();
        DirectoryInfo? d = null;

        if (File.Exists(path))
        {
            var f = new FileInfo(path);
            components.Push(f.Name);
            d = f.Directory;
        }
        else if (Directory.Exists(path))
        {
            d = new DirectoryInfo(path);
        }

        while (d is not null)
        {
            components.Push(d.Name);
            d = d.Parent;
        }

        var index = IndexPath.Unselected;

        if (components.Count > 0)
        {
            var drive = components.Pop();
            var driveIndex = Drives.FindIndex(x => string.Equals(x, drive, StringComparison.OrdinalIgnoreCase));

            if (driveIndex >= 0)
                SelectedDrive = Drives[driveIndex];

            FileNodeViewModel? node = _root;
            index = new IndexPath(0);

            while (node is not null && components.Count > 0)
            {
                node.IsExpanded = true;

                var component = components.Pop();
                var i = node.Children.FindIndex(x => string.Equals(x.Name, component, StringComparison.OrdinalIgnoreCase));
                node = i >= 0 ? node.Children[i] : null;
                index = i >= 0 ? index.Append(i) : default;
            }
        }

        Source.RowSelection!.SelectedIndex = index;
    }
}

public class FileNodeViewModel: ObservableObject, IEditableObject
{
    private string _path;
    private string _name;
    private string? _undoName;
    private long? _size;
    private DateTimeOffset? _modified;
    private FileSystemWatcher? _watcher;
    private ObservableCollection<FileNodeViewModel>? _children;
    private bool _hasChildren = true;
    private bool _isExpanded;

    public FileNodeViewModel( string path, bool isDirectory, bool isRoot = false)
    {
        _path = path;
        _name = isRoot ? path : System.IO.Path.GetFileName(Path);
        _isExpanded = isRoot;
        IsDirectory = isDirectory;
        HasChildren = isDirectory;

        if (!isDirectory)
        {
            var info = new FileInfo(path);
            Size = info.Length;
            Modified = info.LastWriteTimeUtc;
        }
    }

    public string Path 
    {
        get => _path;
        private set => SetProperty(ref _path, value);
    }

    public string Name 
    {
        get => _name;
        private set => SetProperty(ref _name, value);
    }

    public long? Size 
    {
        get => _size;
        private set => SetProperty(ref _size, value);
    }

    public DateTimeOffset? Modified 
    {
        get => _modified;
        private set => SetProperty(ref _modified, value);
    }

    public bool HasChildren
    {
        get => _hasChildren;
        private set => SetProperty(ref _hasChildren, value);
    }

    public bool IsExpanded
    {
        get => _isExpanded;
        set => SetProperty(ref _isExpanded, value);
    }

    public bool IsChecked { get; set; }
    public bool IsDirectory { get; }
    public IReadOnlyList<FileNodeViewModel> Children => _children ??= LoadChildren();

    private ObservableCollection<FileNodeViewModel> LoadChildren()
    {
        if (!IsDirectory)
        {
            throw new NotSupportedException();
        }

        var options = new EnumerationOptions { IgnoreInaccessible = true };
        var result = new ObservableCollection<FileNodeViewModel>();

        foreach (var d in Directory.EnumerateDirectories(Path, "*", options))
        {
            result.Add(new FileNodeViewModel(d, true));
        }

        foreach (var f in Directory.EnumerateFiles(Path, "*", options))
        {
            result.Add(new FileNodeViewModel(f, false));
        }

        _watcher = new FileSystemWatcher
        {
            Path = Path,
            NotifyFilter = NotifyFilters.FileName | NotifyFilters.Size | NotifyFilters.LastWrite,
        };

        _watcher.Changed += OnChanged;
        _watcher.Created += OnCreated;
        _watcher.Deleted += OnDeleted;
        _watcher.Renamed += OnRenamed;
        _watcher.EnableRaisingEvents = true;

        if (result.Count == 0)
            HasChildren = false;

        return result;
    }

    public static Comparison<FileNodeViewModel?> SortAscending<T>(Func<FileNodeViewModel, T> selector)
    {
        return (x, y) =>
        {
            if (x is null && y is null)
                return 0;
            else if (x is null)
                return -1;
            else if (y is null)
                return 1;
            if (x.IsDirectory == y.IsDirectory)
                return Comparer<T>.Default.Compare(selector(x), selector(y));
            else if (x.IsDirectory)
                return -1;
            else
                return 1;
        };
    }

    public static Comparison<FileNodeViewModel?> SortDescending<T>(Func<FileNodeViewModel, T> selector)
    {
        return (x, y) =>
        {
            if (x is null && y is null)
                return 0;
            else if (x is null)
                return 1;
            else if (y is null)
                return -1;
            if (x.IsDirectory == y.IsDirectory)
                return Comparer<T>.Default.Compare(selector(y), selector(x));
            else if (x.IsDirectory)
                return -1;
            else
                return 1;
        };
    }

    void IEditableObject.BeginEdit() => _undoName = _name;
    void IEditableObject.CancelEdit() => _name = _undoName!;
    void IEditableObject.EndEdit() => _undoName = null;

    private void OnChanged(object sender, FileSystemEventArgs e)
    {
        if (e.ChangeType == WatcherChangeTypes.Changed && File.Exists(e.FullPath))
        {
            Dispatcher.UIThread.Post(() =>
            {
                foreach (var child in _children!)
                {
                    if (child.Path == e.FullPath)
                    {
                        if (!child.IsDirectory)
                        {
                            var info = new FileInfo(e.FullPath);
                            child.Size = info.Length;
                            child.Modified = info.LastWriteTimeUtc;
                        }
                        break;
                    }
                }
            });
        }
    }

    private void OnCreated(object sender, FileSystemEventArgs e)
    {
        Dispatcher.UIThread.Post(() =>
        {
            var node = new FileNodeViewModel(
                e.FullPath,
                File.GetAttributes(e.FullPath).HasFlag(FileAttributes.Directory));
            _children!.Add(node);
        });
    }

    private void OnDeleted(object sender, FileSystemEventArgs e)
    {
        Dispatcher.UIThread.Post(() =>
        {
            for (var i = 0; i < _children!.Count; ++i)
            {
                if (_children[i].Path == e.FullPath)
                {
                    _children.RemoveAt(i);
                    System.Diagnostics.Debug.WriteLine($"Removed {e.FullPath}");
                    break;
                }
            }
        });
    }

    private void OnRenamed(object sender, RenamedEventArgs e)
    {
        Dispatcher.UIThread.Post(() =>
        {
            foreach (var child in _children!)
            {
                if (child.Path == e.OldFullPath)
                {
                    child.Path = e.FullPath;
                    child.Name = e.Name ?? string.Empty;
                    break;
                }
            }
        });
    }
}

internal static class ListExtensions
{
    public static int FindIndex<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        int i = 0;
        foreach (var item in source)
        {
            if (predicate(item))
                return i;
            i++;
        }
        return -1;
    }
}