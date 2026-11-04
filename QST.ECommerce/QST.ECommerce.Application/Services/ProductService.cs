using QST.ECommerce.Application.Interfaces;
using QST.ECommerce.Domain.Catalogue;

namespace QST.ECommerce.Application.Services
{
    public class ProductService : IProductService
    {
        //define Class level Variables
        private readonly IProductRepository _productRepository;

        // Inject IProductRepository via constructor (DI container handles this automatically)
        //constructor initialized
        public ProductService(IProductRepository prodRepo)
        {
            _productRepository = prodRepo;
        }

        public int SaveProduct(Product product)
        {    //Need to apply business rules - Use Case Relevant
             //Business Rules
            if (string.IsNullOrWhiteSpace(product.Name))
            {
                return -1;  //can't save
            }
            if(product.Price<=0)
            {
                return -1;
            }

            //write code to pass this data to Infrastructure layer
            _productRepository.AddProduct(product);
            return product.Id;
            
        }
        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();

        }
    }
}
