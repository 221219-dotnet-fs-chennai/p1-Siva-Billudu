using Microsoft.EntityFrameworkCore;
using Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        public TrEducation DeleteTrEducation(string Tuniversity)
        {
            var deletedEducation = erepo.Remove(Tuniversity);
            if (deletedEducation != null)
                return Mapper.MapEducation(deletedEducation);
            else
                return null;

        }

        public IEnumerable<TrEducation> GetTrEducations()
        {
            return Mapper.MapEducation(erepo.GetAllSivaEducation());
        }
    }
}
