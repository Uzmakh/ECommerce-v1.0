using QST.ECommerce.Domain.Catalogue;


namespace QST.ECommerce.Application.Interfaces
{
    public interface ICategoryService
    {
        //Rules of Contract
        //Save means 1-Add, 2-Update, 3-Delete
        int SaveCategory(Category category);
        List<Category> GetAllCategories();
    }
}
