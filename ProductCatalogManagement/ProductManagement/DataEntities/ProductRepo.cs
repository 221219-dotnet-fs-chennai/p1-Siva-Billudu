using DataEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntities
{
    public class ProductRepo : IProductRepo
    {
        private readonly ProductManagementDbContext context;
        public ProductRepo(ProductManagementDbContext _context)
        {
            context = _context;
          
        }
        public Product AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return product;


        }

        public Product DeleteProduct(Guid PId)
        {
            var prd=context.Products.Where(p=>p.PId==PId).FirstOrDefault();
            context.Products.Remove(prd);
            context.SaveChanges();
            return prd;
           
        }

        public Product  GetProductsByCategoryId(int CategoryId)
        {
            var pps = GetProducts();
            var result=pps.FirstOrDefault(p=>p.CategoryId==CategoryId);
            return result;

        }

        public Product GetProductById(Guid PId)
        {
            var pp = (from p in context.Products
                      where p.PId==PId
                      select p).FirstOrDefault();
            return pp;
        }

        public List<Product> GetProducts()
        {
            var ca = (from c in context.Products
                      where c.ProductName != null
                      orderby c.ProductName
                      select c).ToList();
            return ca;
        }

        public Product UpdateProduct(Product product)
        {
           context.Products.Update(product);
            context.SaveChanges();
            return product;
        }
    }
}
