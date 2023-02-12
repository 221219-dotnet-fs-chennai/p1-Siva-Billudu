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
            td.Email = Validation.IsValidEmail(td.Email) ? td.Email : throw new ("Invalid email format");
            td.Password = Validation.IsValidPassword(td.Password) ? td.Password : throw new ("enter Password of length 8-20 with at lest 1 Uppercase Letter,1 number");
            td.Phone = Validation.IsValidPhone(td.Phone) ? td.Phone : throw new ("Enter Phone with 10 digits");
            td.Gender = Validation.IsValidGender(td.Gender) ? td.Gender : throw new ("Enter Male/Female");
            td.Website = Validation.IsValidWebsite(td.Website) ? td.Website : throw new ("Invalid website format");
          

            return Mapper.MapDetail(repo.Add(Mapper.MapDetail(td)));
            
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

        public TrDetails UpdateTrDetails(int TrId, TrDetails td)
        {
            var u = (from tr in repo.GetAllSivaDetail()
                     where 
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

                u = repo.Update(u);
            }
            return Mapper.MapDetail(u);
            //return repo.Update(Mapper.MapDetail(td));



        }
    }
}

