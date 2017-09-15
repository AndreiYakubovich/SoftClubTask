using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intersection
{
    public class Comparer : IEqualityComparer<T>  //Custom Comparer which allow user to change comparison algorithm
    {
        public bool Equals(T firstElement, T secondElement)
        {
            if (secondElement != null && firstElement != null && firstElement.GetHashCode() == secondElement.GetHashCode())
                if (string.Equals(firstElement.Name, secondElement.Name) &&
                    string.Equals(firstElement.Vendor, secondElement.Vendor) &&
                    firstElement.Amount == secondElement.Amount)
                    return true;
            return false;
        }

        public int GetHashCode(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
