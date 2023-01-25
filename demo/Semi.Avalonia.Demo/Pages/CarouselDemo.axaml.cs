using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Semi.Avalonia.Demo.Pages;

public partial class CarouselDemo : UserControl
{
    public CarouselDemo()
    {
        InitializeComponent();
        Previous.Click += OnPreviousClick;
        Next.Click += OnNextClick;
    }

    private void OnPreviousClick(object sender, RoutedEventArgs args)
    {
        carousel.Previous();
    }
    
    private void OnNextClick(object sender, RoutedEventArgs args)
    {
        carousel.Next();
    }
}