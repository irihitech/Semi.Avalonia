using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Semi.Avalonia.Demo.Pages;

public partial class ButtonSpinnerDemo : UserControl
{
    public ButtonSpinnerDemo()
    {
        InitializeComponent();
    }

    public void OnSpin(object sender, SpinEventArgs e)
    {
        var spinner = (ButtonSpinner)sender;

        if (spinner.Content is TextBlock txtBox)
        {
            int value = Array.IndexOf(_mountains, txtBox.Text);
            if (e.Direction == SpinDirection.Increase)
                value++;
            else
                value--;

            if (value < 0)
                value = _mountains.Length - 1;
            else if (value >= _mountains.Length)
                value = 0;

            txtBox.Text = _mountains[value];
        }

    }

    private readonly string[] _mountains = new[]
    {
        "A.S.I.A",
        "饕餮人间",
        "七步咙咚呛",
        "大惊小怪",
        "The ONE",
        "以梦为马 (壮志骄阳版)",
        "emo了",
        "一眼万年",
        "冲刺吧",
        "爱的赏味期限",
        "COSMIC ANTHEM / 手紙",
        "世界晚安",
        "明年也要好好长大",
        "320万年前",
        "W.O.R.L.D.",
    };
}