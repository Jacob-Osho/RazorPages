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
                    PhotoPath = "avatar4.png",
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
                    PhotoPath = "avatar3.png",
                    Department = Dept.HR
                }
            };
        }

        public Employee AddEmployee(Employee newEmployee)
        {
            newEmployee.Id = _employeeList.Max(x => x.Id) + 1;
                _employeeList.Add(newEmployee);
            return newEmployee;
        }

        public Employee DeleteEmployee(int id)
        {
         Employee employeeToDelete=  _employeeList.FirstOrDefault(x => x.Id == id);
            if(employeeToDelete != null)
            _employeeList.Remove(employeeToDelete);
            return employeeToDelete;    
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployeeById(int id)
        {
            return _employeeList.FirstOrDefault(x => x.Id == id);
        }

        public Employee UpdateInfo(Employee updatedEmployee)
        {
            Employee employee = _employeeList.FirstOrDefault(x => x.Id == updatedEmployee.Id);
            if(employee  is not null)
            {
                employee.Name = updatedEmployee.Name;
                employee.Email = updatedEmployee.Email;
                employee.PhotoPath = updatedEmployee.PhotoPath;
                employee.Department = updatedEmployee.Department;
                
            }
            return employee;
        }
    }
}
