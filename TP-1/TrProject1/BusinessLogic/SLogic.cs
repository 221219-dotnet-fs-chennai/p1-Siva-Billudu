using Microsoft.EntityFrameworkCore;
using Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEntityApi.Entities;
using EF = TEntityApi;


namespace BusinessLogic
{
    public  class SLogic : ISkillLogic
    {
        ISRepo<EF.Entities.SivaTrSkill> srepo;
        public SLogic() 
        {
            srepo = new EF.SEFRepo();
        }

        public SivaTrSkill AddTrSkill(TrSkill ts)
        {
            return srepo.AddSkill(Mapper.MapSkill(ts));
        }

        public Modules.TrSkill DeleteTrSkill(int Sid)
        {
            var deletedSkill = srepo.Remove(Sid);
            if (deletedSkill != null)
                return Mapper.MapSkill(deletedSkill);
            else
                return null;

        }

        public TrSkill UpdateTrSkill(string Skill, TrSkill tr)
        {
            var u=(from ss in srepo.GetAllSivaSkill()
                   where ss.Skill == Skill
                   select ss).FirstOrDefault();
            if(u != null)
            {
                u.Skill=tr.Skill;
                u.Sid=tr.Sid;
                u.Trskillid=tr.Trskillid;

//                u = srepo.UpdateTrSkill(u);
            }
            return Mapper.MapSkill(u);



        
        }

        IEnumerable<TrSkill> ISkillLogic.GetTrSkill()
        {
            return Mapper.MapSkill(srepo.GetAllSivaSkill());
        }
    }
}
