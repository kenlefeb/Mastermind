using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public static class Extensions
    {
        public static int DuplicateCount<ItemType>(this IEnumerable<ItemType> items)
        {
            return items.GroupBy(item => item).Count(group => group.Count() > 1);
        }
        public static bool HasDuplicates<ItemType>(this IEnumerable<ItemType> items)
        {
            return items.DuplicateCount() > 0;
        }
    }
}
