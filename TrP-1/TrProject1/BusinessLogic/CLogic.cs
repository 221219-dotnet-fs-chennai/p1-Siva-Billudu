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

    public class CLogic:ICLogic
    {
        ICRepo<EF.Entities.SivaTrcompany> mrepo;
        public CLogic()
        {
            mrepo = new EF.MEFRepo();
        }

        public SivaTrcompany AddTrCompany(TrCompany cc)
        {
            return mrepo.AddCompany(Mapper.MapCompany(cc));
        }

        public TrCompany DeleteTrCompany(string Cname)
        {
            var deletedCompany = mrepo.Remove(Cname);
            if (deletedCompany != null)
                return Mapper.MapCompany(deletedCompany);
            else
                return null;

        }

        public IEnumerable<TrCompany> GetTrCompany()
        {
            return Mapper.MapCompany(mrepo.GetAllSivaCompany());
        }
    }
}
