using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesGeneral.Models;
using RazorPagesGeneral.Services;

namespace RazorPagesGeneral.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly IEmployeeRepository _employeeRepository;
        public Employee Employee { get; private set; }
        public EditModel(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public IActionResult OnGet(int id)
        {
            Employee = _employeeRepository.GetEmployeeById(id);
            if (Employee == null)
                return RedirectToPage("/NotFound");

            return Page();
        }
    }
}
