using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QST.ECommerce.Application.Interfaces;
using QST.ECommerce.Domain.Catalogue;
using System.Collections.Generic;

namespace QST.ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _prodSvc;

        public ProductController(IProductService prodSvc)
        {
            _prodSvc = prodSvc;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            var products = _prodSvc.GetAllProducts();
            return Ok(products);
        }

        [HttpPost]
        public ActionResult AddProduct(Product request)
        {
            _prodSvc.SaveProduct(request);
            return Ok("Product is successfully added!");
        }
       
    }
}
