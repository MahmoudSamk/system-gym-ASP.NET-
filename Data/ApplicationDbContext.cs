using GymSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace GymSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        {
            
        }
        public DbSet<EmployeeGYM> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Client> Clients { get; set; }

    }
}
