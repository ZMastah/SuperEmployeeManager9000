using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SuperEmployeeManager9000.Models;

namespace SuperEmployeeManager9000.Pages
{
    public class DeleteSalaryPeriodModel : PageModel
    {
        private readonly SuperEmployeeManager9000.Models.SuperEmployeeManager9000Context _context;

        public DeleteSalaryPeriodModel(SuperEmployeeManager9000.Models.SuperEmployeeManager9000Context context)
        {
            _context = context;
        }

        [BindProperty]
        public SalaryHistory SalaryHistory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SalaryHistory = await _context.SalaryHistory.FirstOrDefaultAsync(m => m.ID == id);

            if (SalaryHistory == null)
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

            SalaryHistory = await _context.SalaryHistory.FindAsync(id);

            if (SalaryHistory != null)
            {
                _context.SalaryHistory.Remove(SalaryHistory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Employees");
        }
    }
}
