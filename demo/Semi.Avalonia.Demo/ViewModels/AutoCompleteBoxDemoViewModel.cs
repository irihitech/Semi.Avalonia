using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Semi.Avalonia.Demo.ViewModels;

public class AutoCompleteBoxDemoViewModel : ObservableObject
{
    public ObservableCollection<StateData> States { get; set; } =
    [
        new("Alabama", "AL", "Montgomery"),
        new("Alaska", "AK", "Juneau"),
        new("Arizona", "AZ", "Phoenix"),
        new("Arkansas", "AR", "Little Rock"),
        new("California", "CA", "Sacramento"),
        new("Colorado", "CO", "Denver"),
        new("Connecticut", "CT", "Hartford"),
        new("Delaware", "DE", "Dover"),
        new("Florida", "FL", "Tallahassee"),
        new("Georgia", "GA", "Atlanta"),
        new("Hawaii", "HI", "Honolulu"),
        new("Idaho", "ID", "Boise"),
        new("Illinois", "IL", "Springfield"),
        new("Indiana", "IN", "Indianapolis"),
        new("Iowa", "IA", "Des Moines"),
        new("Kansas", "KS", "Topeka"),
        new("Kentucky", "KY", "Frankfort"),
        new("Louisiana", "LA", "Baton Rouge"),
        new("Maine", "ME", "Augusta"),
        new("Maryland", "MD", "Annapolis"),
        new("Massachusetts", "MA", "Boston"),
        new("Michigan", "MI", "Lansing"),
        new("Minnesota", "MN", "St. Paul"),
        new("Mississippi", "MS", "Jackson"),
        new("Missouri", "MO", "Jefferson City"),
        new("Montana", "MT", "Helena"),
        new("Nebraska", "NE", "Lincoln"),
        new("Nevada", "NV", "Carson City"),
        new("New Hampshire", "NH", "Concord"),
        new("New Jersey", "NJ", "Trenton"),
        new("New Mexico", "NM", "Santa Fe"),
        new("New York", "NY", "Albany"),
        new("North Carolina", "NC", "Raleigh"),
        new("North Dakota", "ND", "Bismarck"),
        new("Ohio", "OH", "Columbus"),
        new("Oklahoma", "OK", "Oklahoma City"),
        new("Oregon", "OR", "Salem"),
        new("Pennsylvania", "PA", "Harrisburg"),
        new("Rhode Island", "RI", "Providence"),
        new("South Carolina", "SC", "Columbia"),
        new("South Dakota", "SD", "Pierre"),
        new("Tennessee", "TN", "Nashville"),
        new("Texas", "TX", "Austin"),
        new("Utah", "UT", "Salt Lake City"),
        new("Vermont", "VT", "Montpelier"),
        new("Virginia", "VA", "Richmond"),
        new("Washington", "WA", "Olympia"),
        new("West Virginia", "WV", "Charleston"),
        new("Wisconsin", "WI", "Madison"),
        new("Wyoming", "WY", "Cheyenne")
    ];
}

public class StateData(string name, string abbreviation, string capital)
{
    public string Name { get; private set; } = name;
    public string Abbreviation { get; private set; } = abbreviation;
    public string Capital { get; private set; } = capital;
}