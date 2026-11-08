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

        // NOTE: Retrieves all departments including their audit (CreatedAt, CreatedBy, UpdatedAt, UpdatedBy) and active status.
        [HttpGet("GetAllDepartments")]
        public ActionResult<IEnumerable<Department>> GetAllDepartments()
        {
            var departments = _deptService.GetAllDepartments();
            return Ok(departments);
        }

        // NOTE: Retrieves a single department by its primary key ID; returns 404 if not found.
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

        // NOTE: Creates a new department and validates that business rules pass (returns 400 on failure).
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

        // NOTE: Updates an existing department with audit timestamping (returns 400 on failure or if not found).
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
