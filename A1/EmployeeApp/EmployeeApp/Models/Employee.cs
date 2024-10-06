namespace EmployeeApp.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public decimal Salary { get; set; }

        // Constructor with parameters for initializing employee objects
        public Employee(int id, string firstName, string lastName, string jobTitle, decimal salary)
        {
            EmployeeID = id;
            FirstName = firstName;
            LastName = lastName;
            JobTitle = jobTitle;
            Salary = salary;
        }

        // Parameterless constructor (optional)
        public Employee() { }
    }
}
