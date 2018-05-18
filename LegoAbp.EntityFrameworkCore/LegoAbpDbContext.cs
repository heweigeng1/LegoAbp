using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegoAbp.EntityFrameworkCore
{
    public class LegoAbpDbContext : AbpDbContext
    {
        //在此映射到数据库
        //public DbSet<User> Users { get; set; }

        public LegoAbpDbContext(DbContextOptions<LegoAbpDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<User>();
        }
    }
}
