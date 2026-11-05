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
            return ManageCategory(category, DbCommands.Add);
        }

        public int ManageCategory(Category category, DbCommands dbCommands)
        {
            if (category == null)
            {
                return 0;
            }

            if (dbCommands == DbCommands.Add)
            {
                return _categoryRepository.AddCategory(category);
            }
            else if (dbCommands == DbCommands.Update)
            {
                return _categoryRepository.UpdateCategory(category);
            }
            else if (dbCommands == DbCommands.Delete)
            {
                return _categoryRepository.DeleteCategory(category.Id);
            }
            else
            {
                return 0;
            }
        }

        public Category? GetCategoryById(int categoryId)
        {
            return _categoryRepository.GetCategoryById(categoryId);
        }

        public List<Category> GetAllCategories()
        {
            return _categoryRepository.GetAllCategories();
        }
    }
}
