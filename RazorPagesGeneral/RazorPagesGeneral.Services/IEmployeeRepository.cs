using RazorPagesGeneral.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorPagesGeneral.Services
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        IEnumerable<Employee> Search(string searchTerm);
        Employee GetEmployeeById(int id);
        Employee UpdateInfo(Employee updatedEmployee);

        Employee AddEmployee(Employee newEmployee);
        Employee DeleteEmployee(int  id);
       IEnumerable<DeptHeadCount> EmployeeCountbyDept(Dept? dept);

    }
}
