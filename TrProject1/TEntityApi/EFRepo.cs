using Microsoft.EntityFrameworkCore;
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
        public bool SignIn(string Email)
        {

            var email = context.SivaTrDetails.Where(t => t.Email == Email).First();
            return true;
        }
            public Entities.SivaTrDetail Add(Entities.SivaTrDetail TrDetails)
        {
            context.SivaTrDetails.Add(TrDetails);
            context.SaveChanges();
            return TrDetails;
        }

        public Entities.SivaTrDetail Remove(string Fullname)
        {
            var search=context.SivaTrDetails.Where(x => x.Fullname== Fullname).FirstOrDefault();
            if (search != null)
            {
                context.SivaTrDetails.Remove(search);
                context.SaveChanges();
            }
            return search;
        }
     
        public List<Entities.SivaTrDetail> GetAllSivaDetail()
        {
            return context.SivaTrDetails.ToList();
        }

     
        public Entities.SivaTrDetail Update(Entities.SivaTrDetail TrDetails)
        {
            context.SivaTrDetails.Update(TrDetails);
            context.SaveChanges();
            return TrDetails;

        }
    }
}
