using System;
using System.Collections.Generic;
using static ConsoleCore.CompareAlgorithms;

namespace ConsoleCore
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine(".NET Core Приложение");
            RandomCollectionsGenerator generator = new RandomCollectionsGenerator();
            (IEnumerable<Element> firstCollection, IEnumerable<Element> secondCollection) =
                generator.GetTwoCollections();
            //GetIntersectionByFields(firstCollection, secondCollection);
            Console.WriteLine($"LINQ Methode:{Environment.NewLine}");
            GetIntersectionMethods(firstCollection, secondCollection, new CompareAlgorithms.methodedelegade(GetIntersectionByLinq));
            Console.WriteLine($"Grouping Methode with dictionaries:{Environment.NewLine}");
            GetIntersectionMethods(firstCollection, secondCollection, new CompareAlgorithms.methodedelegade(GetIntersectionListwithDictionaries));
            Console.ReadLine();
        }
    }
}
