using Microsoft.EntityFrameworkCore;
using QST.ECommerce.Domain.Catalogue;
using QST.ECommerce.Infrastructure.DbContexts;
using QST.ECommerce.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QST.ECommerce.Infrastructure.Repositories
{
    public class CatalogRepository : ICatalogRepository
    {
        private CatalogDbContext _dbContext;

        public CatalogRepository(CatalogDbContext dbContext)  //Constructor Injection to initialize the DbContext in the Repository class
        {
            _dbContext = dbContext;
        }

        //5 operations-DML Operations of CRUD (Create, Read, Update, Delete) for each Repository

        #region Department
        public int AddDepartment(Department dept)
        {
            // NOTE: Auto-generate CreatedAt timestamp if not explicitly supplied.
            // UpdatedAt remains null until an update operation occurs.
            if (dept.CreatedAt == null || dept.CreatedAt == default)
            {
                dept.CreatedAt = DateTime.UtcNow;
            }

            _dbContext.Departments.Add(dept);
            int result = _dbContext.SaveChanges();
            return result;
        }
        public int UpdateDepartment(Department dept)
        {
            if (dept == null)
            {
                return 0;
            }
            // NOTE: Null-check on fetched entity prevents NullReferenceException.
            var deptFromDb = GetDepartmentById(dept.Id);
            if (deptFromDb == null)
            {
                return 0;
            }
            deptFromDb.Name = dept.Name;
            deptFromDb.Description = dept.Description;
            // NOTE: Updates the timestamp automatically to UTC now if not already set.
            deptFromDb.UpdatedAt = dept.UpdatedAt ?? DateTime.UtcNow;
            deptFromDb.UpdatedBy = dept.UpdatedBy;
            deptFromDb.IsActive = dept.IsActive;
            int result = _dbContext.SaveChanges();
            return result;
        }

        public List<Department> GetAllDepartments()
        {
            return _dbContext.Departments.ToList();
        }

        public Department? GetDepartmentById(int id)
        {
            // NOTE: Returns null if no match found (nullable return type prevents CS8603 warning).
            var dept= _dbContext.Departments.FirstOrDefault(d => d.Id == id);
            return dept;
        }

        #endregion

        #region Brand
        // Implement Brand-related methods here

        public int AddBrand(Brand brand)
        {
            _dbContext.Brands.Add(brand);
            int result = _dbContext.SaveChanges();
            return result;
        }

        public int UpdateBrand(Brand brand)
        {
            _dbContext.Brands.Update(brand);
            int result = _dbContext.SaveChanges();
            return result;
        }

        public List<Brand> GetAllBrands()
        {
            var list = _dbContext.Brands.ToList();
            return list;
        }

        public Brand? GetBrandById(int brandId)
        {
            var brand = _dbContext.Brands.FirstOrDefault(b => b.Id == brandId);
            return brand;
        }

        #endregion

        #region Category
        // Implement Category-related methods here
        public int AddCategory(Category category)
        {
            _dbContext.Categories.Add(category);
            int result = _dbContext.SaveChanges();
            return result;
        }

        public int UpdateCategory(Category category)
        {
            if (category == null)
            {
                return 0;
            }

            var catFromDb = GetCategoryById(category.Id);
            if (catFromDb == null)
            {
                return 0;
            }

            catFromDb.Name = category.Name;
            catFromDb.Description = category.Description;
            catFromDb.DepartmentId = category.DepartmentId;
            catFromDb.IsActive = category.IsActive;

            int result = _dbContext.SaveChanges();
            return result;
        }

        public int DeleteCategory(int categoryId)
        {
            var catFromDb = GetCategoryById(categoryId);
            if (catFromDb != null)
            {
                _dbContext.Categories.Remove(catFromDb);
                int result = _dbContext.SaveChanges();
                return result;
            }
            return 0;
        }

        public Category? GetCategoryById(int categoryId)
        {
            var category = _dbContext.Categories.FirstOrDefault(c => c.Id == categoryId);
            return category;
        }

        public List<Category> GetAllCategories()
        {
            return _dbContext.Categories.ToList();
        }

        #endregion

        #region Product
        // Implement Product-related methods here
       
        
        public int AddProduct(Product product)
        {
            _dbContext.Products.Add(product);  //to add product into Context Class
            int result = _dbContext.SaveChanges();  //to save product into database
            return result;
        }

        public int UpdateProduct(Product product)
        {
            _dbContext.Products.Update(product);  //to update product into Context Class
            int result = _dbContext.SaveChanges();  //to save product into database
            return result;
        }

        public List<Product> GetAllProducts()
        {
            return _dbContext.Products.ToList();  //to get all products from database
        }

        public Product? GetProductById(int productId)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == productId);
            return product;
        }
        #endregion



    }
}
