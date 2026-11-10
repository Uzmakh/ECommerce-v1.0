using Microsoft.AspNetCore.Mvc;
using QST.ECommerce.Application.Interfaces;
using QST.ECommerce.Domain.Catalogue;
using QST.ECommerce.Domain.Enums;
using System.Collections.Generic;

namespace QST.ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICatalogService _catSvc;

        public CategoryController(ICatalogService catSvc)
        {
            _catSvc = catSvc;
        }

        [HttpPost("AddCategory")]
        public ActionResult AddCategory(Category request)
        {
            int result = _catSvc.ManageCategory(request, DbCommands.Add);
            if (result <= 0)
            {
                return BadRequest("Failed to add category.");
            }
            return Ok("Category is successfully added!");
        }

        [HttpPut("ModifyCategory")]
        public ActionResult UpdateCategory(Category request)
        {
            int result = _catSvc.ManageCategory(request, DbCommands.Update);
            if (result <= 0)
            {
                return BadRequest("Failed to update category. Category not found or data is invalid.");
            }
            return Ok("Category is successfully updated!!");
        }

        [HttpDelete("DeleteCategory/{id}")]
        public ActionResult DeleteCategory(int id)
        {
            var category = new Category { Id = id };
            int result = _catSvc.ManageCategory(category, DbCommands.Delete);
            if (result <= 0)
            {
                return NotFound($"Category with ID {id} not found.");
            }
            return Ok("Category is successfully deleted!");
        }

        [HttpGet("GetCategoryById/{id}")]
        public ActionResult<Category> GetCategoryById(int id)
        {
            var category = _catSvc.GetCategoryById(id);
            if (category == null)
            {
                return NotFound($"Category with ID {id} not found.");
            }
            return Ok(category);
        }

        [HttpGet("GetAllCategories")]
        public ActionResult<IEnumerable<Category>> GetAllCategories()
        {
            var categories = _catSvc.GetAllCategories();
            return Ok(categories);
        }
    }
}
