using Microsoft.EntityFrameworkCore;

namespace SuperEmployeeManager9000.Models
{
    public class SuperEmployeeManager9000Context : DbContext
    {
        public SuperEmployeeManager9000Context(DbContextOptions<SuperEmployeeManager9000Context> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; }
    }
}