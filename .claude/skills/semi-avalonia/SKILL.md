---
name: semi-avalonia
description: Themes and restyles Avalonia applications with Semi.Avalonia, the Semi Design theme for Avalonia's built-in controls. Picks the right style classes and ControlTheme variants, sets up light/dark/high-contrast themes and locales, and overrides resource keys instead of hard-coding values. Use when a project references Semi.Avalonia or Semi.Avalonia.* packages, when XAML contains xmlns semi="https://irihi.tech/semi" or <semi:SemiTheme, or when asked to theme, restyle or re-brand an Avalonia app, switch light/dark mode, or customize Semi colors, radii or spacing.
---

# Semi.Avalonia

Semi.Avalonia (12.1.0.1) themes the controls Avalonia already has — it adds no controls. One style in App.xaml is the whole setup; everything else is style classes, ControlTheme variants and resource keys.

## Workflow

```
Semi task:
- [ ] 1. Apply: <semi:SemiTheme Locale="..."/> alone in Application.Styles, RequestedThemeVariant set
- [ ] 2. Identify: the control is an Avalonia built-in; the difference wanted is a class, a variant or a token
- [ ] 3. Style: only classes/variants from the control's page (reference/classes.md), never invented ones
- [ ] 4. Customize: override resource keys from reference/tokens.md — never hex literals
- [ ] 5. Review: run checklist.md
```

**Apply.** `xmlns:semi="https://irihi.tech/semi"`, `<semi:SemiTheme Locale="en-US" />` in `Application.Styles`. No Fluent or Simple theme next to it. Light/Dark via `RequestedThemeVariant`; extra palettes `SemiTheme.Aquatic/Desert/Dusk/NightSky`.

**Style.** `Classes="Primary"` and `Theme="{DynamicResource SolidButton}"`. Class names are case-insensitive and combine. The full catalog is in [reference/classes.md](reference/classes.md); per-control detail and demo XAML live at https://irihitech.github.io/Semi.Avalonia/controls/<name>.md.

**Customize.** Override `Semi*` resource keys (app-wide in App.xaml, per-subtree in a control's Resources). Keys are string literals, so copy them exactly — a mistyped key fails silently. All keys with values: [reference/tokens.md](reference/tokens.md). Patterns and troubleshooting: [reference/customization.md](reference/customization.md).

## Core rules

1. **Avalonia built-ins only.** There is no `semi:Button`. Write `Button`; SemiTheme styles it. New controls belong to Ursa.
2. **Documented names only.** A class, variant or key not in the pages is invented and fails silently.
3. **Tokens, not values.** No hex colors, no magic numbers; override the key so Light/Dark both follow.
4. **One theme source.** SemiTheme alone; never mix Fluent or Simple into the same app.

## Satellites

`Semi.Avalonia.DataGrid`, `Semi.Avalonia.TreeDataGrid`, `Semi.Avalonia.ColorPicker` — same pattern, separate packages, main theme required.