using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workfulness.Client.Models
{
    public class PlaylistGroup
    {
        public string Category { get; set; }
        public IEnumerable<Playlist> Playlists { get; set; }
    }
}
