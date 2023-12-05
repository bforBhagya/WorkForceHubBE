using EMS.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Data
{
    public class EmsDbContext : DbContext
    {
        public EmsDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; }
    }
}
