using System.Collections.ObjectModel;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Semi.Avalonia.Demo.ViewModels;

public class SplitViewDemoViewModel : ObservableObject
{
    public ObservableCollection<string> Songs { get; set; } =
    [
        "320万年前",
        "隐德来希",
        "孔明",
        "锦鲤卟噜噜",
        "指鹿为马",
        "热带季风Remix",
        "加州梦境",
        "渐近自由",
        "世界所有的烂漫",
    ];

    public static ObservableCollection<SplitViewDisplayMode> DisplayModes { get; set; } =
    [
        SplitViewDisplayMode.Inline,
        SplitViewDisplayMode.CompactInline,
        SplitViewDisplayMode.Overlay,
        SplitViewDisplayMode.CompactOverlay,
    ];
}