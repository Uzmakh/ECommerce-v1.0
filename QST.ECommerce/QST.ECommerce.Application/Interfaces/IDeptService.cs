using System.Collections.Generic;
using QST.ECommerce.Domain.Catalogue;

namespace QST.ECommerce.Application.Interfaces
{
    public interface IDeptService
    {
        // Rules of Contract
        int SaveDepartment(Department dept);

        int UpdateDepartment(Department dept);

        List<Department> GetAllDepartments();

        Department? GetDepartmentById(int deptId);
    }
}
