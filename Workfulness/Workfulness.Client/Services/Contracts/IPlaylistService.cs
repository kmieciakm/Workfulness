using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workfulness.Client.Models;

namespace Workfulness.Client.Services.Contracts
{
    interface IPlaylistService
    {
        Task<Playlist> GetPlaylistAsync(int id);
    }
}
