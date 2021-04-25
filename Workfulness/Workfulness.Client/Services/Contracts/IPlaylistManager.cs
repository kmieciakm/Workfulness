using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workfulness.Client.Models;

namespace Workfulness.Client.Services.Contracts
{
    public interface IPlaylistManager
    {
        event Action PlaylistChanged;
        public Playlist Playlist { get; set; }
    }
}
