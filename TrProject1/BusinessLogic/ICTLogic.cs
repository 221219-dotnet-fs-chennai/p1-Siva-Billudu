using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modules;
using EF = TEntityApi.Entities;

namespace BusinessLogic
{
    public interface ICTLogic
    {
        public EF.SivaTrContact AddTrContact(Modules.TrContact tc);

        IEnumerable<Modules.TrContact> GetTrContact();

        public Modules.TrContact UpdateTrContact(int Cid,Modules.TrContact tc);

        public Modules.TrContact DeleteTrContact(string City);

    }
}
