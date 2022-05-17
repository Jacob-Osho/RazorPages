using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesGeneral.Models;
using RazorPagesGeneral.Services;

namespace RazorPagesGeneral.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        private readonly IEmployeeRepository _employeeRepository;

        public DetailsModel(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Employee Employees { get; private set; }

        public IActionResult OnGet(int id)
        {
            Employees = _employeeRepository.GetEmployeeById(id);
            if (Employees == null)
                return RedirectToPage("/NotFound");

            return Page();
        }
    }
}
