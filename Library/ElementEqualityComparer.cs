using System;
using System.Collections.Generic;

namespace Library
{
    public class ElementEqualityComparer : IEqualityComparer<Element>  //Custom Comparer which allow user to change comparison algorithm
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
            return obj.GetHashCode();
        }
    }
}
