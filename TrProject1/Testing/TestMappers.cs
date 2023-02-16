using BusinessLogic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modules;
using EF = TEntityApi.Entities;

namespace Testing
{
    [TestFixture]
    public class TestMappers
    {
        [Test]
        public void TestMap()
        {
            Modules.TrDetails trDetails = new Modules.TrDetails();

            var detailEF = Mapper.MapDetail(trDetails);

            Assert.AreEqual(detailEF.GetType(), typeof(EF.SivaTrDetail));
        }
        [Test]
       public void TestMaps()
        {
            EF.SivaTrDetail detailEF = new EF.SivaTrDetail();

            var trData = Mapper.MapDetail(detailEF);
            Assert.AreEqual(trData.GetType(), typeof(Modules.TrDetails));
        }
        [Test]
        public void TestSkillMap()
        {
            EF.SivaTrSkill skillEF = new EF.SivaTrSkill();
            var trSkill = Mapper.MapSkill(skillEF);
            Assert.AreEqual(trSkill.GetType(), typeof(Modules.TrSkill));
        }
        [Test]
        public void TestEducationMap()
        {
            EF.SivaTrEducation educationEF = new EF.SivaTrEducation();
            var trEd = Mapper.MapEducation(educationEF);
            Assert.AreEqual(trEd.GetType(), typeof(Modules.TrEducation));
        }
        [Test]
        public void TestContactMap()
        {
            EF.SivaTrContact contactEF = new EF.SivaTrContact();
            var trContact = Mapper.MapContact(contactEF);
            Assert.AreEqual(contactEF.GetType(), typeof(EF.SivaTrContact));
        }
        [Test]
        public void TestCompany()
        {
            EF.SivaTrcompany companyEF = new EF.SivaTrcompany();
            var trCompany = Mapper.MapCompany(companyEF);
            Assert.AreEqual(companyEF.GetType(), typeof(EF.SivaTrcompany));
        }


    }
}
