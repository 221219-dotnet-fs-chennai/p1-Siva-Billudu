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
        public EF.SivaTrDetail AddTrDetails(Modules.TrDetails td);

        IEnumerable<Modules.TrDetails> GetTrDetails();

        public Modules.TrDetails UpdateTrDetails(string Fullname,Modules.TrDetails td);


        public Modules.TrDetails DeleteTrDetail(string Fullname);



    }
}
