using System.Collections.Generic;

namespace WorkfulnessAPI.Services.Ports.Presenters
{
    public interface ISongsService
    {
        IEnumerable<string> GetAllSongsUrl();
    }
}