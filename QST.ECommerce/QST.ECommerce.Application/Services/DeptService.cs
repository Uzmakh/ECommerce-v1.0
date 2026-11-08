using System;
using System.Collections.Generic;
using QST.ECommerce.Application.Interfaces;
using QST.ECommerce.Domain.Catalogue;

namespace QST.ECommerce.Application.Services
{
    public class DeptService : IDeptService
    {
        private readonly IDeptRepository _deptRepository;

        public DeptService(IDeptRepository deptRepository)
        {
            _deptRepository = deptRepository;
        }

        public int SaveDepartment(Department dept)
        {
            // NOTE: Business validation - name is required.
            if (dept == null || string.IsNullOrWhiteSpace(dept.Name))
            {
                return -1;
            }

            // NOTE: Ensure CreatedAt is populated before saving to persistence layer.
            if (dept.CreatedAt == null || dept.CreatedAt == default)
            {
                dept.CreatedAt = DateTime.UtcNow;
            }

            int result = _deptRepository.AddDepartment(dept);
            return result;
        }

        public int UpdateDepartment(Department dept)
        {
            // NOTE: Business validation - name is required for updates.
            if (dept == null || string.IsNullOrWhiteSpace(dept.Name))
            {
                return -1;
            }

            // NOTE: Automatically stamp UpdatedAt with current UTC time during updates.
            dept.UpdatedAt = DateTime.UtcNow;
            return _deptRepository.UpdateDepartment(dept);
        }

        public Department? GetDepartmentById(int deptId)
        {
            return _deptRepository.GetDepartmentById(deptId);
        }

        public List<Department> GetAllDepartments()
        {
            return _deptRepository.GetAllDepartments();
        }
    }
}
