using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperEmployeeManager9000.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public DateTime DateHired { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
