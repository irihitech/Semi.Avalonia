using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Controls.Models.TreeDataGrid;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Semi.Avalonia.Demo.ViewModels;

public class SongsPageViewModel : ObservableObject
{
    public FlatTreeDataGridSource<SongViewModel> Songs { get; }

    public SongsPageViewModel()
    {
        var songs = new ObservableCollection<SongViewModel>(Song.Songs.Select(a => new SongViewModel()
        {
            Title = a.Title,
            Artist = a.Artist,
            Album = a.Album,
            CountOfComment = a.CountOfComment,
            IsSelected = false
        }));

        Songs = new FlatTreeDataGridSource<SongViewModel>(songs)
        {
            Columns =
            {
                new CheckBoxColumn<SongViewModel>(
                    "IsSelected",
                    a => a.IsSelected, 
                    (model, b) => { model.IsSelected = b; },
                    new GridLength(108, GridUnitType.Pixel)),
                new TextColumn<SongViewModel, string>(
                    "Title", 
                    a => a.Title, 
                    (o, a) => o.Title = a,
                    new GridLength(6, GridUnitType.Star)),
                new TextColumn<SongViewModel, string>("Artist", 
                    a => a.Artist, 
                    (o, a) => o.Artist = a,
                    new GridLength(6, GridUnitType.Star)),
                new TemplateColumn<SongViewModel>("Album", 
                    "AlbumCell", 
                    "AlbumEditCell",
                    new GridLength(6, GridUnitType.Star)),
                new TemplateColumn<SongViewModel>(
                    "Comments", 
                    "CommentsCell", 
                    "CommentsEditCell",
                    new GridLength(6, GridUnitType.Star)),
            }
        };
    }
}