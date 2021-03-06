using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workfulness.Client.Models
{
    public record Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Url { get; set; }
        public string FullName { get { return $"{Author} - {Title}"; } }
    }
}