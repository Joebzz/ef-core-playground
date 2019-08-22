using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFCore.Playground.DataAccess;
using EFCore.Playground.DataAccess.Models;

namespace EFCore.Playground.Pages_Employees
{
    public class EditModel : PageModel
    {
        private readonly EFCore.Playground.DataAccess.EmployeeContext _context;

        public EditModel(EFCore.Playground.DataAccess.EmployeeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Employee Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employee = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Manager).FirstOrDefaultAsync(m => m.EmployeeId == id);

            if (Employee == null)
            {
                return NotFound();
            }
            ViewData["Departments"] = new SelectList(_context.Departments, "DepartmentId", "Title");
            ViewData["Managers"] = new SelectList(_context.Employees, "EmployeeId", "Username");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(Employee.EmployeeId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }
    }
}
