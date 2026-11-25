using System;
using Avalonia.Controls;

namespace Semi.Avalonia.Demo.Pages;

public partial class CalendarDemo : ContentPage
{
    public CalendarDemo()
    {
        InitializeComponent();

        var today = DateTime.Today;
        singleDate.SelectedDate = today;
        singleRange.SelectedDates.AddRange(today.AddDays(-3), today.AddDays(1));
        multipleRange.SelectedDates.AddRange(today.AddDays(-9), today.AddDays(-6));
        multipleRange.SelectedDates.AddRange(today.AddDays(3), today.AddDays(6));
    }
}