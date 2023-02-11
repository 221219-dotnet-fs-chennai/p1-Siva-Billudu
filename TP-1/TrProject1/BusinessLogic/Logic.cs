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
        public TrDetails AddTrDetails(TrDetails td)
        {
            //  return repo.Add(Mapper.MapDetail(td));

            return Mapper.MapDetail(repo.Add(Mapper.MapDetail(td)));
            //return Mapper.Map(_repo.AddRestaurant(Mapper.Map(r)));
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
            var u = (from tr in repo.GetAllSivaDetail()
                     where tr.Fullname == Fullname &&
                     tr.TrId == td.TrId
                     select tr).FirstOrDefault();
            if (u != null)
            {
                u.Fullname = td.Fullname;
                u.TrId = td.TrId;
                u.Gender = td.Gender;
                u.Email = td.Email;
                u.Password = td.Password;
                u.Phone = td.Phone;
                u.Website = td.Website;

                // u = repo.UpdateTrDetails(u);
            }
            return Mapper.MapDetail(u);
            //return repo.Update(Mapper.MapDetail(td));



        }
    }
}

