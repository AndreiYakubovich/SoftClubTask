using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Library;

namespace Intersection
{
    public class IntersectAlgorithms
    {
        public IEnumerable<T> Intersect<T>(
            IEnumerable<T> firstList, IEnumerable<T> secondList, IEqualityComparer<T> comparer = null)
        {
            if (firstList == null || secondList == null)
            {
                throw new ArgumentNullException();
            }
            comparer = comparer ?? EqualityComparer<T>.Default;
            List<T> resultList = new List<T>();
            foreach (var elementA in firstList)
            {
                resultList.AddRange(secondList.Where(x => comparer.Equals(elementA, x) &&
                                                          !resultList.Contains(x, comparer)));
            }
            return resultList;
        }

        private static (IEnumerable<Element>, IEnumerable<Element>) GetLists()
        {
            IEnumerable<Element> firstList = new List<Element>()
            {
                new Element() {Amount = 1333, Name = "Glados", Vendor = "Aperture Science"},
                new Element() {Amount = 1, Name = "Gordon", Vendor = "Black Mesa"},
                new Element() {Amount = 535, Name = "Chief", Vendor = "ODST"},
                new Element() {Amount = 354, Name = "Mario", Vendor = "Mashroom Kingdom"},
                new Element() {Amount = 255, Name = "Max", Vendor = "NewYork"},
                new Element() {Amount = 1, Name = "Sam", Vendor = "Sam&Max"},
                new Element() {Amount = 1, Name = "Sam", Vendor = "Sam&Max"},
                new Element() {Amount = 524, Name = "Andrei", Vendor = "BSUIR"}
            }; //First element collection
            IEnumerable<Element> secondList = new List<Element>()
            {
                new Element() {Amount = 524, Name = "Andrei", Vendor = "BSUIR"},
                new Element() {Amount = 524, Name = "Andrei", Vendor = "BSUIR"},
                new Element() {Amount = 245355, Name = "Max", Vendor = "Payne"},
                new Element() {Amount = 1531, Name = "Ivan", Vendor = "ODST"},
                new Element() {Amount = 1531, Name = "Cartman", Vendor = "Mashroom Kingdom"},
                new Element() {Amount = 1, Name = "Sam", Vendor = "Sam&Max"},
            };
            return (firstList, secondList);
        }


        static void Main()
        {
            //IntersectAlgorithms intersectionClass = new IntersectAlgorithms();
            //intersectionClass.FieldComparisonAlgorithm();
            //intersectionClass.LINQcomparisonAlgorithm();
            
            Generator generator = new Generator();
            IEnumerable<Element> randomCollection = generator.GetRandomCollection();
            ToConsole(randomCollection);
            Console.Read();

        }

        private void FieldComparisonAlgorithm()
        {
            ElementEqualityComparer comparer = new ElementEqualityComparer();
            IEnumerable<Element> resultList = new List<Element>();
            Stopwatch timer = new Stopwatch();
            (IEnumerable<Element> firstList, IEnumerable<Element> secondList) = GetLists();
            Console.WriteLine($"1) field comparison algorithm with hash checking:{Environment.NewLine}");
            timer.Start();
            for (int i = 0; i < 1000; i++)
            {
                resultList = Intersect(firstList, secondList, comparer);
            }
            timer.Stop();
            ToConsole(resultList);
            Console.WriteLine(
                $"time of the field comparison algorithm in ticks = {timer.ElapsedTicks / 1000}{Environment.NewLine}");
        }

        private void LINQcomparisonAlgorithm()
        {
            IEnumerable<Element> resultList = new List<Element>();
            Stopwatch timer = new Stopwatch();
            (IEnumerable<Element> firstList, IEnumerable<Element> secondList) = GetLists();
            Console.WriteLine($"2) LINQ conparison algorithm:{Environment.NewLine}");
            timer.Start();
            for (var i = 0; i < 1000; i++)
                resultList = firstList.Intersect(secondList, new ElementEqualityComparer());
            timer.Stop();
            ToConsole(resultList);
            Console.WriteLine(
                $"time of the LINQ conparison algorithm in ticks = {timer.ElapsedTicks / 1000}{Environment.NewLine}");
            Console.Read();
        }

        private static void ToConsole<T>(IEnumerable<T> collection) where T : Element
        {
            Console.WriteLine($"We found {collection.Count()} intersections:");
            int i = 0;
            foreach (var element in collection)
            {
                Console.WriteLine($"{i} : {element.Name} from {element.Vendor} with {element.Amount} amount");
                i++;
            }
            Console.WriteLine();
        }
    }
}
