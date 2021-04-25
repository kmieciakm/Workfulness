using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workfulness.Client.Models;
using Workfulness.Client.Services.Contracts;

namespace Workfulness.Client.Services
{
    public class PlaylistManager : IPlaylistManager
    {
        private Playlist _playlist;
        public Playlist Playlist {
            get { return _playlist; }
            set {
                _playlist = value;
                PlaylistChanged?.Invoke();
            } 
        }

        public event Action PlaylistChanged;
    }
}
