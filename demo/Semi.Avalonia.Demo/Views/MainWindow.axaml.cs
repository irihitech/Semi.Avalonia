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

    private bool _maximizeTogglePending;

    private void OnTitleBarHitAreaPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (!e.Properties.IsLeftButtonPressed)
        {
            return;
        }
        if (e.ClickCount == 2)
        {
            // Defer to PointerReleased: toggling away from Maximized during the
            // press resizes the window and breaks the pointer chain on Windows.
            _maximizeTogglePending = true;
            e.Handled = true;
        }
        else if (WindowState != WindowState.FullScreen)
        {
            BeginMoveDrag(e);
            e.Handled = true;
        }
    }

    private void OnTitleBarHitAreaPointerReleased(object? sender, PointerReleasedEventArgs e)
    {
        if (_maximizeTogglePending
            && e.InitialPressMouseButton == MouseButton.Left
            && CanResize && CanMaximize
            && WindowState is WindowState.Normal or WindowState.Maximized)
        {
            WindowState = WindowState == WindowState.Maximized
                ? WindowState.Normal
                : WindowState.Maximized;
        }
        _maximizeTogglePending = false;
    }
}