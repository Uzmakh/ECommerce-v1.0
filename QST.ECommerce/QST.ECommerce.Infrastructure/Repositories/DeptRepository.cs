using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QST.ECommerce.Application.Interfaces;
using QST.ECommerce.Domain.Catalogue;
using QST.ECommerce.Infrastructure.DbContexts;

namespace QST.ECommerce.Infrastructure.Repositories
{
    public class DeptRepository : IDeptRepository
    {
        private readonly CatalogDbContext _dbContext;

        public DeptRepository(CatalogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int AddDepartment(Department dept)
        {
            // NOTE: Auto-generate CreatedAt timestamp if not explicitly supplied.
            // UpdatedAt remains null until an update operation occurs.
            if (dept.CreatedAt == null || dept.CreatedAt == default)
            {
                dept.CreatedAt = DateTime.UtcNow;
            }

            _dbContext.Departments.Add(dept);
            int result = _dbContext.SaveChanges();
            return result;
        }

        public int UpdateDepartment(Department dept)
        {
            if (dept == null)
            {
                return 0;
            }

            // NOTE: Null-check on fetched entity prevents NullReferenceException.
            var deptFromDb = GetDepartmentById(dept.Id);
            if (deptFromDb == null)
            {
                return 0;
            }

            deptFromDb.Name = dept.Name;
            deptFromDb.Description = dept.Description;
            // NOTE: Updates the timestamp automatically to UTC now if not already set.
            deptFromDb.UpdatedAt = dept.UpdatedAt ?? DateTime.UtcNow;
            deptFromDb.UpdatedBy = dept.UpdatedBy;
            deptFromDb.IsActive = dept.IsActive;

            int result = _dbContext.SaveChanges();
            return result;
        }

        public List<Department> GetAllDepartments()
        {
            return _dbContext.Departments.ToList();
        }

        public Department? GetDepartmentById(int deptId)
        {
            // NOTE: Returns null if no match found (nullable return type prevents CS8603 warning).
            var dept = _dbContext.Departments.FirstOrDefault(d => d.Id == deptId);
            return dept;
        }
    }
}
