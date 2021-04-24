using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkfulnessAPI.Services.Models
{
    public record Playlist(int Id, string Title, string CoverUrl, string Category, IEnumerable<Song> Songs);
}
