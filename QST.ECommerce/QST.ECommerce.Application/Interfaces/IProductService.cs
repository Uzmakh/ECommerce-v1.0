using QST.ECommerce.Domain.Catalogue;

namespace QST.ECommerce.Application.Interfaces
{
    public interface IProductService //Contract (What to do ?)
    {
        //Rules of Contract

        // Contract Rule 1
        //Save means 1-Add, 2-Update, 3-Delete
        int SaveProduct(Product product);

        // Contract Rule 2
        List<Product> GetAllProducts();

        // What to do ?  Very very very much important - Interface defines what to do 
        // How to Do ? Class which implements that interface 
    }
}