using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class TEducation
    {
        public TEducation() { }  
        public TEducation(string TUniversity , string HdegreeName, string Cgpa,string startdate,string enddate) { 
            this.TUniversity = TUniversity;
            this.HdegreeName = HdegreeName;
            this.Cgpa = Cgpa;  
            this.startDate= startDate;
            this.endDate= endDate;
        }  
        public string TUniversity { get; set; }
        public string HdegreeName{ get; set; }
        public string Cgpa{ get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }

        public override string ToString()
        {
            return $"\nInstitute Name: {TUniversity}\nDegree: {HdegreeName}\nGPA:{Cgpa}nStart Date: {startDate}\nEnd Date: {endDate}\n";
        }

    }
}
