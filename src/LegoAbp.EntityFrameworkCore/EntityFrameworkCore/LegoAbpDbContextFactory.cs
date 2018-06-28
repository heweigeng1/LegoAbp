using LegoAbp.Configuration;
using LegoAbp.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace LegoAbp.EntityFrameworkCore
{
    /* This class is needed to run EF Core PMC commands. Not used anywhere else */
    public class LegoAbpDbContextFactory : IDesignTimeDbContextFactory<LegoAbpDbContext>
    {

        public LegoAbpDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<LegoAbpDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());
            DbContextOptionsConfigurer.Configure(
                builder,
                configuration.GetConnectionString(LegoAbpConsts.ConnectionStringName)
            );

            return new LegoAbpDbContext(builder.Options);
        }
    }
}