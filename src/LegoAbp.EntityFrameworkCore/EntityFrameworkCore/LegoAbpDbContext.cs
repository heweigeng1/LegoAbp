using Abp.Dependency;
using Abp.Domain.Entities;
using Abp.EntityFrameworkCore;
using Abp.Reflection;
using LegoAbp.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyModel;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace LegoAbp.EntityFrameworkCore
{
    public class LegoAbpDbContext : AbpDbContext
    {
        
        //Add DbSet properties for your entities...
        public DbSet<UserA> UserAs { get; set; }
        public LegoAbpDbContext(DbContextOptions<LegoAbpDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //获取各个module的entity注册到上下文中.
            var entityType = new EntityConfigurationTypeFinder(new EntityConfigurationAssemblyFinder(new AppDomainAllAssemblyFinder()) );

            IEntityRegister[] registers = entityType.GetEntityRegisters(typeof(LegoAbpDbContext));
            foreach (var item in registers)
            {
                item.RegistTo(modelBuilder);
            }
        }
    }

    public class UserA: Entity<Guid>
    {
        [MaxLength(10)]
        public string NameB { get; set; }
        public string Namec { get; set; }
        public string Named { get; set; }
    }
    public class UserAMap : IEntityTypeConfiguration<UserA>
    {
        public void Configure(EntityTypeBuilder<UserA> builder)
        {
            builder.ToTable("UserC");
        }
    }
}
