using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopMusic.Models
{
    public class Artist
    {
        public int Ranking { get; set; }
        public string Name { get; set; }
        public string ArtistImg { get; set; }
        public string Album { get; set; }
        public List<Song> Songs { get; set; }
    }
}