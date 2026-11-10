using QST.ECommerce.Domain.Catalogue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QST.ECommerce.Application.Interfaces
{
    public interface ICatalogRepository
    {
        #region Department
        int AddDepartment(Department dept);
        int UpdateDepartment(Department dept);

        //int DeleteDepartment(int departmentId);

        Department? GetDepartmentById(int deptId);
        List<Department> GetAllDepartments();

        #endregion

        #region Category
        int AddCategory(Category category);
        int UpdateCategory(Category category);
        Category? GetCategoryById(int categoryId);
        List<Category> GetAllCategories();

        #endregion

        #region Brand
        int AddBrand(Brand brand);
        int UpdateBrand(Brand brand);
        Brand? GetBrandById(int brandId);
        List<Brand> GetAllBrands();
        #endregion

        #region Product
        int AddProduct(Product product);
        int UpdateProduct(Product product);
        Product? GetProductById(int productId);
        List<Product> GetAllProducts();
        #endregion


    }
}
