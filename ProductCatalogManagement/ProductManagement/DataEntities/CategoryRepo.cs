using Azure.Core;
using DataEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataEntities
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly ProductManagementDbContext context;
        public CategoryRepo(ProductManagementDbContext _context)
        {
            context = _context;
             
        }
        public Category AddCategory(Category category)
        {
           context.Categories.Add(category);
            context.SaveChanges();
            return category;
        }

        public Category DeleteCategory(int CategoryId)
        {
            var prd = context.Categories.Where(p => p.CategoryId == CategoryId).FirstOrDefault();
            context.Categories.Remove(prd);
            context.SaveChanges();
            return prd;
        }

        public List<Category> GetAllCategories()
        {
            var ca=(from c in context.Categories
                    where c.CategoryName != null orderby c.CategoryName select c).ToList();
            return ca;
        }

        public Category GetCategoryById(int CategoryId)
        {
            var pp = (from p in context.Categories
                      where p.CategoryId == CategoryId
                      select p).FirstOrDefault();
            return pp;
        }

        public Category UpdateCategory( DataEntities.Entities.Category c)
        {
           context.Categories.Update(c);
            context.SaveChanges();
            return c;
        }
    }
}
