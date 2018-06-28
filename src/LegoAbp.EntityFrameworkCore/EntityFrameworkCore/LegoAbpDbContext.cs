using Abp.Dependency;
using Abp.EntityFrameworkCore;
using Abp.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegoAbp.EntityFrameworkCore
{
    public class LegoAbpDbContext : AbpDbContext
    {

        //Add DbSet properties for your entities...
        //public DbSet<UserA> UserAs { get; set; }
        public LegoAbpDbContext(DbContextOptions<LegoAbpDbContext> options)
            : base(options)
        {
            Console.WriteLine(1);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Console.WriteLine(EntityTypeMapBuilder.ModuleAssemblys.Count);
            modelBuilder.Entity(typeof(UserA));
            var list = IocManager.Instance.Resolve<AbpAssemblyFinder>().GetAllAssemblies();
            Console.WriteLine(list.Count);
            //modelBuilder.ApplyConfiguration(new UserAMap());
        }
    }

    public class UserA
    {
        public Guid Id { get; set; }
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
