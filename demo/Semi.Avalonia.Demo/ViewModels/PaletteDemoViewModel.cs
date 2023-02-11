using System;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Semi.Avalonia.Demo.ViewModels;

public class PaletteDemoViewModel: ObservableObject
{
    private string[] _colors = { "Amber","Blue","Cyan","Green","Grey","Indigo","LightBlue","LightGreen","Lime","Orange","Pink","Purple","Red","Teal","Violet","Yellow" };
    private ObservableCollection<ColorSeries> _series;

    public ObservableCollection<ColorSeries> Series
    {
        get => _series;
        set => SetProperty(ref _series, value);
    }

    public PaletteDemoViewModel()
    {
        Series = new ObservableCollection<ColorSeries>();
        var resouceDictionary = (ResourceDictionary)(AvaloniaXamlLoader.Load(new Uri("avares://Semi.Avalonia/Themes/Light/Palette.axaml")));
        foreach (var color in _colors)
        {
            ColorSeries s = new ColorSeries();
            s.Initialize(resouceDictionary, color);
            Series.Add(s);
        }
    }
}

public class ColorSeries: ObservableObject
{
    private ObservableCollection<ColorItemViewModel>? _colors;

    public ObservableCollection<ColorItemViewModel>? Color
    {
        get => _colors;
        set => SetProperty(ref _colors, value);
    }

    private string? _seriesName;

    public string? SeriesName
    {
        get => _seriesName;
        set => SetProperty(ref _seriesName, value);
    }
    
    internal void Initialize(IResourceDictionary resourceDictionary, string color)
    {
        SeriesName = color;
        Color = new ObservableCollection<ColorItemViewModel>();
        
        for (int i = 0; i < 10; i++)
        {
            var key = "Semi" + color + i;
            if (resourceDictionary.TryGetValue(key, out var value))
            {
                if (value is SolidColorBrush brush)
                {
                    string name = color + " " + i;
                    var item = new ColorItemViewModel(name, brush, key);
                    Color.Add(item);
                } 
            }
        }
    }
}

public class ColorItemViewModel : ObservableObject
{

    private IBrush _color;
    public IBrush Color
    {
        get => _color;
        set => SetProperty(ref _color, value);
    }

    private string _name;
    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    private string _resourceKey;

    public string ResourceKey
    {
        get => _resourceKey;
        set => SetProperty(ref _resourceKey, value);
    }
    
    public ColorItemViewModel(string name, IBrush color, string resourceKey)
    {
        Name = name;
        Color = color;
        ResourceKey = resourceKey;
    }
}