using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesGeneral.Models;
using RazorPagesGeneral.Services;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesGeneral.Pages.Employees
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Employee Employee { get; set; }

        private readonly IEmployeeRepository _employeeRepository;

        public DeleteModel(IEmployeeRepository  employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
       
       
        public IActionResult OnGet(int id)
        {
            Employee=_employeeRepository.GetEmployeeById(id);
            if (Employee == null)
                return RedirectToPage("/NotFOund");
            else
                return Page();
        }
        public IActionResult OnPost()
        {
            Employee deletedEmploye = _employeeRepository.DeleteEmployee(Employee.Id);
            if(deletedEmploye == null)
                return RedirectToPage("/NotFOund");
            else
                return RedirectToPage("Employees");
        }
    }
}
