using BusinessLogic;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TEntityApi.Entities;
using EF = TEntityApi.Entities;


    namespace Test
{
    [TestFixture]
    public class TestMapper
    {
        [Test]
        public void TestMap()
        {
            Modules.TrDetails trDetails= new Modules.TrDetails();

            var detailEF= Mapper.MapDetail(trDetails);

            Assert.AreEqual(detailEF.GetType(),typeof(EF.SivaTrDetail));
        }
        [Test]
        public void TestMaps()
        {
            EF.SivaTrDetail detailEF= new EF.SivaTrDetail();

            var trData=Mapper.MapDetail(detailEF);
            Assert.AreEqual(trData.GetType(),typeof(EF.SivaTrDetail));
        }
        [Test]
        public void TestSkillMap()
        {
            EF.SivaTrSkill skillEF= new EF.SivaTrSkill();
            var trSkill=Mapper.MapSkill(skillEF);
            Assert.AreEqual(trSkill.GetType(),typeof(EF.SivaTrSkill));
        }
        [Test]
        public void TestEducationMap()
        {
            EF.SivaTrEducation educationEF= new EF.SivaTrEducation();
            var trEd=Mapper.MapEducation(educationEF);
            Assert.AreEqual(trEd.GetType(),typeof(EF.SivaTrEducation));
        }
        [Test]
        public void TestContactMap()
        {
            EF.SivaTrContact contactEF= new EF.SivaTrContact();
            var trContact=Mapper.MapContact(contactEF);
            Assert.AreEqual(contactEF.GetType(),typeof(EF.SivaTrContact));
        }
        [Test]
        public void TestCompany()
        {
            EF.SivaTrcompany companyEF=new EF.SivaTrcompany();
            var trCompany=Mapper.MapCompany(companyEF);
            Assert.AreEqual(companyEF.GetType(),typeof(EF.SivaTrcompany));
        }


    }
}