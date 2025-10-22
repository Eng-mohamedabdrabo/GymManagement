using GymManagementDAL.Data.Contexts;
using GymManagementDAL.Entities;
using GymManagementDAL.Reposetories.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Reposetories.implementation
{
    internal class CategoryRepository : ICategoryInterface
    {
        private readonly GymDbContexts _dbContext;

        public int AddCategory(Categories Category)
        {
            _dbContext.Categories.Add(Category);
            return _dbContext.SaveChanges();
        }

        public int DeleteCategory(int id)
        {
            var category = _dbContext.Categories.Find(id);

            if (category is null)
                return 0;

            _dbContext.Categories.Remove(category);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<Categories> GetAllCategories() => _dbContext.Categories.ToList();

        public Categories GetCategory(int id) => _dbContext.Categories.Find(id);
       
     
        public int UpdateCategory(Categories Category)
        {
            _dbContext.Categories.Update(Category);
            return _dbContext.SaveChanges();
        }
    }
}
