using QST.ECommerce.Domain.Catalogue;


namespace QST.ECommerce.Application.Interfaces
{
    public interface ICategoryRepository   //contract to implement
    {
        //contract rules
        int AddCategory(Category category);

        //int UpdateCategory(Category category);
        //int DeleteCategory(int categoryId);
        //Category GetCategoryById(int categoryId);
        List<Category> GetAllCategories();
    }
}
