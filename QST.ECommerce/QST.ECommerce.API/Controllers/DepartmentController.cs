using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using QST.ECommerce.Application.Interfaces;
using QST.ECommerce.Domain.Catalogue;

namespace QST.ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDeptService _deptService;

        public DepartmentController(IDeptService deptService)
        {
            _deptService = deptService;
        }

        [HttpGet("GetAllDepartments")]
        public ActionResult<IEnumerable<Department>> GetAllDepartments()
        {
            var departments = _deptService.GetAllDepartments();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public ActionResult<Department> GetDepartmentById(int id)
        {
            var dept = _deptService.GetDepartmentById(id);
            if (dept == null)
            {
                return NotFound($"Department with ID {id} not found.");
            }
            return Ok(dept);
        }

        [HttpPost]
        public ActionResult AddDepartment(Department dept)
        {
            int result = _deptService.SaveDepartment(dept);
            if (result <= 0)
            {
                return BadRequest("Failed to add department. Department name is required.");
            }
            return Ok("Department is successfully added!");
        }

        [HttpPut]
        public ActionResult UpdateDepartment(Department dept)
        {
            int result = _deptService.UpdateDepartment(dept);
            if (result <= 0)
            {
                return BadRequest("Failed to update department. Department not found or name is invalid.");
            }
            return Ok("Department is successfully updated!");
        }
    }
}
