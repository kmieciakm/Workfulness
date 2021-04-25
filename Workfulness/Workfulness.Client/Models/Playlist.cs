using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workfulness.Client.Models
{
    public record Playlist
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public string CoverUrl { get; set; }
        public List<Song> Songs { get; set; } = new List<Song>();
        public Song CurrentSong { get { return Songs?.ElementAt(CurrentSongIndex); } }
        private int CurrentSongIndex { get; set; } = 0;

        public void SwitchToNextSong()
        {
            if (Songs.Count > CurrentSongIndex + 1)
            {
                CurrentSongIndex++;
            }
        }

        public void SwitchToPreviousSong()
        {
            if (CurrentSongIndex > 0)
            {
                CurrentSongIndex--;
            }
        }

        public void SwitchSongById(int songId)
        {
            var desiredSongIndex = Songs?.FindIndex(song => song.Id == songId);
            if (desiredSongIndex.HasValue || desiredSongIndex != -1)
            {
                CurrentSongIndex = desiredSongIndex.Value;
            }
        }

        public void SwitchToBeginning() {
            CurrentSongIndex = 0;
        }
    }
}
