using System.Text;
using System.Text.RegularExpressions;

namespace Semi.Avalonia.Llms;

/// <summary>A file of the site: its path below the web root, such as <c>tokens.md</c>, and its text.</summary>
public sealed record LlmsFile(string Path, string Text);

/// <summary>Builds every Markdown and text file the site serves to AI assistants from the extracted <see cref="Library"/>.</summary>
public static class Pages
{
    public const string DefaultBaseUrl = "https://irihitech.github.io/Semi.Avalonia";
    public const string SkillName = "semi-avalonia";
    private const string Repository = "https://github.com/irihitech/Semi.Avalonia";

    public static IReadOnlyList<LlmsFile> Build(Library lib, string baseUrl)
    {
        baseUrl = baseUrl.TrimEnd('/');
        var pages = lib.Controls.Where(c => c.Demo is not null).ToArray();
        var catalog = lib.Controls.Where(c => c.Demo is null).ToArray();
        var values = new Dictionary<string, string>
        {
            ["base"] = baseUrl,
            ["version"] = lib.Version,
            ["avalonia"] = lib.AvaloniaVersion,
            ["repository"] = Repository,
            ["skill"] = $"{baseUrl}/skills/{SkillName}",
            ["token-count"] = lib.Tokens.Count.ToString(),
            ["brush-count"] = lib.PaletteBrushes.Count.ToString(),
            ["color-count"] = lib.PaletteColors.Count.ToString(),
            ["demo-count"] = pages.Length.ToString(),
            ["locale-count"] = lib.Locales.Count.ToString(),
            ["preset-list"] = string.Join(", ", lib.HighContrastPresets.Select(p => p.Name)),
            ["skill-name"] = SkillName,
            ["controls-index"] = IndexOf(lib, baseUrl),
        };

        var tokens = TokensPage(lib, baseUrl);
        var customization = Fill(CustomizationText, values, lib);
        var classes = ClassesCatalog(lib, baseUrl);
        var files = new List<LlmsFile>
        {
            new("llms.txt", Fill(LlmsIndex, values, lib)),
            new("tokens.md", tokens),
            new("customization.md", customization),
        };
        foreach (var control in pages)
            files.Add(new($"controls/{control.Name}.md", ControlPage(control, baseUrl)));
        files.Add(new($"skills/{SkillName}/SKILL.md", Fill(SkillText, values, lib)));
        files.Add(new($"skills/{SkillName}/checklist.md", Fill(ChecklistText, values, lib)));
        files.Add(new($"skills/{SkillName}/reference/tokens.md", tokens));
        files.Add(new($"skills/{SkillName}/reference/customization.md", customization));
        files.Add(new($"skills/{SkillName}/reference/classes.md", classes));

        var full = new StringBuilder("# Semi.Avalonia — every page in one file\n\nVersion ").Append(lib.Version).Append("\n\n");
        foreach (var file in files.Where(f => f.Path != "llms.txt" && !f.Path.StartsWith("skills/", StringComparison.Ordinal)))
            full.Append("\n\n---\n\n").Append(file.Text.TrimEnd());
        files.Add(new("llms-full.txt", full + "\n"));
        return files;
    }

    /// <summary>Links that start at <paramref name="baseUrl"/> and point at a file that is not written, as <c>file: url</c>.
    /// Directory-style links (ending in <c>/</c>, or without an extension) refer to the demo app or a folder, not a written file.</summary>
    public static IReadOnlyList<string> BrokenLinks(IReadOnlyList<LlmsFile> files, string baseUrl)
    {
        baseUrl = baseUrl.TrimEnd('/');
        var paths = files.Select(f => f.Path).ToHashSet(StringComparer.Ordinal);
        return files.SelectMany(f => Regex.Matches(f.Text, @"https://[\w\.\-/:%#]+")
                                          .Where(m =>
                                          {
                                              if (!m.Value.StartsWith(baseUrl + "/", StringComparison.Ordinal)) return false;
                                              var path = m.Value[(baseUrl.Length + 1)..];
                                              return !path.EndsWith("/", StringComparison.Ordinal) && path.Contains('.') && !paths.Contains(path);
                                          })
                                          .Select(m => $"{f.Path}: {m.Value}"))
                    .Distinct().OrderBy(x => x).ToArray();
    }

    private static string IndexOf(Library lib, string baseUrl)
    {
        var text = new StringBuilder("\n## Themed controls\n\n");
        text.Append("Each page shows the style classes, ControlTheme variants, pseudo-classes, overridable resource keys and the "
                    + "full source of the demo. Controls without a demo are listed in the skill's reference/classes.md.\n\n");
        foreach (var control in lib.Controls.Where(c => c.Demo is not null))
            text.Append($"- [{control.Name}]({baseUrl}/controls/{control.Name}.md): {Summary(control)}\n");
        text.Append($"\n## Catalog only (no demo page)\n\n");
        foreach (var control in lib.Controls.Where(c => c.Demo is null))
            text.Append($"- {control.Name}: {Summary(control)}\n");
        return text.ToString();
    }

    private static string Summary(ControlInfo c)
    {
        var parts = new List<string>();
        if (c.Classes.Count > 0) parts.Add("classes " + string.Join(", ", c.Classes));
        if (c.Variants.Count > 0) parts.Add("themes " + string.Join(", ", c.Variants));
        if (c.OverrideKeys.Count > 0) parts.Add($"{c.OverrideKeys.Count} override keys");
        if (parts.Count == 0) parts.Add("shared resources");
        return string.Join("; ", parts) + ".";
    }

    private static string TokensPage(Library lib, string baseUrl)
    {
        var text = new StringBuilder($"# Semi.Avalonia tokens\n\nEvery resource key of the theme, extracted from the sources of version {lib.Version}. "
            + "Use the key with `DynamicResource`, or the `SemiTokens` member with `x:Static` — a mistyped member fails at build time.\n\n"
            + "```xml\n<Border Background=\"{DynamicResource SemiColorPrimary}\" />\n<Border Background=\"{DynamicResource {x:Static semi:SemiTokens.ColorPrimary}}\" />\n```\n\n");
        string? region = null;
        foreach (var token in lib.Tokens)
        {
            if (token.Region != region)
            {
                region = token.Region;
                text.Append($"\n## {region}\n\n| Resource key | SemiTokens member | Type | Value | Description (zh) |\n|---|---|---|---|---|\n");
            }
            var v = lib.Variables.GetValueOrDefault(token.Key);
            var palette = lib.PaletteEntries.GetValueOrDefault(token.Key);
            text.Append($"| `{token.Key}` | `SemiTokens.{token.Member}` | {v?.Type ?? palette.Kind} | {v?.Value ?? palette.Value} | {Escape(v?.Comment) ?? ""} |\n");
        }

        text.Append("\n## Palette colors\n\nRaw color scales; each key exists in the Light and the Dark palette.\n\n| Key | Light | Dark |\n|---|---|---|\n");
        foreach (var row in lib.PaletteColors) text.Append($"| `{row.Key}` | {row.Light} | {row.Dark} |\n");

        text.Append("\n## Semantic color tokens\n\nThe brushes controls actually consume; the ones to override when re-branding.\n\n| Key | Light | Dark |\n|---|---|---|\n");
        foreach (var row in lib.PaletteBrushes) text.Append($"| `{row.Key}` | {row.Light} | {row.Dark} |\n");

        if (lib.HighContrastPresets.Count > 0)
        {
            text.Append("\n## High-contrast presets\n\n"
                + "Each preset theme overrides only the keys below; every other key is inherited from its parent Light/Dark variant. "
                + "Keys without the `Semi` prefix are the preset's private helper colors.\n");
            foreach (var preset in lib.HighContrastPresets)
            {
                text.Append($"\n### {preset.Name}\n\n| Key | Kind | Value |\n|---|---|---|\n");
                foreach (var entry in preset.Entries) text.Append($"| `{entry.Key}` | {entry.Kind} | {entry.Value} |\n");
            }
        }
        return text.ToString();
    }

    private static string? Escape(string? text) => text is null ? null : text.Replace("|", "\\|");

    private static string ControlPage(ControlInfo c, string baseUrl)
    {
        var text = new StringBuilder($"# {c.Name}\n\nSemi's theme for Avalonia's `{c.DefaultThemeFor ?? c.Name}` control. "
            + $"[All tokens]({baseUrl}/tokens.md) · [Customizing]({baseUrl}/customization.md) · "
            + $"the [demo site]({baseUrl}/) shows this live (it draws to a canvas; read this file instead).\n\n");
        if (c.Classes.Count > 0)
        {
            text.Append("## Style classes\n\n```xml\n<").Append(c.DefaultThemeFor ?? c.Name).Append(" Classes=\"").Append(c.Classes[0]).Append("\" />\n```\n\n");
            text.Append("All classes: " + string.Join(", ", c.Classes.Select(x => $"`{x}`")) +
                        ". They combine, e.g. `Classes=\"" + string.Join(" ", c.Classes.Take(2)) + "\"`; names are case-insensitive. What each looks like: the demo source below.\n\n");
        }
        if (c.Variants.Count > 0)
        {
            text.Append("## ControlTheme variants\n\n```xml\n<").Append(c.DefaultThemeFor ?? c.Name).Append(" Theme=\"{DynamicResource ").Append(c.Variants[0]).Append("}\" />\n```\n\n");
            foreach (var variant in c.Variants) text.Append($"- `{variant}` — `Theme=\"{{DynamicResource {variant}}}\"`\n");
            text.Append('\n');
        }
        if (c.PseudoClasses.Count > 0)
            text.Append("## Pseudo-classes\n\n" + string.Join(", ", c.PseudoClasses.Select(p => $"`:{p}`")) + "\n\n");
        if (c.OverrideKeys.Count > 0)
        {
            text.Append($"## Overridable resource keys ({c.OverrideKeys.Count})\n\n"
                + "Redefine any of these in your application or control resources to customize this control without touching its template. "
                + "The same keys exist in the Light and Dark themes; the high-contrast presets override a subset.\n\n```\n"
                + string.Join("\n", c.OverrideKeys) + "\n```\n\n");
        }
        text.Append("## Demo source\n\n```xml\n" + c.Demo + "\n```\n");
        return text.ToString();
    }

    private static string ClassesCatalog(Library lib, string baseUrl)
    {
        var text = new StringBuilder("# Semi.Avalonia themed controls\n\n"
            + "Every control themed by Semi, with its style classes and ControlTheme variants, extracted from version "
            + lib.Version + " of the sources. Controls with a demo page link to it.\n\n");
        foreach (var control in lib.Controls)
        {
            text.Append("- **").Append(control.Name).Append("**");
            if (control.Demo is not null) text.Append($" ([page]({baseUrl}/controls/{control.Name}.md))");
            text.Append(Summary(control).Length > 0 ? ": " + Summary(control) : "").Append('\n');
        }
        return text.ToString();
    }

    /// <summary>Fills <c>{{name}}</c> placeholders; unknown placeholders are an error at the call site.</summary>
    private static string Fill(string template, IReadOnlyDictionary<string, string> values, Library lib)
    {
        return Regex.Replace(template, @"\{\{(\w[\w-]*)\}\}", m =>
        {
            if (values.TryGetValue(m.Groups[1].Value, out var value)) return value;
            throw new InvalidOperationException($"Unknown placeholder {m.Value}.");
        });
    }

    private const string LlmsIndex = """
        # Semi.Avalonia

        > Semi.Avalonia is an Avalonia {{avalonia}} THEME library: it themes the controls Avalonia already has (Button, TextBox, DataGrid, …) in the style of Semi Design, with light, dark and four high-contrast palettes, {{locale-count}} built-in locales, and every color, radius and spacing behind a resource key. It adds no controls of its own — for new controls see Ursa. MIT licensed.

        Version {{version}} (pin the exact version on nuget.org). This site's demo is an Avalonia WebAssembly app that draws to a canvas, so its HTML carries no text: read these Markdown files instead.

        ## Install

        ```bash
        dotnet add package Semi.Avalonia
        ```

        ```xml
        <Application xmlns="https://github.com/avaloniaui"
                     xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                     xmlns:semi="https://irihi.tech/semi"
                     x:Class="YourApp.App"
                     RequestedThemeVariant="Light">
            <Application.Styles>
                <semi:SemiTheme Locale="en-US" />
            </Application.Styles>
        </Application>
        ```

        That single style is the whole setup. Do not add Avalonia's Fluent or Simple theme alongside it. `RequestedThemeVariant` switches Light/Dark (Default follows the system); the extra palettes are `SemiTheme.Aquatic`, `SemiTheme.Desert`, `SemiTheme.Dusk` and `SemiTheme.NightSky`.

        ## Rules for agents

        - This is Avalonia, not WPF, WinUI or HTML: no `Visibility`, no CSS. And this is a THEME library: the controls are Avalonia's own. There is no `semi:Button`; write `Button` and let SemiTheme style it.
        - The Semi namespace `https://irihi.tech/semi` is only for `<semi:SemiTheme />`.
        - Appearance differences are style classes and ControlTheme variants, and ONLY the ones listed in a control's page: `Classes="Primary Danger"`, `Theme="{DynamicResource SolidButton}"`. A class or variant that is not in the page is invented.
        - Colors, radii, spacing and fonts come from resource keys: `Background="{DynamicResource SemiColorPrimary}"`, or `{DynamicResource {x:Static semi:SemiTokens.ColorPrimary}}` which fails at build time when mistyped. Never hard-code hex values; override the key instead.
        - Override only the keys a control's page lists — they exist in the Light and Dark themes (the high-contrast presets override a subset). A new global key must be added to `SemiTokens` and all palette files.
        - Localization of built-in control text is `Locale="zh-CN"` on SemiTheme ({{locale-count}} locales); your own strings are your business.
        - DataGrid, TreeDataGrid and ColorPicker themes are separate packages: Semi.Avalonia.DataGrid, Semi.Avalonia.TreeDataGrid, Semi.Avalonia.ColorPicker.

        ## Pages

        - [tokens.md]({{base}}/tokens.md): all {{token-count}} design tokens, {{brush-count}} semantic color tokens and {{color-count}} raw palette colors, with values and Light/Dark pairs.
        - [customization.md]({{base}}/customization.md): theme switching, high-contrast palettes ({{preset-list}}), locale, and every customization pattern.
        - [llms-full.txt]({{base}}/llms-full.txt): every page above in one file.

        ## Agent skill

        - [SKILL.md]({{skill}}/SKILL.md), [checklist.md]({{skill}}/checklist.md) and the reference files next to them. Save the whole `{{skill}}` folder into your agent's skills directory (for Claude Code: `.claude/skills/semi-avalonia/`):

        ```bash
        mkdir -p .claude/skills/semi-avalonia
        for f in SKILL.md checklist.md reference/tokens.md reference/customization.md reference/classes.md; do
          curl -fsSL "{{skill}}/$f" -o ".claude/skills/semi-avalonia/$f"
        done
        ```

        ## Optional

        - [Source code]({{repository}}): the repository; its `AGENTS.md` is for work on the theme itself.
        - [NuGet](https://www.nuget.org/packages/Semi.Avalonia): the package.

        {{controls-index}}
        """;

    private const string CustomizationText = """
        # Customizing Semi.Avalonia

        ## Switching themes

        ```xml
        <Application RequestedThemeVariant="Dark">   <!-- Light, Dark, or Default (follows the system) -->
        ```

        ```csharp
        Application.Current!.RequestedThemeVariant = ThemeVariant.Dark;
        ```

        Four extra palettes ship as theme variants: `SemiTheme.Aquatic`, `SemiTheme.Desert`, `SemiTheme.Dusk`, `SemiTheme.NightSky` ({{preset-list}}):

        ```csharp
        Application.Current!.RequestedThemeVariant = SemiTheme.Dusk;
        ```

        ## Locale

        `<semi:SemiTheme Locale="zh-CN" />` localizes the text Avalonia's own controls show (TextBox cut/copy/paste, Calendar, …). {{locale-count}} locales are built in. To change it at run time, call `SemiTheme.OverrideLocaleResources(application, culture)`.

        ## Overriding tokens (the right way to re-brand)

        Redefine the resource keys — in your App.xaml for the whole application, or in any control's `Resources` for one subtree. Both Light and Dark read the same keys, so one override covers both.

        ```xml
        <Application.Resources>
            <SolidColorBrush x:Key="SemiColorPrimary" Color="#7C3AED" />
            <CornerRadius x:Key="SemiBorderRadiusMedium">8</CornerRadius>
        </Application.Resources>
        ```

        The complete key list with values is in [tokens.md]({{base}}/tokens.md); per-control keys are listed on each control's page.

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
        """;

    private const string SkillText = """
        ---
        name: {{skill-name}}
        description: Themes and restyles Avalonia applications with Semi.Avalonia, the Semi Design theme for Avalonia's built-in controls. Picks the right style classes and ControlTheme variants, sets up light/dark/high-contrast themes and locales, and overrides resource keys instead of hard-coding values. Use when a project references Semi.Avalonia or Semi.Avalonia.* packages, when XAML contains xmlns semi="https://irihi.tech/semi" or <semi:SemiTheme, or when asked to theme, restyle or re-brand an Avalonia app, switch light/dark mode, or customize Semi colors, radii or spacing.
        ---

        # Semi.Avalonia

        Semi.Avalonia ({{version}}) themes the controls Avalonia already has — it adds no controls. One style in App.xaml is the whole setup; everything else is style classes, ControlTheme variants and resource keys.

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

        **Style.** `Classes="Primary"` and `Theme="{DynamicResource SolidButton}"`. Class names are case-insensitive and combine. The full catalog is in [reference/classes.md](reference/classes.md); per-control detail and demo XAML live at {{base}}/controls/<name>.md.

        **Customize.** Override `Semi*` resource keys (app-wide in App.xaml, per-subtree in a control's Resources). In code-behind prefer `{DynamicResource {x:Static semi:SemiTokens.ColorPrimary}}` — a mistyped member is a build error, a mistyped string is not. All keys with values: [reference/tokens.md](reference/tokens.md). Patterns and troubleshooting: [reference/customization.md](reference/customization.md).

        ## Core rules

        1. **Avalonia built-ins only.** There is no `semi:Button`. Write `Button`; SemiTheme styles it. New controls belong to Ursa.
        2. **Documented names only.** A class, variant or key not in the pages is invented and fails silently (classes) or at build time (x:Static).
        3. **Tokens, not values.** No hex colors, no magic numbers; override the key so Light/Dark both follow.
        4. **One theme source.** SemiTheme alone; never mix Fluent or Simple into the same app.

        ## Satellites

        `Semi.Avalonia.DataGrid`, `Semi.Avalonia.TreeDataGrid`, `Semi.Avalonia.ColorPicker` — same pattern, separate packages, main theme required.
        """;

    private const string ChecklistText = """
        # Semi.Avalonia review checklist

        Run over any screen the assistant styled with Semi.Avalonia before calling it done.

        - [ ] `<semi:SemiTheme />` is the only theme style in Application.Styles; no Fluent, no Simple.
        - [ ] Every `Classes="…"` value appears in the control's page or reference/classes.md.
        - [ ] Every `Theme="{DynamicResource …}"` is a ControlTheme variant listed for that control.
        - [ ] No hard-coded `Color="#…"` in XAML; every color/radius/spacing reads a `Semi*` key or `SemiTokens` member.
        - [ ] Every overridden `x:Key` is listed in tokens.md or the control's page.
        - [ ] Overridden keys that differ between light and dark are overridden in a scope that covers both variants.
        - [ ] `RequestedThemeVariant` handles Default (system); the app looks right in Light AND Dark (and a high-contrast palette if used).
        - [ ] `Locale` on SemiTheme is set when built-in control text is user-visible.
        - [ ] DataGrid/TreeDataGrid/ColorPicker screens reference their satellite package.
        """;
}
