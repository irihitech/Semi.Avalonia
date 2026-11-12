# Semi.Avalonia review checklist

Run over any screen the assistant styled with Semi.Avalonia before calling it done.

- [ ] `<semi:SemiTheme />` is the only theme style in Application.Styles; no Fluent, no Simple.
- [ ] Every `Classes="…"` value appears in the control's page or reference/classes.md.
- [ ] Every `Theme="{DynamicResource …}"` is a ControlTheme variant listed for that control.
- [ ] No hard-coded `Color="#…"` in XAML; every color/radius/spacing reads a `Semi*` key.
- [ ] Every overridden `x:Key` is listed in tokens.md or the control's page.
- [ ] Overridden keys that differ between light and dark are overridden in a scope that covers both variants.
- [ ] `RequestedThemeVariant` handles Default (system); the app looks right in Light AND Dark (and a high-contrast palette if used).
- [ ] `Locale` on SemiTheme is set when built-in control text is user-visible.
- [ ] DataGrid/TreeDataGrid/ColorPicker screens reference their satellite package.