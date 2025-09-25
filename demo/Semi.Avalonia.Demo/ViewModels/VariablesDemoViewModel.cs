using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using Semi.Avalonia.Tokens;

namespace Semi.Avalonia.Demo.ViewModels;

public partial class VariablesDemoViewModel : ObservableObject
{
    public DataGridCollectionView GridData { get; set; }
    [ObservableProperty] private string _searchText = string.Empty;

    public VariablesDemoViewModel()
    {
        IResourceDictionary dictionary = new Variables();
        foreach (var token in Tokens)
        {
            if (token.ResourceKey is not null && dictionary.TryGetValue(token.ResourceKey, out var value))
            {
                token.Type = value?.GetType();
                token.Value = GetValueString(value);
            }
        }

        GridData = new DataGridCollectionView(Tokens);
        GridData.GroupDescriptions.Add(new DataGridPathGroupDescription(nameof(VariableItem.Category)));
    }

    private static string? GetValueString(object? value)
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

    partial void OnSearchTextChanged(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            GridData.Filter = _ => true;
            GridData.Refresh();
            return;
        }

        var search = value.Trim();
        GridData.Filter = item =>
        {
            if (item is not VariableItem variableItem) return false;
            return (variableItem.Category?.Contains(search, StringComparison.InvariantCultureIgnoreCase) ?? false) ||
                   (variableItem.ResourceKey?.Contains(search, StringComparison.InvariantCultureIgnoreCase) ?? false) ||
                   (variableItem.Value?.Contains(search, StringComparison.InvariantCultureIgnoreCase) ?? false) ||
                   (variableItem.Type?.Name.Contains(search, StringComparison.InvariantCultureIgnoreCase) ?? false) ||
                   (variableItem.Description?.Contains(search, StringComparison.InvariantCultureIgnoreCase) ?? false);
        };
        GridData.Refresh();
    }

    private static List<VariableItem> Tokens { get; set; } =
    [
        new("Height", "SemiHeightControlSmall"),
        new("Height", "SemiHeightControlDefault"),
        new("Height", "SemiHeightControlLarge"),
        new("Icon Size", "SemiWidthIconExtraSmall"),
        new("Icon Size", "SemiWidthIconSmall"),
        new("Icon Size", "SemiWidthIconMedium"),
        new("Icon Size", "SemiWidthIconLarge"),
        new("Icon Size", "SemiWidthIconExtraLarge"),
        new("Border CornerRadius Spacing", "SemiBorderRadiusSpacingExtraSmall"),
        new("Border CornerRadius Spacing", "SemiBorderRadiusSpacingSmall"),
        new("Border CornerRadius Spacing", "SemiBorderRadiusSpacingMedium"),
        new("Border CornerRadius Spacing", "SemiBorderRadiusSpacingLarge"),
        new("Border CornerRadius Spacing", "SemiBorderRadiusSpacingFull"),
        new("Border CornerRadius", "SemiBorderRadiusExtraSmall"),
        new("Border CornerRadius", "SemiBorderRadiusSmall"),
        new("Border CornerRadius", "SemiBorderRadiusMedium"),
        new("Border CornerRadius", "SemiBorderRadiusLarge"),
        new("Border CornerRadius", "SemiBorderRadiusFull"),
        new("Border Spacing", "SemiBorderSpacing"),
        new("Border Spacing", "SemiBorderSpacingControl"),
        new("Border Spacing", "SemiBorderSpacingControlFocus"),
        new("Border Thickness", "SemiBorderThickness"),
        new("Border Thickness", "SemiBorderThicknessControl"),
        new("Border Thickness", "SemiBorderThicknessControlFocus"),
        new("Spacing", "SemiSpacingNone"),
        new("Spacing", "SemiSpacingSuperTight"),
        new("Spacing", "SemiSpacingExtraTight"),
        new("Spacing", "SemiSpacingTight"),
        new("Spacing", "SemiSpacingBaseTight"),
        new("Spacing", "SemiSpacingBase"),
        new("Spacing", "SemiSpacingBaseLoose"),
        new("Spacing", "SemiSpacingLoose"),
        new("Spacing", "SemiSpacingExtraLoose"),
        new("Spacing", "SemiSpacingSuperLoose"),
        new("Thickness", "SemiThicknessNone"),
        new("Thickness", "SemiThicknessSuperTight"),
        new("Thickness", "SemiThicknessExtraTight"),
        new("Thickness", "SemiThicknessTight"),
        new("Thickness", "SemiThicknessBaseTight"),
        new("Thickness", "SemiThicknessBase"),
        new("Thickness", "SemiThicknessBaseLoose"),
        new("Thickness", "SemiThicknessLoose"),
        new("Thickness", "SemiThicknessExtraLoose"),
        new("Thickness", "SemiThicknessSuperLoose"),
        new("FontSize", "SemiFontSizeSmall"),
        new("FontSize", "SemiFontSizeRegular"),
        new("FontSize", "SemiFontSizeHeader6"),
        new("FontSize", "SemiFontSizeHeader5"),
        new("FontSize", "SemiFontSizeHeader4"),
        new("FontSize", "SemiFontSizeHeader3"),
        new("FontSize", "SemiFontSizeHeader2"),
        new("FontSize", "SemiFontSizeHeader1"),
        new("FontWeight", "SemiFontWeightLight"),
        new("FontWeight", "SemiFontWeightRegular"),
        new("FontWeight", "SemiFontWeightBold"),
        new("FontFamily", "SemiFontFamilyRegular"),
    ];
}

public class VariableItem()
{
    public string? Category { get; set; }
    public string? ResourceKey { get; set; }
    public Type? Type { get; set; }
    public string? Value { get; set; }
    public string? Description { get; set; }

    public VariableItem(string category, string resourceKey, string description = "") : this()
    {
        Category = category;
        ResourceKey = resourceKey;
        Description = description;
    }

    public string CopyText =>
        $"""
         <StaticResource x:Key="" ResourceKey="{ResourceKey}" />
         """;
}