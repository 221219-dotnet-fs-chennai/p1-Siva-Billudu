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


    }
}
