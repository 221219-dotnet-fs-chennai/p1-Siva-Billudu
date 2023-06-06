using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF = DataEntities.Entities;

namespace TestProduct
{
    [TestFixture]
    public class TestMapper
    {
        [Test]
        public void TestCategory()
        {
            Models.Category category = new Models.Category();
            var cc=Mapper.Map(category);
            Assert.That(typeof(EF.Category), Is.EqualTo(cc.GetType()));
        }
        [Test]
        public void TestProduct()
        {
            Models.Product product = new Models.Product();
            var pp=Mapper.Map(product);
            Assert.That(typeof(EF.Product), Is.EqualTo(pp.GetType()));
        }
        [Test]
        public void TestCategories()
        {
            EF.Category category = new EF.Category();
            var cc=Mapper.Map(category);
            Assert.That(typeof(Models.Category), Is.EqualTo(cc.GetType())); 
        }
        [Test]
        public void TestProducts()
        {
            EF.Product product = new EF.Product();
            var pp=Mapper.Map(product);
            Assert.That(typeof(Models.Product), Is.EqualTo(pp.GetType()));
        }

    }
}
