using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules
{
    public interface ISRepo<T>
    {
        T AddSkill(T TrSkill);

        List<T> GetAllSivaSkill();

        T Update(string Skill,T TrSkill);

        T Remove(int Sid);

    }
}
