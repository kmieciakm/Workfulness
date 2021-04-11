using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkfulnessAPI.Services.Models
{
    public record Song(int Id, string Title, string Author, string Url, string FileName, string FilePath);
}
