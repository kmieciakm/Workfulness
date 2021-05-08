using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkfulnessAPI.Services.Helpers
{
    public static class StringExtenstions
    {
        public static bool EqualsCaseInsensitive(this string text, string to)
        {
            return string.Compare(text, to, StringComparison.OrdinalIgnoreCase) == 0;
        }
    }
}
