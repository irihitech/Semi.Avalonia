using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace Semi.Avalonia.Llms;

/// <summary>
/// Builds the machine-readable AI contract and its provenance record from the same extracted
/// <see cref="Library"/> as the Markdown pages. Marketplaces and MCP servers consume these instead
/// of scraping the llms pages; the schema is versioned so consumers can refuse unknown versions.
/// </summary>
public static class Contract
{
    public const int SchemaVersion = 1;
    public const string ContractPath = "ai/semi-avalonia.contract.json";
    public const string ProvenancePath = "ai/provenance.json";

    private static readonly Dictionary<string, string> SatelliteDescriptions = new(StringComparer.Ordinal)
    {
        ["Semi.Avalonia.ColorPicker"] = "Theme for Avalonia's ColorPicker control family.",
        ["Semi.Avalonia.DataGrid"] = "Theme for Avalonia's DataGrid control.",
        ["Semi.Avalonia.TreeDataGrid"] = "Theme for the TreeDataGrid controls.",
    };

    /// <param name="files">Everything <see cref="Pages.Build"/> produced; the skill's files are hashed from here,
    /// because at this point nothing has been written to disk yet.</param>
    public static IReadOnlyList<LlmsFile> Build(Library lib, string baseUrl, string root, IReadOnlyList<LlmsFile> files)
    {
        var prefix = $"skills/{Pages.SkillName}/";
        var skillFiles = files.Where(f => f.Path.StartsWith(prefix, StringComparison.Ordinal))
                              .Select(f => (Path: f.Path[prefix.Length..], f.Text))
                              .OrderBy(x => x.Path, StringComparer.Ordinal)
                              .ToArray();
        var contract = Write(WriteContract, (lib, baseUrl, root, skillFiles.Select(f => f.Path).ToArray()));
        var provenance = Write(WriteProvenance, (lib, root, contract, skillFiles));
        return [new(ContractPath, contract), new(ProvenancePath, provenance)];
    }

    private static void WriteContract(Utf8JsonWriter writer, (Library Lib, string BaseUrl, string Root, string[] SkillFiles) state)
    {
        var (lib, baseUrl, root, skillFiles) = state;
        writer.WriteStartObject();
        writer.WriteNumber("schemaVersion", SchemaVersion);

        writer.WriteStartObject("package");
        writer.WriteString("name", "Semi.Avalonia");
        writer.WriteString("version", lib.Version);
        writer.WriteString("avaloniaVersion", lib.AvaloniaVersion);
        writer.WriteString("repository", "https://github.com/irihitech/Semi.Avalonia");
        writer.WriteEndObject();

        // Empty when git is unavailable (e.g. a source drop without .git); the field always exists.
        WriteSourceRevision(writer, root);

        writer.WriteStartObject("docs");
        writer.WriteString("baseUrl", baseUrl);
        writer.WriteString("llmsTxt", $"{baseUrl}/llms.txt");
        writer.WriteEndObject();

        writer.WriteStartObject("skill");
        writer.WriteString("name", Pages.SkillName);
        writer.WriteString("rootPath", $"skills/{Pages.SkillName}");
        writer.WriteStartArray("files");
        foreach (var file in skillFiles) writer.WriteStringValue(file);
        writer.WriteEndArray();
        writer.WriteEndObject();

        writer.WriteStartArray("locales");
        foreach (var locale in lib.Locales) writer.WriteStringValue(locale);
        writer.WriteEndArray();

        writer.WriteStartArray("satellites");
        foreach (var name in SatelliteDescriptions.Keys.OrderBy(x => x, StringComparer.Ordinal))
        {
            writer.WriteStartObject();
            writer.WriteString("name", name);
            writer.WriteString("description", SatelliteDescriptions[name]);
            writer.WriteEndObject();
        }
        writer.WriteEndArray();

        writer.WriteStartArray("highContrastPresets");
        foreach (var preset in lib.HighContrastPresets)
        {
            writer.WriteStartObject();
            writer.WriteString("name", preset.Name);
            writer.WriteStartArray("entries");
            foreach (var entry in preset.Entries)
            {
                writer.WriteStartObject();
                writer.WriteString("key", entry.Key);
                writer.WriteString("kind", entry.Kind);
                writer.WriteString("value", entry.Value);
                writer.WriteEndObject();
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }
        writer.WriteEndArray();

        WriteTokens(writer, lib);
        WriteControls(writer, lib, baseUrl);
        writer.WriteEndObject();
    }

    private static void WriteProvenance(Utf8JsonWriter writer, (Library Lib, string Root, string Contract, (string Path, string Text)[] SkillFiles) state)
    {
        var (lib, root, contract, skillFiles) = state;
        writer.WriteStartObject();
        writer.WriteNumber("schemaVersion", SchemaVersion);
        writer.WriteStartObject("package");
        writer.WriteString("name", "Semi.Avalonia");
        writer.WriteString("version", lib.Version);
        writer.WriteEndObject();
        WriteSourceRevision(writer, root);
        writer.WriteStartObject("contract");
        writer.WriteString("path", ContractPath);
        writer.WriteString("sha256", Sha256(contract));
        writer.WriteEndObject();
        writer.WriteStartObject("skill");
        writer.WriteString("name", Pages.SkillName);
        writer.WriteString("root", $"skills/{Pages.SkillName}");
        writer.WriteStartArray("files");
        foreach (var file in skillFiles)
        {
            writer.WriteStartObject();
            writer.WriteString("path", file.Path);
            writer.WriteString("sha256", Sha256(file.Text));
            writer.WriteEndObject();
        }
        writer.WriteEndArray();
        writer.WriteEndObject();
        // The timestamp is metadata for humans; the hashes cover only the contract and the skill
        // files, so rebuilding the same sources reproduces every hash (see "notes").
        writer.WriteString("generatedAtUtc", DateTime.UtcNow.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'"));
        writer.WriteStartArray("notes");
        writer.WriteStringValue("sha256 values are computed over the exact bytes of the files they name; provenance.json itself is never hashed.");
        writer.WriteStringValue("generatedAtUtc is not covered by any hash, so two builds of the same sources differ only in that field.");
        writer.WriteEndArray();
        writer.WriteEndObject();
    }

    /// <summary>Every global resource key of the theme, with the variant information each has.</summary>
    private static void WriteTokens(Utf8JsonWriter writer, Library lib)
    {
        var palette = lib.PaletteColors.Concat(lib.PaletteBrushes).ToDictionary(x => x.Key, StringComparer.Ordinal);
        var kinds = lib.PaletteEntries.ToDictionary(x => x.Key, x => x.Value.Kind, StringComparer.Ordinal);
        var byKey = lib.Tokens.ToDictionary(t => t.Key, StringComparer.Ordinal);
        var presetEntries = new Dictionary<string, SortedDictionary<string, string>>(StringComparer.Ordinal);
        foreach (var preset in lib.HighContrastPresets.OrderBy(p => p.Name, StringComparer.OrdinalIgnoreCase))
            foreach (var entry in preset.Entries)
            {
                if (!presetEntries.TryGetValue(entry.Key, out var values))
                    presetEntries[entry.Key] = values = new SortedDictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                values[preset.Name] = entry.Value;
            }
        var keys = lib.Tokens.Select(t => t.Key)
            .Concat(lib.Variables.Keys)
            .Concat(palette.Keys)
            .Concat(presetEntries.Keys)
            .Distinct(StringComparer.Ordinal)
            .OrderBy(x => x, StringComparer.OrdinalIgnoreCase).ThenBy(x => x, StringComparer.Ordinal);

        writer.WriteStartArray("tokens");
        foreach (var key in keys)
        {
            var token = byKey.GetValueOrDefault(key);
            var variable = lib.Variables.GetValueOrDefault(key);
            var row = palette.GetValueOrDefault(key);
            var presets = presetEntries.GetValueOrDefault(key);
            writer.WriteStartObject();
            writer.WriteString("key", key);
            WriteNullable(writer, "member", token?.Member);
            writer.WriteString("category", token?.Region ?? (variable is not null ? "Variables" : presets is not null ? "HighContrast" : "Palette"));
            writer.WriteString("type", variable?.Type ?? kinds.GetValueOrDefault(key) ?? PresetKind(lib, key));
            WriteNullable(writer, "value", variable?.Value);
            WriteNullable(writer, "light", row?.Light);
            WriteNullable(writer, "dark", row?.Dark);
            WriteNullable(writer, "comment", variable?.Comment);
            if (presets is not null)
            {
                writer.WriteStartObject("presets");
                foreach (var preset in presets) writer.WriteString(preset.Key, preset.Value);
                writer.WriteEndObject();
            }
            writer.WriteEndObject();
        }
        writer.WriteEndArray();
    }

    private static string PresetKind(Library lib, string key) =>
        lib.HighContrastPresets.SelectMany(p => p.Entries).First(e => e.Key == key).Kind;

    private static void WriteControls(Utf8JsonWriter writer, Library lib, string baseUrl)
    {
        writer.WriteStartArray("controls");
        foreach (var control in lib.Controls)
        {
            writer.WriteStartObject();
            writer.WriteString("name", control.Name);
            WriteNullable(writer, "defaultThemeFor", control.DefaultThemeFor);
            WriteStartArrayAndValues(writer, "classes", control.Classes);
            WriteStartArrayAndValues(writer, "variants", control.Variants);
            WriteStartArrayAndValues(writer, "pseudoClasses", control.PseudoClasses);
            WriteStartArrayAndValues(writer, "overrideKeys", control.OverrideKeys);
            if (control.Demo is not null) writer.WriteString("demoUrl", $"{baseUrl}/controls/{control.Name}.md");
            writer.WriteEndObject();
        }
        writer.WriteEndArray();
    }

    private static void WriteStartArrayAndValues(Utf8JsonWriter writer, string name, IEnumerable<string> values)
    {
        writer.WriteStartArray(name);
        foreach (var value in values) writer.WriteStringValue(value);
        writer.WriteEndArray();
    }

    private static void WriteSourceRevision(Utf8JsonWriter writer, string root)
    {
        try
        {
            using var git = Process.Start(new ProcessStartInfo("git", $"-C \"{root}\" rev-parse HEAD")
            {
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
            });
            if (git is null)
            {
                writer.WriteNull("sourceRevision");
                return;
            }
            var revision = git.StandardOutput.ReadToEnd().Trim();
            git.WaitForExit(5000);
            writer.WriteString("sourceRevision", git.ExitCode == 0 && revision.Length == 40 ? revision : null);
        }
        catch
        {
            writer.WriteNull("sourceRevision");
        }
    }

    private static void WriteNullable(Utf8JsonWriter writer, string name, string? value)
    {
        if (value is null) writer.WriteNull(name);
        else writer.WriteString(name, value);
    }

    private static string Sha256(string text)
    {
        var hash = SHA256.HashData(new UTF8Encoding(false).GetBytes(text));
        return Convert.ToHexString(hash).ToLowerInvariant();
    }

    private static string Write<TState>(Action<Utf8JsonWriter, TState> write, TState state)
    {
        using var stream = new MemoryStream();
        using (var writer = new Utf8JsonWriter(stream, new JsonWriterOptions
               {
                   Indented = true,
                   Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
               }))
        {
            write(writer, state);
            writer.Flush();
        }
        return Encoding.UTF8.GetString(stream.ToArray()) + "\n";
    }
}
