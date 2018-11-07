using System;
using System.ComponentModel.DataAnnotations;

namespace SuperEmployeeManager9000.Models
{
    public class SalaryHistory
    {
        public int ID { get; set; }

        public int EmployeeID { get; set; }

        [Display(Name = "Salary period began")]
        [DataType(DataType.Date)]
        public DateTime SalaryPeriodBegan { get; set; }

        [Display(Name = "Salary period ended")]
        [DataType(DataType.Date)]
        public DateTime SalaryPeriodEnded { get; set; }

        [Display(Name = "Salary for the period")]
        public int SalaryForThePeriod { get; set; }
    }
}
