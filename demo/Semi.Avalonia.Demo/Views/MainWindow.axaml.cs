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
        PropertyChanged += (_, e) =>
        {
            if (e.Property == WindowStateProperty
                && e.NewValue is WindowState newState
                && newState != WindowState.FullScreen)
            {
                _stateBeforeFullScreen = newState;
            }
        };
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
        WindowState = WindowState is WindowState.FullScreen
            ? _stateBeforeFullScreen
            : WindowState.FullScreen;
    }
}