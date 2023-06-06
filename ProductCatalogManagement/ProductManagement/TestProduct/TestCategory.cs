using AutoFixture;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using ProductManagement.Controllers;
using Xunit;
using DataEntities.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace TestProduct
{
    public class TestCategory
    {
        private readonly IFixture _fixture;
        private readonly Mock<ICategoryLogic> _CategoryLogic;
        private readonly CategoryController _categoryController;

        public TestCategory()
        {
            _fixture = new Fixture();
            _CategoryLogic=_fixture.Freeze<Mock<ICategoryLogic>>();
            _categoryController = new CategoryController(_CategoryLogic.Object);
        }

        [Fact]
        public void GetAllCategories_OK_Test()
        {
            var categoriess=_fixture.Create<Category>();
            _CategoryLogic.Setup(x => x.GetAllCategories()).Returns((IEnumerable<Models.Category>)categoriess);

            var res=_categoryController.GetAllCategories();
            res.Should().NotBeNull();
            res.Should().BeAssignableTo<OkObjectResult>();
            res.As<OkObjectResult>().Should().NotBeNull().And.BeOfType(categoriess.GetType());
            _CategoryLogic.Verify(x=>x.GetAllCategories(), Times.AtLeastOnce());
        }
        [Fact]
        public void GetAllCategories_NoContent_Test() 
        {
            List<Category> cs = null;
            _CategoryLogic.Setup(x => x.GetAllCategories()).Returns((IEnumerable<Models.Category>)cs);
            var res = _categoryController.GetAllCategories();
            res.Should().NotBeNull();
            res.Should().BeAssignableTo<NoContentResult>();
            _CategoryLogic.Verify(x => x.GetAllCategories(), Times.AtLeastOnce());

        }
        [Fact]
        public void GetAllCategories_Bad_Test() 
        {
            List<Category> cs = null;
            _CategoryLogic.Setup(x=>x.GetAllCategories()).Throws(new Exception("Something went wrong"));
            var res=_categoryController.GetAllCategories();
            res.Should().NotBeNull();
            res.Should().BeAssignableTo<BadRequestObjectResult>();
            _CategoryLogic.Verify(x=>x.GetAllCategories(),Times.AtLeastOnce());
        
        }
        [Fact]
        public void AddCategory_OKResponse_Test()
        {
            var cat=_fixture.Create<Models.Category>();
            _CategoryLogic.Setup(x => x.AddCategory(cat));
            var result= _categoryController.AddCategory(cat);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            _CategoryLogic.Verify(x=>x.AddCategory(cat), Times.AtLeastOnce());  
        }
        [Fact]
        public void AddCategory_Bad_Test()
        {
            var cat = _fixture.Create<Models.Category>();
            _CategoryLogic.Setup(x => x.AddCategory(cat)).Throws(new Exception("Somethig went wrong"));
            var result=_categoryController.AddCategory(cat);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            _CategoryLogic.Verify(x=>x.AddCategory(cat),Times.AtLeastOnce());
        }
        [Fact]
        public void UpdateCategory_OKResponse_Test()
        {
            var cat=_fixture.Create<Models.Category>();
            var Cid = _fixture.Create<int>();
            _CategoryLogic.Setup(x => x.UpdateCategory(Cid, cat)).Returns(cat);
            var res=_categoryController.UpdateCategory(Cid,cat);
            res.Should().NotBeNull();
            res.Should().BeAssignableTo<OkObjectResult>();
            res.As<OkObjectResult>().Should().NotBeNull().And.BeOfType(cat.GetType());
            _CategoryLogic.Verify(x=>x.UpdateCategory(Cid, cat), Times.AtLeastOnce());
        }
        [Fact]
        public void UpdateCategory_Bad_Test()
        {
            var cat= _fixture.Create<Models.Category>();
            var Cid= _fixture.Create<int>();
            _CategoryLogic.Setup(x => x.UpdateCategory(Cid, cat)).Throws(new Exception("Something wrong"));
            var res = _categoryController.UpdateCategory(Cid, cat);
            res.Should().NotBeNull();
            res.Should().BeAssignableTo<BadRequestObjectResult>();
            _CategoryLogic.Verify(x=>x.UpdateCategory(Cid,cat), Times.AtLeastOnce());
        }
        [Fact]
        public void DeleteCategory_OKResponse_Test()
        {
            var cat=_fixture.Create<Models.Category>();
            var Cid=_fixture.Create<int>();
            _CategoryLogic.Setup(x=>x.DeleteCategory(Cid)).Returns(cat);
            var res=_categoryController.DeleteCategory(Cid);
            res.Should().NotBeNull();
            res.Should().BeAssignableTo<OkObjectResult>();
            _CategoryLogic.Verify(x=>x.DeleteCategory(Cid), Times.AtLeastOnce());
        }
        [Fact]
        public void DeleteCategory_Bad_Test()
        {
            var cat = _fixture.Create<Models.Category>();
            var Cid = _fixture.Create<int>();
            _CategoryLogic.Setup(x => x.DeleteCategory(Cid)).Throws(new Exception("Something wrong"));
            var res = _categoryController.DeleteCategory(Cid);
            res.Should().NotBeNull();
            res.Should().BeAssignableTo<BadRequestObjectResult>();
            _CategoryLogic.Verify(x => x.DeleteCategory(Cid), Times.AtLeastOnce());
        }

    }
}
