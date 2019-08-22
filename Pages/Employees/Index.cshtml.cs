using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EFCore.Playground.DataAccess;
using EFCore.Playground.DataAccess.Models;

namespace EFCore.Playground.Pages_Employees
{
    public class IndexModel : PageModel
    {
        private readonly EFCore.Playground.DataAccess.EmployeeContext _context;

        public IndexModel(EFCore.Playground.DataAccess.EmployeeContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get;set; }

        public async Task OnGetAsync()
        {
            Employee = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Manager).ToListAsync();
        }
    }
}
