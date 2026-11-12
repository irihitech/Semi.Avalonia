# Customizing Semi.Avalonia

## Switching themes

```xml
<Application RequestedThemeVariant="Dark">   <!-- Light, Dark, or Default (follows the system) -->
```

```csharp
Application.Current!.RequestedThemeVariant = ThemeVariant.Dark;
```

Four extra palettes ship as theme variants: `SemiTheme.Aquatic`, `SemiTheme.Desert`, `SemiTheme.Dusk`, `SemiTheme.NightSky` (Aquatic, Desert, Dusk, NightSky):

```csharp
Application.Current!.RequestedThemeVariant = SemiTheme.Dusk;
```

## Locale

`<semi:SemiTheme Locale="zh-CN" />` localizes the text Avalonia's own controls show (TextBox cut/copy/paste, Calendar, …). 16 locales are built in. To change it at run time, call `SemiTheme.OverrideLocaleResources(application, culture)`.

## Overriding tokens (the right way to re-brand)

Redefine the resource keys — in your App.xaml for the whole application, or in any control's `Resources` for one subtree. Both Light and Dark read the same keys, so one override covers both.

```xml
<Application.Resources>
    <SolidColorBrush x:Key="SemiColorPrimary" Color="#7C3AED" />
    <CornerRadius x:Key="SemiBorderRadiusMedium">8</CornerRadius>
</Application.Resources>
```

The complete key list with values is in [tokens.md](https://irihitech.github.io/Semi.Avalonia/tokens.md); per-control keys are listed on each control's page.

## Overriding a single control

Controls read their geometry and colors from control-scoped keys (`TextBoxDefaultHeight`, `ButtonSolidPrimaryBackground`, …). Override those to adjust one control; switch whole looks with the ControlTheme variants from the control's page.

## When an override does not apply

- SemiTheme is missing from Application.Styles, or Fluent/Simple is loaded after it.
- The key is spelled differently from the one in tokens.md or the control's page.
- The value was set on a scope the control does not read (app resources vs. the control's own `Resources`).

## Satellite packages

```bash
dotnet add package Semi.Avalonia.DataGrid        # Avalonia's DataGrid
dotnet add package Semi.Avalonia.TreeDataGrid    # TreeDataGrid
dotnet add package Semi.Avalonia.ColorPicker     # ColorPicker family
```

Each needs the main Semi.Avalonia theme present. For controls Avalonia and Semi do not have, see [Ursa](https://github.com/irihitech/Ursa.Avalonia).