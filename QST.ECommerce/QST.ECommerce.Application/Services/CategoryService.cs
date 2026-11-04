using QST.ECommerce.Application.Interfaces;
using QST.ECommerce.Domain.Catalogue;
using System.Collections.Generic;

namespace QST.ECommerce.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public int SaveCategory(Category category)
        {
            int result = _categoryRepository.AddCategory(category);
            return result;
        }

        public List<Category> GetAllCategories()
        {
            return _categoryRepository.GetAllCategories();
        }
    }
}
