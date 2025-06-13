using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopMusic.Models
{
    public class Song
    {
        public string Name { get; set; }
        public string SongImg { get; set; }
        public int Year { get; set; }
        public string Time { get; set; }
        public List<string> Lyrics { get; set; }
    }
}
