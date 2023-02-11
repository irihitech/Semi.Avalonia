using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Semi.Avalonia.Demo.ViewModels;

public class PaletteDemoViewModel: ObservableObject
{
    private string[] _colors = { "Amber","Blue","Cyan","Green","Grey","Indigo","LightBlue","LightGreen","Lime","Orange","Pink","Purple","Red","Teal","Violet","Yellow" };
}

public class ColorSeries: ObservableObject
{
    internal void Initialize(IResourceDictionary resourceDictionary, string color)
    {
        
    }
}