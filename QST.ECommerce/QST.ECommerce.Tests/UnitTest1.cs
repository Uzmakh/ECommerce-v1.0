using System;
using System.Collections.Generic;
using System.Linq;
using QST.ECommerce.Application.Interfaces;
using QST.ECommerce.Application.Services;
using QST.ECommerce.Domain.Catalogue;

namespace QST.ECommerce.Tests
{
    public class FakeProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new();
        private int _nextId = 1;

        public int AddProduct(Product product)
        {
            product.Id = _nextId++;
            _products.Add(product);
            return 1;
        }

        public int UpdateProduct(Product product)
        {
            var existing = _products.FirstOrDefault(p => p.Id == product.Id);
            if (existing != null)
            {
                existing.Name = product.Name;
                existing.Price = product.Price;
                existing.StockQuantity = product.StockQuantity;
                return 1;
            }
            return 0;
        }

        public List<Product> GetAllProducts()
        {
            return _products;
        }

        public Product? GetProductById(int productId)
        {
            return _products.FirstOrDefault(p => p.Id == productId);
        }
    }

    public class FakeCategoryRepository : ICategoryRepository
    {
        private readonly List<Category> _categories = new();
        private int _nextId = 1;

        public int AddCategory(Category category)
        {
            category.Id = _nextId++;
            _categories.Add(category);
            return 1;
        }

        public int UpdateCategory(Category category)
        {
            var existing = _categories.FirstOrDefault(c => c.Id == category.Id);
            if (existing != null)
            {
                existing.Name = category.Name;
                existing.Description = category.Description;
                existing.DepartmentId = category.DepartmentId;
                existing.IsActive = category.IsActive;
                return 1;
            }
            return 0;
        }

        public int DeleteCategory(int categoryId)
        {
            var existing = _categories.FirstOrDefault(c => c.Id == categoryId);
            if (existing != null)
            {
                _categories.Remove(existing);
                return 1;
            }
            return 0;
        }

        public List<Category> GetAllCategories()
        {
            return _categories;
        }

        public Category? GetCategoryById(int categoryId)
        {
            return _categories.FirstOrDefault(c => c.Id == categoryId);
        }
    }

    public class FakeDeptRepository : IDeptRepository
    {
        private readonly List<Department> _departments = new();
        private int _nextId = 1;

        public int AddDepartment(Department dept)
        {
            dept.Id = _nextId++;
            _departments.Add(dept);
            return 1;
        }

        public int UpdateDepartment(Department dept)
        {
            var existing = _departments.FirstOrDefault(d => d.Id == dept.Id);
            if (existing != null)
            {
                existing.Name = dept.Name;
                existing.Description = dept.Description;
                existing.UpdatedAt = dept.UpdatedAt;
                existing.UpdatedBy = dept.UpdatedBy;
                existing.IsActive = dept.IsActive;
                return 1;
            }
            return 0;
        }

        public List<Department> GetAllDepartments()
        {
            return _departments;
        }

        public Department? GetDepartmentById(int deptId)
        {
            return _departments.FirstOrDefault(d => d.Id == deptId);
        }
    }

    public class UnitTest1
    {
        [Fact]
        public void Test_Department()
        {
            List<Department> departments = new List<Department>
            {
                new Department { Id = 1, Name = "Electronics", Description = "All kinds of electronic items" },
                new Department { Id = 2, Name = "Clothing", Description = "All kinds of clothing items" },
                new Department { Id = 3, Name = "Home Appliances", Description = "All kinds of home appliances" },
                new Department { Id = 4, Name = "Books", Description = "All kinds of books" }
            };

            Assert.Equal(4, departments.Count);
        }

        [Fact]
        public void Test_Department_NewFields_Defaults()
        {
            var dept = new Department
            {
                Name = "Sports",
                Description = "Sports equipment"
            };

            Assert.True(dept.IsActive);
            Assert.Equal(string.Empty, dept.CreatedBy);
            Assert.Equal(string.Empty, dept.UpdatedBy);
            Assert.Equal(default(DateTime), dept.CreatedAt);
            Assert.Equal(default(DateTime), dept.UpdatedAt);
        }

        [Fact]
        public void Test_DeptService_SaveDepartment_SetsTimestamps()
        {
            var repo = new FakeDeptRepository();
            var service = new DeptService(repo);

            var dept = new Department
            {
                Name = "Footwear",
                Description = "Shoes and socks",
                CreatedBy = "Admin"
            };

            int result = service.SaveDepartment(dept);

            Assert.Equal(1, result);
            Assert.NotEqual(default(DateTime), dept.CreatedAt);
            Assert.NotEqual(default(DateTime), dept.UpdatedAt);
            Assert.Equal("Admin", dept.CreatedBy);
            Assert.True(dept.IsActive);
        }

        [Fact]
        public void Test_DeptService_UpdateDepartment_UpdatesTimestamp()
        {
            var repo = new FakeDeptRepository();
            var service = new DeptService(repo);

            var dept = new Department
            {
                Name = "Footwear",
                Description = "Shoes and socks",
                CreatedBy = "Admin"
            };
            service.SaveDepartment(dept);

            dept.Name = "Luxury Footwear";
            dept.UpdatedBy = "Editor";
            int updateResult = service.UpdateDepartment(dept);

            Assert.Equal(1, updateResult);
            var updated = service.GetDepartmentById(dept.Id);
            Assert.NotNull(updated);
            Assert.Equal("Luxury Footwear", updated.Name);
            Assert.Equal("Editor", updated.UpdatedBy);
        }

        [Fact]
        public void Test_Category()
        {
            List<Category> categories = new List<Category>
            {
                new Category { DepartmentId = 1, Id = 1, Name = "Smartphones", Description = "Mobile phones and tablets" },
                new Category { DepartmentId = 2, Id = 2, Name = "Men's Clothing", Description = "Casual and formal wear for men" },
                new Category { DepartmentId = 3, Id = 3, Name = "Kitchen Gadgets", Description = "Tools for cooking and baking" }
            };

            Assert.Equal(3, categories.Count);
        }

        [Fact]
        public void Test_Brand()
        {
            List<Brand> brands = new List<Brand>
            {
                new Brand { DepartmentId = 1, CategoryId = 1, Id = 1, BrandName = "Samsung", BrandDescription = "Electronics and mobile devices" },
                new Brand { DepartmentId = 2, CategoryId = 2, Id = 2, BrandName = "Nike", BrandDescription = "Sportswear and footwear" },
                new Brand { DepartmentId = 1, CategoryId = 1, Id = 3, BrandName = "Sony", BrandDescription = "Entertainment and electronics" }
            };

            Assert.Equal(3, brands.Count);
        }

        [Fact]
        public void Test_Product()
        {
            List<Product> products = new List<Product>
            {
                new Product { DepartmentId = 1, CategoryId = 1, BrandId = 1, Name = "Galaxy S24", Description = "Latest flagship smartphone", Price = 999.99m },
                new Product { DepartmentId = 2, CategoryId = 2, BrandId = 2, Name = "Running Shoes", Description = "Lightweight comfortable shoes", Price = 89.99m },
                new Product { DepartmentId = 3, CategoryId = 3, BrandId = 3, Name = "Blender", Description = "High-speed kitchen blender", Price = 49.99m }
            };

            Assert.Equal(3, products.Count);
        }

        [Fact]
        public void Test_SaveProduct_ValidProduct_ReturnsId()
        {
            var repo = new FakeProductRepository();
            var service = new ProductService(repo);
            var product = new Product
            {
                Name = "Laptop",
                Price = 1200.00m,
                StockQuantity = 10
            };

            int result = service.SaveProduct(product);

            Assert.True(result > 0);
            Assert.Single(service.GetAllProducts());
        }

        [Fact]
        public void Test_SaveProduct_EmptyName_ReturnsNegativeOne()
        {
            var repo = new FakeProductRepository();
            var service = new ProductService(repo);
            var product = new Product
            {
                Name = "",
                Price = 100.00m
            };

            int result = service.SaveProduct(product);

            Assert.Equal(-1, result);
            Assert.Empty(service.GetAllProducts());
        }

        [Fact]
        public void Test_SaveProduct_InvalidPrice_ReturnsNegativeOne()
        {
            var repo = new FakeProductRepository();
            var service = new ProductService(repo);
            var product = new Product
            {
                Name = "Mouse",
                Price = 0m
            };

            int result = service.SaveProduct(product);

            Assert.Equal(-1, result);
            Assert.Empty(service.GetAllProducts());
        }

        [Fact]
        public void Test_ManageCategory_Add_Update_Delete()
        {
            var repo = new FakeCategoryRepository();
            var service = new CategoryService(repo);

            // Add
            var category = new Category { Name = "Gaming", Description = "Consoles and games", DepartmentId = 1 };
            int addResult = service.ManageCategory(category, DbCommands.Add);
            Assert.Equal(1, addResult);
            Assert.Equal(1, category.Id);

            // GetById
            var fetched = service.GetCategoryById(1);
            Assert.NotNull(fetched);
            Assert.Equal("Gaming", fetched.Name);

            // Update
            fetched.Description = "Updated gaming description";
            int updateResult = service.ManageCategory(fetched, DbCommands.Update);
            Assert.Equal(1, updateResult);
            Assert.Equal("Updated gaming description", service.GetCategoryById(1)?.Description);

            // Delete
            int deleteResult = service.ManageCategory(fetched, DbCommands.Delete);
            Assert.Equal(1, deleteResult);
            Assert.Null(service.GetCategoryById(1));
        }
    }
}
