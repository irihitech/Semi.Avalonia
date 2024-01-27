# Semi.Avalonia

[![Semi Avalonia](https://img.shields.io/nuget/v/Semi.Avalonia.svg?color=red&style=flat-square)](https://www.nuget.org/packages/Semi.Avalonia/)
[![Semi Avalonia](https://img.shields.io/nuget/dt/Semi.Avalonia.svg?style=flat-square)](https://www.nuget.org/packages/Semi.Avalonia/)

Avalonia Theme inspired by Semi Design

# How to Use

## Installation
```bash
dotnet add package Semi.Avalonia --version 11.0.7
```
Include Semi Design Styles in application:

```xaml
<Application.Styles>
    <StyleInclude Source="avares://Semi.Avalonia/Themes/Index.axaml" />
</Application.Styles>
```

That's all. 

ColorPicker, DataGrid and TreeDataGrid are distributed in separated packages. Please install if you need. 
```bash
dotnet add package Semi.Avalonia.ColorPicker --version 11.0.7
dotnet add package Semi.Avalonia.DataGrid --version 11.0.7
dotnet add package Semi.Avalonia.TreeDataGrid --version 11.0.7
```
```xaml
<Application.Styles>
    <StyleInclude Source="avares://Semi.Avalonia.ColorPicker/Index.axaml" />
    <StyleInclude Source="avares://Semi.Avalonia.DataGrid/Index.axaml" />
    <StyleInclude Source="avares://Semi.Avalonia.TreeDataGrid/Index.axaml" />
</Application.Styles>
```

## Demo

You can always download demo executable to play around with Semi Avalonia Themes.
https://github.com/irihitech/Semi.Avalonia/releases

## Version compatibility

| Semi Design Version | Avalonia Version |
|:--------------------|:-----------------|
| 11.0.7              | 11.0.7           |
| 11.0.1              | <=11.0.6         |

## TODO
* FocusAdorner

## Credits

[Semi Design](https://semi.design/)

[Avalonia](https://github.com/AvaloniaUI/Avalonia)

[FluentAvalonia](https://github.com/amwx/FluentAvalonia)

[Material Design Icons](https://pictogrammers.com/library/mdi/)

[CommunityToolKit](https://github.com/CommunityToolkit/dotnet)

## Screenshot

Light Mode
![Light](./docs/Light.png)

Dark Mode
![Dark](./docs/Dark.png)