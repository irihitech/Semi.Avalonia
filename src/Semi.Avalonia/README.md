# Semi.Avalonia

[![Semi Avalonia](https://img.shields.io/nuget/v/Semi.Avalonia.svg?color=red&style=flat-square)](https://www.nuget.org/packages/Semi.Avalonia/)
[![Semi Avalonia](https://img.shields.io/nuget/dt/Semi.Avalonia.svg?style=flat-square)](https://www.nuget.org/packages/Semi.Avalonia/)

Avalonia Theme inspired by Semi Design

## Installation

```bash
dotnet add package Semi.Avalonia
```

## Usage

Include Semi Design Styles in your application:

```xaml
<Application
    ...
    xmlns:semi="https://irihi.tech/semi">
    <Application.Styles>
        <semi:SemiTheme Locale="zh-CN" />
    </Application.Styles>
</Application>
```

That's all.

## Additional Packages

ColorPicker, DataGrid, TreeDataGrid, Dock, Tabalonia and AvaloniaEdit are distributed in separated packages. Please install if you need.

```bash
dotnet add package Semi.Avalonia.ColorPicker
dotnet add package Semi.Avalonia.DataGrid
dotnet add package Semi.Avalonia.TreeDataGrid
dotnet add package Semi.Avalonia.Dock
dotnet add package Semi.Avalonia.Tabalonia
dotnet add package Semi.Avalonia.AvaloniaEdit
```

```xaml
<Application.Styles>
    <semi:ColorPickerSemiTheme />
    <semi:DataGridSemiTheme />
    <semi:TreeDataGridSemiTheme />
    <semi:DockSemiTheme />
    <semi:TabaloniaSemiTheme />
    <semi:AvaloniaEditSemiTheme />
</Application.Styles>
```

## Resources

- [Documentation](https://docs.irihi.tech/semi/)
- [Repository](https://github.com/irihitech/Semi.Avalonia)
- [Online Demo](https://irihitech.github.io/Semi.Avalonia/)
- [Download Demo](https://github.com/irihitech/Semi.Avalonia/releases)

## Credits

[Semi Design](https://semi.design/)

[Avalonia](https://github.com/AvaloniaUI/Avalonia)

[FluentAvalonia](https://github.com/amwx/FluentAvalonia)

[Material Design Icons](https://pictogrammers.com/library/mdi/)

[CommunityToolKit](https://github.com/CommunityToolkit/dotnet)
