using System.Collections.Generic;

namespace Library
{
    public static class IntersectionExt
    {
        public static IEnumerable<T> IntersectExt<T>(this IEnumerable<T> firstList, IEnumerable<T> secondList,
            IEqualityComparer<T> comparer = null)
        {
            return IntersectionAlgorithms.GetIntersection(firstList, secondList, comparer);
        }
    }
}