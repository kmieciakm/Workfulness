using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workfulness.Client.Services.Contracts
{
    interface IPageSize
    {
        bool IsExtraSmall { get; }
        bool IsSmall { get; }
        bool IsMedium { get; }
        bool IsLarge { get; }
        bool IsExtraLarge { get; }
        int Width { get; }
        int Height { get; }

        event Action PageResized;
    }
}
