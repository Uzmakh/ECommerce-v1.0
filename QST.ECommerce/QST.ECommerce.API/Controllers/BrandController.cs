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
    public class BrandController : ControllerBase
    {
        private readonly ICatalogService _brandService;

        public BrandController(ICatalogService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Brand>> GetAllBrands()
        {
            var brands = _brandService.GetAllBrands();
            return Ok(brands);
        }

        [HttpPost]
        public ActionResult AddBrand(Brand request)
        {
            _brandService.ManageBrand(request, DbCommands.Add);
            return Ok("Brand is successfully added");
        }
    }
}
