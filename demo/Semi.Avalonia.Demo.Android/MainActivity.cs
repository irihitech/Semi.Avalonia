using Android.App;
using Android.Content.PM;
using Avalonia.Android;

namespace Semi.Avalonia.Demo;

[Activity(Label = "Semi.Avalonia.Demo.Android", Icon = "@drawable/Icon",
    LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
public class MainActivity : AvaloniaMainActivity
{
}