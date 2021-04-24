using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkfulnessAPI.Services.Models
{
    public class Song {
        public int Id { get; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string FileName { get; set; }

        public Song(int id, string title, string author, string fileName)
        {
            Id = id;
            Title = title;
            Author = author;
            FileName = fileName;
        }
    }
}
