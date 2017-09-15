using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intersection
{
    public class Comparer : IEqualityComparer<Element>  //Custom Comparer which allow user to change comparison algorithm
    {
        public bool Equals(Element firstElement, Element secondElement)
        {
            if (secondElement != null && firstElement != null && firstElement.GetHashCode() == secondElement.GetHashCode())
                if (string.Equals(firstElement.Name, secondElement.Name) &&
                    string.Equals(firstElement.Vendor, secondElement.Vendor) &&
                    firstElement.Amount == secondElement.Amount)
                    return true;
            return false;
        }

        public int GetHashCode(Element obj)
        {
            throw new NotImplementedException();
        }
    }
}
