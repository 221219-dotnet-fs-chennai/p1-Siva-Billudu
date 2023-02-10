using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF = TEntityApi.Entities;
using Modules;

namespace BusinessLogic
{
    public interface ISkillLogic
    {
        public EF.SivaTrSkill AddTrSkill(Modules.TrSkill ts);

        IEnumerable<Modules.TrSkill> GetTrSkill();

        public Modules.TrSkill DeleteTrSkill(int Sid);

    }
}
