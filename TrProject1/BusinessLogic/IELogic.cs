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

        public Modules.TrEducation UpdateEducation(int TrEduid,Modules.TrEducation te);

        public Modules.TrEducation DeleteTrEducation(string Tuniversity);

    }
}
