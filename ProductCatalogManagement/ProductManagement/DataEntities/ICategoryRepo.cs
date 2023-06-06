using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntities.Entities;

namespace DataEntities
{
    public interface ICategoryRepo
    {
        
        public List<Category> GetAllCategories();

        public Category AddCategory(Category category);

        public Category UpdateCategory(Category c);

        public Category DeleteCategory( int CategoryId);

        public Category GetCategoryById(int CategoryId);
    }
}
