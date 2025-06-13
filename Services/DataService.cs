using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TopMusic.Models;

namespace TopMusic.Services
{
    class DataService
    {
        public async Task<List<Artist>> GetArtists()
        {
            // Abre JSON 
            using var stream = await FileSystem.OpenAppPackageFileAsync("music.json");

            // lector del contenido
            using var reader = new StreamReader(stream);

            // Leemos todo el JSON como text
            var contenido = await reader.ReadToEndAsync();

            // Deserializa el texto JSON a una lista de objetos Artista
            return JsonSerializer.Deserialize<List<Artist>>(contenido);
        }
    }
}
