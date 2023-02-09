using Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEntityApi.Entities;

namespace TEntityApi
{
    public class TEFRepo:IERepo<Entities.SivaTrEducation>
    {
        AssociatesDbContext context = new AssociatesDbContext();

        public Entities.SivaTrEducation AddEducation(Entities.SivaTrEducation TrEducation)
        {
            context.Add(TrEducation);
            context.SaveChanges();
            return TrEducation;

        }

        public List<Entities.SivaTrEducation> GetAllSivaEducation()
        {
            return context.SivaTrEducations.ToList();
        }
    }
}
