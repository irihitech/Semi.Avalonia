using System.Text;
using System.Text.RegularExpressions;

namespace Semi.Avalonia.Llms;

/// <summary>A global token constant from <c>SemiTokens.cs</c>: its region, C# member name and resource key.</summary>
public sealed record Token(string Region, string Member, string Key);

/// <summary>A definition site in <c>Variables.axaml</c>: the element type, its value and the Chinese comment.</summary>
public sealed record TokenValue(string Type, string Value, string? Comment);

/// <summary>A themed control: the style classes, ControlTheme variants and pseudo-classes its XAML declares.</summary>
public sealed record ControlInfo(
    string Name,
    IReadOnlyList<string> Classes,
    IReadOnlyList<string> Variants,
    string? DefaultThemeFor,
    IReadOnlyList<string> PseudoClasses,
    IReadOnlyList<string> OverrideKeys,
    string? Demo);

/// <summary>A palette entry with its light and dark values.</summary>
public sealed record PaletteRow(string Key, string Light, string Dark);

/// <summary>One entry of a high-contrast preset: a private helper color or a Semi brush alias, with its resolved value.</summary>
public sealed record PresetEntry(string Key, string Kind, string Value);

/// <summary>A high-contrast preset theme (Aquatic, …): the few keys it overrides; everything else is inherited.</summary>
public sealed record HighContrastPreset(string Name, IReadOnlyList<PresetEntry> Entries);

/// <summary>
/// Everything the site is built from, extracted from the repository's own sources:
/// <c>SemiTokens.cs</c>, <c>Tokens/Variables.axaml</c>, <c>Tokens/Palette/*.axaml</c>,
/// <c>Controls/*.axaml</c> (selectors and ControlTheme keys), <c>Themes/{Light,Dark,HighContrast}/*.axaml</c>
/// (override keys) and the demo pages. Collects consistency errors instead of throwing;
/// the program refuses to write any file when <see cref="Errors"/> is not empty.
/// </summary>
public sealed class Library
{
    public string Version { get; }
    /// <summary>The Avalonia version the theme targets, from <c>Directory.Packages.props</c>.</summary>
    public string AvaloniaVersion { get; }
    public IReadOnlyList<string> Locales { get; }
    public IReadOnlyList<Token> Tokens { get; }
    public IReadOnlyDictionary<string, TokenValue> Variables { get; }
    public IReadOnlyList<PaletteRow> PaletteColors { get; }
    public IReadOnlyList<PaletteRow> PaletteBrushes { get; }
    public IReadOnlyList<HighContrastPreset> HighContrastPresets { get; }
    /// <summary>The Light palette's entries by key (kind and resolved value), for showing token values that live in the palette.</summary>
    public IReadOnlyDictionary<string, (string Kind, string Value)> PaletteEntries { get; }
    public IReadOnlyList<ControlInfo> Controls { get; }
    public IReadOnlyList<string> Warnings { get; }
    public IReadOnlyList<string> Errors { get; }
    /// <summary>Whether <c>SemiTokens.cs</c> exists: with constants the pages teach the <c>x:Static</c> form and the
    /// constant/definition parity is enforced; without them (pre-static-token sources) keys are documented as literals.</summary>
    public bool HasConstants { get; }

    public Library(string root)
    {
        var warnings = new List<string>();
        var errors = new List<string>();
        var src = Path.Combine(root, "src", "Semi.Avalonia");

        Version = Regex.Match(Read(Path.Combine(src, "Semi.Avalonia.csproj")), "<Version>([^<]+)</Version>") is { Success: true } m ? m.Groups[1].Value : "latest";
        AvaloniaVersion = Regex.Match(Read(Path.Combine(root, "Directory.Packages.props")), "<AvaloniaVersion>([^<]+)</AvaloniaVersion>") is { Success: true } a ? a.Groups[1].Value : "latest";
        Locales = Regex.Matches(Read(Path.Combine(src, "SemiTheme.axaml.cs")), @"new CultureInfo\(""([\w-]+)""\)")
                       .Select(x => x.Groups[1].Value).Distinct().OrderBy(x => x).ToArray();

        // 1. Token constants, with their #region as the group. Sources without SemiTokens.cs use literal keys only.
        var tokens = new List<Token>();
        var region = "Misc";
        var constantsPath = Path.Combine(src, "Tokens", "SemiTokens.cs");
        HasConstants = File.Exists(constantsPath);
        foreach (var line in HasConstants ? Lines(constantsPath) : [])
        {
            if (Regex.Match(line, @"#region\s+(\w+)") is { Success: true } r) region = r.Groups[1].Value;
            if (Regex.Match(line, @"const string (\w+) = ""(\w+)"";") is { Success: true } t)
                tokens.Add(new Token(region, t.Groups[1].Value, t.Groups[2].Value));
        }

        // 2. Variables.axaml definitions: element type, key (literal or x:Static member), value, trailing comment.
        var variables = new Dictionary<string, TokenValue>(StringComparer.Ordinal);
        var memberToKey = tokens.ToDictionary(t => t.Member, t => t.Key, StringComparer.Ordinal);
        var lines = Lines(Path.Combine(src, "Tokens", "Variables.axaml")).ToArray();
        for (var i = 0; i < lines.Length; i++)
        {
            var def = Regex.Match(lines[i], @"<(?:x:)?(\w+)\s+x:Key=""(?:\{x:Static semi:SemiTokens\.(\w+)\}|(\w+))"">");
            if (!def.Success) continue;
            var key = def.Groups[3].Success ? def.Groups[3].Value : memberToKey.GetValueOrDefault(def.Groups[2].Value, "?" + def.Groups[2].Value);
            var value = Regex.Match(lines[i][(def.Index + def.Length)..], @"^([^<]*)").Groups[1].Value;
            var comment = Regex.Match(lines[i], @"<!--\s*(.+?)\s*-->").Groups[1].Value;
            // Multi-line values (FontFamily): consume lines until the closing tag.
            for (var next = i + 1; value.Length == 0 && next < lines.Length && !lines[next].Contains("</"); next++)
            {
                value += " " + lines[next].Trim();
                comment = string.IsNullOrEmpty(comment) ? Regex.Match(lines[next], @"<!--\s*(.+?)\s*-->").Groups[1].Value : comment;
                i = next;
            }
            variables[key] = new TokenValue(def.Groups[1].Value, value.Trim(), string.IsNullOrWhiteSpace(comment) ? null : comment);
        }

        // 3. Palettes: raw Color scales and semantic Brushes, light and dark, with StaticResource chains resolved.
        var light = Palette(Path.Combine(src, "Tokens", "Palette", "Light.axaml"), memberToKey);
        var dark = Palette(Path.Combine(src, "Tokens", "Palette", "Dark.axaml"), memberToKey);
        foreach (var key in light.Keys.Concat(dark.Keys).Distinct().Where(k => !light.ContainsKey(k) || !dark.ContainsKey(k)))
            errors.Add($"Palette key '{key}' is missing in {(light.ContainsKey(key) ? "Dark" : "Light")}.axaml.");

        string DarkOf(string key) => dark.TryGetValue(key, out var value) ? value.Value : "-";
        var colors = light.Where(kv => kv.Value.Kind == "Color").Select(kv => new PaletteRow(kv.Key, kv.Value.Value, DarkOf(kv.Key))).ToList();
        var brushes = light.Where(kv => kv.Value.Kind == "Brush").Select(kv => new PaletteRow(kv.Key, kv.Value.Value, DarkOf(kv.Key))).ToList();

        // 3b. High-contrast presets: small overlays (private helper colors + Semi brush aliases), not full palettes.
        //     All presets must define the same keys, and every key must actually be consumed by the high-contrast
        //     themes (their controls reference these keys; the Light/Dark palettes deliberately do not define them).
        var presets = new List<HighContrastPreset>();
        if (Directory.Exists(Path.Combine(src, "Tokens", "HighContrast")))
        {
            var consumers = new StringBuilder();
            foreach (var folder in new[] { Path.Combine(src, "Themes", "HighContrast"), Path.Combine(src, "Themes", "Shared") })
                if (Directory.Exists(folder))
                    foreach (var file in Directory.GetFiles(folder, "*.axaml"))
                        consumers.Append(Read(file));
            var consumed = consumers.ToString();
            HashSet<string>? referenceKeys = null;
            var referenceName = "";
            foreach (var file in Directory.GetFiles(Path.Combine(src, "Tokens", "HighContrast"), "*.axaml").OrderBy(f => f, StringComparer.OrdinalIgnoreCase))
            {
                var name = Path.GetFileNameWithoutExtension(file);
                var map = Palette(file, memberToKey);
                var keys = map.Keys.ToHashSet(StringComparer.Ordinal);
                if (referenceKeys is null)
                {
                    referenceKeys = keys;
                    referenceName = name;
                }
                else if (!keys.SetEquals(referenceKeys))
                    errors.Add($"High-contrast preset '{name}' defines different keys than '{referenceName}'.");
                // References appear either as the literal key or as the SemiTokens member inside {x:Static}.
                bool IsConsumed(string key) =>
                    consumed.Contains(key) || tokens.FirstOrDefault(t => t.Key == key) is { } token && consumed.Contains(token.Member);
                foreach (var key in keys.Where(k => k.StartsWith("Semi", StringComparison.Ordinal) && !IsConsumed(k)))
                    errors.Add($"High-contrast preset '{name}' defines '{key}', which no high-contrast or shared theme references.");
                presets.Add(new HighContrastPreset(name,
                    map.OrderBy(kv => kv.Key, StringComparer.OrdinalIgnoreCase)
                       .Select(kv => new PresetEntry(kv.Key, kv.Value.Kind, kv.Value.Value)).ToArray()));
            }
        }

        // 4. Controls: classes from `^.` selectors, variants from ControlTheme keys, pseudo-classes from `^:` selectors.
        var controls = new List<ControlInfo>();
        var controlNames = Directory.GetFiles(Path.Combine(src, "Controls"), "*.axaml").Select(p => Path.GetFileNameWithoutExtension(p)!).OrderBy(x => x, StringComparer.OrdinalIgnoreCase);
        foreach (var name in controlNames)
        {
            var text = Read(Path.Combine(src, "Controls", name + ".axaml"));
            var classes = Regex.Matches(text, @"Selector=""\^\.(\w+)")
                .Select(x => x.Groups[1].Value).Distinct().OrderBy(x => x, StringComparer.OrdinalIgnoreCase).ToArray();
            var variants = Regex.Matches(text, @"<ControlTheme\s[^>]*?x:Key=""(\w+)""\s", RegexOptions.Singleline)
                .Select(x => x.Groups[1].Value).Distinct().OrderBy(x => x).ToArray();
            var defaultFor = Regex.Match(text, @"x:Key=""\{x:Type ([\w.]+)\}""\s") is { Success: true } d ? d.Groups[1].Value : null;
            var pseudos = Regex.Matches(text, @"Selector=""\^:([\w-]+)")
                .Select(x => x.Groups[1].Value).Distinct().OrderBy(x => x).ToArray();

            // 4b. Override keys from the three theme variants, with a parity check across them.
            var overrideKeys = Array.Empty<string>();
            var keySets = new Dictionary<string, HashSet<string>>();
            foreach (var variant in new[] { "Light", "Dark", "HighContrast" })
            {
                var path = Path.Combine(src, "Themes", variant, name + ".axaml");
                if (!File.Exists(path)) continue;
                keySets[variant] = Regex.Matches(Read(path), @"x:Key=""([^""{}][^""{}]*)""[\s>]")
                                         .Select(x => x.Groups[1].Value).ToHashSet(StringComparer.Ordinal);
                if (variant == "Light") overrideKeys = keySets[variant].OrderBy(x => x, StringComparer.Ordinal).ToArray();
            }
            // Light and Dark are full themes and must define the same keys; the high-contrast presets are
            // overlays that inherit from their parent variant and legitimately override a subset.
            if (keySets.TryGetValue("Light", out var lightKeys))
            {
                if (keySets.TryGetValue("Dark", out var darkKeys) && !lightKeys.SetEquals(darkKeys))
                    errors.Add($"Override keys for '{name}' differ between the Light and Dark themes: {lightKeys.Count} vs {darkKeys.Count} keys.");
                if (keySets.TryGetValue("HighContrast", out var contrastKeys))
                    foreach (var key in contrastKeys.Where(k => !lightKeys.Contains(k) && !(keySets.GetValueOrDefault("Dark")?.Contains(k) ?? false)))
                        warnings.Add($"'{name}' defines override key '{key}' only in the HighContrast theme.");
            }

            var demoPath = Path.Combine(root, "demo", "Semi.Avalonia.Demo", "Pages", name + "Demo.axaml");
            controls.Add(new ControlInfo(name, classes, variants, defaultFor, pseudos, overrideKeys, File.Exists(demoPath) ? Read(demoPath) : null));
        }

        // 5. Consistency: constants and definitions must agree exactly. High-contrast preset
        //    keys count as definitions (they are the only place some Semi keys are defined),
        //    and every Semi* key a preset defines must have a constant — no more blind spots.
        var defined = variables.Keys.ToHashSet(StringComparer.Ordinal);
        defined.UnionWith(light.Keys);
        defined.UnionWith(presets.SelectMany(p => p.Entries).Select(e => e.Key));
        foreach (var token in tokens.Where(t => !defined.Contains(t.Key)))
            errors.Add($"SemiTokens.{token.Member} = '{token.Key}' is not defined in Variables.axaml, Palette/Light.axaml or a high-contrast preset.");
        if (HasConstants)
        {
            foreach (var key in variables.Keys.Where(k => tokens.All(t => t.Key != k)))
                errors.Add($"Variables.axaml defines '{key}' with no SemiTokens constant.");
            foreach (var entry in presets.SelectMany(p => p.Entries.Select(e => (Preset: p.Name, Key: e.Key)))
                                         .Where(x => x.Key.StartsWith("Semi", StringComparison.Ordinal) && tokens.All(t => t.Key != x.Key)))
                errors.Add($"High-contrast preset '{entry.Preset}' defines '{entry.Key}' with no SemiTokens constant.");
            var brushKeys = brushes.Select(b => b.Key).ToHashSet(StringComparer.Ordinal);
            foreach (var key in brushKeys.Where(k => tokens.All(t => t.Key != k)))
                warnings.Add($"Palette brush '{key}' has no SemiTokens constant (agents must use the string literal).");
        }
        else
            warnings.Add("SemiTokens.cs not found — documenting keys as string literals (pre-static-token sources).");

        Tokens = tokens;
        Variables = variables;
        PaletteEntries = light;
        PaletteColors = colors;
        PaletteBrushes = brushes;
        HighContrastPresets = presets;
        Controls = controls;
        Warnings = warnings;
        Errors = errors;
    }

    /// <summary>Palette entries of one variant: key → (Color|Brush, literal or resolved value).</summary>
    private static Dictionary<string, (string Kind, string Value)> Palette(string path, IReadOnlyDictionary<string, string> memberToKey)
    {
        var text = Read(path);
        var map = new Dictionary<string, (string Kind, string Value)>(StringComparer.Ordinal);
        foreach (Match m in Regex.Matches(text, @"<(?:x:)?Color\s+x:Key=""([^""]+)""\s*>([\#A-Za-z0-9]+)</"))
            map[KeyOf(m.Groups[1].Value, memberToKey)] = ("Color", m.Groups[2].Value);
        foreach (Match m in Regex.Matches(text, @"<SolidColorBrush\s+x:Key=""([^""]+)""(?:\s+Opacity=""([\d.]+)"")?[^>]*?Color=""([^""]+)""\s"))
        {
            var value = ColorOf(m.Groups[3].Value, memberToKey);
            if (m.Groups[2].Success) value += $" @ {m.Groups[2].Value} opacity";
            map[KeyOf(m.Groups[1].Value, memberToKey)] = ("Brush", value);
        }
        // Shadows are palette values too.
        foreach (Match m in Regex.Matches(text, @"<BoxShadows\s+x:Key=""([^""]+)""\s*>([^<]+)<"))
            map[KeyOf(m.Groups[1].Value, memberToKey)] = ("BoxShadows", m.Groups[2].Value.Trim());
        // The AI hues are gradients, not flat colors; keep them as first-class keys with a placeholder value.
        foreach (Match m in Regex.Matches(text, @"<(?:Linear|Radial)GradientBrush\s+x:Key=""([^""]+)""\s"))
            map[KeyOf(m.Groups[1].Value, memberToKey)] = ("Brush", "gradient");
        // Resolve StaticResource chains (brush → color, brush → brush) to literal hex where possible.
        for (var pass = 0; pass < 4; pass++)
        {
            var changed = false;
            foreach (var key in map.Keys.ToArray())
            {
                var (kind, value) = map[key];
                if (value.StartsWith("ref:", StringComparison.Ordinal) && map.TryGetValue(value[4..], out var target))
                {
                    map[key] = (kind, target.Value);
                    changed = true;
                }
            }
            if (!changed) break;
        }
        return map;
    }

    /// <summary>An attribute value that is either a literal key or <c>{x:Static semi:SemiTokens.Member}</c>.</summary>
    private static string KeyOf(string attr, IReadOnlyDictionary<string, string> memberToKey)
    {
        var m = Regex.Match(attr, @"\{x:Static semi:SemiTokens\.(\w+)\}");
        return m.Success && memberToKey.TryGetValue(m.Groups[1].Value, out var key) ? key : attr;
    }

    /// <summary>A Color attribute: a literal hex value, or a StaticResource reference (itself possibly x:Static).</summary>
    private static string ColorOf(string attr, IReadOnlyDictionary<string, string> memberToKey)
    {
        if (attr.StartsWith("#", StringComparison.Ordinal)) return attr;
        if (attr.StartsWith("{StaticResource ", StringComparison.Ordinal)) attr = attr["{StaticResource ".Length..^1].Trim();
        return "ref:" + KeyOf(attr, memberToKey);
    }

    private static IEnumerable<string> Lines(string path) => Read(path).Split('\n').Select(l => l.TrimEnd('\r'));

    private static string Read(string path) => File.ReadAllText(path);
}
