# Semi Avalonia

[![Semi Avalonia](https://img.shields.io/nuget/v/Semi.Avalonia.svg?color=red&style=flat-square)](https://www.nuget.org/packages/Semi.Avalonia/)
[![Semi Avalonia](https://img.shields.io/nuget/dt/Semi.Avalonia.svg?style=flat-square)](https://www.nuget.org/packages/Semi.Avalonia/)
[![GitCode](https://gitcode.com/IRIHI_Technology/Semi.Avalonia/star/badge.svg)](https://gitcode.com/IRIHI_Technology/Semi.Avalonia)

[English](./README.md)

Avalonia UI 控件主题，灵感来自 Semi Design

Semi.Avalonia 现在可以在浏览器上 [查看效果](https://irihitech.github.io/Semi.Avalonia/)

如果您希望查看更详细的文档，请浏览 [Semi 文档](https://docs.irihi.tech/semi/)

如果您希望使用更多的拓展控件，欢迎尝试 [Ursa](https://github.com/irihitech/Ursa.Avalonia)

![Light](./docs/demo.jpg)

## 如何使用

### 安装

```bash
dotnet add package Semi.Avalonia
```

在样式中引用 Semi 主题：

```xaml
<Application
    ...
    xmlns:semi="https://irihi.tech/semi">
    <Application.Styles>
        <semi:SemiTheme Locale="zh-CN" />
    </Application.Styles>
</Application>
```

这样就可以了。

ColorPicker、DataGrid、TreeDataGrid、Dock、Tabalonia 和 AvaloniaEdit 的样式单独分发，如果需要请安装并引用。

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

注意：Dock、Tabalonia 和 AvaloniaEdit 是通过 NuGet 免费分发的，但不是开源的。请阅读许可协议并同意后继续使用这些包。如果您需要源代码，请通过电子邮件联系我们：[contact@irihi.tech](contact@irihi.tech)

## 示例

您可以从 Semi Avalonia 的 release 页下载并试用 Semi Avalonia 的展示应用。
<https://github.com/irihitech/Semi.Avalonia/releases>

## 社区支持

我们提供有限度的免费社区支持，如果您有任何问题或建议，除了在GitHub上提交issue或发起讨论，也欢迎加入我们的飞书交流群：

![FeiShu](./docs/community-support.png)

## 版本兼容性

| Semi Design Version | Avalonia Version |
|:--------------------|:-----------------|
| 11.3.7              | 11.3.7           |
| 11.2.1              | >=11.2.1         |
| 11.2.0              | 11.2.0           |
| 11.1.0              | >=11.1.0         |
| 11.0.7              | >=11.0.7         |
| 11.0.1              | <=11.0.6         |

## 致谢

[Semi Design](https://semi.design/)

[Avalonia](https://github.com/AvaloniaUI/Avalonia)

[FluentAvalonia](https://github.com/amwx/FluentAvalonia)

[Material Design Icons](https://pictogrammers.com/library/mdi/)

[CommunityToolKit](https://github.com/CommunityToolkit/dotnet)

