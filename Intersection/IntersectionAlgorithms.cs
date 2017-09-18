using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace Intersection
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

        public void GetIntersectionByFields<T>(IEnumerable<T> firstCollection, IEnumerable<T> secondCollection)
            where T : Element
        {
            IEnumerable<Element> resultList;
            Stopwatch timer = new Stopwatch();
            Console.WriteLine($"Field comparison algorithm without hash checking:{Environment.NewLine}");
            timer.Start();
            resultList = GetIntersection(firstCollection, secondCollection, new ElementEqualityComparer())
                .ToList();
            timer.Stop();
            Console.WriteLine(
                $"time of the field comparison algorithm in ticks = {timer.ElapsedTicks}, coincidence percentage = {GetPercentOfDifference(resultList, firstCollection)}%{Environment.NewLine}");
        }

        public void GetIntersectionByLinq<T>(IEnumerable<T> firstCollection, IEnumerable<T> secondCollection)
            where T : Element
        {
            Stopwatch timer = new Stopwatch();
            Console.WriteLine($"LINQ conparison algorithm:{Environment.NewLine}");
            timer.Start();
            IEnumerable<Element> resultList =
                firstCollection.Intersect(secondCollection, new ElementEqualityComparer()).ToList();
            timer.Stop();
            Console.WriteLine(
                $"Time of the LINQ conparison algorithm in ticks = {timer.ElapsedTicks},coincidence percentage = {GetPercentOfDifference(resultList, firstCollection)}%{Environment.NewLine}");
        }

        private static double GetPercentOfDifference<T>(IEnumerable<T> firstCollection, IEnumerable<T> secondCollection)
        {
            return ((double)firstCollection.Count() / (double)secondCollection.Count()) * 100;
        }
    }
}
