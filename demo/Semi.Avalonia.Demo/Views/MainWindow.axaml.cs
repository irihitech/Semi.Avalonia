using Avalonia.Controls;
using Avalonia.Input;

namespace Semi.Avalonia.Demo.Views;

public partial class MainWindow : Window
{
    private WindowState _stateBeforeFullScreen = WindowState.Normal;

    public MainWindow()
    {
        InitializeComponent();
        KeyDown += FullScreenKeyDown;
    }

    private void FullScreenKeyDown(object? sender, KeyEventArgs e)
    {
        if (e.Key == Key.F11)
        {
            
            ToggleFullScreen();
            e.Handled = true;
        }
    }

    private void ToggleFullScreen()
    {
        if (WindowState is not WindowState.FullScreen)
        {
            _stateBeforeFullScreen = WindowState;
            WindowState = WindowState.FullScreen;
        }
        else
        {
            WindowState = _stateBeforeFullScreen;
        }
    }
}