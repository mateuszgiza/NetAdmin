using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace NetAdmin.Infrastructure
{
    public static class EnumerableExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HaveItems<T>(this IEnumerable<T> collection)
        {
            return collection != null && collection.Any();
        }
    }
}