using Microsoft.EntityFrameworkCore.Migrations;
using Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEntityApi.Entities;

namespace TEntityApi
{
    public class EFRepo : IRepo<Entities.SivaTrDetail> 
    {
        AssociatesDbContext context = new AssociatesDbContext();
        public Entities.SivaTrDetail Add(Entities.SivaTrDetail TrDetails)
        {
            context.Add(TrDetails);
            context.SaveChanges();
            return TrDetails;
        }

        public List<Entities.SivaTrDetail> GetAllSivaDetail()
        {
            return context.SivaTrDetails.ToList();
        }

        public Entities.SivaTrDetail Update(Entities.SivaTrDetail TrDetails)
        {
            context.Update(TrDetails);
            context.SaveChanges();
            return TrDetails;
        }
    }
}
