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
           IntersectionAlgorithms intersectionClass = new IntersectionAlgorithms();
           RandomCollectionsGenerator generator = new RandomCollectionsGenerator();
           (IEnumerable<Element> firstCollection, IEnumerable<Element> secondCollection) =
                generator.GetTwoCollections();
            intersectionClass.GetIntersectionByFields(firstCollection, secondCollection);
            intersectionClass.GetIntersectionByLinq(firstCollection, secondCollection);
            Console.WriteLine($"As you can see, LINQ method works much faster. I thinks thats because LINQ was written on IL code with a high degree of optimization");
            Console.ReadLine();
        }
    }
}
