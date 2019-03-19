﻿using LegoAbp.EntityFrameworkCore;
using LegoAbp.Zero.Authorization.Roles.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LegoAbp.Zero.Authorization.Roles.EntityConfig
{
    public class RoleMap : EntityConfigurationBase<Role>
    {
        public const int adminRoleId = 1;
        public const string defaultName = "admin";
        public const string defaultDisplayName = "超级管理员";

        public override void Configure(EntityTypeBuilder<Role> builder)
        {
        }

        //public  void RegistTo(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<Role>().HasData(new Role { Id = new Guid(defaultKey), Name = defaultName, NormalizedName = defaultName.ToUpperInvariant(), DisplayName = defaultDisplayName, IsDeleted = false, CreationTime = DateTime.Now });
        //    base.RegistTo(modelBuilder);
        //}
    }
}