using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Intersection
{
    public class Program
    {
        public static IEnumerable<T> Intersect<T>(IEnumerable<T> firstList, IEnumerable<T> secondList, IEqualityComparer<T> comparer)
        {
            List<T> resultList = new List<T>();
            foreach (var elementA in firstList)
            {
               resultList.AddRange(secondList.Where(x => comparer.Equals(elementA, x) && !resultList.Contains(x,comparer)));
            }
            return resultList;
        }

       
        static void Main()
        {
            IEnumerable<T> firstList = new List<T>()
            {
                new T() {Amount = 1333, Name = "Glados", Vendor = "Aperture Science"},
                new T() {Amount = 1, Name = "Gordon", Vendor = "Black Mesa"},
                new T() {Amount = 535, Name = "Chief", Vendor = "ODST"},
                new T() {Amount = 354, Name = "Mario", Vendor = "Mashroom Kingdom"},
                new T() {Amount = 255, Name = "Max", Vendor = "NewYork"},
                new T() {Amount = 1, Name = "Sam", Vendor = "Sam&Max"},
                new T() {Amount = 524, Name = "Andrei", Vendor = "BSUIR"}
            }; //First element collection
            IEnumerable<T> secondList = new List<T>()
            {
                new T() {Amount = 524, Name = "Andrei", Vendor = "BSUIR"},
                new T() {Amount = 524, Name = "Andrei", Vendor = "BSUIR"},
                new T() {Amount = 245355, Name = "Max", Vendor = "Payne"},
                new T() {Amount = 1531, Name = "Ivan", Vendor = "ODST"},
                new T() {Amount = 1531, Name = "Cartman", Vendor = "Mashroom Kingdom"},
                new T() {Amount = 1, Name = "Sam", Vendor = "Sam&Max"},
            }; //Second element collection
            IEnumerable<T> resultList = new List<T>(); //Result collection of Intersected elements

            Comparer comparer = new Comparer();
            Stopwatch timer = new Stopwatch();

            Console.WriteLine($"1) field comparison algorithm with hash checking:{Environment.NewLine}");
            timer.Start();
            for (int i = 0; i < 1000; i++)
            {
                resultList = Intersect(firstList, secondList, comparer);
            }
            timer.Stop();
            ToConsole(resultList);
            Console.WriteLine($"time of the field comparison algorithm in ticks = {timer.ElapsedTicks / 1000}{Environment.NewLine}");


           Console.WriteLine($"2) LINQ conparison algorithm:{Environment.NewLine}");
            timer.Restart();
            for (int i = 0; i < 1000; i++)
            {
                resultList = firstList.Intersect(secondList, new Comparer());
            }
            timer.Stop();
            ToConsole(resultList);
            Console.WriteLine($"time of the LINQ conparison algorithm in ticks = {timer.ElapsedTicks / 1000}{Environment.NewLine}");
            Console.Read();
        }

        private static void ToConsole<T>(IEnumerable<T> collection) where T : Intersection.T
        {
            Console.WriteLine(String.Format($"We found {collection.Count()} intersections:"));
            foreach (var element in collection)
            {   
                Console.WriteLine(String.Format($"{element.Name} from {element.Vendor} with {element.Amount} amount"));
            }
            Console.WriteLine();
        }
    }
}
