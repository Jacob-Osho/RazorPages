using Microsoft.EntityFrameworkCore;
using RazorPagesGeneral.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorPagesGeneral.Services
{
    public class SQLEmployeeRepository :IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public SQLEmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public Employee AddEmployee(Employee newEmployee)
        {
            //_context.Employees.Add(newEmployee);
            //_context.SaveChanges();
            //return newEmployee;
            _context.Database.ExecuteSqlRaw("spAddNewEmployee {0},{1},{2},{3}", newEmployee.Name, newEmployee.Email, newEmployee.PhotoPath, newEmployee.Department);
            return newEmployee;

        }

        public Employee DeleteEmployee(int id)
        {
           var employeeToDelete = _context.Employees.Find(id);
            if (employeeToDelete != null)
            {
                _context.Remove(employeeToDelete);
                _context.SaveChanges();
            }
            return employeeToDelete;
        }

        public IEnumerable<DeptHeadCount> EmployeeCountbyDept(Dept? dept)
        {
            IEnumerable<Employee> query = _context.Employees;
            if (dept.HasValue)
                query = query.Where(x => x.Department == dept.Value);

            return query.GroupBy(x => x.Department)
                .Select(x => new DeptHeadCount
                {
                    Department = x.Key.Value,//присвоение департамента
                    Counter = x.Count()
                }).ToList();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            //return _context.Employees;
            return _context.Employees.FromSqlRaw<Employee>("Select * From Employees").ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            //return _context.Employees.Find(id);
            return _context.Employees
                    .FromSqlRaw<Employee>("CideFirstSpGetEmployeeById {0}",id)
                    .ToList().FirstOrDefault();
        }

        public IEnumerable<Employee> Search(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return _context.Employees;
            return _context.Employees.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower()) || x.Email.ToLower().Contains(searchTerm.ToLower()));
        }

        public Employee UpdateInfo(Employee updatedEmployee)
        {
            var employee = _context.Employees.Attach(updatedEmployee);//prikrepitb
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;//происит ЕФ обновить состояние этой переменной
            _context.SaveChanges();
            return updatedEmployee;
        }
    }
}
