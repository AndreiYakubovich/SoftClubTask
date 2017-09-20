using System;
using System.Collections.Generic;

namespace Intersection
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
            List<Element> collection = new List<Element>();
            List<string> VendorsList = GetVendors();
            for (int i = 0; i < count; i++)
            {
                collection.Add(new Element()
                {
                    Amount = Int32.Parse(RandomStringUtils.RandomStringUtils.RandomNumeric(5)),
                    Name = RandomStringUtils.RandomStringUtils.RandomAlphabetic(5),
                    Vendor = VendorsList[Int32.Parse(RandomStringUtils.RandomStringUtils.RandomNumeric(2))]
                });
            }
            return collection;
        }

        private IEnumerable<Element> GetSecondCollection(IEnumerable<Element> firstCollection)
        {
            List<Element> secondCollection = new List<Element>();
            foreach (var element in firstCollection)
            {
                if (Int32.Parse(RandomStringUtils.RandomStringUtils.RandomNumeric(1)) <= 5)
                {
                    secondCollection.Add(element);
                }
                else
                {
                    secondCollection.Add(new Element()
                    {
                        Amount = Int32.Parse(RandomStringUtils.RandomStringUtils.RandomNumeric(5)),
                        Name = RandomStringUtils.RandomStringUtils.RandomAlphabetic(5),
                        Vendor = RandomStringUtils.RandomStringUtils.RandomAlphabetic(6)
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
                vendorsList.Add(RandomStringUtils.RandomStringUtils.RandomAlphabetic(6));
            }
            return vendorsList;
        }
    }

    
}
