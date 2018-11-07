using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SuperEmployeeManager9000.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperEmployeeManager9000.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        private readonly SuperEmployeeManager9000Context _context;

        public int LastSalaryReference { get; set; }

        public DetailsModel(SuperEmployeeManager9000Context context)
        {
            _context = context;
        }

        public Employee Employee { get; set; }
        public List<SalaryHistory> SalaryHistory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employee = await _context.Employee.FirstOrDefaultAsync(m => m.ID == id);
            SalaryHistory = await _context.SalaryHistory.Where(e => e.EmployeeID == id).ToListAsync();
            if (Employee.IsCurrentlyHired && SalaryHistory.Count > 0)
            {
                SalaryHistory.RemoveAt(SalaryHistory.Count - 1);
            }

            if (Employee == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}