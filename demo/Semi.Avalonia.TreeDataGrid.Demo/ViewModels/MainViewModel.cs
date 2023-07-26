using CommunityToolkit.Mvvm.ComponentModel;

namespace Semi.Avalonia.TreeDataGrid.Demo.ViewModels;

public class MainViewModel: ObservableObject
{
    public SongsPageViewModel SongsContext { get; } = new();
    public FilesPageViewModel FilesContext { get; } = new();
}