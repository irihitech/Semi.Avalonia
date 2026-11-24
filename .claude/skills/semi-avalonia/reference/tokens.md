# Semi.Avalonia tokens

Every resource key of the theme, extracted from the sources of version 12.1.0.2. Use the key with `DynamicResource`, or the `SemiTokens` member with `x:Static` — a mistyped member fails at build time.

```xml
<Border Background="{DynamicResource SemiColorPrimary}" />
<Border Background="{DynamicResource {x:Static semi:SemiTokens.ColorPrimary}}" />
```


## Sizing

| Resource key | SemiTokens member | Type | Value | Description (zh) |
|---|---|---|---|---|
| `SemiHeightControlSmall` | `SemiTokens.HeightControlSmall` | Double | 24 | 表单项高度 - 小尺寸 |
| `SemiHeightControlDefault` | `SemiTokens.HeightControlDefault` | Double | 32 | 表单项高度 - 默认尺寸 |
| `SemiHeightControlLarge` | `SemiTokens.HeightControlLarge` | Double | 40 | 表单项高度 - 大尺寸 |
| `SemiWidthIconExtraSmall` | `SemiTokens.WidthIconExtraSmall` | Double | 8 | 图标尺寸 - 超小 |
| `SemiWidthIconSmall` | `SemiTokens.WidthIconSmall` | Double | 12 | 图标尺寸 - 小 |
| `SemiWidthIconMedium` | `SemiTokens.WidthIconMedium` | Double | 16 | 图标尺寸 - 中 |
| `SemiWidthIconLarge` | `SemiTokens.WidthIconLarge` | Double | 20 | 图标尺寸 - 大 |
| `SemiWidthIconExtraLarge` | `SemiTokens.WidthIconExtraLarge` | Double | 24 | 图标尺寸 - 超大 |

## Border

| Resource key | SemiTokens member | Type | Value | Description (zh) |
|---|---|---|---|---|
| `SemiBorderSpacing` | `SemiTokens.BorderSpacing` | Double | 0 | 描边间距 - 零 |
| `SemiBorderSpacingControl` | `SemiTokens.BorderSpacingControl` | Double | 1 | 描边间距 - 默认状态 |
| `SemiBorderSpacingControlFocus` | `SemiTokens.BorderSpacingControlFocus` | Double | 1 | 描边间距 - focus 状态 |
| `SemiBorderThickness` | `SemiTokens.BorderThickness` | Thickness | 0 | 描边宽度 - 零 |
| `SemiBorderThicknessControl` | `SemiTokens.BorderThicknessControl` | Thickness | 1 | 描边宽度 - 默认状态 |
| `SemiBorderThicknessControlFocus` | `SemiTokens.BorderThicknessControlFocus` | Thickness | 1 | 描边宽度 - focus 状态 |
| `SemiBorderRadiusSpacingExtraSmall` | `SemiTokens.BorderRadiusSpacingExtraSmall` | Double | 3 | 半径 - 超小 |
| `SemiBorderRadiusSpacingSmall` | `SemiTokens.BorderRadiusSpacingSmall` | Double | 3 | 半径 - 小 |
| `SemiBorderRadiusSpacingMedium` | `SemiTokens.BorderRadiusSpacingMedium` | Double | 6 | 半径 - 中 |
| `SemiBorderRadiusSpacingLarge` | `SemiTokens.BorderRadiusSpacingLarge` | Double | 12 | 半径 - 大 |
| `SemiBorderRadiusSpacingFull` | `SemiTokens.BorderRadiusSpacingFull` | Double | 9999 | 半径 - 全圆 |
| `SemiBorderRadiusExtraSmall` | `SemiTokens.BorderRadiusExtraSmall` | CornerRadius | 3 | 圆角 - 超小 |
| `SemiBorderRadiusSmall` | `SemiTokens.BorderRadiusSmall` | CornerRadius | 3 | 圆角 - 小 |
| `SemiBorderRadiusMedium` | `SemiTokens.BorderRadiusMedium` | CornerRadius | 6 | 圆角 - 中 |
| `SemiBorderRadiusLarge` | `SemiTokens.BorderRadiusLarge` | CornerRadius | 12 | 圆角 - 大 |
| `SemiBorderRadiusFull` | `SemiTokens.BorderRadiusFull` | CornerRadius | 9999 | 圆角 - 全圆 |

## Spacing

| Resource key | SemiTokens member | Type | Value | Description (zh) |
|---|---|---|---|---|
| `SemiSpacingNone` | `SemiTokens.SpacingNone` | Double | 0 | 间距 - 零 |
| `SemiSpacingSuperTight` | `SemiTokens.SpacingSuperTight` | Double | 2 | 间距 - 极紧凑 |
| `SemiSpacingExtraTight` | `SemiTokens.SpacingExtraTight` | Double | 4 | 间距 - 超紧凑 |
| `SemiSpacingTight` | `SemiTokens.SpacingTight` | Double | 8 | 间距 - 紧凑 |
| `SemiSpacingBaseTight` | `SemiTokens.SpacingBaseTight` | Double | 12 | 间距 - 偏紧凑 |
| `SemiSpacingBase` | `SemiTokens.SpacingBase` | Double | 16 | 间距 - 默认 |
| `SemiSpacingBaseLoose` | `SemiTokens.SpacingBaseLoose` | Double | 20 | 间距 - 偏宽松 |
| `SemiSpacingLoose` | `SemiTokens.SpacingLoose` | Double | 24 | 间距 - 宽松 |
| `SemiSpacingExtraLoose` | `SemiTokens.SpacingExtraLoose` | Double | 32 | 间距 - 超宽松 |
| `SemiSpacingSuperLoose` | `SemiTokens.SpacingSuperLoose` | Double | 40 | 间距 - 极宽松 |

## Thickness

| Resource key | SemiTokens member | Type | Value | Description (zh) |
|---|---|---|---|---|
| `SemiThicknessNone` | `SemiTokens.ThicknessNone` | Thickness | 0 | 宽度 - 零 |
| `SemiThicknessSuperTight` | `SemiTokens.ThicknessSuperTight` | Thickness | 2 | 宽度 - 极紧凑 |
| `SemiThicknessExtraTight` | `SemiTokens.ThicknessExtraTight` | Thickness | 4 | 宽度 - 超紧凑 |
| `SemiThicknessTight` | `SemiTokens.ThicknessTight` | Thickness | 8 | 宽度 - 紧凑 |
| `SemiThicknessBaseTight` | `SemiTokens.ThicknessBaseTight` | Thickness | 12 | 宽度 - 偏紧凑 |
| `SemiThicknessBase` | `SemiTokens.ThicknessBase` | Thickness | 16 | 宽度 - 默认 |
| `SemiThicknessBaseLoose` | `SemiTokens.ThicknessBaseLoose` | Thickness | 20 | 宽度 - 偏宽松 |
| `SemiThicknessLoose` | `SemiTokens.ThicknessLoose` | Thickness | 24 | 宽度 - 宽松 |
| `SemiThicknessExtraLoose` | `SemiTokens.ThicknessExtraLoose` | Thickness | 32 | 宽度 - 超宽松 |
| `SemiThicknessSuperLoose` | `SemiTokens.ThicknessSuperLoose` | Thickness | 40 | 宽度 - 极宽松 |

## Font

| Resource key | SemiTokens member | Type | Value | Description (zh) |
|---|---|---|---|---|
| `SemiFontSizeSmall` | `SemiTokens.FontSizeSmall` | Double | 12 | 小文本字号 |
| `SemiFontSizeRegular` | `SemiTokens.FontSizeRegular` | Double | 14 | 常规文本字号 |
| `SemiFontSizeHeader6` | `SemiTokens.FontSizeHeader6` | Double | 16 | 六级标题字号 |
| `SemiFontSizeHeader5` | `SemiTokens.FontSizeHeader5` | Double | 18 | 五级标题字号 |
| `SemiFontSizeHeader4` | `SemiTokens.FontSizeHeader4` | Double | 20 | 四级标题字号 |
| `SemiFontSizeHeader3` | `SemiTokens.FontSizeHeader3` | Double | 24 | 三级标题字号 |
| `SemiFontSizeHeader2` | `SemiTokens.FontSizeHeader2` | Double | 28 | 二级标题字号 |
| `SemiFontSizeHeader1` | `SemiTokens.FontSizeHeader1` | Double | 32 | 一级标题字号 |
| `SemiFontWeightLight` | `SemiTokens.FontWeightLight` | FontWeight | 200 | 字重 - 轻 |
| `SemiFontWeightRegular` | `SemiTokens.FontWeightRegular` | FontWeight | 400 | 字重 - 常规 |
| `SemiFontWeightBold` | `SemiTokens.FontWeightBold` | FontWeight | 600 | 字重 - 粗 |
| `SemiFontFamilyRegular` | `SemiTokens.FontFamilyRegular` | FontFamily | fonts:Inter#Inter, Inter, -apple-system, BlinkMacSystemFont, PingFang SC, |  |

## Color

| Resource key | SemiTokens member | Type | Value | Description (zh) |
|---|---|---|---|---|
| `SemiColorWhite` | `SemiTokens.ColorWhite` | Brush | White |  |
| `SemiColorBlack` | `SemiTokens.ColorBlack` | Brush | Black |  |
| `SemiColorPrimary` | `SemiTokens.ColorPrimary` | Brush | #0064FA |  |
| `SemiColorPrimaryPointerover` | `SemiTokens.ColorPrimaryPointerover` | Brush | #0062D6 |  |
| `SemiColorPrimaryActive` | `SemiTokens.ColorPrimaryActive` | Brush | #004FB3 |  |
| `SemiColorPrimaryDisabled` | `SemiTokens.ColorPrimaryDisabled` | Brush | #98CDFD |  |
| `SemiColorPrimaryLight` | `SemiTokens.ColorPrimaryLight` | Brush | #EAF5FF |  |
| `SemiColorPrimaryLightPointerover` | `SemiTokens.ColorPrimaryLightPointerover` | Brush | #CBE7FE |  |
| `SemiColorPrimaryLightActive` | `SemiTokens.ColorPrimaryLightActive` | Brush | #98CDFD |  |
| `SemiColorSecondary` | `SemiTokens.ColorSecondary` | Brush | #0095EE |  |
| `SemiColorSecondaryPointerover` | `SemiTokens.ColorSecondaryPointerover` | Brush | #007BCA |  |
| `SemiColorSecondaryActive` | `SemiTokens.ColorSecondaryActive` | Brush | #0063A7 |  |
| `SemiColorSecondaryDisabled` | `SemiTokens.ColorSecondaryDisabled` | Brush | #95D8F8 |  |
| `SemiColorSecondaryLight` | `SemiTokens.ColorSecondaryLight` | Brush | #E9F7FD |  |
| `SemiColorSecondaryLightPointerover` | `SemiTokens.ColorSecondaryLightPointerover` | Brush | #C9ECFC |  |
| `SemiColorSecondaryLightActive` | `SemiTokens.ColorSecondaryLightActive` | Brush | #95D8F8 |  |
| `SemiColorTertiary` | `SemiTokens.ColorTertiary` | Brush | #6B7075 |  |
| `SemiColorTertiaryPointerover` | `SemiTokens.ColorTertiaryPointerover` | Brush | #555B61 |  |
| `SemiColorTertiaryActive` | `SemiTokens.ColorTertiaryActive` | Brush | #41464C |  |
| `SemiColorTertiaryLight` | `SemiTokens.ColorTertiaryLight` | Brush | #F9F9F9 |  |
| `SemiColorTertiaryLightPointerover` | `SemiTokens.ColorTertiaryLightPointerover` | Brush | #E6E8EA |  |
| `SemiColorTertiaryLightActive` | `SemiTokens.ColorTertiaryLightActive` | Brush | #C6CACD |  |
| `SemiColorDanger` | `SemiTokens.ColorDanger` | Brush | #F93920 |  |
| `SemiColorDangerPointerover` | `SemiTokens.ColorDangerPointerover` | Brush | #D52515 |  |
| `SemiColorDangerActive` | `SemiTokens.ColorDangerActive` | Brush | #B2140C |  |
| `SemiColorDangerLight` | `SemiTokens.ColorDangerLight` | Brush | #FEF2ED |  |
| `SemiColorDangerLightPointerover` | `SemiTokens.ColorDangerLightPointerover` | Brush | #FEDDD2 |  |
| `SemiColorDangerLightActive` | `SemiTokens.ColorDangerLightActive` | Brush | #FDB7A5 |  |
| `SemiColorWarning` | `SemiTokens.ColorWarning` | Brush | #FC8800 |  |
| `SemiColorWarningPointerover` | `SemiTokens.ColorWarningPointerover` | Brush | #D26700 |  |
| `SemiColorWarningActive` | `SemiTokens.ColorWarningActive` | Brush | #A84A00 |  |
| `SemiColorWarningLight` | `SemiTokens.ColorWarningLight` | Brush | #FFF8EA |  |
| `SemiColorWarningLightPointerover` | `SemiTokens.ColorWarningLightPointerover` | Brush | #FEEECC |  |
| `SemiColorWarningLightActive` | `SemiTokens.ColorWarningLightActive` | Brush | #FED998 |  |
| `SemiColorSuccess` | `SemiTokens.ColorSuccess` | Brush | #3BB346 |  |
| `SemiColorSuccessPointerover` | `SemiTokens.ColorSuccessPointerover` | Brush | #30953B |  |
| `SemiColorSuccessActive` | `SemiTokens.ColorSuccessActive` | Brush | #25772F |  |
| `SemiColorSuccessDisabled` | `SemiTokens.ColorSuccessDisabled` | Brush | #A4E0A7 |  |
| `SemiColorSuccessLight` | `SemiTokens.ColorSuccessLight` | Brush | #ECF7EC |  |
| `SemiColorSuccessLightPointerover` | `SemiTokens.ColorSuccessLightPointerover` | Brush | #D0F0D1 |  |
| `SemiColorSuccessLightActive` | `SemiTokens.ColorSuccessLightActive` | Brush | #A4E0A7 |  |
| `SemiColorInformation` | `SemiTokens.ColorInformation` | Brush | #0064FA |  |
| `SemiColorInformationPointerover` | `SemiTokens.ColorInformationPointerover` | Brush | #0062D6 |  |
| `SemiColorInformationActive` | `SemiTokens.ColorInformationActive` | Brush | #004FB3 |  |
| `SemiColorInformationDisabled` | `SemiTokens.ColorInformationDisabled` | Brush | #98CDFD |  |
| `SemiColorInformationLight` | `SemiTokens.ColorInformationLight` | Brush | #EAF5FF |  |
| `SemiColorInformationLightPointerover` | `SemiTokens.ColorInformationLightPointerover` | Brush | #CBE7FE |  |
| `SemiColorInformationLightActive` | `SemiTokens.ColorInformationLightActive` | Brush | #98CDFD |  |
| `SemiColorText0` | `SemiTokens.ColorText0` | Brush | #1C1F23 |  |
| `SemiColorText1` | `SemiTokens.ColorText1` | Brush | ref:SemiGrey9Color @ 0.8 opacity |  |
| `SemiColorText2` | `SemiTokens.ColorText2` | Brush | ref:SemiGrey9Color @ 0.62 opacity |  |
| `SemiColorText3` | `SemiTokens.ColorText3` | Brush | ref:SemiGrey9Color @ 0.35 opacity |  |
| `SemiColorBackground0` | `SemiTokens.ColorBackground0` | Brush | White |  |
| `SemiColorBackground1` | `SemiTokens.ColorBackground1` | Brush | White |  |
| `SemiColorBackground2` | `SemiTokens.ColorBackground2` | Brush | White |  |
| `SemiColorBackground3` | `SemiTokens.ColorBackground3` | Brush | White |  |
| `SemiColorBackground4` | `SemiTokens.ColorBackground4` | Brush | White |  |
| `SemiColorFill0` | `SemiTokens.ColorFill0` | Brush | ref:SemiGrey8Color @ 0.05 opacity |  |
| `SemiColorFill1` | `SemiTokens.ColorFill1` | Brush | ref:SemiGrey8Color @ 0.09 opacity |  |
| `SemiColorFill2` | `SemiTokens.ColorFill2` | Brush | ref:SemiGrey8Color @ 0.13 opacity |  |
| `SemiColorBorder` | `SemiTokens.ColorBorder` | Brush | ref:SemiGrey9Color @ 0.08 opacity |  |
| `SemiColorFocusBorder` | `SemiTokens.ColorFocusBorder` | Brush | #0064FA |  |
| `SemiColorDisabledBackground` | `SemiTokens.ColorDisabledBackground` | Brush | #E6E8EA |  |
| `SemiColorDisabledBorder` | `SemiTokens.ColorDisabledBorder` | Brush | #E6E8EA |  |
| `SemiColorDisabledFill` | `SemiTokens.ColorDisabledFill` | Brush | ref:SemiGrey8Color @ 0.02 opacity |  |
| `SemiColorDisabledText` | `SemiTokens.ColorDisabledText` | Brush | ref:SemiGrey9Color @ 0.35 opacity |  |
| `SemiColorLink` | `SemiTokens.ColorLink` | Brush | #0064FA |  |
| `SemiColorLinkPointerover` | `SemiTokens.ColorLinkPointerover` | Brush | #0062D6 |  |
| `SemiColorLinkActive` | `SemiTokens.ColorLinkActive` | Brush | #004FB3 |  |
| `SemiColorLinkVisited` | `SemiTokens.ColorLinkVisited` | Brush | #0064FA |  |
| `SemiColorHighlight` | `SemiTokens.ColorHighlight` | Brush | White |  |
| `SemiColorHighlightBackground` | `SemiTokens.ColorHighlightBackground` | Brush | #FDF398 |  |
| `SemiColorOverlayBackground` | `SemiTokens.ColorOverlayBackground` | Brush | #16161A @ 0.6 opacity |  |
| `SemiColorNavBackground` | `SemiTokens.ColorNavBackground` | Brush | White |  |
| `SemiColorShadow` | `SemiTokens.ColorShadow` | BoxShadows | 0 0 #0A000000 |  |
| `SemiShadowElevated` | `SemiTokens.ShadowElevated` | BoxShadows | 0 0 1 #4A000000, 0 4 14 #1A000000 |  |
| `SemiColorAIGeneral` | `SemiTokens.ColorAIGeneral` | Brush | gradient |  |
| `SemiColorAIGeneralPointerover` | `SemiTokens.ColorAIGeneralPointerover` | Brush | gradient |  |
| `SemiColorAIGeneralActive` | `SemiTokens.ColorAIGeneralActive` | Brush | gradient |  |
| `SemiColorAIGeneralDisabled` | `SemiTokens.ColorAIGeneralDisabled` | Brush | gradient |  |
| `SemiColorAIPurple` | `SemiTokens.ColorAIPurple` | Brush | #A647FF |  |
| `SemiColorAIPurplePointerover` | `SemiTokens.ColorAIPurplePointerover` | Brush | #8636DB |  |
| `SemiColorAIPurpleActive` | `SemiTokens.ColorAIPurpleActive` | Brush | #6928B8 |  |
| `SemiColorAIPurpleDisabled` | `SemiTokens.ColorAIPurpleDisabled` | Brush | #E3B5FF |  |
| `SemiColorAIBackgroundTop` | `SemiTokens.ColorAIBackgroundTop` | Brush | gradient |  |
| `SemiColorAIBackgroundTopPointerover` | `SemiTokens.ColorAIBackgroundTopPointerover` | Brush | gradient |  |
| `SemiColorAIBackgroundTopActive` | `SemiTokens.ColorAIBackgroundTopActive` | Brush | gradient |  |
| `SemiColorAIBackgroundBottom` | `SemiTokens.ColorAIBackgroundBottom` | Brush | gradient |  |
| `SemiColorAIBackgroundBottomPointerover` | `SemiTokens.ColorAIBackgroundBottomPointerover` | Brush | gradient |  |
| `SemiColorAIBackgroundBottomActive` | `SemiTokens.ColorAIBackgroundBottomActive` | Brush | gradient |  |

## Palette

| Resource key | SemiTokens member | Type | Value | Description (zh) |
|---|---|---|---|---|
| `SemiWhite` | `SemiTokens.White` | Brush | White |  |
| `SemiWhiteColor` | `SemiTokens.WhiteColor` | Color | White |  |
| `SemiBlack` | `SemiTokens.Black` | Brush | Black |  |
| `SemiBlackColor` | `SemiTokens.BlackColor` | Color | Black |  |
| `SemiBackground0Color` | `SemiTokens.Background0Color` | Color | White |  |
| `SemiBackground1Color` | `SemiTokens.Background1Color` | Color | White |  |
| `SemiBackground2Color` | `SemiTokens.Background2Color` | Color | White |  |
| `SemiBackground3Color` | `SemiTokens.Background3Color` | Color | White |  |
| `SemiBackground4Color` | `SemiTokens.Background4Color` | Color | White |  |
| `SemiRed0` | `SemiTokens.Red0` | Brush | #FEF2ED |  |
| `SemiRed0Color` | `SemiTokens.Red0Color` | Color | #FEF2ED |  |
| `SemiRed1` | `SemiTokens.Red1` | Brush | #FEDDD2 |  |
| `SemiRed1Color` | `SemiTokens.Red1Color` | Color | #FEDDD2 |  |
| `SemiRed2` | `SemiTokens.Red2` | Brush | #FDB7A5 |  |
| `SemiRed2Color` | `SemiTokens.Red2Color` | Color | #FDB7A5 |  |
| `SemiRed3` | `SemiTokens.Red3` | Brush | #FB9078 |  |
| `SemiRed3Color` | `SemiTokens.Red3Color` | Color | #FB9078 |  |
| `SemiRed4` | `SemiTokens.Red4` | Brush | #FA664C |  |
| `SemiRed4Color` | `SemiTokens.Red4Color` | Color | #FA664C |  |
| `SemiRed5` | `SemiTokens.Red5` | Brush | #F93920 |  |
| `SemiRed5Color` | `SemiTokens.Red5Color` | Color | #F93920 |  |
| `SemiRed6` | `SemiTokens.Red6` | Brush | #D52515 |  |
| `SemiRed6Color` | `SemiTokens.Red6Color` | Color | #D52515 |  |
| `SemiRed7` | `SemiTokens.Red7` | Brush | #B2140C |  |
| `SemiRed7Color` | `SemiTokens.Red7Color` | Color | #B2140C |  |
| `SemiRed8` | `SemiTokens.Red8` | Brush | #8E0805 |  |
| `SemiRed8Color` | `SemiTokens.Red8Color` | Color | #8E0805 |  |
| `SemiRed9` | `SemiTokens.Red9` | Brush | #6A0103 |  |
| `SemiRed9Color` | `SemiTokens.Red9Color` | Color | #6A0103 |  |
| `SemiPink0` | `SemiTokens.Pink0` | Brush | #FDECEF |  |
| `SemiPink0Color` | `SemiTokens.Pink0Color` | Color | #FDECEF |  |
| `SemiPink1` | `SemiTokens.Pink1` | Brush | #FBCFD8 |  |
| `SemiPink1Color` | `SemiTokens.Pink1Color` | Color | #FBCFD8 |  |
| `SemiPink2` | `SemiTokens.Pink2` | Brush | #F6A0B5 |  |
| `SemiPink2Color` | `SemiTokens.Pink2Color` | Color | #F6A0B5 |  |
| `SemiPink3` | `SemiTokens.Pink3` | Brush | #F27396 |  |
| `SemiPink3Color` | `SemiTokens.Pink3Color` | Color | #F27396 |  |
| `SemiPink4` | `SemiTokens.Pink4` | Brush | #ED487B |  |
| `SemiPink4Color` | `SemiTokens.Pink4Color` | Color | #ED487B |  |
| `SemiPink5` | `SemiTokens.Pink5` | Brush | #E91E63 |  |
| `SemiPink5Color` | `SemiTokens.Pink5Color` | Color | #E91E63 |  |
| `SemiPink6` | `SemiTokens.Pink6` | Brush | #C51356 |  |
| `SemiPink6Color` | `SemiTokens.Pink6Color` | Color | #C51356 |  |
| `SemiPink7` | `SemiTokens.Pink7` | Brush | #A20B48 |  |
| `SemiPink7Color` | `SemiTokens.Pink7Color` | Color | #A20B48 |  |
| `SemiPink8` | `SemiTokens.Pink8` | Brush | #7E053A |  |
| `SemiPink8Color` | `SemiTokens.Pink8Color` | Color | #7E053A |  |
| `SemiPink9` | `SemiTokens.Pink9` | Brush | #5A012B |  |
| `SemiPink9Color` | `SemiTokens.Pink9Color` | Color | #5A012B |  |
| `SemiAmber0` | `SemiTokens.Amber0` | Brush | #FEFBEB |  |
| `SemiAmber0Color` | `SemiTokens.Amber0Color` | Color | #FEFBEB |  |
| `SemiAmber1` | `SemiTokens.Amber1` | Brush | #FCF5CE |  |
| `SemiAmber1Color` | `SemiTokens.Amber1Color` | Color | #FCF5CE |  |
| `SemiAmber2` | `SemiTokens.Amber2` | Brush | #F9E89E |  |
| `SemiAmber2Color` | `SemiTokens.Amber2Color` | Color | #F9E89E |  |
| `SemiAmber3` | `SemiTokens.Amber3` | Brush | #F6D86F |  |
| `SemiAmber3Color` | `SemiTokens.Amber3Color` | Color | #F6D86F |  |
| `SemiAmber4` | `SemiTokens.Amber4` | Brush | #F3C641 |  |
| `SemiAmber4Color` | `SemiTokens.Amber4Color` | Color | #F3C641 |  |
| `SemiAmber5` | `SemiTokens.Amber5` | Brush | #F0B114 |  |
| `SemiAmber5Color` | `SemiTokens.Amber5Color` | Color | #F0B114 |  |
| `SemiAmber6` | `SemiTokens.Amber6` | Brush | #C88A0F |  |
| `SemiAmber6Color` | `SemiTokens.Amber6Color` | Color | #C88A0F |  |
| `SemiAmber7` | `SemiTokens.Amber7` | Brush | #A0660A |  |
| `SemiAmber7Color` | `SemiTokens.Amber7Color` | Color | #A0660A |  |
| `SemiAmber8` | `SemiTokens.Amber8` | Brush | #784606 |  |
| `SemiAmber8Color` | `SemiTokens.Amber8Color` | Color | #784606 |  |
| `SemiAmber9` | `SemiTokens.Amber9` | Brush | #502B03 |  |
| `SemiAmber9Color` | `SemiTokens.Amber9Color` | Color | #502B03 |  |
| `SemiOrange0` | `SemiTokens.Orange0` | Brush | #FFF8EA |  |
| `SemiOrange0Color` | `SemiTokens.Orange0Color` | Color | #FFF8EA |  |
| `SemiOrange1` | `SemiTokens.Orange1` | Brush | #FEEECC |  |
| `SemiOrange1Color` | `SemiTokens.Orange1Color` | Color | #FEEECC |  |
| `SemiOrange2` | `SemiTokens.Orange2` | Brush | #FED998 |  |
| `SemiOrange2Color` | `SemiTokens.Orange2Color` | Color | #FED998 |  |
| `SemiOrange3` | `SemiTokens.Orange3` | Brush | #FDC165 |  |
| `SemiOrange3Color` | `SemiTokens.Orange3Color` | Color | #FDC165 |  |
| `SemiOrange4` | `SemiTokens.Orange4` | Brush | #FDA633 |  |
| `SemiOrange4Color` | `SemiTokens.Orange4Color` | Color | #FDA633 |  |
| `SemiOrange5` | `SemiTokens.Orange5` | Brush | #FC8800 |  |
| `SemiOrange5Color` | `SemiTokens.Orange5Color` | Color | #FC8800 |  |
| `SemiOrange6` | `SemiTokens.Orange6` | Brush | #D26700 |  |
| `SemiOrange6Color` | `SemiTokens.Orange6Color` | Color | #D26700 |  |
| `SemiOrange7` | `SemiTokens.Orange7` | Brush | #A84A00 |  |
| `SemiOrange7Color` | `SemiTokens.Orange7Color` | Color | #A84A00 |  |
| `SemiOrange8` | `SemiTokens.Orange8` | Brush | #7E3100 |  |
| `SemiOrange8Color` | `SemiTokens.Orange8Color` | Color | #7E3100 |  |
| `SemiOrange9` | `SemiTokens.Orange9` | Brush | #541D00 |  |
| `SemiOrange9Color` | `SemiTokens.Orange9Color` | Color | #541D00 |  |
| `SemiYellow0` | `SemiTokens.Yellow0` | Brush | #FFFDEA |  |
| `SemiYellow0Color` | `SemiTokens.Yellow0Color` | Color | #FFFDEA |  |
| `SemiYellow1` | `SemiTokens.Yellow1` | Brush | #FEFBCB |  |
| `SemiYellow1Color` | `SemiTokens.Yellow1Color` | Color | #FEFBCB |  |
| `SemiYellow2` | `SemiTokens.Yellow2` | Brush | #FDF398 |  |
| `SemiYellow2Color` | `SemiTokens.Yellow2Color` | Color | #FDF398 |  |
| `SemiYellow3` | `SemiTokens.Yellow3` | Brush | #FCE865 |  |
| `SemiYellow3Color` | `SemiTokens.Yellow3Color` | Color | #FCE865 |  |
| `SemiYellow4` | `SemiTokens.Yellow4` | Brush | #FBDA32 |  |
| `SemiYellow4Color` | `SemiTokens.Yellow4Color` | Color | #FBDA32 |  |
| `SemiYellow5` | `SemiTokens.Yellow5` | Brush | #FAC800 |  |
| `SemiYellow5Color` | `SemiTokens.Yellow5Color` | Color | #FAC800 |  |
| `SemiYellow6` | `SemiTokens.Yellow6` | Brush | #D0AA00 |  |
| `SemiYellow6Color` | `SemiTokens.Yellow6Color` | Color | #D0AA00 |  |
| `SemiYellow7` | `SemiTokens.Yellow7` | Brush | #A78B00 |  |
| `SemiYellow7Color` | `SemiTokens.Yellow7Color` | Color | #A78B00 |  |
| `SemiYellow8` | `SemiTokens.Yellow8` | Brush | #7D6A00 |  |
| `SemiYellow8Color` | `SemiTokens.Yellow8Color` | Color | #7D6A00 |  |
| `SemiYellow9` | `SemiTokens.Yellow9` | Brush | #534800 |  |
| `SemiYellow9Color` | `SemiTokens.Yellow9Color` | Color | #534800 |  |
| `SemiLime0` | `SemiTokens.Lime0` | Brush | #F2FAE6 |  |
| `SemiLime0Color` | `SemiTokens.Lime0Color` | Color | #F2FAE6 |  |
| `SemiLime1` | `SemiTokens.Lime1` | Brush | #E3F6C5 |  |
| `SemiLime1Color` | `SemiTokens.Lime1Color` | Color | #E3F6C5 |  |
| `SemiLime2` | `SemiTokens.Lime2` | Brush | #CBED8E |  |
| `SemiLime2Color` | `SemiTokens.Lime2Color` | Color | #CBED8E |  |
| `SemiLime3` | `SemiTokens.Lime3` | Brush | #B7E35B |  |
| `SemiLime3Color` | `SemiTokens.Lime3Color` | Color | #B7E35B |  |
| `SemiLime4` | `SemiTokens.Lime4` | Brush | #A7DA2C |  |
| `SemiLime4Color` | `SemiTokens.Lime4Color` | Color | #A7DA2C |  |
| `SemiLime5` | `SemiTokens.Lime5` | Brush | #9BD100 |  |
| `SemiLime5Color` | `SemiTokens.Lime5Color` | Color | #9BD100 |  |
| `SemiLime6` | `SemiTokens.Lime6` | Brush | #7EAE00 |  |
| `SemiLime6Color` | `SemiTokens.Lime6Color` | Color | #7EAE00 |  |
| `SemiLime7` | `SemiTokens.Lime7` | Brush | #638B00 |  |
| `SemiLime7Color` | `SemiTokens.Lime7Color` | Color | #638B00 |  |
| `SemiLime8` | `SemiTokens.Lime8` | Brush | #486800 |  |
| `SemiLime8Color` | `SemiTokens.Lime8Color` | Color | #486800 |  |
| `SemiLime9` | `SemiTokens.Lime9` | Brush | #2F4600 |  |
| `SemiLime9Color` | `SemiTokens.Lime9Color` | Color | #2F4600 |  |
| `SemiLightGreen0` | `SemiTokens.LightGreen0` | Brush | #F3F8EC |  |
| `SemiLightGreen0Color` | `SemiTokens.LightGreen0Color` | Color | #F3F8EC |  |
| `SemiLightGreen1` | `SemiTokens.LightGreen1` | Brush | #E3F0D0 |  |
| `SemiLightGreen1Color` | `SemiTokens.LightGreen1Color` | Color | #E3F0D0 |  |
| `SemiLightGreen2` | `SemiTokens.LightGreen2` | Brush | #C8E2A5 |  |
| `SemiLightGreen2Color` | `SemiTokens.LightGreen2Color` | Color | #C8E2A5 |  |
| `SemiLightGreen3` | `SemiTokens.LightGreen3` | Brush | #ADD37E |  |
| `SemiLightGreen3Color` | `SemiTokens.LightGreen3Color` | Color | #ADD37E |  |
| `SemiLightGreen4` | `SemiTokens.LightGreen4` | Brush | #93C55B |  |
| `SemiLightGreen4Color` | `SemiTokens.LightGreen4Color` | Color | #93C55B |  |
| `SemiLightGreen5` | `SemiTokens.LightGreen5` | Brush | #7BB63C |  |
| `SemiLightGreen5Color` | `SemiTokens.LightGreen5Color` | Color | #7BB63C |  |
| `SemiLightGreen6` | `SemiTokens.LightGreen6` | Brush | #649830 |  |
| `SemiLightGreen6Color` | `SemiTokens.LightGreen6Color` | Color | #649830 |  |
| `SemiLightGreen7` | `SemiTokens.LightGreen7` | Brush | #4E7926 |  |
| `SemiLightGreen7Color` | `SemiTokens.LightGreen7Color` | Color | #4E7926 |  |
| `SemiLightGreen8` | `SemiTokens.LightGreen8` | Brush | #395B1B |  |
| `SemiLightGreen8Color` | `SemiTokens.LightGreen8Color` | Color | #395B1B |  |
| `SemiLightGreen9` | `SemiTokens.LightGreen9` | Brush | #253D12 |  |
| `SemiLightGreen9Color` | `SemiTokens.LightGreen9Color` | Color | #253D12 |  |
| `SemiGreen0` | `SemiTokens.Green0` | Brush | #ECF7EC |  |
| `SemiGreen0Color` | `SemiTokens.Green0Color` | Color | #ECF7EC |  |
| `SemiGreen1` | `SemiTokens.Green1` | Brush | #D0F0D1 |  |
| `SemiGreen1Color` | `SemiTokens.Green1Color` | Color | #D0F0D1 |  |
| `SemiGreen2` | `SemiTokens.Green2` | Brush | #A4E0A7 |  |
| `SemiGreen2Color` | `SemiTokens.Green2Color` | Color | #A4E0A7 |  |
| `SemiGreen3` | `SemiTokens.Green3` | Brush | #7DD182 |  |
| `SemiGreen3Color` | `SemiTokens.Green3Color` | Color | #7DD182 |  |
| `SemiGreen4` | `SemiTokens.Green4` | Brush | #5AC262 |  |
| `SemiGreen4Color` | `SemiTokens.Green4Color` | Color | #5AC262 |  |
| `SemiGreen5` | `SemiTokens.Green5` | Brush | #3BB346 |  |
| `SemiGreen5Color` | `SemiTokens.Green5Color` | Color | #3BB346 |  |
| `SemiGreen6` | `SemiTokens.Green6` | Brush | #30953B |  |
| `SemiGreen6Color` | `SemiTokens.Green6Color` | Color | #30953B |  |
| `SemiGreen7` | `SemiTokens.Green7` | Brush | #25772F |  |
| `SemiGreen7Color` | `SemiTokens.Green7Color` | Color | #25772F |  |
| `SemiGreen8` | `SemiTokens.Green8` | Brush | #1B5924 |  |
| `SemiGreen8Color` | `SemiTokens.Green8Color` | Color | #1B5924 |  |
| `SemiGreen9` | `SemiTokens.Green9` | Brush | #113C18 |  |
| `SemiGreen9Color` | `SemiTokens.Green9Color` | Color | #113C18 |  |
| `SemiCyan0` | `SemiTokens.Cyan0` | Brush | #E5F7F8 |  |
| `SemiCyan0Color` | `SemiTokens.Cyan0Color` | Color | #E5F7F8 |  |
| `SemiCyan1` | `SemiTokens.Cyan1` | Brush | #C2EFF0 |  |
| `SemiCyan1Color` | `SemiTokens.Cyan1Color` | Color | #C2EFF0 |  |
| `SemiCyan2` | `SemiTokens.Cyan2` | Brush | #8ADDE2 |  |
| `SemiCyan2Color` | `SemiTokens.Cyan2Color` | Color | #8ADDE2 |  |
| `SemiCyan3` | `SemiTokens.Cyan3` | Brush | #58CBD3 |  |
| `SemiCyan3Color` | `SemiTokens.Cyan3Color` | Color | #58CBD3 |  |
| `SemiCyan4` | `SemiTokens.Cyan4` | Brush | #2CB8C5 |  |
| `SemiCyan4Color` | `SemiTokens.Cyan4Color` | Color | #2CB8C5 |  |
| `SemiCyan5` | `SemiTokens.Cyan5` | Brush | #05A4B6 |  |
| `SemiCyan5Color` | `SemiTokens.Cyan5Color` | Color | #05A4B6 |  |
| `SemiCyan6` | `SemiTokens.Cyan6` | Brush | #038698 |  |
| `SemiCyan6Color` | `SemiTokens.Cyan6Color` | Color | #038698 |  |
| `SemiCyan7` | `SemiTokens.Cyan7` | Brush | #016979 |  |
| `SemiCyan7Color` | `SemiTokens.Cyan7Color` | Color | #016979 |  |
| `SemiCyan8` | `SemiTokens.Cyan8` | Brush | #004D5B |  |
| `SemiCyan8Color` | `SemiTokens.Cyan8Color` | Color | #004D5B |  |
| `SemiCyan9` | `SemiTokens.Cyan9` | Brush | #00323D |  |
| `SemiCyan9Color` | `SemiTokens.Cyan9Color` | Color | #00323D |  |
| `SemiTeal0` | `SemiTokens.Teal0` | Brush | #E4F7F4 |  |
| `SemiTeal0Color` | `SemiTokens.Teal0Color` | Color | #E4F7F4 |  |
| `SemiTeal1` | `SemiTokens.Teal1` | Brush | #C0F0E8 |  |
| `SemiTeal1Color` | `SemiTokens.Teal1Color` | Color | #C0F0E8 |  |
| `SemiTeal2` | `SemiTokens.Teal2` | Brush | #87E0D3 |  |
| `SemiTeal2Color` | `SemiTokens.Teal2Color` | Color | #87E0D3 |  |
| `SemiTeal3` | `SemiTokens.Teal3` | Brush | #54D1C1 |  |
| `SemiTeal3Color` | `SemiTokens.Teal3Color` | Color | #54D1C1 |  |
| `SemiTeal4` | `SemiTokens.Teal4` | Brush | #27C2B0 |  |
| `SemiTeal4Color` | `SemiTokens.Teal4Color` | Color | #27C2B0 |  |
| `SemiTeal5` | `SemiTokens.Teal5` | Brush | #00B3A1 |  |
| `SemiTeal5Color` | `SemiTokens.Teal5Color` | Color | #00B3A1 |  |
| `SemiTeal6` | `SemiTokens.Teal6` | Brush | #009589 |  |
| `SemiTeal6Color` | `SemiTokens.Teal6Color` | Color | #009589 |  |
| `SemiTeal7` | `SemiTokens.Teal7` | Brush | #00776F |  |
| `SemiTeal7Color` | `SemiTokens.Teal7Color` | Color | #00776F |  |
| `SemiTeal8` | `SemiTokens.Teal8` | Brush | #005955 |  |
| `SemiTeal8Color` | `SemiTokens.Teal8Color` | Color | #005955 |  |
| `SemiTeal9` | `SemiTokens.Teal9` | Brush | #003C3A |  |
| `SemiTeal9Color` | `SemiTokens.Teal9Color` | Color | #003C3A |  |
| `SemiLightBlue0` | `SemiTokens.LightBlue0` | Brush | #E9F7FD |  |
| `SemiLightBlue0Color` | `SemiTokens.LightBlue0Color` | Color | #E9F7FD |  |
| `SemiLightBlue1` | `SemiTokens.LightBlue1` | Brush | #C9ECFC |  |
| `SemiLightBlue1Color` | `SemiTokens.LightBlue1Color` | Color | #C9ECFC |  |
| `SemiLightBlue2` | `SemiTokens.LightBlue2` | Brush | #95D8F8 |  |
| `SemiLightBlue2Color` | `SemiTokens.LightBlue2Color` | Color | #95D8F8 |  |
| `SemiLightBlue3` | `SemiTokens.LightBlue3` | Brush | #62C3F5 |  |
| `SemiLightBlue3Color` | `SemiTokens.LightBlue3Color` | Color | #62C3F5 |  |
| `SemiLightBlue4` | `SemiTokens.LightBlue4` | Brush | #30ACF1 |  |
| `SemiLightBlue4Color` | `SemiTokens.LightBlue4Color` | Color | #30ACF1 |  |
| `SemiLightBlue5` | `SemiTokens.LightBlue5` | Brush | #0095EE |  |
| `SemiLightBlue5Color` | `SemiTokens.LightBlue5Color` | Color | #0095EE |  |
| `SemiLightBlue6` | `SemiTokens.LightBlue6` | Brush | #007BCA |  |
| `SemiLightBlue6Color` | `SemiTokens.LightBlue6Color` | Color | #007BCA |  |
| `SemiLightBlue7` | `SemiTokens.LightBlue7` | Brush | #0063A7 |  |
| `SemiLightBlue7Color` | `SemiTokens.LightBlue7Color` | Color | #0063A7 |  |
| `SemiLightBlue8` | `SemiTokens.LightBlue8` | Brush | #004B83 |  |
| `SemiLightBlue8Color` | `SemiTokens.LightBlue8Color` | Color | #004B83 |  |
| `SemiLightBlue9` | `SemiTokens.LightBlue9` | Brush | #00355F |  |
| `SemiLightBlue9Color` | `SemiTokens.LightBlue9Color` | Color | #00355F |  |
| `SemiBlue0` | `SemiTokens.Blue0` | Brush | #EAF5FF |  |
| `SemiBlue0Color` | `SemiTokens.Blue0Color` | Color | #EAF5FF |  |
| `SemiBlue1` | `SemiTokens.Blue1` | Brush | #CBE7FE |  |
| `SemiBlue1Color` | `SemiTokens.Blue1Color` | Color | #CBE7FE |  |
| `SemiBlue2` | `SemiTokens.Blue2` | Brush | #98CDFD |  |
| `SemiBlue2Color` | `SemiTokens.Blue2Color` | Color | #98CDFD |  |
| `SemiBlue3` | `SemiTokens.Blue3` | Brush | #65B2FC |  |
| `SemiBlue3Color` | `SemiTokens.Blue3Color` | Color | #65B2FC |  |
| `SemiBlue4` | `SemiTokens.Blue4` | Brush | #3295FB |  |
| `SemiBlue4Color` | `SemiTokens.Blue4Color` | Color | #3295FB |  |
| `SemiBlue5` | `SemiTokens.Blue5` | Brush | #0064FA |  |
| `SemiBlue5Color` | `SemiTokens.Blue5Color` | Color | #0064FA |  |
| `SemiBlue6` | `SemiTokens.Blue6` | Brush | #0062D6 |  |
| `SemiBlue6Color` | `SemiTokens.Blue6Color` | Color | #0062D6 |  |
| `SemiBlue7` | `SemiTokens.Blue7` | Brush | #004FB3 |  |
| `SemiBlue7Color` | `SemiTokens.Blue7Color` | Color | #004FB3 |  |
| `SemiBlue8` | `SemiTokens.Blue8` | Brush | #003D8F |  |
| `SemiBlue8Color` | `SemiTokens.Blue8Color` | Color | #003D8F |  |
| `SemiBlue9` | `SemiTokens.Blue9` | Brush | #002C6B |  |
| `SemiBlue9Color` | `SemiTokens.Blue9Color` | Color | #002C6B |  |
| `SemiIndigo0` | `SemiTokens.Indigo0` | Brush | #ECEFF8 |  |
| `SemiIndigo0Color` | `SemiTokens.Indigo0Color` | Color | #ECEFF8 |  |
| `SemiIndigo1` | `SemiTokens.Indigo1` | Brush | #D1D8F0 |  |
| `SemiIndigo1Color` | `SemiTokens.Indigo1Color` | Color | #D1D8F0 |  |
| `SemiIndigo2` | `SemiTokens.Indigo2` | Brush | #A7B3E1 |  |
| `SemiIndigo2Color` | `SemiTokens.Indigo2Color` | Color | #A7B3E1 |  |
| `SemiIndigo3` | `SemiTokens.Indigo3` | Brush | #8090D3 |  |
| `SemiIndigo3Color` | `SemiTokens.Indigo3Color` | Color | #8090D3 |  |
| `SemiIndigo4` | `SemiTokens.Indigo4` | Brush | #5E6FC4 |  |
| `SemiIndigo4Color` | `SemiTokens.Indigo4Color` | Color | #5E6FC4 |  |
| `SemiIndigo5` | `SemiTokens.Indigo5` | Brush | #3F51B5 |  |
| `SemiIndigo5Color` | `SemiTokens.Indigo5Color` | Color | #3F51B5 |  |
| `SemiIndigo6` | `SemiTokens.Indigo6` | Brush | #3342A1 |  |
| `SemiIndigo6Color` | `SemiTokens.Indigo6Color` | Color | #3342A1 |  |
| `SemiIndigo7` | `SemiTokens.Indigo7` | Brush | #28348C |  |
| `SemiIndigo7Color` | `SemiTokens.Indigo7Color` | Color | #28348C |  |
| `SemiIndigo8` | `SemiTokens.Indigo8` | Brush | #1F2878 |  |
| `SemiIndigo8Color` | `SemiTokens.Indigo8Color` | Color | #1F2878 |  |
| `SemiIndigo9` | `SemiTokens.Indigo9` | Brush | #171D63 |  |
| `SemiIndigo9Color` | `SemiTokens.Indigo9Color` | Color | #171D63 |  |
| `SemiViolet0` | `SemiTokens.Violet0` | Brush | #F3EDF9 |  |
| `SemiViolet0Color` | `SemiTokens.Violet0Color` | Color | #F3EDF9 |  |
| `SemiViolet1` | `SemiTokens.Violet1` | Brush | #E2D1F4 |  |
| `SemiViolet1Color` | `SemiTokens.Violet1Color` | Color | #E2D1F4 |  |
| `SemiViolet2` | `SemiTokens.Violet2` | Brush | #C4A7E9 |  |
| `SemiViolet2Color` | `SemiTokens.Violet2Color` | Color | #C4A7E9 |  |
| `SemiViolet3` | `SemiTokens.Violet3` | Brush | #A67FDD |  |
| `SemiViolet3Color` | `SemiTokens.Violet3Color` | Color | #A67FDD |  |
| `SemiViolet4` | `SemiTokens.Violet4` | Brush | #885BD2 |  |
| `SemiViolet4Color` | `SemiTokens.Violet4Color` | Color | #885BD2 |  |
| `SemiViolet5` | `SemiTokens.Violet5` | Brush | #6A3AC7 |  |
| `SemiViolet5Color` | `SemiTokens.Violet5Color` | Color | #6A3AC7 |  |
| `SemiViolet6` | `SemiTokens.Violet6` | Brush | #572FB3 |  |
| `SemiViolet6Color` | `SemiTokens.Violet6Color` | Color | #572FB3 |  |
| `SemiViolet7` | `SemiTokens.Violet7` | Brush | #46259E |  |
| `SemiViolet7Color` | `SemiTokens.Violet7Color` | Color | #46259E |  |
| `SemiViolet8` | `SemiTokens.Violet8` | Brush | #361C8A |  |
| `SemiViolet8Color` | `SemiTokens.Violet8Color` | Color | #361C8A |  |
| `SemiViolet9` | `SemiTokens.Violet9` | Brush | #281475 |  |
| `SemiViolet9Color` | `SemiTokens.Violet9Color` | Color | #281475 |  |
| `SemiPurple0` | `SemiTokens.Purple0` | Brush | #F7E9F7 |  |
| `SemiPurple0Color` | `SemiTokens.Purple0Color` | Color | #F7E9F7 |  |
| `SemiPurple1` | `SemiTokens.Purple1` | Brush | #EFCAF0 |  |
| `SemiPurple1Color` | `SemiTokens.Purple1Color` | Color | #EFCAF0 |  |
| `SemiPurple2` | `SemiTokens.Purple2` | Brush | #DD9BE0 |  |
| `SemiPurple2Color` | `SemiTokens.Purple2Color` | Color | #DD9BE0 |  |
| `SemiPurple3` | `SemiTokens.Purple3` | Brush | #C96FD1 |  |
| `SemiPurple3Color` | `SemiTokens.Purple3Color` | Color | #C96FD1 |  |
| `SemiPurple4` | `SemiTokens.Purple4` | Brush | #B449C2 |  |
| `SemiPurple4Color` | `SemiTokens.Purple4Color` | Color | #B449C2 |  |
| `SemiPurple5` | `SemiTokens.Purple5` | Brush | #9E28B3 |  |
| `SemiPurple5Color` | `SemiTokens.Purple5Color` | Color | #9E28B3 |  |
| `SemiPurple6` | `SemiTokens.Purple6` | Brush | #871E9E |  |
| `SemiPurple6Color` | `SemiTokens.Purple6Color` | Color | #871E9E |  |
| `SemiPurple7` | `SemiTokens.Purple7` | Brush | #71168A |  |
| `SemiPurple7Color` | `SemiTokens.Purple7Color` | Color | #71168A |  |
| `SemiPurple8` | `SemiTokens.Purple8` | Brush | #5C0F75 |  |
| `SemiPurple8Color` | `SemiTokens.Purple8Color` | Color | #5C0F75 |  |
| `SemiPurple9` | `SemiTokens.Purple9` | Brush | #490A61 |  |
| `SemiPurple9Color` | `SemiTokens.Purple9Color` | Color | #490A61 |  |
| `SemiGrey0` | `SemiTokens.Grey0` | Brush | #F9F9F9 |  |
| `SemiGrey0Color` | `SemiTokens.Grey0Color` | Color | #F9F9F9 |  |
| `SemiGrey1` | `SemiTokens.Grey1` | Brush | #E6E8EA |  |
| `SemiGrey1Color` | `SemiTokens.Grey1Color` | Color | #E6E8EA |  |
| `SemiGrey2` | `SemiTokens.Grey2` | Brush | #C6CACD |  |
| `SemiGrey2Color` | `SemiTokens.Grey2Color` | Color | #C6CACD |  |
| `SemiGrey3` | `SemiTokens.Grey3` | Brush | #A7ABB0 |  |
| `SemiGrey3Color` | `SemiTokens.Grey3Color` | Color | #A7ABB0 |  |
| `SemiGrey4` | `SemiTokens.Grey4` | Brush | #888D92 |  |
| `SemiGrey4Color` | `SemiTokens.Grey4Color` | Color | #888D92 |  |
| `SemiGrey5` | `SemiTokens.Grey5` | Brush | #6B7075 |  |
| `SemiGrey5Color` | `SemiTokens.Grey5Color` | Color | #6B7075 |  |
| `SemiGrey6` | `SemiTokens.Grey6` | Brush | #555B61 |  |
| `SemiGrey6Color` | `SemiTokens.Grey6Color` | Color | #555B61 |  |
| `SemiGrey7` | `SemiTokens.Grey7` | Brush | #41464C |  |
| `SemiGrey7Color` | `SemiTokens.Grey7Color` | Color | #41464C |  |
| `SemiGrey8` | `SemiTokens.Grey8` | Brush | #2E3238 |  |
| `SemiGrey8Color` | `SemiTokens.Grey8Color` | Color | #2E3238 |  |
| `SemiGrey9` | `SemiTokens.Grey9` | Brush | #1C1F23 |  |
| `SemiGrey9Color` | `SemiTokens.Grey9Color` | Color | #1C1F23 |  |
| `SemiAIPurple0` | `SemiTokens.AIPurple0` | Brush | #F8EDFF |  |
| `SemiAIPurple0Color` | `SemiTokens.AIPurple0Color` | Color | #F8EDFF |  |
| `SemiAIPurple1` | `SemiTokens.AIPurple1` | Brush | #F2DAFF |  |
| `SemiAIPurple1Color` | `SemiTokens.AIPurple1Color` | Color | #F2DAFF |  |
| `SemiAIPurple2` | `SemiTokens.AIPurple2` | Brush | #E3B5FF |  |
| `SemiAIPurple2Color` | `SemiTokens.AIPurple2Color` | Color | #E3B5FF |  |
| `SemiAIPurple3` | `SemiTokens.AIPurple3` | Brush | #D191FF |  |
| `SemiAIPurple3Color` | `SemiTokens.AIPurple3Color` | Color | #D191FF |  |
| `SemiAIPurple4` | `SemiTokens.AIPurple4` | Brush | #BD6CFF |  |
| `SemiAIPurple4Color` | `SemiTokens.AIPurple4Color` | Color | #BD6CFF |  |
| `SemiAIPurple5` | `SemiTokens.AIPurple5` | Brush | #A647FF |  |
| `SemiAIPurple5Color` | `SemiTokens.AIPurple5Color` | Color | #A647FF |  |
| `SemiAIPurple6` | `SemiTokens.AIPurple6` | Brush | #8636DB |  |
| `SemiAIPurple6Color` | `SemiTokens.AIPurple6Color` | Color | #8636DB |  |
| `SemiAIPurple7` | `SemiTokens.AIPurple7` | Brush | #6928B8 |  |
| `SemiAIPurple7Color` | `SemiTokens.AIPurple7Color` | Color | #6928B8 |  |
| `SemiAIPurple8` | `SemiTokens.AIPurple8` | Brush | #4E1C94 |  |
| `SemiAIPurple8Color` | `SemiTokens.AIPurple8Color` | Color | #4E1C94 |  |
| `SemiAIPurple9` | `SemiTokens.AIPurple9` | Brush | #361270 |  |
| `SemiAIPurple9Color` | `SemiTokens.AIPurple9Color` | Color | #361270 |  |
| `SemiAIGeneral0` | `SemiTokens.AIGeneral0` | Brush | gradient |  |
| `SemiAIGeneral1` | `SemiTokens.AIGeneral1` | Brush | gradient |  |
| `SemiAIGeneral2` | `SemiTokens.AIGeneral2` | Brush | gradient |  |
| `SemiAIGeneral3` | `SemiTokens.AIGeneral3` | Brush | gradient |  |
| `SemiAIGeneral4` | `SemiTokens.AIGeneral4` | Brush | gradient |  |
| `SemiAIGeneral5` | `SemiTokens.AIGeneral5` | Brush | gradient |  |
| `SemiAIGeneral6` | `SemiTokens.AIGeneral6` | Brush | gradient |  |
| `SemiAIGeneral7` | `SemiTokens.AIGeneral7` | Brush | gradient |  |
| `SemiAIGeneral8` | `SemiTokens.AIGeneral8` | Brush | gradient |  |
| `SemiAIGeneral9` | `SemiTokens.AIGeneral9` | Brush | gradient |  |

## HighContrast

| Resource key | HighContrastTokens member | Type | Value | Description (zh) |
|---|---|---|---|---|
| `SemiColorWindow` | `HighContrastTokens.ColorWindow` | Brush | high-contrast presets only, e.g. #202020 |  |
| `SemiColorWindowText` | `HighContrastTokens.ColorWindowText` | Brush | high-contrast presets only, e.g. #FFFFFF |  |
| `SemiColorHotlight` | `HighContrastTokens.ColorHotlight` | Brush | high-contrast presets only, e.g. #75E9FC |  |
| `SemiColorGrayText` | `HighContrastTokens.ColorGrayText` | Brush | high-contrast presets only, e.g. #A6A6A6 |  |
| `SemiColorHighlightText` | `HighContrastTokens.ColorHighlightText` | Brush | high-contrast presets only, e.g. #263B50 |  |
| `SemiColorHighlight` | `HighContrastTokens.ColorHighlight` | Brush | high-contrast presets, e.g. #8EE3F0 |  |
| `SemiColorButtonText` | `HighContrastTokens.ColorButtonText` | Brush | high-contrast presets only, e.g. #FFFFFF |  |
| `SemiColorButtonFace` | `HighContrastTokens.ColorButtonFace` | Brush | high-contrast presets only, e.g. #202020 |  |

## Palette colors

Raw color scales; each key exists in the Light and the Dark palette.

| Key | Light | Dark |
|---|---|---|
| `SemiWhiteColor` | White | White |
| `SemiBlackColor` | Black | Black |
| `SemiRed0Color` | #FEF2ED | #6C090B |
| `SemiRed1Color` | #FEDDD2 | #901110 |
| `SemiRed2Color` | #FDB7A5 | #B42019 |
| `SemiRed3Color` | #FB9078 | #D73324 |
| `SemiRed4Color` | #FA664C | #FB4932 |
| `SemiRed5Color` | #F93920 | #FC725A |
| `SemiRed6Color` | #D52515 | #FD9983 |
| `SemiRed7Color` | #B2140C | #FDBEAC |
| `SemiRed8Color` | #8E0805 | #FEE0D5 |
| `SemiRed9Color` | #6A0103 | #FFF3EF |
| `SemiPink0Color` | #FDECEF | #5C0730 |
| `SemiPink1Color` | #FBCFD8 | #800E41 |
| `SemiPink2Color` | #F6A0B5 | #A41751 |
| `SemiPink3Color` | #F27396 | #C72261 |
| `SemiPink4Color` | #ED487B | #EB2F71 |
| `SemiPink5Color` | #E91E63 | #EF5686 |
| `SemiPink6Color` | #C51356 | #F37E9F |
| `SemiPink7Color` | #A20B48 | #F7A8BC |
| `SemiPink8Color` | #7E053A | #FBD3DC |
| `SemiPink9Color` | #5A012B | #FDEEF1 |
| `SemiPurple0Color` | #F7E9F7 | #4A1061 |
| `SemiPurple1Color` | #EFCAF0 | #5E1776 |
| `SemiPurple2Color` | #DD9BE0 | #731F8A |
| `SemiPurple3Color` | #C96FD1 | #89289F |
| `SemiPurple4Color` | #B449C2 | #A033B3 |
| `SemiPurple5Color` | #9E28B3 | #B553C2 |
| `SemiPurple6Color` | #871E9E | #CA78D1 |
| `SemiPurple7Color` | #71168A | #DDA0E1 |
| `SemiPurple8Color` | #5C0F75 | #EFCEF0 |
| `SemiPurple9Color` | #490A61 | #F7EBF7 |
| `SemiViolet0Color` | #F3EDF9 | #401B77 |
| `SemiViolet1Color` | #E2D1F4 | #4C248C |
| `SemiViolet2Color` | #C4A7E9 | #582EA0 |
| `SemiViolet3Color` | #A67FDD | #6439B5 |
| `SemiViolet4Color` | #885BD2 | #7246C9 |
| `SemiViolet5Color` | #6A3AC7 | #8865D4 |
| `SemiViolet6Color` | #572FB3 | #A288DF |
| `SemiViolet7Color` | #46259E | #BEADE9 |
| `SemiViolet8Color` | #361C8A | #DDD4F4 |
| `SemiViolet9Color` | #281475 | #F1EEFA |
| `SemiIndigo0Color` | #ECEFF8 | #171E65 |
| `SemiIndigo1Color` | #D1D8F0 | #20297A |
| `SemiIndigo2Color` | #A7B3E1 | #29368E |
| `SemiIndigo3Color` | #8090D3 | #3444A3 |
| `SemiIndigo4Color` | #5E6FC4 | #4053B7 |
| `SemiIndigo5Color` | #3F51B5 | #5F71C5 |
| `SemiIndigo6Color` | #3342A1 | #8191D4 |
| `SemiIndigo7Color` | #28348C | #A7B4E2 |
| `SemiIndigo8Color` | #1F2878 | #D1D8F1 |
| `SemiIndigo9Color` | #171D63 | #EDEFF8 |
| `SemiBlue0Color` | #EAF5FF | #053170 |
| `SemiBlue1Color` | #CBE7FE | #0A4694 |
| `SemiBlue2Color` | #98CDFD | #135CB8 |
| `SemiBlue3Color` | #65B2FC | #1D75DB |
| `SemiBlue4Color` | #3295FB | #2990FF |
| `SemiBlue5Color` | #0064FA | #54A9FF |
| `SemiBlue6Color` | #0062D6 | #7FC1FF |
| `SemiBlue7Color` | #004FB3 | #A9D7FF |
| `SemiBlue8Color` | #003D8F | #D4ECFF |
| `SemiBlue9Color` | #002C6B | #EFF8FF |
| `SemiLightBlue0Color` | #E9F7FD | #003761 |
| `SemiLightBlue1Color` | #C9ECFC | #004D85 |
| `SemiLightBlue2Color` | #95D8F8 | #0366A9 |
| `SemiLightBlue3Color` | #62C3F5 | #0A81CC |
| `SemiLightBlue4Color` | #30ACF1 | #139FF0 |
| `SemiLightBlue5Color` | #0095EE | #40B4F3 |
| `SemiLightBlue6Color` | #007BCA | #6EC8F6 |
| `SemiLightBlue7Color` | #0063A7 | #9DDCF9 |
| `SemiLightBlue8Color` | #004B83 | #CEEEFC |
| `SemiLightBlue9Color` | #00355F | #EBF8FE |
| `SemiCyan0Color` | #E5F7F8 | #04343D |
| `SemiCyan1Color` | #C2EFF0 | #074F5C |
| `SemiCyan2Color` | #8ADDE2 | #0A6C7B |
| `SemiCyan3Color` | #58CBD3 | #0E8999 |
| `SemiCyan4Color` | #2CB8C5 | #13A8B8 |
| `SemiCyan5Color` | #05A4B6 | #38BBC6 |
| `SemiCyan6Color` | #038698 | #62CDD4 |
| `SemiCyan7Color` | #016979 | #91DFE3 |
| `SemiCyan8Color` | #004D5B | #C6EFF1 |
| `SemiCyan9Color` | #00323D | #E7F7F8 |
| `SemiTeal0Color` | #E4F7F4 | #023C39 |
| `SemiTeal1Color` | #C0F0E8 | #045A55 |
| `SemiTeal2Color` | #87E0D3 | #07776F |
| `SemiTeal3Color` | #54D1C1 | #0A9588 |
| `SemiTeal4Color` | #27C2B0 | #0EB3A1 |
| `SemiTeal5Color` | #00B3A1 | #33C2B0 |
| `SemiTeal6Color` | #009589 | #5ED1C1 |
| `SemiTeal7Color` | #00776F | #8EE1D3 |
| `SemiTeal8Color` | #005955 | #C4F0E8 |
| `SemiTeal9Color` | #003C3A | #E6F7F4 |
| `SemiGreen0Color` | #ECF7EC | #123C19 |
| `SemiGreen1Color` | #D0F0D1 | #1C5A25 |
| `SemiGreen2Color` | #A4E0A7 | #277731 |
| `SemiGreen3Color` | #7DD182 | #32953D |
| `SemiGreen4Color` | #5AC262 | #3EB349 |
| `SemiGreen5Color` | #3BB346 | #5DC264 |
| `SemiGreen6Color` | #30953B | #7FD184 |
| `SemiGreen7Color` | #25772F | #A6E1A8 |
| `SemiGreen8Color` | #1B5924 | #D0F0D1 |
| `SemiGreen9Color` | #113C18 | #ECF7EC |
| `SemiLightGreen0Color` | #F3F8EC | #263D13 |
| `SemiLightGreen1Color` | #E3F0D0 | #3B5C1D |
| `SemiLightGreen2Color` | #C8E2A5 | #517B28 |
| `SemiLightGreen3Color` | #ADD37E | #679934 |
| `SemiLightGreen4Color` | #93C55B | #7FB840 |
| `SemiLightGreen5Color` | #7BB63C | #97C65F |
| `SemiLightGreen6Color` | #649830 | #B0D481 |
| `SemiLightGreen7Color` | #4E7926 | #C9E3A7 |
| `SemiLightGreen8Color` | #395B1B | #E4F1D1 |
| `SemiLightGreen9Color` | #253D12 | #F3F8ED |
| `SemiLime0Color` | #F2FAE6 | #314603 |
| `SemiLime1Color` | #E3F6C5 | #4B6905 |
| `SemiLime2Color` | #CBED8E | #678D09 |
| `SemiLime3Color` | #B7E35B | #84B00C |
| `SemiLime4Color` | #A7DA2C | #A2D311 |
| `SemiLime5Color` | #9BD100 | #AEDC3A |
| `SemiLime6Color` | #7EAE00 | #BDE566 |
| `SemiLime7Color` | #638B00 | #CFED96 |
| `SemiLime8Color` | #486800 | #E5F6C9 |
| `SemiLime9Color` | #2F4600 | #F3FBE9 |
| `SemiYellow0Color` | #FFFDEA | #544903 |
| `SemiYellow1Color` | #FEFBCB | #7E6C06 |
| `SemiYellow2Color` | #FDF398 | #A88E0A |
| `SemiYellow3Color` | #FCE865 | #D2AF0F |
| `SemiYellow4Color` | #FBDA32 | #FCCE14 |
| `SemiYellow5Color` | #FAC800 | #FDDE43 |
| `SemiYellow6Color` | #D0AA00 | #FDEB71 |
| `SemiYellow7Color` | #A78B00 | #FEF5A0 |
| `SemiYellow8Color` | #7D6A00 | #FEFBD0 |
| `SemiYellow9Color` | #534800 | #FFFEEC |
| `SemiAmber0Color` | #FEFBEB | #512E09 |
| `SemiAmber1Color` | #FCF5CE | #794B0F |
| `SemiAmber2Color` | #F9E89E | #A16B16 |
| `SemiAmber3Color` | #F6D86F | #CA8F1E |
| `SemiAmber4Color` | #F3C641 | #F2B726 |
| `SemiAmber5Color` | #F0B114 | #F5CA50 |
| `SemiAmber6Color` | #C88A0F | #F7DB7A |
| `SemiAmber7Color` | #A0660A | #FAEAA6 |
| `SemiAmber8Color` | #784606 | #FCF6D2 |
| `SemiAmber9Color` | #502B03 | #FEFBED |
| `SemiOrange0Color` | #FFF8EA | #551F03 |
| `SemiOrange1Color` | #FEEECC | #803506 |
| `SemiOrange2Color` | #FED998 | #AA500A |
| `SemiOrange3Color` | #FDC165 | #D56F0F |
| `SemiOrange4Color` | #FDA633 | #FF9214 |
| `SemiOrange5Color` | #FC8800 | #FFAE43 |
| `SemiOrange6Color` | #D26700 | #FFC772 |
| `SemiOrange7Color` | #A84A00 | #FFDDA1 |
| `SemiOrange8Color` | #7E3100 | #FFEFD0 |
| `SemiOrange9Color` | #541D00 | #FFF9ED |
| `SemiGrey0Color` | #F9F9F9 | #1C1F23 |
| `SemiGrey1Color` | #E6E8EA | #2E3238 |
| `SemiGrey2Color` | #C6CACD | #41464C |
| `SemiGrey3Color` | #A7ABB0 | #555B61 |
| `SemiGrey4Color` | #888D92 | #6B7075 |
| `SemiGrey5Color` | #6B7075 | #888D92 |
| `SemiGrey6Color` | #555B61 | #A7ABB0 |
| `SemiGrey7Color` | #41464C | #C6CACD |
| `SemiGrey8Color` | #2E3238 | #E6E8EA |
| `SemiGrey9Color` | #1C1F23 | #F9F9F9 |
| `SemiBackground0Color` | White | #16161A |
| `SemiBackground1Color` | White | #232429 |
| `SemiBackground2Color` | White | #35363C |
| `SemiBackground3Color` | White | #43444A |
| `SemiBackground4Color` | White | #4F5159 |
| `SemiAIPurple0Color` | #F8EDFF | #3A1770 |
| `SemiAIPurple1Color` | #F2DAFF | #532394 |
| `SemiAIPurple2Color` | #E3B5FF | #6F31B8 |
| `SemiAIPurple3Color` | #D191FF | #8D41DB |
| `SemiAIPurple4Color` | #BD6CFF | #A744FF |
| `SemiAIPurple5Color` | #A647FF | #C375FF |
| `SemiAIPurple6Color` | #8636DB | #D598FF |
| `SemiAIPurple7Color` | #6928B8 | #E5BAFF |
| `SemiAIPurple8Color` | #4E1C94 | #F3DDFF |
| `SemiAIPurple9Color` | #361270 | #FBF3FF |

## Semantic color tokens

The brushes controls actually consume; the ones to override when re-branding.

| Key | Light | Dark |
|---|---|---|
| `SemiWhite` | White | White |
| `SemiBlack` | Black | Black |
| `SemiRed0` | #FEF2ED | #6C090B |
| `SemiRed1` | #FEDDD2 | #901110 |
| `SemiRed2` | #FDB7A5 | #B42019 |
| `SemiRed3` | #FB9078 | #D73324 |
| `SemiRed4` | #FA664C | #FB4932 |
| `SemiRed5` | #F93920 | #FC725A |
| `SemiRed6` | #D52515 | #FD9983 |
| `SemiRed7` | #B2140C | #FDBEAC |
| `SemiRed8` | #8E0805 | #FEE0D5 |
| `SemiRed9` | #6A0103 | #FFF3EF |
| `SemiPink0` | #FDECEF | #5C0730 |
| `SemiPink1` | #FBCFD8 | #800E41 |
| `SemiPink2` | #F6A0B5 | #A41751 |
| `SemiPink3` | #F27396 | #C72261 |
| `SemiPink4` | #ED487B | #EB2F71 |
| `SemiPink5` | #E91E63 | #EF5686 |
| `SemiPink6` | #C51356 | #F37E9F |
| `SemiPink7` | #A20B48 | #F7A8BC |
| `SemiPink8` | #7E053A | #FBD3DC |
| `SemiPink9` | #5A012B | #FDEEF1 |
| `SemiPurple0` | #F7E9F7 | #4A1061 |
| `SemiPurple1` | #EFCAF0 | #5E1776 |
| `SemiPurple2` | #DD9BE0 | #731F8A |
| `SemiPurple3` | #C96FD1 | #89289F |
| `SemiPurple4` | #B449C2 | #A033B3 |
| `SemiPurple5` | #9E28B3 | #B553C2 |
| `SemiPurple6` | #871E9E | #CA78D1 |
| `SemiPurple7` | #71168A | #DDA0E1 |
| `SemiPurple8` | #5C0F75 | #EFCEF0 |
| `SemiPurple9` | #490A61 | #F7EBF7 |
| `SemiViolet0` | #F3EDF9 | #401B77 |
| `SemiViolet1` | #E2D1F4 | #4C248C |
| `SemiViolet2` | #C4A7E9 | #582EA0 |
| `SemiViolet3` | #A67FDD | #6439B5 |
| `SemiViolet4` | #885BD2 | #7246C9 |
| `SemiViolet5` | #6A3AC7 | #8865D4 |
| `SemiViolet6` | #572FB3 | #A288DF |
| `SemiViolet7` | #46259E | #BEADE9 |
| `SemiViolet8` | #361C8A | #DDD4F4 |
| `SemiViolet9` | #281475 | #F1EEFA |
| `SemiIndigo0` | #ECEFF8 | #171E65 |
| `SemiIndigo1` | #D1D8F0 | #20297A |
| `SemiIndigo2` | #A7B3E1 | #29368E |
| `SemiIndigo3` | #8090D3 | #3444A3 |
| `SemiIndigo4` | #5E6FC4 | #4053B7 |
| `SemiIndigo5` | #3F51B5 | #5F71C5 |
| `SemiIndigo6` | #3342A1 | #8191D4 |
| `SemiIndigo7` | #28348C | #A7B4E2 |
| `SemiIndigo8` | #1F2878 | #D1D8F1 |
| `SemiIndigo9` | #171D63 | #EDEFF8 |
| `SemiBlue0` | #EAF5FF | #053170 |
| `SemiBlue1` | #CBE7FE | #0A4694 |
| `SemiBlue2` | #98CDFD | #135CB8 |
| `SemiBlue3` | #65B2FC | #1D75DB |
| `SemiBlue4` | #3295FB | #2990FF |
| `SemiBlue5` | #0064FA | #54A9FF |
| `SemiBlue6` | #0062D6 | #7FC1FF |
| `SemiBlue7` | #004FB3 | #A9D7FF |
| `SemiBlue8` | #003D8F | #D4ECFF |
| `SemiBlue9` | #002C6B | #EFF8FF |
| `SemiLightBlue0` | #E9F7FD | #003761 |
| `SemiLightBlue1` | #C9ECFC | #004D85 |
| `SemiLightBlue2` | #95D8F8 | #0366A9 |
| `SemiLightBlue3` | #62C3F5 | #0A81CC |
| `SemiLightBlue4` | #30ACF1 | #139FF0 |
| `SemiLightBlue5` | #0095EE | #40B4F3 |
| `SemiLightBlue6` | #007BCA | #6EC8F6 |
| `SemiLightBlue7` | #0063A7 | #9DDCF9 |
| `SemiLightBlue8` | #004B83 | #CEEEFC |
| `SemiLightBlue9` | #00355F | #EBF8FE |
| `SemiCyan0` | #E5F7F8 | #04343D |
| `SemiCyan1` | #C2EFF0 | #074F5C |
| `SemiCyan2` | #8ADDE2 | #0A6C7B |
| `SemiCyan3` | #58CBD3 | #0E8999 |
| `SemiCyan4` | #2CB8C5 | #13A8B8 |
| `SemiCyan5` | #05A4B6 | #38BBC6 |
| `SemiCyan6` | #038698 | #62CDD4 |
| `SemiCyan7` | #016979 | #91DFE3 |
| `SemiCyan8` | #004D5B | #C6EFF1 |
| `SemiCyan9` | #00323D | #E7F7F8 |
| `SemiTeal0` | #E4F7F4 | #023C39 |
| `SemiTeal1` | #C0F0E8 | #045A55 |
| `SemiTeal2` | #87E0D3 | #07776F |
| `SemiTeal3` | #54D1C1 | #0A9588 |
| `SemiTeal4` | #27C2B0 | #0EB3A1 |
| `SemiTeal5` | #00B3A1 | #33C2B0 |
| `SemiTeal6` | #009589 | #5ED1C1 |
| `SemiTeal7` | #00776F | #8EE1D3 |
| `SemiTeal8` | #005955 | #C4F0E8 |
| `SemiTeal9` | #003C3A | #E6F7F4 |
| `SemiGreen0` | #ECF7EC | #123C19 |
| `SemiGreen1` | #D0F0D1 | #1C5A25 |
| `SemiGreen2` | #A4E0A7 | #277731 |
| `SemiGreen3` | #7DD182 | #32953D |
| `SemiGreen4` | #5AC262 | #3EB349 |
| `SemiGreen5` | #3BB346 | #5DC264 |
| `SemiGreen6` | #30953B | #7FD184 |
| `SemiGreen7` | #25772F | #A6E1A8 |
| `SemiGreen8` | #1B5924 | #D0F0D1 |
| `SemiGreen9` | #113C18 | #ECF7EC |
| `SemiLightGreen0` | #F3F8EC | #263D13 |
| `SemiLightGreen1` | #E3F0D0 | #3B5C1D |
| `SemiLightGreen2` | #C8E2A5 | #517B28 |
| `SemiLightGreen3` | #ADD37E | #679934 |
| `SemiLightGreen4` | #93C55B | #7FB840 |
| `SemiLightGreen5` | #7BB63C | #97C65F |
| `SemiLightGreen6` | #649830 | #B0D481 |
| `SemiLightGreen7` | #4E7926 | #C9E3A7 |
| `SemiLightGreen8` | #395B1B | #E4F1D1 |
| `SemiLightGreen9` | #253D12 | #F3F8ED |
| `SemiLime0` | #F2FAE6 | #314603 |
| `SemiLime1` | #E3F6C5 | #4B6905 |
| `SemiLime2` | #CBED8E | #678D09 |
| `SemiLime3` | #B7E35B | #84B00C |
| `SemiLime4` | #A7DA2C | #A2D311 |
| `SemiLime5` | #9BD100 | #AEDC3A |
| `SemiLime6` | #7EAE00 | #BDE566 |
| `SemiLime7` | #638B00 | #CFED96 |
| `SemiLime8` | #486800 | #E5F6C9 |
| `SemiLime9` | #2F4600 | #F3FBE9 |
| `SemiYellow0` | #FFFDEA | #544903 |
| `SemiYellow1` | #FEFBCB | #7E6C06 |
| `SemiYellow2` | #FDF398 | #A88E0A |
| `SemiYellow3` | #FCE865 | #D2AF0F |
| `SemiYellow4` | #FBDA32 | #FCCE14 |
| `SemiYellow5` | #FAC800 | #FDDE43 |
| `SemiYellow6` | #D0AA00 | #FDEB71 |
| `SemiYellow7` | #A78B00 | #FEF5A0 |
| `SemiYellow8` | #7D6A00 | #FEFBD0 |
| `SemiYellow9` | #534800 | #FFFEEC |
| `SemiAmber0` | #FEFBEB | #512E09 |
| `SemiAmber1` | #FCF5CE | #794B0F |
| `SemiAmber2` | #F9E89E | #A16B16 |
| `SemiAmber3` | #F6D86F | #CA8F1E |
| `SemiAmber4` | #F3C641 | #F2B726 |
| `SemiAmber5` | #F0B114 | #F5CA50 |
| `SemiAmber6` | #C88A0F | #F7DB7A |
| `SemiAmber7` | #A0660A | #FAEAA6 |
| `SemiAmber8` | #784606 | #FCF6D2 |
| `SemiAmber9` | #502B03 | #FEFBED |
| `SemiOrange0` | #FFF8EA | #551F03 |
| `SemiOrange1` | #FEEECC | #803506 |
| `SemiOrange2` | #FED998 | #AA500A |
| `SemiOrange3` | #FDC165 | #D56F0F |
| `SemiOrange4` | #FDA633 | #FF9214 |
| `SemiOrange5` | #FC8800 | #FFAE43 |
| `SemiOrange6` | #D26700 | #FFC772 |
| `SemiOrange7` | #A84A00 | #FFDDA1 |
| `SemiOrange8` | #7E3100 | #FFEFD0 |
| `SemiOrange9` | #541D00 | #FFF9ED |
| `SemiGrey0` | #F9F9F9 | #1C1F23 |
| `SemiGrey1` | #E6E8EA | #2E3238 |
| `SemiGrey2` | #C6CACD | #41464C |
| `SemiGrey3` | #A7ABB0 | #555B61 |
| `SemiGrey4` | #888D92 | #6B7075 |
| `SemiGrey5` | #6B7075 | #888D92 |
| `SemiGrey6` | #555B61 | #A7ABB0 |
| `SemiGrey7` | #41464C | #C6CACD |
| `SemiGrey8` | #2E3238 | #E6E8EA |
| `SemiGrey9` | #1C1F23 | #F9F9F9 |
| `SemiAIPurple0` | #F8EDFF | #3A1770 |
| `SemiAIPurple1` | #F2DAFF | #532394 |
| `SemiAIPurple2` | #E3B5FF | #6F31B8 |
| `SemiAIPurple3` | #D191FF | #8D41DB |
| `SemiAIPurple4` | #BD6CFF | #A744FF |
| `SemiAIPurple5` | #A647FF | #C375FF |
| `SemiAIPurple6` | #8636DB | #D598FF |
| `SemiAIPurple7` | #6928B8 | #E5BAFF |
| `SemiAIPurple8` | #4E1C94 | #F3DDFF |
| `SemiAIPurple9` | #361270 | #FBF3FF |
| `SemiColorWhite` | White | White |
| `SemiColorBlack` | Black | Black |
| `SemiColorPrimary` | #0064FA | #54A9FF |
| `SemiColorPrimaryPointerover` | #0062D6 | #7FC1FF |
| `SemiColorPrimaryActive` | #004FB3 | #A9D7FF |
| `SemiColorPrimaryDisabled` | #98CDFD | #135CB8 |
| `SemiColorPrimaryLight` | #EAF5FF | ref:SemiBlue5Color @ 0.2 opacity |
| `SemiColorPrimaryLightPointerover` | #CBE7FE | ref:SemiBlue5Color @ 0.3 opacity |
| `SemiColorPrimaryLightActive` | #98CDFD | ref:SemiBlue5Color @ 0.4 opacity |
| `SemiColorSecondary` | #0095EE | #40B4F3 |
| `SemiColorSecondaryPointerover` | #007BCA | #6EC8F6 |
| `SemiColorSecondaryActive` | #0063A7 | #9DDCF9 |
| `SemiColorSecondaryDisabled` | #95D8F8 | #0366A9 |
| `SemiColorSecondaryLight` | #E9F7FD | ref:SemiLightBlue5Color @ 0.2 opacity |
| `SemiColorSecondaryLightPointerover` | #C9ECFC | ref:SemiLightBlue5Color @ 0.3 opacity |
| `SemiColorSecondaryLightActive` | #95D8F8 | ref:SemiLightBlue5Color @ 0.4 opacity |
| `SemiColorTertiary` | #6B7075 | #888D92 |
| `SemiColorTertiaryPointerover` | #555B61 | #A7ABB0 |
| `SemiColorTertiaryActive` | #41464C | #C6CACD |
| `SemiColorTertiaryLight` | #F9F9F9 | ref:SemiGrey5Color @ 0.2 opacity |
| `SemiColorTertiaryLightPointerover` | #E6E8EA | ref:SemiGrey5Color @ 0.3 opacity |
| `SemiColorTertiaryLightActive` | #C6CACD | ref:SemiGrey5Color @ 0.4 opacity |
| `SemiColorInformation` | #0064FA | #54A9FF |
| `SemiColorInformationPointerover` | #0062D6 | #7FC1FF |
| `SemiColorInformationActive` | #004FB3 | #A9D7FF |
| `SemiColorInformationDisabled` | #98CDFD | #135CB8 |
| `SemiColorInformationLight` | #EAF5FF | ref:SemiBlue5Color @ 0.2 opacity |
| `SemiColorInformationLightPointerover` | #CBE7FE | ref:SemiBlue5Color @ 0.3 opacity |
| `SemiColorInformationLightActive` | #98CDFD | ref:SemiBlue5Color @ 0.4 opacity |
| `SemiColorSuccess` | #3BB346 | #5DC264 |
| `SemiColorSuccessPointerover` | #30953B | #7FD184 |
| `SemiColorSuccessActive` | #25772F | #A6E1A8 |
| `SemiColorSuccessDisabled` | #A4E0A7 | #277731 |
| `SemiColorSuccessLight` | #ECF7EC | ref:SemiGreen5Color @ 0.2 opacity |
| `SemiColorSuccessLightPointerover` | #D0F0D1 | ref:SemiGreen5Color @ 0.3 opacity |
| `SemiColorSuccessLightActive` | #A4E0A7 | ref:SemiGreen5Color @ 0.4 opacity |
| `SemiColorWarning` | #FC8800 | #FFAE43 |
| `SemiColorWarningPointerover` | #D26700 | #FFC772 |
| `SemiColorWarningActive` | #A84A00 | #FFDDA1 |
| `SemiColorWarningLight` | #FFF8EA | ref:SemiOrange5Color @ 0.2 opacity |
| `SemiColorWarningLightPointerover` | #FEEECC | ref:SemiOrange5Color @ 0.3 opacity |
| `SemiColorWarningLightActive` | #FED998 | ref:SemiOrange5Color @ 0.4 opacity |
| `SemiColorDanger` | #F93920 | #FC725A |
| `SemiColorDangerPointerover` | #D52515 | #FD9983 |
| `SemiColorDangerActive` | #B2140C | #FDBEAC |
| `SemiColorDangerLight` | #FEF2ED | ref:SemiRed5Color @ 0.2 opacity |
| `SemiColorDangerLightPointerover` | #FEDDD2 | ref:SemiRed5Color @ 0.3 opacity |
| `SemiColorDangerLightActive` | #FDB7A5 | ref:SemiRed5Color @ 0.4 opacity |
| `SemiColorAIPurple` | #A647FF | #C375FF |
| `SemiColorAIPurplePointerover` | #8636DB | #D598FF |
| `SemiColorAIPurpleActive` | #6928B8 | #E5BAFF |
| `SemiColorAIPurpleDisabled` | #E3B5FF | #6F31B8 |
| `SemiColorText0` | #1C1F23 | #F9F9F9 |
| `SemiColorText1` | ref:SemiGrey9Color @ 0.8 opacity | ref:SemiGrey9Color @ 0.8 opacity |
| `SemiColorText2` | ref:SemiGrey9Color @ 0.62 opacity | ref:SemiGrey9Color @ 0.6 opacity |
| `SemiColorText3` | ref:SemiGrey9Color @ 0.35 opacity | ref:SemiGrey9Color @ 0.35 opacity |
| `SemiColorLink` | #0064FA | #54A9FF |
| `SemiColorLinkPointerover` | #0062D6 | #7FC1FF |
| `SemiColorLinkActive` | #004FB3 | #A9D7FF |
| `SemiColorLinkVisited` | #0064FA | #54A9FF |
| `SemiColorBackground0` | White | #16161A |
| `SemiColorBackground1` | White | #232429 |
| `SemiColorBackground2` | White | #35363C |
| `SemiColorBackground3` | White | #43444A |
| `SemiColorBackground4` | White | #4F5159 |
| `SemiColorFill0` | ref:SemiGrey8Color @ 0.05 opacity | ref:SemiWhiteColor @ 0.12 opacity |
| `SemiColorFill1` | ref:SemiGrey8Color @ 0.09 opacity | ref:SemiWhiteColor @ 0.16 opacity |
| `SemiColorFill2` | ref:SemiGrey8Color @ 0.13 opacity | ref:SemiWhiteColor @ 0.20 opacity |
| `SemiColorBorder` | ref:SemiGrey9Color @ 0.08 opacity | ref:SemiWhiteColor @ 0.08 opacity |
| `SemiColorFocusBorder` | #0064FA | #54A9FF |
| `SemiColorDisabledText` | ref:SemiGrey9Color @ 0.35 opacity | ref:SemiGrey9Color @ 0.35 opacity |
| `SemiColorDisabledBorder` | #E6E8EA | #2E3238 |
| `SemiColorDisabledBackground` | #E6E8EA | #2E3238 |
| `SemiColorDisabledFill` | ref:SemiGrey8Color @ 0.02 opacity | ref:SemiGrey8Color @ 0.04 opacity |
| `SemiColorNavBackground` | White | #232429 |
| `SemiColorOverlayBackground` | #16161A @ 0.6 opacity | ref:SemiBackground0Color @ 0.6 opacity |
| `SemiColorHighlightBackground` | #FDF398 | #FCCE14 |
| `SemiColorHighlight` | White | Black |
| `SemiAIGeneral0` | gradient | gradient |
| `SemiAIGeneral1` | gradient | gradient |
| `SemiAIGeneral2` | gradient | gradient |
| `SemiAIGeneral3` | gradient | gradient |
| `SemiAIGeneral4` | gradient | gradient |
| `SemiAIGeneral5` | gradient | gradient |
| `SemiAIGeneral6` | gradient | gradient |
| `SemiAIGeneral7` | gradient | gradient |
| `SemiAIGeneral8` | gradient | gradient |
| `SemiAIGeneral9` | gradient | gradient |
| `SemiColorAIGeneral` | gradient | gradient |
| `SemiColorAIGeneralPointerover` | gradient | gradient |
| `SemiColorAIGeneralActive` | gradient | gradient |
| `SemiColorAIGeneralDisabled` | gradient | gradient |
| `SemiColorAIBackgroundBottom` | gradient | gradient |
| `SemiColorAIBackgroundBottomPointerover` | gradient | gradient |
| `SemiColorAIBackgroundBottomActive` | gradient | gradient |
| `SemiColorAIBackgroundTop` | gradient | gradient |
| `SemiColorAIBackgroundTopPointerover` | gradient | gradient |
| `SemiColorAIBackgroundTopActive` | gradient | gradient |

## High-contrast presets

Each preset theme overrides only the keys below; every other key is inherited from its parent Light/Dark variant. Keys without the `Semi` prefix are the preset's private helper colors.

### Aquatic

| Key | Kind | Value |
|---|---|---|
| `ButtonFaceColor` | Color | #202020 |
| `ButtonTextColor` | Color | #FFFFFF |
| `GrayTextColor` | Color | #A6A6A6 |
| `HighlightColor` | Color | #8EE3F0 |
| `HighlightTextColor` | Color | #263B50 |
| `HotlightColor` | Color | #75E9FC |
| `SemiColorButtonFace` | Brush | #202020 |
| `SemiColorButtonText` | Brush | #FFFFFF |
| `SemiColorGrayText` | Brush | #A6A6A6 |
| `SemiColorHighlight` | Brush | #8EE3F0 |
| `SemiColorHighlightText` | Brush | #263B50 |
| `SemiColorHotlight` | Brush | #75E9FC |
| `SemiColorWindow` | Brush | #202020 |
| `SemiColorWindowText` | Brush | #FFFFFF |
| `WindowColor` | Color | #202020 |
| `WindowTextColor` | Color | #FFFFFF |

### Desert

| Key | Kind | Value |
|---|---|---|
| `ButtonFaceColor` | Color | #FFFAEF |
| `ButtonTextColor` | Color | #202020 |
| `GrayTextColor` | Color | #676767 |
| `HighlightColor` | Color | #903909 |
| `HighlightTextColor` | Color | #FFF5E3 |
| `HotlightColor` | Color | #1C5E75 |
| `SemiColorButtonFace` | Brush | #FFFAEF |
| `SemiColorButtonText` | Brush | #202020 |
| `SemiColorGrayText` | Brush | #676767 |
| `SemiColorHighlight` | Brush | #903909 |
| `SemiColorHighlightText` | Brush | #FFF5E3 |
| `SemiColorHotlight` | Brush | #1C5E75 |
| `SemiColorWindow` | Brush | #FFFAEF |
| `SemiColorWindowText` | Brush | #3D3D3D |
| `WindowColor` | Color | #FFFAEF |
| `WindowTextColor` | Color | #3D3D3D |

### Dusk

| Key | Kind | Value |
|---|---|---|
| `ButtonFaceColor` | Color | #2D3236 |
| `ButtonTextColor` | Color | #B6F6F0 |
| `GrayTextColor` | Color | #A6A6A6 |
| `HighlightColor` | Color | #A1BFDE |
| `HighlightTextColor` | Color | #212D3B |
| `HotlightColor` | Color | #70EBDE |
| `SemiColorButtonFace` | Brush | #2D3236 |
| `SemiColorButtonText` | Brush | #B6F6F0 |
| `SemiColorGrayText` | Brush | #A6A6A6 |
| `SemiColorHighlight` | Brush | #A1BFDE |
| `SemiColorHighlightText` | Brush | #212D3B |
| `SemiColorHotlight` | Brush | #70EBDE |
| `SemiColorWindow` | Brush | #2D3236 |
| `SemiColorWindowText` | Brush | #FFFFFF |
| `WindowColor` | Color | #2D3236 |
| `WindowTextColor` | Color | #FFFFFF |

### NightSky

| Key | Kind | Value |
|---|---|---|
| `ButtonFaceColor` | Color | #000000 |
| `ButtonTextColor` | Color | #FFEE32 |
| `GrayTextColor` | Color | #A6A6A6 |
| `HighlightColor` | Color | #D6B4FD |
| `HighlightTextColor` | Color | #2B2B2B |
| `HotlightColor` | Color | #8080FF |
| `SemiColorButtonFace` | Brush | #000000 |
| `SemiColorButtonText` | Brush | #FFEE32 |
| `SemiColorGrayText` | Brush | #A6A6A6 |
| `SemiColorHighlight` | Brush | #D6B4FD |
| `SemiColorHighlightText` | Brush | #2B2B2B |
| `SemiColorHotlight` | Brush | #8080FF |
| `SemiColorWindow` | Brush | #000000 |
| `SemiColorWindowText` | Brush | #FFFFFF |
| `WindowColor` | Color | #000000 |
| `WindowTextColor` | Color | #FFFFFF |
