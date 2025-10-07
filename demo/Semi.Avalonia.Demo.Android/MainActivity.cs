using Android.App;
using Android.Content.PM;
using Avalonia;
using Avalonia.Android;

namespace Semi.Avalonia.Demo.Android;

[Activity(
    Label = "Semi.Avalonia",
    Theme = "@style/MyTheme.NoActionBar",
    Icon = "@drawable/Icon",
    MainLauncher = true,
    LaunchMode = LaunchMode.SingleTop,
    ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.UiMode)]
public class MainActivity : AvaloniaMainActivity<App>
{
    protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
    {
        return base.CustomizeAppBuilder(builder)
            .WithSourceHanSansCNFont();
    }
}