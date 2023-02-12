using Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEntityApi.Entities;

namespace TEntityApi
{
    public class CEFRepo:ICTRepo<Entities.SivaTrContact>
    {
        AssociatesDbContext context = new AssociatesDbContext();
        public Entities.SivaTrContact AddContact(Entities.SivaTrContact TrContact)
        {
            context.Add(TrContact);
            context.SaveChanges();
            return TrContact;

        }
        public List<Entities.SivaTrContact> GetAllSivaContact()
        {
            return context.SivaTrContacts.ToList();
        }

        public SivaTrContact Remove(string City)
        {
            var search = context.SivaTrContacts.Where(x => x.City == City).FirstOrDefault();
            if (search != null)
            {
                context.SivaTrContacts.Remove(search);
                context.SaveChanges();
            }
            return search;
        }

        public SivaTrContact Update(SivaTrContact TrContact)
        {
            context.SivaTrContacts.Update(TrContact);
            context.SaveChanges();
            return TrContact;
        }
    }
}
