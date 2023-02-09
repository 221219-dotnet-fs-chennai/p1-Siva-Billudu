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
            return crepo.AddContact(Mapper.MapContact(tc));
                
        }

        public IEnumerable<TrContact> GetTrContact()
        {
            return Mapper.MapContact(crepo.GetAllSivaContact());
        }
    }
}
