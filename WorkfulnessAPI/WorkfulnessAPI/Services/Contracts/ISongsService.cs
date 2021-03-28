using System.Collections.Generic;

namespace WorkfulnessAPI.Services.Contracts
{
    public interface ISongsService
    {
        IEnumerable<string> GetAllSongsUrl();
    }
}