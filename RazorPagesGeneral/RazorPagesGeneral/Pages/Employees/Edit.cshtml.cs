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

        [BindProperty]
        public Employee Employee { get; set; }
        [BindProperty]// делает его доступным во всех пост методах без передачи в параметры
        public IFormFile Photo { get; set; }
        [BindProperty]
        public bool Notify { get; set; }
        public string Message { get; set; }
        public EditModel(IEmployeeRepository employeeRepository, IWebHostEnvironment webHostEnvironment)
        {
            _employeeRepository = employeeRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
                Employee = _employeeRepository.GetEmployeeById(id.Value);
            else
            {
                Employee = new Employee();
            }
            if (Employee == null)
                return RedirectToPage("/NotFound");

            return Page();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Photo is not null)
                {
                    if (Employee.PhotoPath is not null)
                    {
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", Employee.PhotoPath);
                        if (Employee.PhotoPath != "noimage.png")
                            System.IO.File.Delete(filePath);
                    }
                    Employee.PhotoPath = UploadingFileProcces();
                }
                if (Employee.Id > 0)
                {
                    Employee = _employeeRepository.UpdateInfo(Employee);
                    TempData["SM"] = $"Upadete {Employee.Name} successful";
                }
                else
                {
                    Employee = _employeeRepository.AddEmployee(Employee);
                    TempData["SM"] = $"Addition {Employee.Name} successful";
                }
                return RedirectToPage("Employees");
            }

            return Page();


        }
        public void OnPostUpdateNotificationPreferences(int id)
        {
            if (Notify)
                Message = "Thank's for turning on notification";
            else
                Message = "email notifications turned off";
            Employee = _employeeRepository.GetEmployeeById(id);
        }
        private string UploadingFileProcces()
        {
            string uniqueFileName = null;
            if (Photo is not null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fs);
                }
            }
            return uniqueFileName;
        }
    }
}
