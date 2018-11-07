using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SuperEmployeeManager9000.Models;
using System.Threading.Tasks;

namespace SuperEmployeeManager9000.Pages.Employees
{
    public class DeleteModel : PageModel
    {
        private readonly SuperEmployeeManager9000Context _context;

        public DeleteModel(SuperEmployeeManager9000Context context)
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

            Employee = await _context.Employee.FirstOrDefaultAsync(m => m.ID == id);

            if (Employee == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employee = await _context.Employee.FindAsync(id);

            if (Employee != null)
            {
                Employee.IsCurrentlyHired = false;
                Employee.Salary = 0;
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Employees");
        }
    }
}