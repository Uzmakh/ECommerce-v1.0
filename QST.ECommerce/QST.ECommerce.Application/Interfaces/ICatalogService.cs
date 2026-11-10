using QST.ECommerce.Domain.Catalogue;
using QST.ECommerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QST.ECommerce.Application.Interfaces
{
    public interface ICatalogService
    {
        #region Department
        int ManageDepartment(Department dept,DbCommands dbCommand);  //insert,update and delete commands
        Department? GetDepartmentById(int deptId);
        List<Department> GetAllDepartments();
        #endregion

        #region Category
        int ManageCategory(Category category,DbCommands dbCommand);
        Category? GetCategoryById(int categoryId);
        List<Category> GetAllCategories();
        #endregion

        #region Brand
        int ManageBrand(Brand brand,DbCommands dbCommand);
        Brand? GetBrandById(int brandId);
        List<Brand> GetAllBrands();
        #endregion

        #region Product
        int ManageProduct(Product product,DbCommands dbCommand);
        Product? GetProductById(int productId);
        List<Product> GetAllProducts();
        #endregion

    }
}
