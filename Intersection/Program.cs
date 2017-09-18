using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Library;

namespace Intersection
{
    public class Program
    {
        static void Main()
        {
            RandomCollectionsGenerator generator = new RandomCollectionsGenerator();
           (IEnumerable<Element> firstCollection, IEnumerable<Element> secondCollection) =
                generator.GetTwoCollections();
            GetIntersectionByFields(firstCollection, secondCollection);
            GetIntersectionByLinq(firstCollection, secondCollection);
            Console.WriteLine($"As you can see, LINQ method works much faster. I thinks thats because LINQ was written on IL code with a high degree of optimization");
            Console.ReadLine();
        }

        public static void GetIntersectionByFields<T>(IEnumerable<T> firstCollection, IEnumerable<T> secondCollection)
            where T : Element
        {
            IEnumerable<Element> resultList;
            Stopwatch timer = new Stopwatch();
            Console.WriteLine($"Field comparison algorithm without hash checking:{Environment.NewLine}");
            timer.Start();
            resultList = IntersectionAlgorithms.GetIntersection<Element>(firstCollection, secondCollection, new ElementEqualityComparer())
                .ToList();
            timer.Stop();
            Console.WriteLine(
                $"time of the field comparison algorithm in ticks = {timer.ElapsedTicks}, coincidence percentage = {IntersectionAlgorithms.GetPercentOfDifference(resultList, firstCollection)}%{Environment.NewLine}");
        }

        public static void GetIntersectionByLinq<T>(IEnumerable<T> firstCollection, IEnumerable<T> secondCollection)
            where T : Element
        {
            Stopwatch timer = new Stopwatch();
            Console.WriteLine($"LINQ conparison algorithm:{Environment.NewLine}");
            timer.Start();
            IEnumerable<Element> resultList =
                firstCollection.Intersect(secondCollection, new ElementEqualityComparer()).ToList();
            timer.Stop();
            Console.WriteLine(
                $"Time of the LINQ conparison algorithm in ticks = {timer.ElapsedTicks},coincidence percentage = {IntersectionAlgorithms.GetPercentOfDifference(resultList, firstCollection)}%{Environment.NewLine}");
        }
    }
}
