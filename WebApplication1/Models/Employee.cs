using System;
using System.ComponentModel.DataAnnotations;

namespace SuperEmployeeManager9000.Models
{
    public class Employee
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        public int Salary { get; set; }

        [Display(Name = "Date hired")]
        [DataType(DataType.Date)]
        public DateTime DateHired { get; set; }

        [Display(Name = "Phone number")]
        public int PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Display(Name = "Currently employed")]
        public bool IsCurrentlyHired { get; set; }
    }
}