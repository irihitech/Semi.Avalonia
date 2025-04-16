using CommunityToolkit.Mvvm.ComponentModel;

namespace Semi.Avalonia.Demo.ViewModels;

public class TreeDataGridDemoViewModel: ObservableObject
{
    public SongsPageViewModel SongsContext { get; } = new();
    public FilesPageViewModel FilesContext { get; } = new();
}