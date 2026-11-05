using QST.ECommerce.Domain.Catalogue;
using System.Collections.Generic;

namespace QST.ECommerce.Application.Interfaces
{
    public interface IDeptRepository
    {
        int AddDepartment(Department dept);

        int UpdateDepartment(Department dept);

        List<Department> GetAllDepartments();

        Department? GetDepartmentById(int deptId);
    }
}
