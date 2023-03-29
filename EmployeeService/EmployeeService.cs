using EmployeeDataAccess;

namespace EmployeeService

{
    public interface IEmployeeService
    {   
        void AddEmployee(EmployeeServiceInfo employeeServiceInfo);

        EmployeeServiceInfo UpdateEmployee(EmployeeServiceInfo employeeServiceInfo);

        EmployeeResponseServiceInfo GetEmployee(string Name);

        void DeleteEmployee(int id); 
    }
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeStore _employeeStore;


        public EmployeeService(IEmployeeStore employeeStore)
        {
            _employeeStore = employeeStore;
        }
                
        public void AddEmployee(EmployeeServiceInfo employeeServiceInfo)
        {
            var employeeStoreInfo = new EmployeeStoreInfo();
            employeeStoreInfo.Id = employeeServiceInfo.Id;
            employeeStoreInfo.Name = employeeServiceInfo.Name;
            employeeStoreInfo.Department = employeeServiceInfo.Department;
            employeeStoreInfo.Dob = employeeServiceInfo.Dob;
            employeeStoreInfo.Address1 = employeeServiceInfo.Address1;
            employeeStoreInfo.Address2 = employeeServiceInfo.Address2;
            employeeStoreInfo.Salary = employeeServiceInfo.Salary;

            _employeeStore.AddEmployee(employeeStoreInfo);

        }

        public EmployeeResponseServiceInfo GetEmployee(string Name)
        {
            var employeeStoreInfo = _employeeStore.GetEmployee(Name);
            if (employeeStoreInfo == null)
            {
                return null;
            }
            else
            {
                var age = DateTime.Now.Year - employeeStoreInfo.Dob.Year;
                return new EmployeeResponseServiceInfo
                {
                    id = employeeStoreInfo.Id,
                    Name = employeeStoreInfo.Name,
                    Age = age,
                    Address = employeeStoreInfo.Address1 + " " + employeeStoreInfo.Address2,
                };
            }
        }
        public EmployeeServiceInfo UpdateEmployee(EmployeeServiceInfo employeeServiceInfo)
        {
            var employeeStoreInfo = new EmployeeStoreInfo();
            employeeStoreInfo.Id = employeeServiceInfo.Id;
            employeeStoreInfo.Name = employeeServiceInfo.Name;
            employeeStoreInfo.Department = employeeServiceInfo.Department;
            employeeStoreInfo.Dob = employeeServiceInfo.Dob;
            employeeStoreInfo.Address1 = employeeServiceInfo.Address1;
            employeeStoreInfo.Address2 = employeeServiceInfo.Address2;
            employeeStoreInfo.Salary = employeeServiceInfo.Salary;
           
            _employeeStore.UpdateEmployee(employeeStoreInfo);

            if (employeeStoreInfo == null)
            {
                return null;
            }
            else
            {
                return new EmployeeServiceInfo
                {
                    Id = employeeStoreInfo.Id,
                    Name = employeeStoreInfo.Name,
                    Department = employeeStoreInfo.Department,
                    Dob = employeeStoreInfo.Dob,
                    Address1 = employeeStoreInfo.Address1,
                    Address2 = employeeStoreInfo.Address2,
                    Salary = employeeStoreInfo.Salary,
                };
            }
        }
        public  void  DeleteEmployee (int  id)
        {
            _employeeStore.DeleteEmployee(id);
        }
    }
}
