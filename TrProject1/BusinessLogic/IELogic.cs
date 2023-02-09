using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF = TEntityApi.Entities;
using Modules;


namespace BusinessLogic
{
    public interface IELogic
    {
        public EF.SivaTrEducation AddTrEducation(Modules.TrEducation te);
        IEnumerable<Modules.TrEducation> GetTrEducations();
          

    }
}
