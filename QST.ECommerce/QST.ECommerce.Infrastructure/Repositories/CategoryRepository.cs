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

        public List<Category> GetAllCategories()
        {
            return _dbContext.Categories.ToList();
        }
    }
}
