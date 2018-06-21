using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LegoAbp.EntityFrameworkCore
{
    public class LegoAbpDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...

        public LegoAbpDbContext(DbContextOptions<LegoAbpDbContext> options) 
            : base(options)
        {

        }
    }
}
