using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QST.ECommerce.Application.Interfaces;
using QST.ECommerce.Domain.Catalogue;
using QST.ECommerce.Domain.Enums;
using System.Collections.Generic;

namespace QST.ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ICatalogService _prodSvc;

        public ProductController(ICatalogService prodSvc)
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
            int result = _prodSvc.ManageProduct(request, DbCommands.Add);
            if (result == -1)
            {
                return BadRequest("Invalid product data. Product name is required and price must be greater than zero.");
            }
            return Ok("Product is successfully added!");
        }
       
    }
}
