using Microsoft.EntityFrameworkCore;
using Sundues_Employee_CRUD.Models;

namespace Sundues_Employee_CRUD.Data
{
    public class EmployeeDbContext:DbContext
    {        
        public EmployeeDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}
