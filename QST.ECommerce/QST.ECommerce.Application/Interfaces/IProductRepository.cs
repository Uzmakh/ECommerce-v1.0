using QST.ECommerce.Domain.Catalogue;


namespace QST.ECommerce.Application.Interfaces
{
    public interface IProductRepository //Contract
    {
        // Contract Rules
        int AddProduct(Product product);
        //int UpdateProduct(Product product);
        //int DeleteProduct(int id);
        //Product GetProductById(int productId); 
        List<Product> GetAllProducts();

    }
}