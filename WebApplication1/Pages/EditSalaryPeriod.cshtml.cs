using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SuperEmployeeManager9000.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SuperEmployeeManager9000.Pages
{
    public class EditSalaryPeriodModel : PageModel
    {
        private readonly SuperEmployeeManager9000Context _context;

        public EditSalaryPeriodModel(SuperEmployeeManager9000Context context)
        {
            _context = context;
        }

        [BindProperty]
        public SalaryHistory SalaryHistory { get; set; }
        public Employee Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SalaryHistory = await _context.SalaryHistory.FirstOrDefaultAsync(m => m.ID == id);
            Employee = await _context.Employee.FirstOrDefaultAsync(e => e.ID == SalaryHistory.EmployeeID);

            if (SalaryHistory == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SalaryHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalaryHistoryExists(SalaryHistory.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Employees");
        }

        private bool SalaryHistoryExists(int id)
        {
            return _context.SalaryHistory.Any(e => e.ID == id);
        }
    }
}
