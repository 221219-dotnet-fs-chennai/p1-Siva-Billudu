using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TData
{
    public class TraineeSkills
    {
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public string Experience { get; set; }
        public int TSkillsId { get; set; }
        public TraineeSkills() { }

        public TraineeSkills(int skillId, string skillName, string experience, int tSkillsId)
        {
            this.SkillId = skillId;
            this.SkillName = skillName;
            this.Experience = experience;
            this.TSkillsId = tSkillsId;
        }

        public override string ToString()
        {
            return $"{SkillId}, {SkillName} ,{Experience},{TSkillsId}";
        }
    }
}

    
