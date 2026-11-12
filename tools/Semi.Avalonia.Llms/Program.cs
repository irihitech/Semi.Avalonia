using System.Text;

namespace Semi.Avalonia.Llms;

/// <summary>
/// Writes the files for AI assistants into the web root of a published demo host:
/// <code>
///   dotnet run --project tools/Semi.Avalonia.Llms -- &lt;repo-root&gt; &lt;wwwroot&gt; [--base-url https://irihitech.github.io/Semi.Avalonia]
/// </code>
/// Extracts every fact from the repository's own sources and refuses to write anything when the sources are
/// inconsistent (token constants without definitions, palettes or theme variants out of sync, broken links).
/// </summary>
public static class Program
{
    public static int Main(string[] args)
    {
        if (args.Length is not (2 or 4) || (args.Length == 4 && args[2] != "--base-url"))
        {
            Console.Error.WriteLine($"usage: Semi.Avalonia.Llms <repo-root> <wwwroot> [--base-url {Pages.DefaultBaseUrl}]");
            return 2;
        }

        var root = Path.GetFullPath(args[0]);
        var output = Path.GetFullPath(args[1]);
        var baseUrl = args.Length == 4 ? args[3] : Pages.DefaultBaseUrl;

        var lib = new Library(root);
        foreach (var warning in lib.Warnings) Console.Error.WriteLine($"warning: {warning}");
        if (lib.Errors.Count > 0)
        {
            foreach (var error in lib.Errors) Console.Error.WriteLine($"error: {error}");
            Console.Error.WriteLine($"{lib.Errors.Count} inconsistencies; nothing written.");
            return 1;
        }

        var files = Pages.Build(lib, baseUrl);
        if (Pages.BrokenLinks(files, baseUrl) is { Count: > 0 } broken)
        {
            foreach (var link in broken) Console.Error.WriteLine($"broken link: {link}");
            return 1;
        }

        var utf8 = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);
        foreach (var file in files)
        {
            var path = Path.Combine(output, file.Path);
            Directory.CreateDirectory(Path.GetDirectoryName(path)!);
            File.WriteAllText(path, file.Text, utf8);
        }
        Console.WriteLine($"Wrote {files.Count} files ({files.Sum(f => utf8.GetByteCount(f.Text)) / 1024} KB) for {baseUrl} to {output}");
        Console.WriteLine($"{(lib.HasConstants ? lib.Tokens.Count : lib.Variables.Count)} tokens, {lib.PaletteBrushes.Count} semantic brushes, {lib.Controls.Count} themed controls, "
                          + $"{lib.Controls.Count(c => c.Demo is not null)} demo pages.");
        return 0;
    }
}
