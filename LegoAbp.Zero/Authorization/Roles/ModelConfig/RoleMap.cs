using LegoAbp.EntityFrameworkCore;
using LegoAbp.Zero.Authorization.Roles.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LegoAbp.Zero.Authorization.Roles.ModelConfig
{
    public class RoleMap : EntityConfigurationBase<Role, Guid>
    {
        public const string defaultKey = "2a88fe00-b533-4eb0-8888-14419cf56b9f";
        public const string defaultName = "admin";
        public const string defaultDisplayName = "超级管理员";
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(new Role { Id = new Guid(defaultKey), Name = defaultName, NormalizedName = defaultName.ToUpperInvariant(), DisplayName = defaultDisplayName, IsDeleted = false, CreationTime = DateTime.Now });
        }
    }
}
