using Microsoft.EntityFrameworkCore;
using ZooManager.Api.Models;

namespace ZooManager.Api
{
    public class ZooManagetDbContext : DbContext
    {

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Ticket> Tickets { get; set; }


        public ZooManagetDbContext(DbContextOptions options) : base(options) { }
    }
}
