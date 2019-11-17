using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public static class Extensions
    {
        public static bool HasDuplicates<ItemType>(this IEnumerable<ItemType> items)
        {
            return items.GroupBy(item => item).Any(group => group.Count() > 1);
        }
    }
}
