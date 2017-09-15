using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class IntersectionTest
    {
        [TestMethod]
        public void CheckwithInt()
        {
            IEnumerable<int> first = new int[] { 1, 3, 49, 64, 71, 4 };
            IEnumerable<int> second = new int[] { 49, 27, 3, 9, 4 };
            IEnumerable<int> predictedResult = new List<int>() { 3, 49, 4 };
            IEnumerable<int> experimentResult = Intersection.Program.Intersect(first, second);
            Assert.IsTrue(predictedResult.SequenceEqual(experimentResult));
        }

    }
 }

