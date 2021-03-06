﻿using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SuperEmployeeManager9000.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperEmployeeManager9000.Pages.Employees
{
    public class EmployeesModel : PageModel
    {
        public int EmployeeCount { get; set; }
        public int TotalSalary { get; set; }
        public int AverageSalary { get; set; }

        public int[] MonthlyTotalSalaries { get; set; } = new int[12];
        public int[] AmountOfPeopleContributingToSalary { get; set; } = new int[12];
        public int[] MonthlyAverageSalaries { get; set; } = new int[12];
        public int CurrentlyInspectedYear { get; set; } = DateTime.Now.Year;

        private readonly SuperEmployeeManager9000Context _context;

        public EmployeesModel(SuperEmployeeManager9000Context context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get; set; }

        public async Task OnGetAsync(string searchString, int year)
        {
            if (year > 1900)
            {
                CurrentlyInspectedYear = year;
            }

            var employees = from e in _context.Employee select e;

            if (!String.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(e => e.Name.Contains(searchString));
            }

            Employee = await employees.ToListAsync();
        }
    }
}