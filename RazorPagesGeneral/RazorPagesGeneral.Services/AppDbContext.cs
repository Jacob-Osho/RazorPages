using Microsoft.EntityFrameworkCore;
using RazorPagesGeneral.Models;

namespace RazorPagesGeneral.Services
{
    public class AppDbContext :DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base (options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}
