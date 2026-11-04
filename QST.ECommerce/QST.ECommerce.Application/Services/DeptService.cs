using QST.ECommerce.Application.Interfaces;
using QST.ECommerce.Domain.Catalogue;


namespace QST.ECommerce.Application.Services
{
    public class DeptService : IDeptService
    {
        private readonly IDeptRepository _deptRepository;

       //Construction Injection of the Class IDeptRepository to access the database
        public DeptService(IDeptRepository deptRepository)
        {
            _deptRepository = deptRepository;
        }
       

        public int SaveDepartment(Department dept)
        {


            //Need to apply business rules - Use Case Relevant
            //Business Rules



            //write code to pass this data to Infrastructure layer
            int result = _deptRepository.AddDepartment(dept);  //to add department into Context Class
            return result;

            //throw new NotImplementedException();
        }

        public List<Department> GetAllDepartments()
        {
            return _deptRepository.GetAllDepartments();
        }

       
    }
}
