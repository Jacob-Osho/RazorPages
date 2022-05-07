using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesGeneral.Models;
using RazorPagesGeneral.Services;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace RazorPagesGeneral.Pages.Employees
{
    public class DeleteModel : PageModel
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        [BindProperty]
        public Employee Employee { get; set; }

        private readonly IEmployeeRepository _employeeRepository;

        public DeleteModel(IEmployeeRepository  employeeRepository, IWebHostEnvironment webHostEnvironment)
        {
            _employeeRepository = employeeRepository;
            _webHostEnvironment = webHostEnvironment; 
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
            if (deletedEmploye.PhotoPath is not null)
            {
                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", deletedEmploye.PhotoPath);
                if (deletedEmploye.PhotoPath != "noimage.png")
                    System.IO.File.Delete(filePath);
            }
            if (deletedEmploye == null)
                return RedirectToPage("/NotFOund");
            else
                return RedirectToPage("Employees");
        }
    }
}
