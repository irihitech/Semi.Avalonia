using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using Semi.Avalonia.Demo.Constant;
using Semi.Avalonia.Tokens;

namespace Semi.Avalonia.Demo.ViewModels;

public partial class VariablesDemoViewModel : ObservableObject
{
    private readonly IResourceDictionary? _dictionary;
    public ObservableCollection<VariableGridViewModel> VariableGrid { get; set; } = [];

    public VariablesDemoViewModel()
    {
        _dictionary = new Variables();
    }

    public void InitializeResources()
    {
        VariableGrid.Add(new VariableGridViewModel("Height", _dictionary, ColorTokens.HeightTokens));
        VariableGrid.Add(new VariableGridViewModel("Icon Size", _dictionary, ColorTokens.IconSizeTokens));
        VariableGrid.Add(new VariableGridViewModel("Border CornerRadius", _dictionary, ColorTokens.CornerRadiusTokens));
        VariableGrid.Add(new VariableGridViewModel("Border Spacing", _dictionary, ColorTokens.BorderSpacingTokens));
        VariableGrid.Add(new VariableGridViewModel("Border Thickness", _dictionary, ColorTokens.BorderThicknessTokens));
        VariableGrid.Add(new VariableGridViewModel("Spacing", _dictionary, ColorTokens.SpacingTokens));
        VariableGrid.Add(new VariableGridViewModel("Thickness", _dictionary, ColorTokens.ThicknessTokens));
        VariableGrid.Add(new VariableGridViewModel("FontSize", _dictionary, ColorTokens.FontSizeTokens));
        VariableGrid.Add(new VariableGridViewModel("FontWeight", _dictionary, ColorTokens.FontWeightTokens));
        VariableGrid.Add(new VariableGridViewModel("FontFamily", _dictionary, ColorTokens.FontFamilyTokens));
    }
}

public partial class VariableGridViewModel : ObservableObject
{
    [ObservableProperty] private string? _title;
    public ObservableCollection<VariableItemViewModel> VariableItems { get; set; } = [];

    public VariableGridViewModel(string title, IResourceDictionary? dictionary,
        IReadOnlyList<Tuple<string, string>> tokens)
    {
        Title = title;
        foreach (var (key, name) in tokens)
        {
            if (dictionary?.TryGetValue(key, out var value) ?? false)
            {
                VariableItems.Add(new VariableItemViewModel(name, GetValueString(value), key));
            }
        }
    }

    private static string GetValueString(object? value)
    {
        if (value is null) return string.Empty;

        return value switch
        {
            double d => d.ToString(CultureInfo.InvariantCulture),
            CornerRadius c => c.IsUniform ? $"{c.TopLeft}" : c.ToString(),
            Thickness t => t.IsUniform ? $"{t.Left}" : t.ToString(),
            FontWeight fontWeight => Convert.ToInt32(fontWeight).ToString(),
            FontFamily fontFamily => fontFamily.FamilyNames.ToString(),
            _ => value.ToString()
        };
    }
}

public partial class VariableItemViewModel : ObservableObject
{
    [ObservableProperty] private string? _resourceKey;
    [ObservableProperty] private string? _description;
    [ObservableProperty] private string? _value;

    public string CopyText =>
        $"""
         <StaticResource x:Key="" ResourceKey="{ResourceKey}" />
         """;

    public VariableItemViewModel(string description, object value, string resourceKey)
    {
        ResourceKey = resourceKey;
        Description = description;
        Value = value.ToString();
    }
}