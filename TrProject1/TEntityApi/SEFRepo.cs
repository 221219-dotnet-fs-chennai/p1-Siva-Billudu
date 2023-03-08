using Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEntityApi.Entities;

namespace TEntityApi
{
    public class SEFRepo:ISRepo<Entities.SivaTrSkill>
    {
        AssociatesDbContext context = new AssociatesDbContext();
        public Entities.SivaTrSkill AddSkill(Entities.SivaTrSkill TrSkill)
        {
            context.Add(TrSkill);
            context.SaveChanges();
            return TrSkill;

        }

        public List<Entities.SivaTrSkill> GetAllSivaSkill()
        {
            return context.SivaTrSkills.ToList();
        }

        public SivaTrSkill Remove(int Sid)
        {
            var search = context.SivaTrSkills.Where(x => x.Sid == Sid).FirstOrDefault();
            if (search != null)
            {
                context.SivaTrSkills.Remove(search);
                context.SaveChanges();
            }
            return search;
        }

        public Entities.SivaTrSkill Update(Entities.SivaTrSkill TrSkill)
        {
            context.SivaTrSkills.Update(TrSkill);
            context.SaveChanges();
            return TrSkill;
        }
    }
}
