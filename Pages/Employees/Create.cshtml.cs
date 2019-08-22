using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EFCore.Playground.DataAccess;
using EFCore.Playground.DataAccess.Models;

namespace EFCore.Playground.Pages_Employees
{
    public class CreateModel : PageModel
    {
        private readonly EFCore.Playground.DataAccess.EmployeeContext _context;

        public CreateModel(EFCore.Playground.DataAccess.EmployeeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["Departments"] = new SelectList(_context.Departments, "DepartmentId", "Title");
            ViewData["Managers"] = new SelectList(_context.Employees, "EmployeeId", "Username");
            return Page();
        }

        [BindProperty]
        public Employee Employee { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Employees.Add(Employee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}