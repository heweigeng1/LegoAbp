using Microsoft.EntityFrameworkCore;

namespace LegoAbp.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
    {
        public static void Configure(
            DbContextOptionsBuilder<LegoAbpDbContext> dbContextOptions, 
            string connectionString
            )
        {
            /* This is the single point to configure DbContextOptions for LegoAbpDbContext */
            dbContextOptions.UseSqlServer(connectionString);
        }
    }
}
