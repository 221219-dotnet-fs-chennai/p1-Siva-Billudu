using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Migrations.Internal;
using Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEntityApi;
using TEntityApi.Entities;
using EF = TEntityApi;

namespace BusinessLogic
{
    public class Logic : ILogic
    {
        IRepo<EF.Entities.SivaTrDetail> repo;
        public Logic()
        {
            repo = new EF.EFRepo();
            
        }
         public SivaTrDetail AddTrDetails(TrDetails td)
        {
            return repo.Add(Mapper.MapDetail(td));
        }

        public TrDetails DeleteTrDetail(string Fullname)
        {
            var deletedTrainer = repo.Remove(Fullname);
            if (deletedTrainer != null)
                return Mapper.MapDetail(deletedTrainer);
            else
                return null;

        }

        public IEnumerable<Modules.TrDetails> GetTrDetails()
        {
            return Mapper.MapDetail(repo.GetAllSivaDetail());
        }

        public TrDetails UpdateTrDetails(string Fullname, TrDetails td)
        {
            throw new NotImplementedException();
        }
    }
}
