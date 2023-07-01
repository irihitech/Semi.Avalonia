using Android.App;
using Android.Content;
using Avalonia;
using Avalonia.Android;
using Application = Android.App.Application;

namespace Semi.Avalonia.Demo.Android;

[Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
public class SplashActivity: AvaloniaMainActivity<App>
{
    protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
    {
        return base.CustomizeAppBuilder(builder);
    }

    protected override void OnResume()
    {
        base.OnResume();
        StartActivity(new Intent(Application.Context, typeof(MainActivity)));
    }
}