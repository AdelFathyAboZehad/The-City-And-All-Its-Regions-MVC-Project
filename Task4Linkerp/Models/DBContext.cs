using Microsoft.EntityFrameworkCore;

namespace Task4Linkerp.Models
{
    public class DBContext:DbContext
    {
    
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
        public DbSet<City> Cities { get; set; }

        public DbSet<Region> Regions { get; set; }
    }
}
