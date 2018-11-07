using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SuperEmployeeManager9000.Models;
using System.Threading.Tasks;

namespace SuperEmployeeManager9000.Pages.Employees
{
    public class CreateModel : PageModel
    {
        private readonly SuperEmployeeManager9000Context _context;

        public CreateModel(SuperEmployeeManager9000Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
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
            Employee.IsCurrentlyHired = true;
            _context.Employee.Add(Employee);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Employees");
        }
    }
}