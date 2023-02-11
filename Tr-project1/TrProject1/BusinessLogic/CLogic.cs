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

        public TrCompany Update(int Trcompanyid, TrCompany cm)
        {
            var u =( from mm in mrepo.GetAllSivaCompany()
                     where mm.Trcompanyid == Trcompanyid
                     select mm).FirstOrDefault();
            if( u != null)
            {
                u.Cid= cm.Cid;
                u.Ctype= cm.Ctype;
                u.Cname= cm.Cname;
                u.Startyear= cm.Startyear;
                u.Endyear= cm.Endyear;
                u.Trcompanyid= cm.Trcompanyid;

                u = mrepo.Update(u);
            }
            return Mapper.MapCompany(u);
          
        }
    }
}
