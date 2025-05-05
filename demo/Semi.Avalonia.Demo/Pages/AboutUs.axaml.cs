using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Semi.Avalonia.Demo.Pages;

public partial class AboutUs : UserControl
{
    public AboutUs()
    {
        InitializeComponent();
        this.DataContext = new AboutUsViewModel();
    }

    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);
        if (this.DataContext is AboutUsViewModel vm)
        {
            var launcher = TopLevel.GetTopLevel(this)?.Launcher;
            vm.Launcher = launcher;
        }
    }
}

public partial class AboutUsViewModel: ObservableObject
{
    public ICommand NavigateCommand { get; set; }
    
    internal ILauncher? Launcher { get; set; }

    public AboutUsViewModel()
    {
        NavigateCommand = new AsyncRelayCommand<string>(OnNavigateAsync);
    }

    private static readonly IReadOnlyDictionary<string, string> _keyToUrlMapping = new Dictionary<string, string>()
    {
        ["semi"] = "https://github.com/irihitech/Semi.Avalonia",
    };

    private async Task OnNavigateAsync(string? arg)
    {
        if (Launcher is not null && arg is not null && _keyToUrlMapping.TryGetValue(arg.ToLower(), out var uri))
        {
            await Launcher.LaunchUriAsync(new Uri(uri));
        }
        
    }
}