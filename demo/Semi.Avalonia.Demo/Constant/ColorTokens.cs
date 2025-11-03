using System;
using System.Collections.Generic;

namespace Semi.Avalonia.Demo.Constant;

public static class ColorTokens
{
    public static IReadOnlyList<Tuple<string, string>> PrimaryTokens { get; } =
    [
        new("SemiColorPrimary", "Primary"),
        new("SemiColorPrimaryPointerover", "Primary Pointerover"),
        new("SemiColorPrimaryActive", "Primary Active"),
        new("SemiColorPrimaryDisabled", "Primary Disabled"),
        new("SemiColorPrimaryLight", "Primary Light"),
        new("SemiColorPrimaryLightPointerover", "Primary Light Pointerover"),
        new("SemiColorPrimaryLightActive", "Primary Light Active"),
    ];

    public static IReadOnlyList<Tuple<string, string>> SecondaryTokens { get; } =
    [
        new("SemiColorSecondary", "Secondary"),
        new("SemiColorSecondaryPointerover", "Secondary Pointerover"),
        new("SemiColorSecondaryActive", "Secondary Active"),
        new("SemiColorSecondaryDisabled", "Secondary Disabled"),
        new("SemiColorSecondaryLight", "Secondary Light"),
        new("SemiColorSecondaryLightPointerover", "Secondary Light Pointerover"),
        new("SemiColorSecondaryLightActive", "Secondary Light Active")
    ];

    public static IReadOnlyList<Tuple<string, string>> TertiaryTokens { get; } =
    [
        new("SemiColorTertiary", "Tertiary"),
        new("SemiColorTertiaryPointerover", "Tertiary Pointerover"),
        new("SemiColorTertiaryActive", "Tertiary Active"),
        new("SemiColorTertiaryLight", "Tertiary Light"),
        new("SemiColorTertiaryLightPointerover", "Tertiary Light Pointerover"),
        new("SemiColorTertiaryLightActive", "Tertiary Light Active")
    ];

    public static IReadOnlyList<Tuple<string, string>> InformationTokens { get; } =
    [
        new("SemiColorInformation", "Information"),
        new("SemiColorInformationPointerover", "Information Pointerover"),
        new("SemiColorInformationActive", "Information Active"),
        new("SemiColorInformationDisabled", "Information Disabled"),
        new("SemiColorInformationLight", "Information Light"),
        new("SemiColorInformationLightPointerover", "Information Light Pointerover"),
        new("SemiColorInformationLightActive", "Information Light Active")
    ];

    public static IReadOnlyList<Tuple<string, string>> SuccessTokens { get; } =
    [
        new("SemiColorSuccess", "Success"),
        new("SemiColorSuccessPointerover", "Success Pointerover"),
        new("SemiColorSuccessActive", "Success Active"),
        new("SemiColorSuccessDisabled", "Success Disabled"),
        new("SemiColorSuccessLight", "Success Light"),
        new("SemiColorSuccessLightPointerover", "Success Light Pointerover"),
        new("SemiColorSuccessLightActive", "Success Light Active")
    ];

    public static IReadOnlyList<Tuple<string, string>> WarningTokens { get; } =
    [
        new("SemiColorWarning", "Warning"),
        new("SemiColorWarningPointerover", "Warning Pointerover"),
        new("SemiColorWarningActive", "Warning Active"),
        new("SemiColorWarningLight", "Warning Light"),
        new("SemiColorWarningLightPointerover", "Warning Light Pointerover"),
        new("SemiColorWarningLightActive", "Warning Light Active")
    ];

    public static IReadOnlyList<Tuple<string, string>> DangerTokens { get; } =
    [
        new("SemiColorDanger", "Danger"),
        new("SemiColorDangerPointerover", "Danger Pointerover"),
        new("SemiColorDangerActive", "Danger Active"),
        new("SemiColorDangerLight", "Danger Light"),
        new("SemiColorDangerLightPointerover", "Danger Light Pointerover"),
        new("SemiColorDangerLightActive", "Danger Light Active")
    ];

    public static IReadOnlyList<Tuple<string, string>> AIGeneralTokens { get; } =
    [
        new("SemiColorAIGeneral", "AI General"),
        new("SemiColorAIGeneralPointerover", "AI General Pointerover"),
        new("SemiColorAIGeneralActive", "AI General Active"),
        new("SemiColorAIGeneralDisabled", "AI General Disabled")
    ];

    public static IReadOnlyList<Tuple<string, string>> AIPurpleTokens { get; } =
    [
        new("SemiColorAIPurple", "AI Purple"),
        new("SemiColorAIPurplePointerover", "AI Purple Pointerover"),
        new("SemiColorAIPurpleActive", "AI Purple Active"),
        new("SemiColorAIPurpleDisabled", "AI Purple Disabled")
    ];

    public static IReadOnlyList<Tuple<string, string>> AIBackgroundTokens { get; } =
    [
        new("SemiColorAIBackgroundBottom", "AI Bottom Background"),
        new("SemiColorAIBackgroundBottomPointerover", "AI Bottom Background Pointerover"),
        new("SemiColorAIBackgroundBottomActive", "AI Bottom Background Active"),
        new("SemiColorAIBackgroundTop", "AI Top Background"),
        new("SemiColorAIBackgroundTopPointerover", "AI Top Background Pointerover"),
        new("SemiColorAIBackgroundTopActive", "AI Top Background Active"),
    ];

    public static IReadOnlyList<Tuple<string, string>> TextTokens { get; } =
    [
        new("SemiColorText0", "Text 0"),
        new("SemiColorText1", "Text 1"),
        new("SemiColorText2", "Text 2"),
        new("SemiColorText3", "Text 3")
    ];

    public static IReadOnlyList<Tuple<string, string>> LinkTokens { get; } =
    [
        new("SemiColorLink", "Link"),
        new("SemiColorLinkPointerover", "Link Pointerover"),
        new("SemiColorLinkActive", "Link Active"),
        new("SemiColorLinkVisited", "Link Visited")
    ];

    public static IReadOnlyList<Tuple<string, string>> BackgroundTokens { get; } =
    [
        new("SemiColorBackground0", "Background 0"),
        new("SemiColorBackground1", "Background 1"),
        new("SemiColorBackground2", "Background 2"),
        new("SemiColorBackground3", "Background 3"),
        new("SemiColorBackground4", "Background 4")
    ];

    public static IReadOnlyList<Tuple<string, string>> FillTokens { get; } =
    [
        new("SemiColorFill0", "Fill 0"),
        new("SemiColorFill1", "Fill 1"),
        new("SemiColorFill2", "Fill 2")
    ];

    public static IReadOnlyList<Tuple<string, string>> BorderTokens { get; } =
    [
        new("SemiColorBorder", "Border"),
        new("SemiColorFocusBorder", "Focus Border")
    ];

    public static IReadOnlyList<Tuple<string, string>> DisabledTokens { get; } =
    [
        new("SemiColorDisabledText", "Disabled Text"),
        new("SemiColorDisabledBorder", "Disabled Border"),
        new("SemiColorDisabledBackground", "Disabled Background"),
        new("SemiColorDisabledFill", "Disabled Fill")
    ];

    public static IReadOnlyList<Tuple<string, string>> OtherTokens { get; } =
    [
        new("SemiColorWhite", "White"),
        new("SemiColorBlack", "Black"),
        new("SemiColorNavBackground", "Navigation Background"),
        new("SemiColorOverlayBackground", "Overlay Background"),
        new("SemiColorHighlightBackground", "Highlight Background"),
        new("SemiColorHighlight", "Highlight Text")
    ];

    public static IReadOnlyList<Tuple<string, string>> ShadowTokens { get; } =
    [
        new("SemiColorShadow", "Shadow"),
        new("SemiShadowElevated", "Shadow Elevated")
    ];
}