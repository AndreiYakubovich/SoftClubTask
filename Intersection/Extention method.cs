using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intersection
{
    public static class Extention
    {
        public static IEnumerable<T> Intersect<T>(this IEnumerable<T> firstList, IEnumerable<T> secondList,
            IEqualityComparer<T> comparer)
        {
            return Program.Intersect<T>(firstList, secondList, comparer);
        }
    }

}
