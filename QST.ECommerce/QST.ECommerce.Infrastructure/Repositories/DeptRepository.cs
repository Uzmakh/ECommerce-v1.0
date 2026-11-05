using System;
using QST.ECommerce.Domain.Catalogue;
using QST.ECommerce.Infrastructure.DbContexts;
using QST.ECommerce.Application.Interfaces;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace QST.ECommerce.Infrastructure.Repositories
{
    public class DeptRepository : IDeptRepository
    {
        //Making Variable of the Class CatalogueDbContext to access the database
        private readonly CatalogDbContext _dbContext;

       //Constructor Injection of the Class CatalogueDbContext to access the database
       public DeptRepository(CatalogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //5 operations-DML Operations of CRUD (Create, Read, Update, Delete) for Product Repository
        //Add first method of AddProduct
        public int AddDepartment(Department dept)
        {
            _dbContext.Departments.Add(dept);  //to add department into Context Class
            int result = _dbContext.SaveChanges();  //to save department into database
            return result;
        }

        public int UpdateDepartment(Department dept)
        {
            _dbContext.Departments.Update(dept);  //to update department into Context Class
            int result = _dbContext.SaveChanges();  //to save department into database
            return result;
        }

        public List<Department> GetAllDepartments()
        {
            return _dbContext.Departments.ToList();  //to get all departments from database
        }

        public Department? GetDepartmentById(int deptId)
        {
            var dept = _dbContext.Departments.FirstOrDefault(d => d.Id == deptId);
            return dept;
        }
    }
}
