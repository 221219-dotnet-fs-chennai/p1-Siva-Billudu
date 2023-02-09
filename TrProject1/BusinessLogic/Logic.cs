using Microsoft.EntityFrameworkCore.SqlServer.Migrations.Internal;
using Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public IEnumerable<Modules.TrDetails> GetTrDetails()
        {
            return Mapper.MapDetail(repo.GetAllSivaDetail());
        }

        public SivaTrDetail UpdateTrDetails(string Fullname, TrDetails td)
        {
            var SivaTrDetail = (from str in repo.GetAllSivaDetail()
                                where str.Fullname == Fullname &&
                                str.TrId== td.TrId
                                select str).FirstOrDefault();
            if(SivaTrDetail !=null)
            {
                SivaTrDetail.Fullname = Fullname;
                SivaTrDetail.TrId = td.TrId;
                SivaTrDetail.Gender = td.Gender;
                SivaTrDetail.Email = td.Email;
                SivaTrDetail.Password= td.Password;
                SivaTrDetail.Phone= td.Phone;
                SivaTrDetail.Website= td.Website;

                SivaTrDetail = repo.Update(SivaTrDetail); 
            }
            return Mapper.MapDetail(EF.SivaTrDetail);
        }

    }
}
