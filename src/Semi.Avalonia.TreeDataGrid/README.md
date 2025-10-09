# Semi.Avalonia.TreeDataGrid

[![Semi Avalonia](https://img.shields.io/nuget/v/Semi.Avalonia.svg?color=red&style=flat-square)](https://www.nuget.org/packages/Semi.Avalonia/)

Avalonia TreeDataGrid Theme inspired by Semi Design

This package provides Semi Design theming for the Avalonia TreeDataGrid control.

## Installation

```bash
dotnet add package Semi.Avalonia.TreeDataGrid
```

## Prerequisites

This package requires the main Semi.Avalonia theme to be installed:

```bash
dotnet add package Semi.Avalonia
```

## Usage

Include the TreeDataGrid theme in your application:

```xaml
<Application
    ...
    xmlns:semi="https://irihi.tech/semi">
    <Application.Styles>
        <semi:SemiTheme Locale="zh-CN" />
        <semi:TreeDataGridSemiTheme />
    </Application.Styles>
</Application>
```

## Resources

- [Documentation](https://docs.irihi.tech/semi/)
- [Repository](https://github.com/irihitech/Semi.Avalonia)
- [Online Demo](https://irihitech.github.io/Semi.Avalonia/)
- [Download Demo](https://github.com/irihitech/Semi.Avalonia/releases)

## Credits

[Semi Design](https://semi.design/)

[Avalonia](https://github.com/AvaloniaUI/Avalonia)
