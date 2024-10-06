using EmployeeApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace EmployeeApp.Controllers
{
    public class EmployeeController : Controller
    {
        // Static ArrayList to store employees
        private static ArrayList employees = new ArrayList()
        {
            new Employee(01, "Sam", "Shrestha", "Software Developer", 69000),
            new Employee(02, "Kid", "Ink", "Project Manager", 55000),
            new Employee(03, "Sammy", "Rai", "QA Engineer", 59000),
            new Employee(04, "Rhitu", "Thapa", "Business Analyst", 99000),
            new Employee(05, "Chris", "Brown", "UI/UX Designer", 87000)
        };

        private static int currentEmployeeIndex = 0; // Keeps track of the current employee when browsing

        // Action to display the form for a new employee
        public IActionResult Index()
        {
            return View();
        }

        // Action to add a new employee to the ArrayList
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            // Automatically generate the Employee ID by incrementing the count
            employee.EmployeeID = employees.Count + 1;

            // Add the new employee to the ArrayList
            employees.Add(employee);

            // Redirect to the browse page
            return RedirectToAction("Browse");
        }

        // Action to browse employees one by one
        public IActionResult Browse()
        {
            if (employees.Count == 0)
            {
                ViewBag.Message = "No employees available.";
                return View();
            }

            // Circular browsing: Go back to the first employee when the end is reached
            if (currentEmployeeIndex >= employees.Count)
            {
                currentEmployeeIndex = 0;
            }

            // Get the current employee to display
            var employee = (Employee)employees[currentEmployeeIndex];
            currentEmployeeIndex++;

            // Return the view with the current employee
            return View(employee);
        }
    }
}
