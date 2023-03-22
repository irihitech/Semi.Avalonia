# Semi.Avalonia

[![Semi Avalonia](https://img.shields.io/nuget/v/Semi.Avalonia.svg?color=red&style=flat-square)](https://www.nuget.org/packages/Semi.Avalonia/)
[![Semi Avalonia](https://img.shields.io/nuget/dt/Semi.Avalonia.svg?style=flat-square)](https://www.nuget.org/packages/Semi.Avalonia/)

Avalonia Theme inspired by Semi Design

> Semi.Avalonia is still in very early stage. Please don't use in production.

# How to Use

## Installation
```bash
dotnet add package Semi.Avalonia --version 0.1.0-preview6
```
Include Semi Design Styles in application:

```xaml
<Application.Styles>
    <StyleInclude Source="avares://Semi.Avalonia/Themes/Index.axaml" />
</Application.Styles>
```

That's all. 

DataGrid and ColorPicker are distributed in separated packages. Please install if you need. 
```bash
dotnet add package Semi.Avalonia.ColorPicker --version 0.1.0-preview6
dotnet add package Semi.Avalonia.DataGrid --version 0.1.0-preview6
```
```xaml
<Application.Styles>
    <StyleInclude Source="avares://Semi.Avalonia.DataGrid/Index.axaml" />
    <StyleInclude Source="avares://Semi.Avalonia.ColorPicker/Index.axaml" />
</Application.Styles>
```

## Demo

You can always download demo executable to play around with Semi Avalonia Themes.
https://github.com/irihitech/Semi.Avalonia/releases

## Version compatibility

| Semi Design Version | Avalonia Version |
|:--------------------|:-----------------|
| 0.1.0-preview3      | 11.0-preview4    |
| 0.1.0-preview5.x    | 11.0-preview5    |
| 0.1.0-preview6.x    | 11.0-preview6    |

## TODO
* DataValidationErrors
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