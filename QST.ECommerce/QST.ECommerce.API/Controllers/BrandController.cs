using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QST.ECommerce.Application.Interfaces;
using QST.ECommerce.Domain.Catalogue;
using System.Collections.Generic;

namespace QST.ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
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
            _brandService.SaveBrand(request);
            return Ok("Brand is successfully added");
        }
    }
}
