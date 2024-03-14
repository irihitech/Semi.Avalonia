# Semi Avalonia

[![Semi Avalonia](https://img.shields.io/nuget/v/Semi.Avalonia.svg?color=red&style=flat-square)](https://www.nuget.org/packages/Semi.Avalonia/)
[![Semi Avalonia](https://img.shields.io/nuget/dt/Semi.Avalonia.svg?style=flat-square)](https://www.nuget.org/packages/Semi.Avalonia/)

[English](./README.md)

Avalonia UI 控件主题，灵感来自 Semi Design

如果您希望使用更多的拓展控件，欢迎尝试 [Ursa](https://github.com/irihitech/Ursa.Avalonia)

![Light](./docs/demo.jpg)

## 如何使用

### 安装

```bash
dotnet add package Semi.Avalonia --version 11.0.7
```

在样式中引用 Semi 主题：

```xaml
<Application.Styles>
    <StyleInclude Source="avares://Semi.Avalonia/Themes/Index.axaml" />
</Application.Styles>
```

这样就可以了。

ColorPicker， DataGrid 和 GreeDataGrid 的样式单独分发，如果需要请安装并引用。

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

## 示例

您可以从 Semi Avalonia 的 release 页下载并试用 Semi Avalonia 的展示应用。

<https://github.com/irihitech/Semi.Avalonia/releases>

## 版本兼容性

| Semi Design Version | Avalonia Version |
|:--------------------|:-----------------|
| 11.0.7              | >=11.0.7           |
| 11.0.1              | <=11.0.6         |

## 代办事项

* FocusAdorner

## 致谢

[Semi Design](https://semi.design/)

[Avalonia](https://github.com/AvaloniaUI/Avalonia)

[FluentAvalonia](https://github.com/amwx/FluentAvalonia)

[Material Design Icons](https://pictogrammers.com/library/mdi/)

[CommunityToolKit](https://github.com/CommunityToolkit/dotnet)

