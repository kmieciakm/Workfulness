using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workfulness.Models;

namespace Workfulness.Services.Contracts
{
    interface IPlaylistService
    {
        Playlist GetPlaylist();
       // List<Playlist> GetPlaylistsList();
    }
}
