using QST.ECommerce.Domain.Catalogue;
using System.Collections.Generic;

namespace QST.ECommerce.Application.Interfaces
{
    public interface IProductRepository
    {
        int AddProduct(Product product);

        int UpdateProduct(Product product);

        List<Product> GetAllProducts();

        Product? GetProductById(int productId);
    }
}
