using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperEmployeeManager9000.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }

        [Display(Name = "Date Hired")]
        [DataType(DataType.Date)]
        public DateTime DateHired { get; set; }

        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }

        [Display(Name = "Email Address")]
        public string Email { get; set; }
    }
}
