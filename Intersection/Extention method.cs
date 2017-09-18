using System.Collections.Generic;

namespace Intersection
{
    public static class Extention
    {
        public static IEnumerable<T> IntersectExt<T>(this IEnumerable<T> firstList, IEnumerable<T> secondList,
            IEqualityComparer<T> comparer = null)
        {
            return new IntersectionAlgorithm().Intersect(firstList, secondList, comparer);
        }
    }
}