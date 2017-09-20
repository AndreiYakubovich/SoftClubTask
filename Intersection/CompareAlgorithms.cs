using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Intersection
{
    public class CompareAlgorithms
    {
        public delegate IEnumerable<Element> methodedelegade(IEnumerable<Element> firstCollection,
            IEnumerable<Element> secondCollection);

        public static void GetIntersectionByFields(IEnumerable<Element> firstCollection, IEnumerable<Element> secondCollection)
        {
            IEnumerable<Element> resultList;
            Stopwatch timer = new Stopwatch();
            Console.WriteLine($"Field comparison algorithm without hash checking:{Environment.NewLine}");
            timer.Start();
            resultList = GetIntersection(firstCollection, secondCollection, new ElementEqualityComparer())
                .ToList();
            timer.Stop();
            Console.WriteLine(
                $"time of the field comparison algorithm = {timer.ElapsedMilliseconds}, coincidence percentage = {GetPercentOfDifference(resultList, firstCollection)}%{Environment.NewLine}");
        }

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

        public static void GetIntersectionMethods(IEnumerable<Element> firstCollection,
            IEnumerable<Element> secondCollection, methodedelegade methode)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            IEnumerable<Element> resultList = methode(firstCollection, secondCollection);
            timer.Stop();
            Console.WriteLine(
                $"Time of the algorithm = {timer.ElapsedMilliseconds},coincidence percentage = {GetPercentOfDifference(resultList, firstCollection)}%{Environment.NewLine}");
        }

        public static IEnumerable<Element> GetIntersectionByLinq(IEnumerable<Element> firstCollection,
            IEnumerable<Element> secondCollection)
        {
            return firstCollection.Intersect(secondCollection, new ElementEqualityComparer());
        }


        public static IEnumerable<Element> GetIntersectionListwithDictionaries(IEnumerable<Element> firstCollection,
            IEnumerable<Element> secondCollection)
        {
            Dictionary<string, List<Element>> firstDictionary = firstCollection.GroupBy(o => o.Vendor).ToDictionary(g => g.Key, g => g.ToList());
            Dictionary<string, List<Element>> secondDictionary = secondCollection.GroupBy(o => o.Vendor).ToDictionary(g => g.Key, g => g.ToList());
            List<Element> resultList = new List<Element>();
            foreach (var firstventor in firstDictionary)
            {
                List<Element> secondvendorgroup = new List<Element>();
                secondDictionary.TryGetValue(firstventor.Key, out secondvendorgroup);
                foreach (var element in firstventor.Value)
                {
                    if (secondvendorgroup.Contains(element))
                        resultList.Add(element);
                }
            }

           
            return resultList;
        }



    }

    public class Element
    {
        public string Name;
        public string Vendor;
        public int Amount;

        public override int GetHashCode()
        {
            return (Name == null ? 0 : Name.GetHashCode()) +
                   (Vendor == null ? 0 : Vendor.GetHashCode()) +
                   Amount.GetHashCode();
        }
    }

}

