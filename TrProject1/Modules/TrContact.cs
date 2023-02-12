using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules
{
    public class TrContact
    {
        public TrContact() { }

        public int Lid { get; set; }

        public string Pincode { get; set; } = null!;

        public string City { get; set; }

        public int Cid { get; set; }

        public override string ToString()
        {
            return $"\nLid:{Lid}\nPincode:{Pincode}\nCity:{City}\n";
        }

    }
}
