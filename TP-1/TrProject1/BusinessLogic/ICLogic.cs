using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modules;
using EF = TEntityApi.Entities;


namespace BusinessLogic
{
    public interface ICLogic
    {
        public EF.SivaTrcompany AddTrCompany(Modules.TrCompany cc);

        IEnumerable<Modules.TrCompany> GetTrCompany();

        public Modules.TrCompany DeleteTrCompany(string  Cname);


    }
}
