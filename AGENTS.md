# Semi.Avalonia agent guide

Semi.Avalonia is an Avalonia **theme** library: it themes the controls Avalonia already ships (Button, TextBox, Calendar, …) in the style of Semi Design. It adds no controls of its own — new controls belong to [Ursa](https://github.com/irihitech/Ursa.Avalonia). Keep that boundary in mind: every change here is about resources, selectors and templates for existing controls.

## Layout

- `src/Semi.Avalonia`: the main theme.
  - Global resource keys are string literals today (`x:Key="SemiColorPrimary"`, referenced via `DynamicResource`/`StaticResource`); the static-token branch (targeted at the 12.2 cycle) introduces `Tokens/SemiTokens.cs` constants and `{x:Static semi:SemiTokens.*}` references so a mistyped key fails at build time.
  - `Tokens/Variables.axaml`: sizing, spacing, radius, font and motion tokens (values with zh comments).
  - `Tokens/Palette/{Light,Dark}.axaml`: colors — raw scales, per-hue brushes, semantic `SemiColor*` brushes, gradients and `BoxShadows`. `Tokens/HighContrast/*.axaml`: the Aquatic/Desert/Dusk/NightSky preset palettes.
  - `Controls/<Name>.axaml`: the actual ControlThemes and class selectors for a control (style classes = `^.Class` selectors; theme variants = keyed ControlThemes).
  - `Themes/{Light,Dark}/<Name>.axaml`: per-control resource keys (Light and Dark define the same set). `Themes/HighContrast/` intentionally overrides only a subset — the presets inherit from their parent Light/Dark variant.
  - `Themes/Shared/`: resources shared by every variant. `Locale/`: built-in control text per culture (`SemiTheme.Locale`).
- `src/Semi.Avalonia.{DataGrid,TreeDataGrid,ColorPicker}`: satellite themes, each needs the main package.
- `demo/Semi.Avalonia.Demo/Pages/<Name>Demo.axaml`: the live example of a themed control; the docs for AI assistants embed this source.
- `tools/Semi.Avalonia.Llms`: generates the site's files for AI assistants (below) and doubles as the consistency gate for the theme sources.

## Non-negotiable rules

- **New global keys** are defined as string literals in `Variables.axaml` (sizing, spacing, …) or in both palette files (colors). `Light` and `Dark` must define the same key set.
- **No new hard-coded colors** in theme files; reference `Semi*` tokens (or compose from them). New style classes or ControlTheme variants are public API: add the selector/theme in `Controls/<Name>.axaml`, the resources in all due `Themes/*` files, and a matching demo page.
- Class selectors are written `^.ClassName` inside the ControlTheme; pseudo-classes come from the control, never new ones invented.
- **Light == Dark** per-control key sets; `HighContrast` stays a subset. `tools/Semi.Avalonia.Llms` fails on any drift — treat its exit code as a test result.
- No reflection; keep AOT/trimming safe. C# control-flow bodies always use braces.
- The generated AI files (`llms.txt`, `*.md` pages, `skills/`) are written into the published web root by the deploy workflow — never hand-edit or commit them.

## Files for AI assistants

`dotnet run --project tools/Semi.Avalonia.Llms -- <repo-root> <out-dir>` extracts everything from the sources and refuses to write when palettes or theme variants disagree; with `SemiTokens.cs` present it additionally gates constant/definition parity. The deploy workflow runs it into the demo's `wwwroot`, so https://irihitech.github.io/Semi.Avalonia/llms.txt indexes the theme for coding agents (rules, every control's classes/variants/override keys, token tables, the `semi-avalonia` agent skill).

## Verify

```bash
dotnet build src/Semi.Avalonia
dotnet run --project tools/Semi.Avalonia.Llms -- . %TEMP%/semi-llms-check   # must exit 0
```
