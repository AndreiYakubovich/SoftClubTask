using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intersection
{
    public class T
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
