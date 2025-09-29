using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace Semi.Avalonia.Demo.ViewModels;

public partial class ApplicationViewModel : ObservableObject
{
    [RelayCommand]
    private void Activate()
    {
        if (Application.Current?.ApplicationLifetime is not IClassicDesktopStyleApplicationLifetime desktop) return;
        var mainWindow = desktop.MainWindow;
        if (mainWindow is not null && !mainWindow.IsActive)
        {
            if (mainWindow.WindowState is WindowState.Minimized)
            {
                mainWindow.WindowState = WindowState.Normal;
            }

            mainWindow.Activate();
        }
    }

    [RelayCommand]
    private void JumpTo(string header)
    {
        Activate();
        WeakReferenceMessenger.Default.Send(header, "JumpTo");
    }

    [RelayCommand]
    private void Exit()
    {
        if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.Shutdown();
        }
    }
}