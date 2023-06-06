using AutoFixture;
using BusinessLogic;
using DataEntities.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProductManagement.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProduct
{
    public class TestControllerProduct
    {
        private readonly IFixture _fixture;
        private readonly Mock<IProductLogic> _ProductLogic;
        private readonly ProductController _productController;

        public TestControllerProduct()
        {
            _fixture = new Fixture();
            _ProductLogic = _fixture.Freeze<Mock<IProductLogic>>();
            _productController = new ProductController(_ProductLogic.Object);
        }
        [Fact]
        public void Getproducts_OK_Test()
        {
            var pss = _fixture.Create<Models.Product>();
            _ProductLogic.Setup(x => x.GetProducts()).Returns((IEnumerable<Models.Product>)pss);

            var res = _productController.GetProducts();
            res.Should().NotBeNull();
            res.Should().BeAssignableTo<OkObjectResult>();
            res.As<OkObjectResult>().Should().NotBeNull().And.BeOfType(pss.GetType());
            _ProductLogic.Verify(x => x.GetProducts(), Times.AtLeastOnce());
        }
        [Fact]
        public void Getproducts_NoContent_Test()
        {
            List<Product> cs = null;
            _ProductLogic.Setup(x => x.GetProducts()).Returns((IEnumerable<Models.Product>)cs);
            var res = _productController.GetProducts();
            res.Should().NotBeNull();
            res.Should().BeAssignableTo<NoContentResult>();
            _ProductLogic.Verify(x => x.GetProducts(), Times.AtLeastOnce());

        }
        [Fact]
        public void Getproducts_Bad_Test()
        {
            List<Product> cs = null;
            _ProductLogic.Setup(x => x.GetProducts()).Throws(new Exception("Something went wrong"));
            var res = _productController.GetProducts();
            res.Should().NotBeNull();
            res.Should().BeAssignableTo<BadRequestObjectResult>();
            _ProductLogic.Verify(x => x.GetProducts(), Times.AtLeastOnce());

        }
        [Fact]
        public void AddProducts_ok_Test()
        {
            var pat = _fixture.Create<Models.Product>();
            _ProductLogic.Setup(x => x.AddProduct(pat));
            var result = _productController.AddProduct(pat);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            _ProductLogic.Verify(x => x.AddProduct(pat), Times.AtLeastOnce());
        }
        [Fact]
        public void AddProducts_Bad_Test()
        {
            var pat = _fixture.Create<Models.Product>();
            _ProductLogic.Setup(x => x.AddProduct(pat)).Throws(new Exception("Something went wrong"));
            var result = _productController.AddProduct(pat);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            _ProductLogic.Verify(x => x.AddProduct(pat), Times.AtLeastOnce());
        }
        [Fact]
        public void UpdateProducts_OK_Test()
        {
            var pat=_fixture.Create<Models.Product>();
            var pid=_fixture.Create<Guid>();
            _ProductLogic.Setup(x => x.UpdateProduct(pid, pat)).Returns(pat);
            var result = _productController.UpdateProduct(pid, pat);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            _ProductLogic.Verify(x=>x.UpdateProduct(pid, pat), Times.AtLeastOnce());
        }
        [Fact]
        public void UpdateProducts_Bad_Test()
        {
            var pat = _fixture.Create<Models.Product>();
            var pid = _fixture.Create<Guid>();
            _ProductLogic.Setup(x => x.UpdateProduct(pid, pat)).Throws(new Exception("Something went wrong"));
            var result = _productController.UpdateProduct(pid, pat);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            _ProductLogic.Verify(x => x.UpdateProduct(pid, pat), Times.AtLeastOnce());

        }
        [Fact]
        public void DeleteProduct_OK_Test()
        {
            var pat = _fixture.Create<Models.Product>();
            var pid = _fixture.Create<Guid>();
            _ProductLogic.Setup(x => x.DeleteProduct(pid)).Returns(pat);
            var result = _productController.DeleteProduct(pid);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            _ProductLogic.Verify(x => x.DeleteProduct(pid), Times.AtLeastOnce());

        }
        [Fact]
        public void DeleteProduct_Bad_Test()
        {
            var pat = _fixture.Create<Models.Product>();
            var pid = _fixture.Create<Guid>();
            _ProductLogic.Setup(x => x.DeleteProduct(pid)).Throws(new Exception("Something went wrong"));
            var result = _productController.DeleteProduct(pid);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            _ProductLogic.Verify(x => x.DeleteProduct(pid), Times.AtLeastOnce());

        }
        [Fact]
        public void GetProductsbyid_OK_Test()
        {
            var pat=_fixture.Create<Models.Product>();
            var pid = _fixture.Create<Guid>();  
            _ProductLogic.Setup(x=>x.GetProductById(pid)).Returns(pat);
            var result=_productController.GetProductsByProductId(pid);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            _ProductLogic.Verify(x=>x.GetProductById(pid), Times.AtLeastOnce());
        }
        [Fact]
        public void GetProductsByid_NoContent_Test()
        {
            var pat = _fixture.Create<Models.Product>();
            var pid = _fixture.Create<Guid>();
            _ProductLogic.Setup(x => x.GetProductById(pid));
            var result = _productController.GetProductsByProductId(pid);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<NoContentResult>();
            _ProductLogic.Verify(x => x.GetProductById(pid), Times.AtLeastOnce());

        }
        [Fact]
        public void GetProductsByid_Bad_Test()
        {
            var pat = _fixture.Create<Models.Product>();
            var pid = _fixture.Create<Guid>();
            _ProductLogic.Setup(x => x.GetProductById(pid)).Throws(new Exception("Something went wrong"));
            var result = _productController.GetProductsByProductId(pid);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            _ProductLogic.Verify(x => x.GetProductById(pid), Times.AtLeastOnce());

        }

    }
}
