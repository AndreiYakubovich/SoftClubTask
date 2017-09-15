using System;
using System.Collections.Generic;
using System.Linq;
using Intersection;
using Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTestProject
{
    [TestClass]
    public class ComparerTest
    {
        [TestMethod]
        public void EqualsTrue()
        {
            ElementEqualityComparer comparer = new ElementEqualityComparer();
            Element element1 = new Element(){Amount = 100,Name = "Andrei",Vendor = "Bsuir"};
            Element element2 = new Element(){ Amount = 100, Name = "Andrei", Vendor = "Bsuir" };
            bool result = comparer.Equals(element1, element2);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EqualsFalse()
        {
            ElementEqualityComparer comparer = new ElementEqualityComparer();
            Element element1 = new Element() { Amount = 100, Name = "Andrei", Vendor = "Bsuir" };
            Element element2 = new Element() { Amount = 50, Name = "Igor", Vendor = "BNTU" };
            bool result = comparer.Equals(element1, element2);
            Assert.IsFalse(result);
        }
    }
    
}
