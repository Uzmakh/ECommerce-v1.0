using QST.ECommerce.Domain.Catalogue;
using System.Reflection.Metadata.Ecma335;

namespace QST.ECommerce.Application.Interfaces
{
    public interface IDeptService  //contract class for Department Service
    {
        //Rules of Contract
        //Save means 1-Add, 2-Update, 3-Delete
        int SaveDepartment(Department dept);

        List<Department> GetAllDepartments();
    }
}
