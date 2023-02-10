﻿using Microsoft.EntityFrameworkCore;
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
       
        IEnumerable<TrSkill> ISkillLogic.GetTrSkill()
        {
            return Mapper.MapSkill(srepo.GetAllSivaSkill());
        }
    }
}