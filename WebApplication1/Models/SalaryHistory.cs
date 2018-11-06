using System;
using System.ComponentModel.DataAnnotations;

namespace SuperEmployeeManager9000.Models
{
    public class SalaryHistory
    {
        public int ID { get; set; }

        public int EmployeeID { get; set; }

        [Display(Name = "Salary Period Began")]
        [DataType(DataType.Date)]
        public DateTime SalaryPeriodBegan { get; set; }

        [Display(Name = "Salary Period Ended")]
        [DataType(DataType.Date)]
        public DateTime SalaryPeriodEnded { get; set; }

        public int SalaryForThePeriod { get; set; }
    }
}
