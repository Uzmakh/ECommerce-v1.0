using QST.ECommerce.Domain.Catalogue;


namespace QST.ECommerce.Application.Interfaces
{
    //what to do
    public interface IDeptRepository  //contract to implement
    {
        //contract rules
        int AddDepartment(Department dept);
       
        //int UpdateDepartment(Department dept);
        //int DeleteDepartment(int deptId);
        //Department GetDepartmentById(int deptId);
        List<Department> GetAllDepartments();
    }
}
