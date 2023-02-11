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

        public TrEducation UpdateEducation(int TrEduid, TrEducation te)
        {
            var u = (from ee in erepo.GetAllSivaEducation()
                     where ee.TrEduid == TrEduid
                     select ee).FirstOrDefault();
            if (u != null)
            {
                u.Cgpa = te.Cgpa;
                u.Tuniversity = te.Tuniversity;
                u.Eid = te.Eid;
                u.HdegreeName = te.HdegreeName;
                u.Startdate = te.Startdate;
                u.PassoutDate = te.PassoutDate;
                u.TrEduid = te.TrEduid;

                u = erepo.Update(u);

            }
            return Mapper.MapEducation(u);

        }
    }
}
