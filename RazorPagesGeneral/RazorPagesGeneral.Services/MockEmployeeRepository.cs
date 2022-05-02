using RazorPagesGeneral.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorPagesGeneral.Services
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        List<Employee> _employeeList;
        public MockEmployeeRepository()
        {
            _employeeList = new()
            {
                new Employee
                {
                    Id = 0,
                    Name = "Jimbo",
                    Email = "Jimbo@gmail.com",
                    PhotoPath ="avatar.png",
                    Department = Dept.HR
                },
                new Employee
                {
                    Id = 1,
                    Name = "Klerk",
                    Email = "Klerk@gmail.com",
                    PhotoPath = "avatar2.png",
                    Department = Dept.IT
                },
                new Employee
                {
                    Id = 2,
                    Name = "Frodo",
                    Email = "Frodo@gmail.com",
                    PhotoPath = "avatar3.png",
                    Department = Dept.Payroll
                },
                new Employee
                {
                    Id = 3,
                    Name = "Mimito",
                    Email = "Mimito@gmail.com",
                    PhotoPath = "avatar3.png",
                    Department = Dept.IT
                },
                new Employee
                {
                    Id = 4,
                    Name = "Scott",
                    Email = "Scott@gmail.com",
                    PhotoPath = "avatar5.png",
                    Department = Dept.Payroll
                },
                new Employee
                {
                    Id = 5,
                    Name = "Natasha",
                    Email = "Natasha@gmail.com",
                    PhotoPath = "avatar4.png",
                    Department = Dept.HR
                }
            };
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }
    }
}
