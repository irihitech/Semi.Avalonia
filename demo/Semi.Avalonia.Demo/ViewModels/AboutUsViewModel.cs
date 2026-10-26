using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Semi.Avalonia.Demo.ViewModels;

public partial class AboutUsViewModel : ObservableObject
{
    public ICommand NavigateCommand { get; set; }

    internal ILauncher? Launcher { get; set; }

    public AboutUsViewModel()
    {
        NavigateCommand = new AsyncRelayCommand<string>(OnNavigateAsync);
    }

    private static readonly IReadOnlyDictionary<string, string> _keyToUrlMapping = new Dictionary<string, string>()
    {
        ["semi"] = "https://irihi.tech/products/semi",
        ["ursa"] = "https://irihi.tech/products/ursa",
        ["mantra"] = "https://irihi.tech/products/mantra",
        ["huska"] = "https://irihi.tech/products/huska",
        ["lingua"] = "https://irihi.tech/products/lingua",
        ["mafia"] = "https://irihi.tech/products/mafia",
        ["iconica"] = "https://irihi.tech/products/iconica",
        ["asura"] = "https://irihi.tech",
    };

    private async Task OnNavigateAsync(string? arg)
    {
        if (Launcher is not null && arg is not null && _keyToUrlMapping.TryGetValue(arg.ToLower(), out var uri))
        {
            await Launcher.LaunchUriAsync(new Uri(uri));
        }
    }
}