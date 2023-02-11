using Modules;
using System.Security.Cryptography;
using TEntityApi.Entities;
using TData = TEntityApi.Entities;

namespace BusinessLogic
{
    public class Mapper
    {
        public static Modules.TrDetails MapDetail(TData.SivaTrDetail s )
        {
            return new Modules.TrDetails()
            {
                TrId = s.TrId,
                Fullname=s.Fullname,
                Phone=s.Phone,
                Website=s.Website,
                Gender=s.Gender,
                Email=s.Email,
                Password=s.Password

                };
        }

        public static TData.SivaTrDetail MapDetail(Modules.TrDetails s)
        {
            return new TData.SivaTrDetail()
            {
                TrId = s.TrId,
                Fullname = s.Fullname,
                Phone = s.Phone,
                Website = s.Website,
                Gender = s.Gender,
                Email=s.Email,
                Password=s.Password

            };
        }
        public static IEnumerable<TrDetails> MapDetail(List<SivaTrDetail> sivaTrDetails)
        {
            return sivaTrDetails.Select(MapDetail);
        }
//.............................Mapskill

        public static Modules.TrSkill MapSkill(TData.SivaTrSkill si)
          {
              return new Modules.TrSkill()
              {
                  Sid = si.Sid,
                  Skill = si.Skill,
                  Trskillid=si.Trskillid
                  


              };
          }

        public static TData.SivaTrSkill MapSkill(Modules.TrSkill si)
        {
            return new TData.SivaTrSkill()
            {
                Sid = si.Sid,
                Skill = si.Skill,
                Trskillid=si.Trskillid
                
            };
        }
       public static IEnumerable<TrSkill> MapSkill(List<SivaTrSkill> sivaTrSkills)
        {
            return sivaTrSkills.Select(MapSkill);
        }
     

//..............................MapEducation
        public static Modules.TrEducation MapEducation(TData.SivaTrEducation siv)
         {
             return new Modules.TrEducation()
             {
                 Eid=siv.Eid,
                 Tuniversity=siv.Tuniversity,
                 HdegreeName=siv.HdegreeName,
                 Cgpa=siv.Cgpa,
                 Startdate=siv.Startdate,
                 PassoutDate=siv.PassoutDate,
                 TrEduid=siv.TrEduid

             };
         }

        public static TData.SivaTrEducation MapEducation(Modules.TrEducation siv)
        {
            return new TData.SivaTrEducation()
            {
                Eid = siv.Eid,
                Tuniversity = siv.Tuniversity,
                HdegreeName = siv.HdegreeName,
                Cgpa = siv.Cgpa,
                Startdate = siv.Startdate,
                PassoutDate = siv.PassoutDate,
                TrEduid = siv.TrEduid
            };
        }
        public static IEnumerable<TrEducation> MapEducation(List<SivaTrEducation> sivaTrEducations)
        {
            return sivaTrEducations.Select(MapEducation);
        }


        //....................MapCompany
        public static Modules.TrCompany MapCompany(TData.SivaTrcompany sit)
          {
              return new Modules.TrCompany()
              {
                  Cid=sit.Cid,
                  Cname=sit.Cname,
                  Ctype=sit.Ctype,
                  Startyear = sit.Startyear,
                  Endyear = sit.Endyear,
                  Trcompanyid=sit.Trcompanyid
              };
          }

        public static  TData.SivaTrcompany MapCompany(Modules.TrCompany sit)
        {
            return new TData.SivaTrcompany()
            {
                Cid = sit.Cid,
                Cname = sit.Cname,
                Ctype = sit.Ctype,
                Startyear = sit.Startyear,
                Endyear = sit.Endyear,
                Trcompanyid = sit.Trcompanyid
            };
        }
        public static IEnumerable<TrCompany> MapCompany(List<SivaTrcompany> sivaTrCompanys)
        {
            return sivaTrCompanys.Select(MapCompany);
        }



        //..................MapContact
        public static Modules.TrContact MapContact(TData.SivaTrContact sc)
          {
              return new Modules.TrContact()
              {
                  Lid=sc.Lid,
                  Pincode=sc.Pincode,
                  City=sc.City,
                  Cid=sc.Cid
              };
          }

        public static TData.SivaTrContact MapContact(Modules.TrContact sc)
        {
            return new TData.SivaTrContact()
            {
                Lid = sc.Lid,
                Pincode = sc.Pincode,
                City = sc.City,
                Cid= sc.Cid
            };
        }
        public static IEnumerable<TrContact> MapContact(List<SivaTrContact> sivaTrContacts)
        {
            return sivaTrContacts.Select(MapContact);
        }









    }
}


    
