using DataEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface ICategoryLogic
    {
        public IEnumerable<Models.Category> GetAllCategories();

        public Models.Category AddCategory(Models.Category category);

        public Models.Category UpdateCategory(int CategoryId,Models.Category c);

        public Models.Category DeleteCategory(int CategoryId);

        public Models.Category  GetCategoryByCategoryId(int CategoryId);
    }
}
