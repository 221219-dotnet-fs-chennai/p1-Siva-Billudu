using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace BusinessLogic
{
    public static  class Mapper
    {
        public  static Models.Product Map(DataEntities.Entities.Product p)
        {
            return new Models.Product()
            {
                PId = p.PId,
                ProductName = p.ProductName,
                Cost = p.Cost,
                About = p.About,
                CategoryId = p.CategoryId,
                
            };
            
        }

        public static IEnumerable<Models.Product> Map(IEnumerable<DataEntities.Entities.Product> products)
        {
            return products.Select(Map);
        }

        public static DataEntities.Entities.Product Map(Models.Product p)
        {
            return new DataEntities.Entities.Product()
            {
                PId = p.PId,
                ProductName = p.ProductName,
                Cost = p.Cost,
                About = p.About,
                CategoryId = p.CategoryId,
                
            };
        }

        //---------product--//

        public static Models.Category Map(DataEntities.Entities.Category c)
        {
            return new Models.Category()
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName
            };
        }

        public static IEnumerable<Models.Category> Map(IEnumerable<DataEntities.Entities.Category> categories)
        {
            return categories.Select(Map);
        }

        public static DataEntities.Entities.Category Map(Models.Category c)
        {
            return new DataEntities.Entities.Category()
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName
            };
        }
    }
}
