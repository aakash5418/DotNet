using System.Text.Json;

namespace EmployeeDataAccess
{
    public interface IEmployeeStore
    {
        EmployeeStoreInfo GetEmployee(string Name);
        void AddEmployee(EmployeeStoreInfo employeeStoreInfo);
        void DeleteEmployee(int id);
        void UpdateEmployee(EmployeeStoreInfo employeeStoreInfo);
    }
    public class EmployeeStore : IEmployeeStore
    {
        public void AddEmployee(EmployeeStoreInfo employeeStoreInfo)
        {
            string fileName = @"C:\Users\Admin\Desktop\Employees.json";
            string text = System.IO.File.ReadAllText(fileName);
            var employees = JsonSerializer.Deserialize<List<EmployeeStoreInfo>>(text);
            if (employees == null)
            {
                employees = new List<EmployeeStoreInfo>();
            }
            employees.Add(employeeStoreInfo);

            string json = System.Text.Json.JsonSerializer.Serialize(employees);
            System.IO.File.WriteAllText(fileName, json);
        }
        
        public EmployeeStoreInfo GetEmployee(string Name)
        {
            string fileName = @"C:\Users\Admin\Desktop\Employees.json";
            string text = System.IO.File.ReadAllText(fileName);
            var employees = JsonSerializer.Deserialize<List<EmployeeStoreInfo>>(text);

            if (employees != null)
            {
                var emp = employees.FirstOrDefault(a => a.Name.Contains(Name));
                if (emp == null)
                {
                    return null;
                    //return new EmployeeStoreInfo();//empty object create and return
                }
                else
                {
                    return emp;
                }
            }
            else
            {
                return null;
            }
        }
        public  void UpdateEmployee(EmployeeStoreInfo employeeStoreInfo)
        {
            string fileName = @"C:\Users\Admin\Desktop\Employees.json";
            string text = System.IO.File.ReadAllText(fileName);
            var employees = JsonSerializer.Deserialize<List<EmployeeStoreInfo>>(text);

            if (employees != null)
            {
                var employee = employees.FirstOrDefault(a => a.Id == employeeStoreInfo.Id);
                if(employee!= null)
                {  
                    employee.Id = employeeStoreInfo.Id;
                    employee.Name = employeeStoreInfo.Name;
                    employee.Department = employeeStoreInfo.Department;
                    employee.Dob = employeeStoreInfo.Dob;
                    employee.Address1 = employeeStoreInfo.Address1;
                    employee.Address2 = employeeStoreInfo.Address2;
                    employee.Salary = employeeStoreInfo.Salary;
                }
                string json = System.Text.Json.JsonSerializer.Serialize(employees);
                System.IO.File.WriteAllText(fileName, json);
            }
        }
        public void DeleteEmployee (int id)
        {
            string fileName = @"C:\Users\Admin\Desktop\Employees.json";
            string text = System.IO.File.ReadAllText(fileName);
            var employees = JsonSerializer.Deserialize<List<EmployeeStoreInfo>>(text);

            if (employees != null)
            {
               var employee = employees.FirstOrDefault(a => a.Id == id);
                if(employee!= null)
                {
                    employees.Remove(employee);
                    string json = System.Text.Json.JsonSerializer.Serialize(employees);
                    System.IO.File.WriteAllText(fileName, json);
                }
            }
        }
    }
}
