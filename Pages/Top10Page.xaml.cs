using TopMusic.Models;
namespace TopMusic.Pages;

public partial class Top10Page : ContentPage
{
    public Top10Page()
    {
        InitializeComponent();
    }
    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Artist selectedArtist)
        {
            // Navega a la página del artista, enviando el nombre como param
            await Shell.Current.GoToAsync($"{nameof(ArtistPage)}?Artista={selectedArtist.Name}");
        }

    // Limpia la selección para permitir volver a seleccionar el mismo artista
    ((CollectionView)sender).SelectedItem = null;
    }
}