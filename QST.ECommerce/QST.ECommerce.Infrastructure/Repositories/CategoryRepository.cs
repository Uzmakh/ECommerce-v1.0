using QST.ECommerce.Application.Interfaces;
using QST.ECommerce.Domain.Catalogue;
using QST.ECommerce.Infrastructure.DbContexts;
using System.Collections.Generic;
using System.Linq;

namespace QST.ECommerce.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CatalogDbContext _dbContext;

        public CategoryRepository(CatalogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int AddCategory(Category category)
        {
            _dbContext.Categories.Add(category);
            int result = _dbContext.SaveChanges();
            return result;
        }

        public int UpdateCategory(Category category)
        {
            if (category == null)
            {
                return 0;
            }

            var catFromDb = GetCategoryById(category.Id);  
            if (catFromDb == null)
            {
                return 0;
            }

            catFromDb.Name = category.Name;
            catFromDb.Description = category.Description;
            catFromDb.DepartmentId = category.DepartmentId;
            catFromDb.IsActive = category.IsActive;

            int result = _dbContext.SaveChanges();
            return result;
        }

        public int DeleteCategory(int categoryId)
        {
            var catFromDb = GetCategoryById(categoryId);
            if (catFromDb != null)
            {
                _dbContext.Categories.Remove(catFromDb);
                int result = _dbContext.SaveChanges();
                return result;
            }
            return 0;
        }

        public Category? GetCategoryById(int categoryId)
        {
            var category = _dbContext.Categories.FirstOrDefault(c => c.Id == categoryId);
            return category;
        }

        public List<Category> GetAllCategories()
        {
            return _dbContext.Categories.ToList();
        }
    }
}
