using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SuperEmployeeManager9000.Models
{
    public class SuperEmployeeManager9000Context : DbContext
    {
        public SuperEmployeeManager9000Context (DbContextOptions<SuperEmployeeManager9000Context> options)
            : base(options)
        {
        }

        public DbSet<SuperEmployeeManager9000.Models.Employee> Employee { get; set; }
    }
}
