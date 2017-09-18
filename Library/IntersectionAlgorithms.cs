using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    public class IntersectionAlgorithms
    {
        public static IEnumerable<T> GetIntersection<T>(
            IEnumerable<T> firstCollection, IEnumerable<T> secondCollection, IEqualityComparer<T> comparer = null)
        {
            if (firstCollection == null || secondCollection == null)
            {
                throw new ArgumentNullException();
            }
            comparer = comparer ?? EqualityComparer<T>.Default;
            List<T> resultList = new List<T>();
            foreach (var elementA in firstCollection)
            {
                resultList.AddRange(secondCollection.Where(x => comparer.Equals(elementA, x) &&
                                                                !resultList.Contains(x, comparer)).ToList());
            }
            return resultList;
        }


        public static double GetPercentOfDifference<T>(IEnumerable<T> firstCollection, IEnumerable<T> secondCollection)
        {
            return ((double)firstCollection.Count() / (double)secondCollection.Count()) * 100;
        }
    }
}
