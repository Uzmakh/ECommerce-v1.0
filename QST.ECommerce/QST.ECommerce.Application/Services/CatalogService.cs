using QST.ECommerce.Application.Interfaces;
using QST.ECommerce.Domain.Catalogue;
using QST.ECommerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QST.ECommerce.Application.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly ICatalogRepository _catRepo;

        public CatalogService(ICatalogRepository catRepo)
        {
            _catRepo = catRepo;
        }

        #region Department
        public int ManageDepartment(Department dept, DbCommands dbCommand) //insert, update, delete
        {
            int result = 0;
            if (dept == null)
            {
                return 0;
            }

            if (dbCommand == DbCommands.Insert || dbCommand == DbCommands.Add)
            {
                result = _catRepo.AddDepartment(dept);
            }
            else if (dbCommand == DbCommands.Update || dbCommand == DbCommands.Delete)
            {
                result = UpdateDepartment(dept, dbCommand);
            }
            return result;
        }

        public int UpdateDepartment(Department dept, DbCommands dbCommand = DbCommands.Update)
        {
            // NOTE: Business validation - name is required for updates.
            if (dept == null)
            {
                return -1;
            }

            if (dbCommand == DbCommands.Update)
            {
                if (string.IsNullOrWhiteSpace(dept.Name))
                {
                    return -1;
                }
                dept.IsActive = true;
            }
            else if (dbCommand == DbCommands.Delete)
            {
                dept.IsActive = false;
            }

            // NOTE: Automatically stamp UpdatedAt with current UTC time during updates.
            dept.UpdatedAt = DateTime.UtcNow;
            return _catRepo.UpdateDepartment(dept);
        }

        public Department? GetDepartmentById(int deptId)
        {
            return _catRepo.GetDepartmentById(deptId);
        }

        public List<Department> GetAllDepartments()
        {
            return _catRepo.GetAllDepartments();
        }
        #endregion

        #region Category
        public int SaveCategory(Category category)
        {
            return ManageCategory(category, DbCommands.Add);
        }

        public int ManageCategory(Category category, DbCommands dbCommand)
        {
            int result = 0;
            if (category == null)
            {
                return 0;
            }

            if (dbCommand == DbCommands.Insert || dbCommand == DbCommands.Add)
            {
                result = _catRepo.AddCategory(category);
            }
            else if (dbCommand == DbCommands.Update || dbCommand == DbCommands.Delete)
            {
                result = UpdateCategory(category, dbCommand);
            }
            return result;
        }

        public int UpdateCategory(Category category, DbCommands dbCommand = DbCommands.Update)
        {
            if (category == null)
            {
                return -1;
            }

            if (dbCommand == DbCommands.Update)
            {
                if (string.IsNullOrWhiteSpace(category.Name))
                {
                    return -1;
                }
                category.IsActive = true;
            }
            else if (dbCommand == DbCommands.Delete)
            {
                category.IsActive = false;
            }

            return _catRepo.UpdateCategory(category);
        }

        public Category? GetCategoryById(int categoryId)
        {
            return _catRepo.GetCategoryById(categoryId);
        }

        public List<Category> GetAllCategories()
        {
            return _catRepo.GetAllCategories();
        }
        #endregion

        #region Brand
        public int ManageBrand(Brand brand, DbCommands dbCommand)
        {
            int result = 0;
            if (brand == null)
            {
                return 0;
            }

            if (dbCommand == DbCommands.Insert || dbCommand == DbCommands.Add)
            {
                result = _catRepo.AddBrand(brand);
            }
            else if (dbCommand == DbCommands.Update || dbCommand == DbCommands.Delete)
            {
                result = UpdateBrand(brand, dbCommand);
            }
            return result;
        }

        public int UpdateBrand(Brand brand, DbCommands dbCommand = DbCommands.Update)
        {
            if (brand == null)
            {
                return -1;
            }

            if (dbCommand == DbCommands.Update)
            {
                if (string.IsNullOrWhiteSpace(brand.BrandName))
                {
                    return -1;
                }
            }

            return _catRepo.UpdateBrand(brand);
        }

        public Brand? GetBrandById(int brandId)
        {
            return _catRepo.GetBrandById(brandId);
        }

        public List<Brand> GetAllBrands()
        {
            return _catRepo.GetAllBrands();
        }
        #endregion

        #region Product
        public int ManageProduct(Product product, DbCommands dbCommand)
        {
            int result = 0;
            if (product == null)
            {
                return 0;
            }

            if (dbCommand == DbCommands.Insert || dbCommand == DbCommands.Add)
            {
                result = _catRepo.AddProduct(product);
            }
            else if (dbCommand == DbCommands.Update || dbCommand == DbCommands.Delete)
            {
                result = UpdateProduct(product, dbCommand);
            }
            return result;
        }

        public int UpdateProduct(Product product, DbCommands dbCommand = DbCommands.Update)
        {
            if (product == null)
            {
                return -1;
            }

            if (dbCommand == DbCommands.Update)
            {
                if (string.IsNullOrWhiteSpace(product.Name))
                {
                    return -1;
                }
            }

            product.UpdatedAt = DateTime.UtcNow;
            return _catRepo.UpdateProduct(product);
        }

        public Product? GetProductById(int productId)
        {
            return _catRepo.GetProductById(productId);
        }

        public List<Product> GetAllProducts()
        {
            return _catRepo.GetAllProducts();
        }
        #endregion
    }
}
