using TopMusic.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using TopMusic.Services;
using System.Linq;

namespace TopMusic.PageModels
{
    [QueryProperty(nameof(ArtistaName), "Artista")]
    public class ArtistPageModel : INotifyPropertyChanged
    {
        private string _artistaName;
        public string ArtistaName
        {
            get => _artistaName;
            set
            {
                if (_artistaName != value)
                {
                    _artistaName = value;
                    OnPropertyChanged(nameof(ArtistaName));
                    _ = LoadArtistAsync();
                }
            }
        }

        private Artist _artist;
        public Artist Artist
        {
            get => _artist;
            set
            {
                _artist = value;
                OnPropertyChanged(nameof(Artist));
            }
        }

        public ObservableCollection<Song> Songs { get; set; } = new ObservableCollection<Song>();

        private Song _selectedSong;
        public Song SelectedSong
        {
            get => _selectedSong;
            set
            {
                if (_selectedSong != value)
                {
                    _selectedSong = value;
                    OnPropertyChanged(nameof(SelectedSong));

                    if (_selectedSong != null)
                    {
                        Shell.Current.GoToAsync(nameof(SongPage), new Dictionary<string, object>
                        {
                            { "Cancion", _selectedSong }
                        });

                        SelectedSong = null;
                    }
                }
            }
        }

        private async Task LoadArtistAsync()
        {
            var dataService = new DataService();
            var artists = await dataService.GetArtists();

            Artist = artists.FirstOrDefault(a => a.Name == ArtistaName);

            if (Artist != null && Artist.Songs != null)
            {
                Songs.Clear();
                foreach (var song in Artist.Songs)
                {
                    Songs.Add(song);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}