using Microsoft.EntityFrameworkCore;

namespace ExampleWeb.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Students>  Students { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) :  base(options)
        {
            
        }
    }
}
