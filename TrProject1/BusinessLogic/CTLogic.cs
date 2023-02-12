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
    public class CTLogic : ICTLogic
    {
        ICTRepo<EF.Entities.SivaTrContact> crepo;
        public CTLogic()
        {
            crepo = new EF.CEFRepo();
        }
        public SivaTrContact AddTrContact(TrContact tc)
        {
            tc.Pincode = Validation.IsValidPincode(tc.Pincode) ? tc.Pincode : throw new Exception("ivalid pincode");
            return crepo.AddContact(Mapper.MapContact(tc));

        }

        public TrContact DeleteTrContact(string City)
        {
            var deletedContact = crepo.Remove(City);
            if (deletedContact != null)
            {
                return Mapper.MapContact(deletedContact);
            }
            else
                return null;
        }

        public IEnumerable<TrContact> GetTrContact()
        {
            return Mapper.MapContact(crepo.GetAllSivaContact());
        }

        public TrContact UpdateTrContact(int Cid, TrContact tc)
        {
            var u = (from cc in crepo.GetAllSivaContact()
                     where cc.Cid == Cid
                     select cc).FirstOrDefault();
            if (u != null)
            {
                u.Cid = tc.Cid;
                u.Lid = tc.Lid;
                u.Pincode = tc.Pincode;
                u.City = tc.City;

                u = crepo.Update(u);
            }
            return Mapper.MapContact(u);

        }
    }
}

