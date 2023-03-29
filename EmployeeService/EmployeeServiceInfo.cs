namespace EmployeeService
{
    public class EmployeeServiceInfo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Department { get; set; }

        public DateTime Dob { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public int Salary { get; set; }


    }
    public class EmployeeResponseServiceInfo
    {
        public int id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

    }
}