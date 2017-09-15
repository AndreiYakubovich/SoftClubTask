using System;
using Intersection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class ComparerTest
    {
        [TestMethod]
        public void EqualsTrue()
        {
            Comparer comparer = new Comparer();
            T element1 = new T(){Amount = 100,Name = "Andrei",Vendor = "Bsuir"};
            T element2 = new T(){ Amount = 100, Name = "Andrei", Vendor = "Bsuir" };
            bool result = comparer.Equals(element1, element2);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EqualsFalse()
        {
            Comparer comparer = new Comparer();
            T element1 = new T() { Amount = 100, Name = "Andrei", Vendor = "Bsuir" };
            T element2 = new T() { Amount = 50, Name = "Igor", Vendor = "BNTU" };
            bool result = comparer.Equals(element1, element2);
            Assert.IsFalse(result);
        }
    }
}
