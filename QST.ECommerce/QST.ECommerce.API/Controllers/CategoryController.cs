using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QST.ECommerce.Application.Interfaces;
using QST.ECommerce.Domain.Catalogue;
using System.Collections.Generic;

namespace QST.ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _catSvc;

        public CategoryController(ICategoryService catSvc)
        {
            _catSvc = catSvc;
        }

        [HttpGet("GetAllCategories")]
        public ActionResult<IEnumerable<Category>> GetAllCategories()
        {
            var categories = _catSvc.GetAllCategories();
            return Ok(categories);
        }

        [HttpPost]
        public ActionResult AddCategory(Category request)
        {
            _catSvc.SaveCategory(request);
            return Ok("Category is successfully added!");
        }
    }
}
