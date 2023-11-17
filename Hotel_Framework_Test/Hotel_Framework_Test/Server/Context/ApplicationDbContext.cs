//using Hotel_Framework_Test.Shared;
using Hotel_Framework_Test.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Framework_Test.Server.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
