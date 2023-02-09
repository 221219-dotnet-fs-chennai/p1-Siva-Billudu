using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules
{
    public class TrEducation
    {
        public TrEducation() { }
        public int Eid { get; set; }

        public string  Tuniversity { get; set; }

        public string HdegreeName { get; set; }

        public string Cgpa { get; set; }

        public string Startdate { get; set; }

        public string PassoutDate { get; set; }

        public int TrEduid { get; set; }


        public override string ToString()
        {
            return $"\nEid:{Eid}\nInstitute Name: {Tuniversity}\nDegree: {HdegreeName}\nGPA:{Cgpa}nStart Date: {Startdate}\nEnd Date: {PassoutDate}\n";
        }

    }
}
