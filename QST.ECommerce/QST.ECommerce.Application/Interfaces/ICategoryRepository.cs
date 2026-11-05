using QST.ECommerce.Domain.Catalogue;
using System.Collections.Generic;

namespace QST.ECommerce.Application.Interfaces
{
    public interface ICategoryRepository
    {
        int AddCategory(Category category);

        int UpdateCategory(Category category);

        int DeleteCategory(int categoryId);

        List<Category> GetAllCategories();

        Category? GetCategoryById(int categoryId);
    }
}
