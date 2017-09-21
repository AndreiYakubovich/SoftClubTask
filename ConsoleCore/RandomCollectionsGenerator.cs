using System;
using System.Collections.Generic;

namespace ConsoleCore
{
    public class RandomCollectionsGenerator
    {
        public (IEnumerable<Element>, IEnumerable<Element>) GetTwoCollections()
        {
            int count=0;
            while (count==0)
            {
                Console.WriteLine($"Enter the size of collection");
                int.TryParse(Console.ReadLine(),out count);
            }
            IEnumerable<Element> firstCollection = GetRandomCollection(count);
            return (firstCollection, GetSecondCollection(firstCollection));
        }



        private IEnumerable<Element> GetRandomCollection(int count)
        {
            Random rand = new Random();
            List<Element> collection = new List<Element>();
            List<string> VendorsList = GetVendors();
            for (int i = 0; i < count; i++)
            {
                collection.Add(new Element()
                {
                    Amount = rand.Next(),
                    Name = $"Name-{rand.Next()}-{rand.Next()}",
                    Vendor = VendorsList[rand.Next(100)]
                });
            }
            return collection;
        }

        private IEnumerable<Element> GetSecondCollection(IEnumerable<Element> firstCollection)
        {
            Random rand = new Random();
            List<Element> secondCollection = new List<Element>();
            foreach (var element in firstCollection)
            {
                if (rand.Next(10) <= 5)
                {
                    secondCollection.Add(element);
                }
                else
                {
                    secondCollection.Add(new Element()
                    {
                        Amount = rand.Next(),
                        Name = $"Name-{rand.Next()}-{rand.Next()}",
                        Vendor = $"Vendor - {rand.Next()}"
                    });
                }
            }
            return secondCollection;
        }
        private List<string> GetVendors()
        {
            List<string> vendorsList = new List<string>();
            for(int i = 0; i<=100;i++)
            {
                vendorsList.Add($"Vendor - {i}");
            }
            return vendorsList;
        }
    }

    
}
