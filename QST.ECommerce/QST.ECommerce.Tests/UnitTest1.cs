using System.Collections.Generic;
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

        public List<Product> GetAllProducts()
        {
            return _products;
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
    }
}
