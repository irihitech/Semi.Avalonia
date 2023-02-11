using System;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

namespace Semi.Avalonia.Demo.ViewModels;

public class PaletteDemoViewModel: ObservableObject
{
    private string[] _colors = { "Amber","Blue","Cyan","Green","Grey","Indigo","LightBlue","LightGreen","Lime","Orange","Pink","Purple","Red","Teal","Violet","Yellow" };
    private ObservableCollection<ColorSeries> _lightSeries;

    private ColorItemViewModel _selectedColor;

    public ColorItemViewModel SelectedColor
    {
        get => _selectedColor;
        set => SetProperty(ref _selectedColor, value);
    }

    public ObservableCollection<ColorSeries> LightSeries
    {
        get => _lightSeries;
        set => SetProperty(ref _lightSeries, value);
    }
    
    private ObservableCollection<ColorSeries> _darkSeries;

    public ObservableCollection<ColorSeries> DarkSeries
    {
        get => _darkSeries;
        set => SetProperty(ref _darkSeries, value);
    }

    public PaletteDemoViewModel()
    {
        LightSeries = new ObservableCollection<ColorSeries>();
        var lightResourceDictionary = (ResourceDictionary)(AvaloniaXamlLoader.Load(new Uri("avares://Semi.Avalonia/Themes/Light/Palette.axaml")));
        foreach (var color in _colors)
        {
            ColorSeries s = new ColorSeries();
            s.Initialize(lightResourceDictionary, color, true);
            LightSeries.Add(s);
        }
        DarkSeries = new ObservableCollection<ColorSeries>();
        var darkResouceDictionary = (ResourceDictionary)(AvaloniaXamlLoader.Load(new Uri("avares://Semi.Avalonia/Themes/Dark/Palette.axaml")));
        foreach (var color in _colors)
        {
            ColorSeries s = new ColorSeries();
            s.Initialize(darkResouceDictionary, color, false);
            DarkSeries.Add(s);
        }
        WeakReferenceMessenger.Default.Register<PaletteDemoViewModel, ColorItemViewModel>(this, OnClickColorItem);
    }

    private void OnClickColorItem(PaletteDemoViewModel vm, ColorItemViewModel item)
    {
        SelectedColor = item;
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
    
    internal void Initialize(IResourceDictionary resourceDictionary, string color, bool light)
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
                    var item = new ColorItemViewModel(name, brush, key, light, i);
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
    
    private IBrush _textColor;
    public IBrush TextColor
    {
        get => _textColor;
        set => SetProperty(ref _textColor, value);
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

    private string _hex;

    public string Hex
    {
        get => _hex;
        set => SetProperty(ref _hex, value);
    }
    
    public ColorItemViewModel(string name, IBrush color, string resourceKey, bool light, int index)
    {
        Name = name;
        Color = color;
        ResourceKey = resourceKey;
        Hex = color.ToString().ToUpperInvariant();
        if ((light && index < 5) || (!light && index > 5))
        {
            TextColor = Brushes.Black;
        }
        else
        {
            TextColor = Brushes.White;
        }
    }
}