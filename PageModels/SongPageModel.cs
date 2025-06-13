using System.ComponentModel;
using System.Runtime.CompilerServices;
using TopMusic.Models;

namespace TopMusic.PageModels
{
    [QueryProperty(nameof(Song), "Cancion")]
    public class SongPageModel : INotifyPropertyChanged
    {
        private Song _song;

        public Song Song
        {
            get => _song;
            set
            {
                _song = value;
                OnPropertyChanged();
                SongName = _song.Name;
                SongImg = _song.SongImg;
                Year = _song.Year;
                Time = _song.Time;
                Lyrics = string.Join("\n", _song.Lyrics);
            }
        }

        private string _songName;
        public string SongName { get => _songName; set { _songName = value; OnPropertyChanged(); } }

        private string _songImg;
        public string SongImg { get => _songImg; set { _songImg = value; OnPropertyChanged(); } }

        private int _year;
        public int Year { get => _year; set { _year = value; OnPropertyChanged(); } }

        private string _time;
        public string Time { get => _time; set { _time = value; OnPropertyChanged(); } }

        private string _lyrics;
        public string Lyrics { get => _lyrics; set { _lyrics = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}