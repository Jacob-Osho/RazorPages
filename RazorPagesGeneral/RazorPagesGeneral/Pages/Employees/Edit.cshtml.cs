using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesGeneral.Models;
using RazorPagesGeneral.Services;
using System;
using System.IO;

namespace RazorPagesGeneral.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public Employee Employee { get; private set; }
        [BindProperty]// делает его доступным во всех пост методах без передачи в параметры
        public IFormFile Photo { get;  set; }
        public EditModel(IEmployeeRepository employeeRepository,IWebHostEnvironment webHostEnvironment)
        {
            _employeeRepository = employeeRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult OnGet(int id)
        {
            Employee = _employeeRepository.GetEmployeeById(id);
            if (Employee == null)
                return RedirectToPage("/NotFound");

            return Page();
        }
        public IActionResult OnPost(Employee employee)
        {
            if(Photo is not  null)
            {
                if(employee.PhotoPath is not null)
                {
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images",employee.PhotoPath);
                    System.IO.File.Delete(filePath); 
                }
                employee.PhotoPath = UploadingFileProcces();
            }


            Employee = _employeeRepository.UpdateInfo(employee);
            return RedirectToPage("Employees");
            
        }
        private string UploadingFileProcces()
        {
            string uniqueFileName = null;
            if(Photo is not null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath,"images");
                uniqueFileName = Guid.NewGuid().ToString()+"_"+Photo.FileName;
                string filePath = Path.Combine(uploadsFolder,uniqueFileName);
                using(var fs =new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fs); 
                }
            }
            return uniqueFileName;
        }
    }
}
