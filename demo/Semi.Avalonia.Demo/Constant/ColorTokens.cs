using System;
using System.Collections.Generic;

namespace Semi.Avalonia.Demo.Constant;

public static class ColorTokens
{
    public static IReadOnlyList<Tuple<string, string>> PrimaryTokens { get; } = new List<Tuple<string, string>>
    {
        new("SemiColorPrimary", "Primary"),
        new("SemiColorPrimaryPointerover", "Primary Pointerover"),
        new("SemiColorPrimaryActive", "Primary Active"),
        new("SemiColorPrimaryDisabled", "Primary Disabled"),
        new("SemiColorPrimaryLight", "Primary Light"),
        new("SemiColorPrimaryLightPointerover", "Primary Light Pointerover"),
        new("SemiColorPrimaryLightActive", "Primary Light Active"),
    };

    public static IReadOnlyList<Tuple<string, string>> SecondaryTokens { get; } = new List<Tuple<string, string>>
    {
        new("SemiColorSecondary", "Secondary"),
        new("SemiColorSecondaryPointerover", "Secondary Pointerover"),
        new("SemiColorSecondaryActive", "Secondary Active"),
        new("SemiColorSecondaryDisabled", "Secondary Disabled"),
        new("SemiColorSecondaryLight", "Secondary Light"),
        new("SemiColorSecondaryLightPointerover", "Secondary Light Pointerover"),
        new("SemiColorSecondaryLightActive", "Secondary Light Active"),
    };

    public static IReadOnlyList<Tuple<string, string>> TertiaryTokens { get; } = new List<Tuple<string, string>>
    {
        new("SemiColorTertiary", "Tertiary"),
        new("SemiColorTertiaryPointerover", "Tertiary Pointerover"),
        new("SemiColorTertiaryActive", "Tertiary Active"),
        new("SemiColorTertiaryLight", "Tertiary Light"),
        new("SemiColorTertiaryLightPointerover", "Tertiary Light Pointerover"),
        new("SemiColorTertiaryLightActive", "Tertiary Light Active"),
    };

    public static IReadOnlyList<Tuple<string, string>> InformationTokens { get; } = new List<Tuple<string, string>>
    {
        new("SemiColorInformation", "Information"),
        new("SemiColorInformationPointerover", "Information Pointerover"),
        new("SemiColorInformationActive", "Information Active"),
        new("SemiColorInformationDisabled", "Information Disabled"),
        new("SemiColorInformationLight", "Information Light"),
        new("SemiColorInformationLightPointerover", "Information Light Pointerover"),
        new("SemiColorInformationLightActive", "Information Light Active"),
    };

    public static IReadOnlyList<Tuple<string, string>> SuccessTokens { get; } = new List<Tuple<string, string>>
    {
        new("SemiColorSuccess", "Success"),
        new("SemiColorSuccessPointerover", "Success Pointerover"),
        new("SemiColorSuccessActive", "Success Active"),
        new("SemiColorSuccessDisabled", "Success Disabled"),
        new("SemiColorSuccessLight", "Success Light"),
        new("SemiColorSuccessLightPointerover", "Success Light Pointerover"),
        new("SemiColorSuccessLightActive", "Success Light Active"),
    };

    public static IReadOnlyList<Tuple<string, string>> WarningTokens { get; } = new List<Tuple<string, string>>
    {
        new("SemiColorWarning", "Warning"),
        new("SemiColorWarningPointerover", "Warning Pointerover"),
        new("SemiColorWarningActive", "Warning Active"),
        new("SemiColorWarningLight", "Warning Light"),
        new("SemiColorWarningLightPointerover", "Warning Light Pointerover"),
        new("SemiColorWarningLightActive", "Warning Light Active"),
    };

    public static IReadOnlyList<Tuple<string, string>> DangerTokens { get; } = new List<Tuple<string, string>>
    {
        new("SemiColorDanger", "Danger"),
        new("SemiColorDangerPointerover", "Danger Pointerover"),
        new("SemiColorDangerActive", "Danger Active"),
        new("SemiColorDangerLight", "Danger Light"),
        new("SemiColorDangerLightPointerover", "Danger Light Pointerover"),
        new("SemiColorDangerLightActive", "Danger Light Active"),
    };

    public static IReadOnlyList<Tuple<string, string>> TextTokens { get; } = new List<Tuple<string, string>>
    {
        new("SemiColorText0", "Text 0"),
        new("SemiColorText1", "Text 1"),
        new("SemiColorText2", "Text 2"),
        new("SemiColorText3", "Text 3"),
    };

    public static IReadOnlyList<Tuple<string, string>> LinkTokens { get; } = new List<Tuple<string, string>>
    {
        new("SemiColorLink", "Link"),
        new("SemiColorLinkPointerover", "Link Pointerover"),
        new("SemiColorLinkActive", "Link Active"),
        new("SemiColorLinkVisited", "Link Visited"),
    };

    public static IReadOnlyList<Tuple<string, string>> BackgroundTokens { get; } = new List<Tuple<string, string>>
    {
        new("SemiColorBackground0", "Background 0"),
        new("SemiColorBackground1", "Background 1"),
        new("SemiColorBackground2", "Background 2"),
        new("SemiColorBackground3", "Background 3"),
        new("SemiColorBackground4", "Background 4"),
    };

    public static IReadOnlyList<Tuple<string, string>> FillTokens { get; } = new List<Tuple<string, string>>
    {
        new("SemiColorFill0", "Fill 0"),
        new("SemiColorFill1", "Fill 1"),
        new("SemiColorFill2", "Fill 2"),
    };

    public static IReadOnlyList<Tuple<string, string>> BorderTokens { get; } = new List<Tuple<string, string>>
    {
        new("SemiColorBorder", "Border"),
    };

    public static IReadOnlyList<Tuple<string, string>> DisabledTokens { get; } = new List<Tuple<string, string>>
    {
        new("SemiColorDisabledText", "Disabled Text"),
        new("SemiColorDisabledBorder", "Disabled Border"),
        new("SemiColorDisabledBackground", "Disabled Background"),
        new("SemiColorDisabledFill", "Disabled Fill"),
    };

    public static IReadOnlyList<Tuple<string, string>> ShadowTokens { get; } = new List<Tuple<string, string>>
    {
        new("SemiColorShadow", "Shadow"),
        new("SemiShadowElevated", "Shadow Elevated"),
    };

    public static IReadOnlyList<Tuple<string, string>> HeightTokens { get; } = new List<Tuple<string, string>>
    {
        new("SemiHeightControlSmall", ""),
        new("SemiHeightControlDefault", ""),
        new("SemiHeightControlLarge", ""),
    };

    public static IReadOnlyList<Tuple<string, string>> IconSizeTokens { get; } = new List<Tuple<string, string>>
    {
        new("SemiWidthIconExtraSmall", ""),
        new("SemiWidthIconSmall", ""),
        new("SemiWidthIconMedium", ""),
        new("SemiWidthIconLarge", ""),
        new("SemiWidthIconExtraLarge", ""),
    };

    public static IReadOnlyList<Tuple<string, string>> CornerRadiusTokens { get; } = new List<Tuple<string, string>>
    {
        new("SemiBorderRadiusExtraSmall", ""),
        new("SemiBorderRadiusSmall", ""),
        new("SemiBorderRadiusMedium", ""),
        new("SemiBorderRadiusLarge", ""),
        new("SemiBorderRadiusFull", ""),
    };

    public static IReadOnlyList<Tuple<string, string>> BorderSpacingTokens { get; } = new List<Tuple<string, string>>
    {
        new("SemiBorderSpacing", ""),
        new("SemiBorderSpacingControl", ""),
        new("SemiBorderSpacingControlFocus", ""),
    };

    public static IReadOnlyList<Tuple<string, string>> BorderThicknessTokens { get; } = new List<Tuple<string, string>>
    {
        new("SemiBorderThickness", ""),
        new("SemiBorderThicknessControl", ""),
        new("SemiBorderThicknessControlFocus", ""),
    };

    public static IReadOnlyList<Tuple<string, string>> SpacingTokens { get; } = new List<Tuple<string, string>>
    {
        new("SemiSpacingNone", ""),
        new("SemiSpacingSuperTight", ""),
        new("SemiSpacingExtraTight", ""),
        new("SemiSpacingTight", ""),
        new("SemiSpacingBaseTight", ""),
        new("SemiSpacingBase", ""),
        new("SemiSpacingBaseLoose", ""),
        new("SemiSpacingLoose", ""),
        new("SemiSpacingExtraLoose", ""),
        new("SemiSpacingSuperLoose", ""),
    };

    public static IReadOnlyList<Tuple<string, string>> ThicknessTokens { get; } = new List<Tuple<string, string>>
    {
        new("SemiThicknessNone", ""),
        new("SemiThicknessSuperTight", ""),
        new("SemiThicknessExtraTight", ""),
        new("SemiThicknessTight", ""),
        new("SemiThicknessBaseTight", ""),
        new("SemiThicknessBase", ""),
        new("SemiThicknessBaseLoose", ""),
        new("SemiThicknessLoose", ""),
        new("SemiThicknessExtraLoose", ""),
        new("SemiThicknessSuperLoose", ""),
    };

    public static IReadOnlyList<Tuple<string, string>> FontSizeTokens { get; } = new List<Tuple<string, string>>
    {
        new("SemiFontSizeSmall", ""),
        new("SemiFontSizeRegular", ""),
        new("SemiFontSizeHeader6", ""),
        new("SemiFontSizeHeader5", ""),
        new("SemiFontSizeHeader4", ""),
        new("SemiFontSizeHeader3", ""),
        new("SemiFontSizeHeader2", ""),
        new("SemiFontSizeHeader1", ""),
    };

    public static IReadOnlyList<Tuple<string, string>> FontWeightTokens { get; } = new List<Tuple<string, string>>
    {
        new("SemiFontWeightLight", ""),
        new("SemiFontWeightRegular", ""),
        new("SemiFontWeightBold", ""),
    };

    public static IReadOnlyList<Tuple<string, string>> FontFamilyTokens { get; } = new List<Tuple<string, string>>
    {
        new("SemiFontFamilyRegular", ""),
    };
}