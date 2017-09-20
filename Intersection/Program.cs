using System;
using System.Collections.Generic;
using static Intersection.CompareAlgorithms;

namespace Intersection
{
    public class Program
    {
        static void Main()
        {
            RandomCollectionsGenerator generator = new RandomCollectionsGenerator();
            (IEnumerable<Element> firstCollection, IEnumerable<Element> secondCollection) =
                generator.GetTwoCollections();
            CompareAlgorithms.GetIntersectionByFields(firstCollection, secondCollection);
            Console.WriteLine($"LINQ Methode:{Environment.NewLine}");
            GetIntersectionMethods(firstCollection, secondCollection, new methodedelegade(GetIntersectionByLinq));
            Console.WriteLine($"Grouping Methode with dictionaries:{Environment.NewLine}");
            GetIntersectionMethods(firstCollection,secondCollection, new methodedelegade(GetIntersectionListwithDictionaries));
            Console.ReadLine();
        }

    }
}
