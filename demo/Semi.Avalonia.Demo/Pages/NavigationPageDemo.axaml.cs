using System;
using Avalonia.Animation;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Semi.Avalonia.Demo.Pages;

public partial class NavigationPageDemo : UserControl
{
    private int _pageCount;
    private int _modalCount;

    public NavigationPageDemo()
    {
        InitializeComponent();
        Loaded += OnLoaded;
    }

    private async void OnLoaded(object? sender, RoutedEventArgs e)
    {
        await DemoNav.PushAsync(NavigationDemoHelper.MakePage("Home", "Welcome!\nUse the buttons to push and pop pages/modals.", 0), null);
        UpdateStatus();
    }

    private async void OnPush(object? sender, RoutedEventArgs e)
    {
        _pageCount++;
        var page = NavigationDemoHelper.MakePage($"Page {_pageCount}", $"This is page {_pageCount}.", _pageCount);
        NavigationPage.SetHasNavigationBar(page, HasNavBarCheck.IsChecked == true);
        NavigationPage.SetHasBackButton(page, HasBackButtonCheck.IsChecked == true);
        await DemoNav.PushAsync(page);
        UpdateStatus();
    }

    private async void OnPop(object? sender, RoutedEventArgs e)
    {
        await DemoNav.PopAsync();
        UpdateStatus();
    }

    private async void OnPopToRoot(object? sender, RoutedEventArgs e)
    {
        await DemoNav.PopToRootAsync();
        _pageCount = 0;
        UpdateStatus();
    }

    private async void OnPushModal(object? sender, RoutedEventArgs e)
    {
        _modalCount++;
        var modal = NavigationDemoHelper.MakePage($"Modal {_modalCount}", "This page was presented modally.\nTap 'Pop Modal' to dismiss.", _modalCount);
        await DemoNav.PushModalAsync(modal);
        UpdateStatus();
    }

    private async void OnPopModal(object? sender, RoutedEventArgs e)
    {
        await DemoNav.PopModalAsync();
        UpdateStatus();
    }

    private async void OnPopAllModals(object? sender, RoutedEventArgs e)
    {
        await DemoNav.PopAllModalsAsync();
        _modalCount = 0;
        UpdateStatus();
    }

    private void OnHasNavBarChanged(object? sender, RoutedEventArgs e)
    {
        if (DemoNav == null)
            return;
        if (DemoNav.CurrentPage != null)
            NavigationPage.SetHasNavigationBar(DemoNav.CurrentPage, HasNavBarCheck.IsChecked == true);
    }

    private void OnHasBackButtonChanged(object? sender, RoutedEventArgs e)
    {
        if (DemoNav == null)
            return;
        if (DemoNav.CurrentPage != null)
            NavigationPage.SetHasBackButton(DemoNav.CurrentPage, HasBackButtonCheck.IsChecked == true);
    }

    private void OnHasShadowChanged(object? sender, RoutedEventArgs e)
    {
        if (DemoNav == null)
            return;
        if (DemoNav.CurrentPage != null)
            DemoNav.HasShadow = HasShadowCheck.IsChecked == true;
    }

    private void OnTransitionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (DemoNav == null)
            return;
        DemoNav.ModalTransition = TransitionCombo.SelectedIndex switch
        {
            1 => new CrossFade(TimeSpan.FromMilliseconds(250)),
            2 => null,
            _ => new PageSlide(TimeSpan.FromMilliseconds(300), PageSlide.SlideAxis.Vertical)
        };
    }

    private void UpdateStatus()
    {
        StatusText.Text = $"Depth: {DemoNav.StackDepth}";
        HeaderText.Text = $"Current: {DemoNav.CurrentPage?.Header ?? "(none)"}";
        ModalText.Text = $"Modals: {DemoNav.ModalStack.Count}";
    }
}