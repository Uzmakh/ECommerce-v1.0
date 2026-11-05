using System;
using QST.ECommerce.Application.Interfaces;
using QST.ECommerce.Domain.Catalogue;
using QST.ECommerce.Infrastructure.DbContexts;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Linq;

namespace QST.ECommerce.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        //Making Variable of the Class CatalogueDbContext to access the database
        private readonly CatalogDbContext _catalogDbContext;

        //Constructor Injection of the Class CatalogueDbContext to access the database
        public ProductRepository(CatalogDbContext catalogDbContext)
        {
            _catalogDbContext = catalogDbContext;
        }

        //5 operations-DML Operations of CRUD (Create, Read, Update, Delete) for Product Repository
        //Add first method of AddProduct
        public int AddProduct(Product product)
        {
            _catalogDbContext.Products.Add(product);  //to add product into Context Class
            int result = _catalogDbContext.SaveChanges();  //to save product into database
            return result;
        }

        public int UpdateProduct(Product product)
        {
            _catalogDbContext.Products.Update(product);  //to update product into Context Class
            int result = _catalogDbContext.SaveChanges();  //to save product into database
            return result;
        }

        public List<Product> GetAllProducts()
        {
            return _catalogDbContext.Products.ToList();  //to get all products from database
        }

        public Product? GetProductById(int productId)
        {
            var product = _catalogDbContext.Products.FirstOrDefault(p => p.Id == productId);
            return product;
        }
    }
}
