using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workfulness.Models
{
    public record Playlist
    {
        public string Title { get; init; }
        public string CoverUrl { get; init; }
        public List<Song> Songs { get; init; }
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
            var desiredSongIndex = Songs?.FindIndex(song => song.SongId == songId);
            if (desiredSongIndex.HasValue || desiredSongIndex != -1)
            {
                CurrentSongIndex = desiredSongIndex.Value;
            }
        }
    }
}
