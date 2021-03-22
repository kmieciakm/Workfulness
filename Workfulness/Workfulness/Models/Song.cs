using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workfulness.Models
{
    public record Song
    {
        public int SongId { get; init; }
        public string Title { get; init; }
        public string Author { get; init; }
        public string SongUrl { get; init; }

        public string SongFullName { get { return $"{Author} - {Title}"; } }
    }
}