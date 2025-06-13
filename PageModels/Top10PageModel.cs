using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using TopMusic.Models;
using TopMusic.Services;
using Microsoft.Maui.Controls;

namespace TopMusic.PageModels
{
    public class Top10PageModel : INotifyPropertyChanged
    {
        public ObservableCollection<Artist> Artists { get; set; } = new ObservableCollection<Artist>();

        public ICommand SelectArtistCommand { get; }

        public Top10PageModel()
        {
            LoadArtists();
            SelectArtistCommand = new Command<Artist>(async (artist) => await NavigateToArtistPage(artist));
        }

        private async void LoadArtists()
        {
            var dataService = new DataService();
            var artists = await dataService.GetArtists();

            foreach (var artist in artists)
                Artists.Add(artist);
        }

        private async Task NavigateToArtistPage(Artist artist)
        {
            if (artist != null)
            {
                await Shell.Current.GoToAsync($"{nameof(ArtistPage)}?Artista={Uri.EscapeDataString(artist.Name)}");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}