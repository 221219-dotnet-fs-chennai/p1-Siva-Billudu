using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules
{
    public  class TrSkill
    {
        public TrSkill() { }

        public int Sid { get; set; }
        public string Skill{ get; set; }
        public int Trskillid { get; set; }

        

        public override string ToString()
        {
            return $" Sid:{Sid}\nSkill Name: {Skill}\n";
        }
    }
}
