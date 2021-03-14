using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workfulness.Models
{
    public record Song
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string SongUrl { get; set; }

        public string SongFullName { get { return $"{Author} - {Title}"; } }
    }
}