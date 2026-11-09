using QST.ECommerce.Domain.Catalogue;
using QST.ECommerce.Domain.Enums;
using System.Collections.Generic;

namespace QST.ECommerce.Application.Interfaces
{
    public interface ICategoryService
    {
        // Rules of Contract
        // Manage Category handles CRUD operations based on DbCommands (Add, Update, Delete)
        int ManageCategory(Category category, DbCommands dbCommands);

        Category? GetCategoryById(int categoryId);

        List<Category> GetAllCategories();

        int SaveCategory(Category category);
    }
}
