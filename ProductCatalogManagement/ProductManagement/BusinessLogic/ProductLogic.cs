using DataEntities;
using DataEntities.Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace BusinessLogic
{
    public class ProductLogic : IProductLogic
    {
        private readonly IProductRepo repo;
        private readonly ProductManagementDbContext context;
        public ProductLogic(ProductManagementDbContext _context,IProductRepo _repo) 
        {
            repo = _repo;
            context = _context;
           
        }
        public Models.Product AddProduct(Models.Product product)
        {
            return Mapper.Map(repo.AddProduct(Mapper.Map(product)));
        }

        public Models.Product DeleteProduct(Guid PId)
        {
            var pat = repo.DeleteProduct(PId);
            return Mapper.Map(pat);
        }

        public Models.Product GetProductdByCategoryId(int CategoryId)
        {
            //return Mapper.Map(repo.GetByCategoryName(CategoryName));
            var pp = (from data in repo.GetProducts()
                      where data.CategoryId == CategoryId
                      select data).FirstOrDefault();
            if(pp != null)
            {
                return Mapper.Map(pp);
            }
            else
            {
                return null;
            }

        }

        public Models.Product GetProductById(Guid PId)
        {
           
           var pa=(from data in repo.GetProducts()
                   where data.PId==PId
                   select data).FirstOrDefault();
            if(pa!=null)
            {
                return Mapper.Map(pa);
            }
            else
            {
                return null;
            }

        }

        public IEnumerable<Models.Product> GetProducts()
        {
            return Mapper.Map(repo.GetProducts());
        }

        public Models.Product UpdateProduct(Guid PId,Models.Product product)
        {
            var p = (from pa in repo.GetProducts()
                     where pa.PId == PId
                     select pa).FirstOrDefault();
            if(p!=null)
            {
                p.ProductName=product.ProductName;
                p.About= product.About;
                p.Cost= product.Cost;
                p.CategoryId= product.CategoryId;

                p=repo.UpdateProduct(p);
            }
            return Mapper.Map(p);
        }
    }
}
