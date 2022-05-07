using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesGeneral.Models;
using RazorPagesGeneral.Services;
using System.Collections.Generic;

namespace RazorPagesGeneral.Pages.Employees
{
    public class EmpoyeesModel : PageModel
    {
        private readonly IEmployeeRepository _db;

        public EmpoyeesModel(IEmployeeRepository db)
        {
            _db = db;
        }
        [BindProperty(SupportsGet =true)]//работает только на методе пост
        public string SearchTerm { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public void OnGet()
        {
            Employees = _db.Search(SearchTerm);
        }
    }
}
