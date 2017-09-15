using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
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
