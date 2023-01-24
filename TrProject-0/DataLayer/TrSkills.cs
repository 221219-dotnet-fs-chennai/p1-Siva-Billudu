using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class TrSkills
    {
        public TrSkills() { } 
        public TrSkills(string skillName) { 
            this.skillName = skillName; 
        }
        public string skillName { get; set; }
        public int Trskillid{get;set; }

        public override string ToString()
        {
            return $"\nSkill Name: {skillName}"; 
        }
    }
}
