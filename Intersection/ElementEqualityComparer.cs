using System.Collections.Generic;

namespace Intersection
{
    public class ElementEqualityComparer : IEqualityComparer<Element>  //Custom Comparer which allow user to change comparison algorithm
    {
        public bool Equals(Element firstElement, Element secondElement)
        {
            if (secondElement != null && firstElement != null)
                return firstElement.Name.Equals(secondElement.Name) &&
                       firstElement.Vendor.Equals(secondElement.Vendor) &&
                       firstElement.Amount == secondElement.Amount;
            return false;
        }

        public int GetHashCode(Element obj)
        {
            return obj.GetHashCode();
        }
    }
}
