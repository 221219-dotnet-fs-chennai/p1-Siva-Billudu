using Microsoft.EntityFrameworkCore;
using Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEntityApi.Entities;

namespace TEntityApi
{
    public class MEFRepo : ICRepo<Entities.SivaTrcompany>
    {
        AssociatesDbContext context=new AssociatesDbContext();
        public SivaTrcompany AddCompany(SivaTrcompany TrCompany)
        {
            context.Add(TrCompany);
            context.SaveChanges();
            return TrCompany;
        }

        public List<SivaTrcompany> GetAllSivaCompany()
        {
            return context.SivaTrcompanies.ToList();
        }

        public SivaTrcompany Remove(string Cname)
        {
            var search = context.SivaTrcompanies.Where(x => x.Cname == Cname).FirstOrDefault();
            if (search != null)
            {
                context.SivaTrcompanies.Remove(search);
                context.SaveChanges();
            }
            return search;

        }

        public SivaTrcompany Update(SivaTrcompany TrCompany)
        {
            context.SivaTrcompanies.Update(TrCompany);
            context.SaveChanges();
            return TrCompany;
        }
    }
}
