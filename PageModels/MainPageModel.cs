using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TopMusic.Models;
using TopMusic.Services;
using System.Windows.Input;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.Maui.Controls; // Para ImageSource
using System;

namespace TopMusic.PageModels
{
    public class MainPageModel : INotifyPropertyChanged
    {
        // Comando que navega al Top10Page
        public ICommand StartCommand { get; set; }

        public MainPageModel()
        {
            StartCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync("Top10Page");
            });

            _ = LoadRandomImageAsync();
        }

        private ImageSource _randomImageSource;
        private Random _random = new Random();

        public ImageSource RandomImageSource
        {
            get => _randomImageSource;
            set
            {
                if (_randomImageSource != value)
                {
                    _randomImageSource = value;
                    OnPropertyChanged(nameof(RandomImageSource));
                }
            }
        }

        public async Task LoadRandomImageAsync()
        {
            var dataService = new DataService();
            var artists = await dataService.GetArtists();

            if (artists != null && artists.Count > 0)
            {
                var randomIndex = _random.Next(artists.Count);
                var imgFileName = artists[randomIndex].ArtistImg;

                // Asigna la imagen a recursos locales
                RandomImageSource = ImageSource.FromFile(imgFileName);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
