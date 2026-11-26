using System;
using System.Windows.Input;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Semi.Avalonia.Demo.ViewModels;

public partial class NavigationItemViewModel : ObservableObject
{
    private readonly Func<ContentPage> _contentFactory;

    public NavigationItemViewModel(string key, IObservable<string?> title, ICommand navigateCommand, Func<ContentPage> contentFactory)
    {
        Key = key;
        Title = title;
        NavigateCommand = navigateCommand;
        _contentFactory = contentFactory;
    }

    public string Key { get; }

    public Control? Icon => NavigationIcons.Icons.TryGetValue(Key, out var factory) ? factory() : null;

    public IObservable<string?> Title { get; }

    /// <summary>
    /// The section listing this page; null for pages reached from elsewhere, such as Settings.
    /// </summary>
    public NavigationSectionViewModel? Section { get; internal set; }

    [ObservableProperty] public partial bool IsVisible { get; set; } = true;

    public ICommand NavigateCommand { get; }

    public ContentPage Page
    {
        get
        {
            if (field is null)
            {
                field = _contentFactory();
                Title.Subscribe(new PageHeaderObserver(field));
            }
            return field;
        }
    }

    [ObservableProperty] public partial bool IsSelected { get; set; }

    private sealed class PageHeaderObserver(ContentPage page) : IObserver<string?>
    {
        public void OnNext(string? value) => page.Header = value;
        public void OnCompleted() { }
        public void OnError(Exception error) { }
    }
}
