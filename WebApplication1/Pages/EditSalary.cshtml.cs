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
    public class EditSalaryModel : PageModel
    {
        private readonly SuperEmployeeManager9000Context _context;

        public EditSalaryModel(SuperEmployeeManager9000Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Employee Employee { get; set; }
        
        public SalaryHistory SalaryHistory { get; set; }
        public SalaryHistory NewSalaryHistory { get; set; }

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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            NewSalaryHistory = new SalaryHistory
            {
                EmployeeID = Employee.ID,
                SalaryPeriodBegan = Employee.DateHired,
                SalaryForThePeriod = Employee.Salary,
                SalaryPeriodEnded = DateTime.Now
            };

            _context.Attach(Employee).State = EntityState.Modified;
            _context.SalaryHistory.Add(NewSalaryHistory);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(Employee.ID))
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

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.ID == id);
        }
    }
}