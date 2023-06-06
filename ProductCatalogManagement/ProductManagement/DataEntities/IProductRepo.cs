using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntities.Entities;

namespace DataEntities
{
    public interface IProductRepo
    {
        public List<Product> GetProducts();

        public Product AddProduct(Product product);

        public Product UpdateProduct(Product product);

        public Product DeleteProduct(Guid PId);

        public  Product GetProductById(Guid PId);

        public DataEntities.Entities.Product GetProductsByCategoryId(int CategoryId);
    }
}
