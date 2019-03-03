using LegoAbp.EntityFrameworkCore;
using LegoAbp.Zero.Authorization.Roles.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegoAbp.Zero.Authorization.Roles.ModelConfig
{
    public class RoleMap : EntityConfigurationBase<Role, Guid>
    {
        public const string RoleId = "2a88fe00-b533-4eb0-8888-14419cf56b9f";
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(new Role { Id = new Guid(RoleId), Name = "admin",NormalizedName="ADMIN", DisplayName="超级管理员", IsDeleted = false,CreationTime = DateTime.Now});
        }
    }
}
