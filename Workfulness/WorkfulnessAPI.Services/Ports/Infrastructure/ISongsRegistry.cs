using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkfulnessAPI.Services.Models;

namespace WorkfulnessAPI.Services.Ports.Infrastructure
{
    public interface ISongsRegistry
    {
        public Song Get(int id);
        public void Add(Song song);
        public void Remove(int id);
        public void Update(Song song);
    }
}
