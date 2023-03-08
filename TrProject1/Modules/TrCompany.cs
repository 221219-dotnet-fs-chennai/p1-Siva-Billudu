using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules
{
    public  class TrCompany
    {
        public TrCompany() { }
        public int Cid { get; set; }

        public string Cname { get; set; }

        public string Ctype { get; set; }

        public string Startyear { get; set; }

        public string Endyear { get; set; }

        public int Trcompanyid { get; set; }

        public override string ToString()
        {
            return $"\nCid:{Cid}\nCompany Name: {Cname}nTitle: {Ctype} Year: {Startyear}\nEnd Year: {Endyear}\n";
        }


    }
}
