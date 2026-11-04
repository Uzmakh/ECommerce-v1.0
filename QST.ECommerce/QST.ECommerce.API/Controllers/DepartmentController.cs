using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QST.ECommerce.Application.Interfaces;
using QST.ECommerce.Domain.Catalogue;
using System.Collections.Generic;

namespace QST.ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        //Variable of the Class IDeptService to access the database
        private readonly IDeptService _deptService;

        //Constructor Injection - of the Class IDeptService to access the database
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

        [HttpPost]
        public ActionResult AddDepartment(Department dept)
        {
            _deptService.SaveDepartment(dept);
            return Ok("Department is successfully added!");
        }

    }
}
