using LegoAbp.Core.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegoAbp.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class LegoAbpDbContextFactory :  IDesignTimeDbContextFactory<LegoAbpDbContext>
    {
        public LegoAbpDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<LegoAbpDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            LegoAbpDbContextConfigurer.Configure(builder, configuration.GetConnectionString(LegoAbpConsts.ConnectionStringName));

            return new LegoAbpDbContext(builder.Options);
        }
    }
}
