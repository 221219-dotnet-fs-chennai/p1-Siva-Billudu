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
    public class ELogic : IELogic
    {
        IERepo<EF.Entities.SivaTrEducation> erepo;
        public ELogic() {
            erepo = new EF.TEFRepo();
        }
        public SivaTrEducation AddTrEducation(TrEducation te)
        {
            return erepo.AddEducation(Mapper.MapEducation(te));
        }

        public IEnumerable<TrEducation> GetTrEducations()
        {
            return Mapper.MapEducation(erepo.GetAllSivaEducation());
        }
    }
}
