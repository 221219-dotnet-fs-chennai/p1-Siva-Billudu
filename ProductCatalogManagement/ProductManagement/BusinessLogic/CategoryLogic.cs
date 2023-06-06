using DataEntities;
using DataEntities.Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class CategoryLogic : ICategoryLogic
    {
        private readonly ProductManagementDbContext context;
        private readonly ICategoryRepo repo;
        public CategoryLogic(ProductManagementDbContext _context,ICategoryRepo _repo) 
        {
            context = _context;
            repo = _repo;
        }
        public Models.Category AddCategory(Models.Category category)
        {
            return Mapper.Map(repo.AddCategory(Mapper.Map(category)));
        }

        public Models.Category DeleteCategory(int CategoryId)
        {
            // return Mapper.Map(repo.DeleteCategory(CategoryId,));
            var cat = repo.DeleteCategory(CategoryId);
            return Mapper.Map(cat);
        }

        public IEnumerable<Models.Category> GetAllCategories()
        {
            return Mapper.Map(repo.GetAllCategories());
        }

        public Models.Category GetCategoryByCategoryId(int CategoryId)
        {
            var pa = (from data in repo.GetAllCategories()
                      where data.CategoryId == CategoryId
                      select data).FirstOrDefault();
            if (pa != null)
            {
                return Mapper.Map(pa);
            }
            else
            {
                return null;
            }
        }

        public Models.Category UpdateCategory(int CategoryId,Models.Category c)
        {
           // return Mapper.Map(repo.UpdateCategory(CategoryId));
           var ca=(from data in repo.GetAllCategories()
                   where  data.CategoryId == CategoryId
                   select data).FirstOrDefault();
            if(ca !=null)
            {
                ca.CategoryName=c.CategoryName;

                ca = repo.UpdateCategory(ca);
            }
            return Mapper.Map(ca);

        }
    }
}
