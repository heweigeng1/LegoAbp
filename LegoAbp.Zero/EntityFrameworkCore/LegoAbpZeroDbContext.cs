using Abp.Zero.EntityFrameworkCore;
using LegoAbp.Zero.Authorization.Roles.Domain;
using LegoAbp.Zero.Authorization.Users.Domain;
using LegoAbp.Zero.Tenants.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegoAbp.Zero.EntityFrameworkCore
{
    public class LegoAbpZeroDbContext<TSelf> : AbpZeroDbContext<Tenant, Role, User, TSelf> 
        where TSelf : AbpZeroDbContext<Tenant, Role, User, TSelf>
    {
        public LegoAbpZeroDbContext(DbContextOptions<TSelf> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
