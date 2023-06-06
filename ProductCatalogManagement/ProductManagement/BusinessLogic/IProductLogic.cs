using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface IProductLogic
    {
        public IEnumerable<Models.Product> GetProducts();

        public Models.Product AddProduct(Models.Product product);

        public Models.Product UpdateProduct(Guid PId,Models.Product P);

        public Models.Product DeleteProduct(Guid PId);

        public Models.Product GetProductById(Guid PId);

        public Models.Product GetProductdByCategoryId(int CategoryId);
    }
}
