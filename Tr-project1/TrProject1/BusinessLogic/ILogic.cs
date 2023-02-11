using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modules;
using EF = TEntityApi.Entities;

namespace BusinessLogic
{
    public interface ILogic
    {
        public Modules.TrDetails AddTrDetails(Modules.TrDetails td);

        IEnumerable<Modules.TrDetails> GetTrDetails();

       public Modules.TrDetails UpdateTrDetails(int TrId, Modules.TrDetails td);


        public Modules.TrDetails DeleteTrDetail(string Fullname);



    }
}
